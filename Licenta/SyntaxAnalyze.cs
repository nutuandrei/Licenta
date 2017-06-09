using Google.Cloud.Language.V1;
using Google.Cloud.Translation.V2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Licenta.Resources
{
    public partial class SyntaxAnalyze : Form
    {
        int tokenIndex = 0;
        AnalyzeSyntaxResponse response;
        Document document;
        LanguageServiceClient syntaxAnalyze;
        TranslationClient translate;
        String textToAnalyze;
        string language;

        public SyntaxAnalyze(String text)
        {
            InitializeComponent();
            textToAnalyze = text;
            translate = TranslationClient.Create();
            syntaxAnalyze = LanguageServiceClient.Create();
            language = translate.DetectLanguage(text).Language;
            textLabel.Text = "    Original Text - Language " + language + "\n-" + text + "\n";
            if (language.Equals("en") == false)
            {
                textToAnalyze = translate.TranslateText(text, LanguageCodes.English).TranslatedText;
                textLabel.Text += "    Translated text:\n-" + textToAnalyze;
            }
            document = Document.FromPlainText(textToAnalyze);
            response = syntaxAnalyze.AnalyzeSyntax(document);
            dependence.Text = "";
            lemma.Text = "";
            string part = response.Tokens[0].PartOfSpeech.ToString();
            part = part.Replace("\"", "");
            part = part.Replace("{", "");
            part = part.Replace("}", "");
            tokenText.Text = response.Tokens[0].Text.Content;
            partOfSpeech.Text = "-> " + part + "\n";
            string dependences = response.Tokens[tokenIndex].DependencyEdge.ToString();
            dependences = dependences.Replace("\"", "").Replace("{", "").Replace("}", "");
            string[] split = dependences.Split(',');
            foreach (string s in split)
                dependence.Text += "-> " + s + "\n";
            lemma.Text = response.Tokens[tokenIndex].Lemma.ToString().Replace("\"", "").Replace("{", "").Replace("}", "");
        }

        private void right_Click(object sender, EventArgs e)
        {
            if (tokenIndex < response.Tokens.Count() - 1)
            {
                tokenIndex++;
                partOfSpeech.Text = "";
                dependence.Text = "";
                lemma.Text = "";
                string part = response.Tokens[tokenIndex].PartOfSpeech.ToString();
                part = part.Replace("\"", "");
                part = part.Replace("{", "");
                part = part.Replace("}", "");
                tokenText.Text = response.Tokens[tokenIndex].Text.Content;
                string[] syntax = part.Split(',');
                foreach (string s in syntax)
                    partOfSpeech.Text += "-> " + s + "\n";
                string dependences = response.Tokens[tokenIndex].DependencyEdge.ToString();
                dependences = dependences.Replace("\"", "").Replace("{", "").Replace("}", "");
                string[] split = dependences.Split(',');
                foreach (string s in split)
                    dependence.Text += "-> " + s + "\n";
                lemma.Text = "-> " + response.Tokens[tokenIndex].Lemma.ToString().Replace("\"", "").Replace("{", "").Replace("}", "");
            }
        }

        private void left_Click(object sender, EventArgs e)
        {
            if (tokenIndex > 0)
            {
                tokenIndex--;
                partOfSpeech.Text = "";
                dependence.Text = "";
                lemma.Text = "";
                string part = response.Tokens[tokenIndex].PartOfSpeech.ToString();
                part = part.Replace("\"", "");
                part = part.Replace("{", "");
                part = part.Replace("}", "");
                tokenText.Text = response.Tokens[tokenIndex].Text.Content;
                string[] syntax = part.Split(',');
                foreach (string s in syntax)
                    partOfSpeech.Text += "-> " + s + "\n";
                string dependences = response.Tokens[tokenIndex].DependencyEdge.ToString();
                dependences = dependences.Replace("\"", "").Replace("{", "").Replace("}", "");
                string[] split = dependences.Split(',');
                foreach (string s in split)
                    dependence.Text += "-> " + s + "\n";
                lemma.Text = "-> " + response.Tokens[tokenIndex].Lemma.ToString().Replace("\"", "").Replace("{", "").Replace("}", "");
            }
        }
    }
}
