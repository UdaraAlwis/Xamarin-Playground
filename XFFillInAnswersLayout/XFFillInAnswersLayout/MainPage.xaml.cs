using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFFillInAnswersLayout
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            string fillInTheBlanksQuestion =
                "THERE IS A {MONKEY} EATING {PIZZA} WITH {BANANA SLICES} DRESSED UP IN A RED {JUMP SUITE}! BUT HIS " +
                "FRIEND WANTS TO WEAR A WHAT? A FLYING {SPACE SUITE} WITH AN ACTUAL HELMET ON {IT'S HEAD!} I MEAN, IS HE FOR REAL!?";

            // Extract the marked blanks fields from the input text
            var matches = Regex.Matches(fillInTheBlanksQuestion, "\\{(.*?)\\}", RegexOptions.IgnoreCase);
            Dictionary<int, object> answerIndexList = new Dictionary<int, object>();
            var index = 0;
            foreach (Match item in matches)
            {
                answerIndexList.Add(index, item.Value); ;
                var regex = new Regex(Regex.Escape(item.Value));
                fillInTheBlanksQuestion = regex.Replace(fillInTheBlanksQuestion, "{[" + index++ + "]}", 1);
            }

            // Create the words array from the 
            string[] wordsArray = fillInTheBlanksQuestion.Split(' ');

            fillInTheBlanksQuestionPanel.Children.Clear();
            for (int i = 0; i < wordsArray.Length; i++)
            {
                string word = wordsArray[i];
                if (Regex.IsMatch(word, "(\\{\\[[0-9]\\]\\})"))
                {
                    var answerFieldIndex = int.Parse(Regex.Match(word, "[0-9]", RegexOptions.IgnoreCase).Value);
                    var placeholderForAnswerField = answerIndexList[answerFieldIndex] as string;

                    fillInTheBlanksQuestionPanel.Children.Add(new Entry()
                    {
                        Placeholder = placeholderForAnswerField.Replace("{", "").Replace("}", ""),
                        FontSize = 20,
                        HeightRequest = 45,
                    });
                    fillInTheBlanksQuestionPanel.Children.Add(new Label()
                    {
                        Text = " ", 
                        BackgroundColor = Color.SkyBlue,
                        VerticalTextAlignment = TextAlignment.Center,
                        FontSize = 20,
                        HeightRequest = 45,
                    });
                }
                else
                {
                    fillInTheBlanksQuestionPanel.Children.Add(new Label()
                    {
                        Text = word + " ",
                        BackgroundColor = Color.SkyBlue,
                        VerticalTextAlignment = TextAlignment.Center,
                        FontSize = 20,
                        HeightRequest = 45,
                    });
                }
            }

        }
    }
}
