using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Google.Cloud.Translation.V2;
using Licenta.Resources;

namespace Licenta
{
    public partial class Crawling : Form
    {
        HttpWebRequest request;
        HttpWebResponse response;
        Stream stream;
        StreamReader reader;
        CultureInfo culture = CultureInfo.CurrentCulture;
        string url;
        string[] keywords;
        string html;
        int searchDepth;
        HashSet<string> parsedAlready;
        List<String> refs;
        Thread parseThread;
        HtmlAgilityPack.HtmlDocument htmlSnippet = new HtmlAgilityPack.HtmlDocument();
        Boolean otherDomains = true;
        String mainDomain;
        int context;

        public Crawling()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {
            if (parseThread == null || parseThread.IsAlive == false)
            {
                grid.Rows.Clear();
                parsedAlready = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                html = string.Empty;
                url = urlTextBox.Text;
                Uri myUri = new Uri(url);
                mainDomain = (myUri.Host.Contains("www.")) ? (myUri.Host.Replace("www.","")) : (myUri.Host);
                keywords = keywordTextBox.Text.Split(',');
                if (url.Length < 10)
                {
                    MessageBox.Show("Insert complete http:// address!");
                    return;
                }
                if (keywordTextBox.Text == "")
                {
                    MessageBox.Show("Insert earching keywords!");
                    return;
                }
                if(depth.Text =="")
                {
                    MessageBox.Show("Select the depth of the search!");
                    return;
                }
                if (searchContext.Text == "")
                {
                    MessageBox.Show("Select the context of the search!");
                    return;
                }
                searchDepth = Convert.ToInt16(this.depth.Text);
                File.Delete("file.txt");
                File.Delete("results.txt");
                searchButton.Text = "Stop Searching";
                switch (searchContext.Text)
                {
                    case "Sentence":
                        {
                            context = 0;
                            break;
                        }
                    case "Paragraph":
                        {
                            context = 1;
                            break;
                        }
                    case "Page":
                        {
                            context = 2;
                            break;
                        }
                }
                parseThread = new Thread(() => Parse_Page(url, searchDepth));
                parseThread.Start();
            }
            else
            {
                parseThread.Abort();
                searchButton.Text = "Search";
            }
        }

        public String Fetch_Page(String url)
        {
            String html;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                response = (HttpWebResponse)request.GetResponse();
                stream = response.GetResponseStream();
                reader = new StreamReader(stream, Encoding.UTF8);
                html = reader.ReadToEnd();
                if (html.Contains("<body"))
                    return html.Substring(html.IndexOf("<body"));
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public List<String> Get_Refs(String html)
        {
            HtmlAgilityPack.HtmlDocument htmlSnippet = new HtmlAgilityPack.HtmlDocument();
            htmlSnippet.LoadHtml(html);
            List<string> hrefTags = new List<string>();
            foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                if (otherDomains == false)
                    if ((att.Value.Contains("://") || att.Value.Contains("www.")) && (!att.Value.Contains(mainDomain)))
                        continue;
                hrefTags.Add(att.Value);
                File.AppendAllText(@"agility.txt", att.Value + Environment.NewLine);
            }
            return hrefTags;
        }

        public string GetContent(string html)
        {
            String content ="";
            html = Regex.Replace(html, "<script.*?</script>", "\b", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            html = Regex.Replace(html, "<style.*?</style>", "\b", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            html = html.Replace("\b\n", "");
            html = html.Replace("\b", "");
            html = Regex.Replace(html, "<!--.*?-->", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            html = html.Replace("<em>", "");
            html = html.Replace("</em>", "");
            html = html.Replace("<strong>", "");
            html = html.Replace("</strong>", "");
            html = html.Replace("</div>", "\n</div>");
            html = html.Replace("&quot;", "\"");
            html = html.Replace("&nbsp;", " ");
            htmlSnippet.LoadHtml(html);
            return Regex.Replace(htmlSnippet.DocumentNode.InnerText, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
        }

        public Boolean ContentHasKeywords(String content, String keywordToSearch)
        { 
            String[] keywords = keywordToSearch.Split(' ');
            foreach (string keyword in keywords)
                if (culture.CompareInfo.IndexOf(content, keyword, CompareOptions.IgnoreCase) < 0)
                    return false;
            return true;
        }

        public List<String> SplitContent(String content)
        {
            List<String> elements = new List<String>();
            switch (context)
            {
                case 0:
                    {
                        elements = content.Split(new char[] { '.', '\n' }).ToList();
                        break;
                    }
                case 1:
                    {
                        elements = content.Split('\n').ToList();
                        break;
                    }
                case 2:
                    {
                        elements.Add(content);
                        break;
                    }
            }
            return elements;
        }

        public void SearchKeywords(String url, String html)
        {
            int index = 0;
            html = GetContent(html);
                List<String> elements = SplitContent(html);
            for (int i = 0; i < elements.Count(); i++)
                if (elements[i].ToLower().IndexOfAny("abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray()) > -1)
                    foreach (var keyword in keywords)
                    {
                        if (ContentHasKeywords(elements[i], keyword.Trim()))
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                grid.Rows.Add(grid.Rows.Count, keyword.Trim(), url, elements[i].Trim());
                            });
                            File.AppendAllText(@"results.txt", elements[i].Trim() + Environment.NewLine);
                        }
                    }
        }

        public bool AlreadyParsed(string link)
        {
            return parsedAlready.Contains(link);
        }

        public void Parse_Page(String link, int depth)
        {
            if (!AlreadyParsed(link))
            {
                parsedAlready.Add(link);
                if ((html = Fetch_Page(link)) != null)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        urlTextBox.Text = link;
                    });
                    SearchKeywords(link, html);
                    if (depth >= 1)
                    {
                        refs = new List<String>();
                        refs = Get_Refs(html);
                        foreach (String reference in refs)
                        {
                            if (reference.Contains("//"))
                                Parse_Page(reference, depth - 1);
                            else if (reference.Length > 0 && reference.Substring(0, 1).Equals("/"))
                                Parse_Page(link + reference, depth - 1);
                            else
                                Parse_Page(link + "/" + reference, depth - 1);
                            File.AppendAllText(@"file.txt", reference + Environment.NewLine);
                            
                        }
                    }
                }
            }
            if (depth == searchDepth)
            {
                MessageBox.Show("Search Finished. Check Results!");
                this.Invoke((MethodInvoker)delegate
                {
                    this.Enabled = true;
                    searchButton.Text = "Search";
                });
            }
        }

        private void keywordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                searchButton.PerformClick();
            }
        }

        private void domainRange_CheckedChanged(object sender, EventArgs e)
        {
            otherDomains = !otherDomains;
        }

        private void sentymental_Click(object sender, EventArgs e)
        {
            int index = grid.SelectedCells[0].RowIndex;
            SentimentalAnalyze aa = new SentimentalAnalyze(grid.Rows[index].Cells[3].Value.ToString());
            aa.ShowDialog();
        }

        private void syntax_Click(object sender, EventArgs e)
        {
            int index = grid.SelectedCells[0].RowIndex;
            SyntaxAnalyze aa = new SyntaxAnalyze(grid.Rows[index].Cells[3].Value.ToString());
            aa.ShowDialog();
        }

        private void showResult_Click(object sender, EventArgs e)
        {
            int index = grid.SelectedCells[0].RowIndex;
           MessageBox.Show(grid.Rows[index].Cells[3].Value.ToString());
        }
    }
}
