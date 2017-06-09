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

namespace Licenta
{
    public partial class SentimentalAnalyze : Form
    {
        public SentimentalAnalyze(String text)
        {
            InitializeComponent();
            String textToAnalyze = text;
            TranslationClient translate = TranslationClient.Create();
            LanguageServiceClient sentimentalAnalyze = LanguageServiceClient.Create();
            AnalyzeSentimentResponse response;
            Document document;
            string language = translate.DetectLanguage(text).Language;
            textLabel.Text = "    Original Text - Language " + language + "\n-" + text + "\n";
            if (language.Equals("en") == false)
            {
                textToAnalyze = translate.TranslateText(text, LanguageCodes.English).TranslatedText;
                textLabel.Text += "    Translated text:\n-" + textToAnalyze;
            }
            document = Document.FromPlainText(textToAnalyze);
            response = sentimentalAnalyze.AnalyzeSentiment(document);
            float score = response.DocumentSentiment.Score;
            float magnitude = response.DocumentSentiment.Magnitude;
            scoreLabel.Text += score.ToString();
            scoreBar.Width = Convert.ToInt16((score * 100 + 100) * 2.2);
            magnitudeLabel.Text += magnitude.ToString();
            magnitudeBar.Width = Convert.ToInt16((magnitude * 100 + 100) * 2.2);
            panel1.AutoScroll = true;
        }
    }
}
