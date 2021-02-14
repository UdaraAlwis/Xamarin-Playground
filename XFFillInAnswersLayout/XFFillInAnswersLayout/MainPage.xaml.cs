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
                "THERE IS A {MONKEY} EATING {PIZZA} WITH {BANANA SLICES} DRESSED UP IN A RED {JUMP SUITE}!";

            // Extract the marked blanks fields from the input text
            var matches = Regex.Matches(fillInTheBlanksQuestion, "\\{(.*?)\\}", RegexOptions.IgnoreCase);
            Dictionary<int, object> answerIndexList = new Dictionary<int, object>();
            var index = 0;
            foreach (Match item in matches)
            {
                answerIndexList.Add(index, item.Value); ;
                var regex = new Regex(Regex.Escape(item.Value));
                // Mark out the answer blanks with a unique signature ex: {[0]}, {[1]}
                fillInTheBlanksQuestion = regex.Replace(fillInTheBlanksQuestion, "{[" + index++ + "]}", 1);
            }

            // Segment out the words from the input text
            string[] wordsArray = fillInTheBlanksQuestion.Split(' ');

            fillInTheBlanksQuestionPanel.Children.Clear();
            // Populate the segmented words in the Layout
            for (int i = 0; i < wordsArray.Length; i++)
            {
                string word = wordsArray[i];
                if (Regex.IsMatch(word, "(\\{\\[[0-9]\\]\\})"))
                {
                    // This is an answer input segment
                    var answerFieldIndex = int.Parse(Regex.Match(word, "[0-9]", RegexOptions.IgnoreCase).Value);
                    var placeholderForAnswerField = answerIndexList[answerFieldIndex] as string;

                    // Create the Entry field
                    fillInTheBlanksQuestionPanel.Children.Add(new Entry()
                    {
                        Placeholder = placeholderForAnswerField.Replace("{", "").Replace("}", ""),
                        FontSize = 20,
                        HeightRequest = 45,
                        Margin = 2,
                        BackgroundColor = Color.BurlyWood,
                    });
                }
                else
                {
                    // This is a normal text segment
                    fillInTheBlanksQuestionPanel.Children.Add(new Label()
                    {
                        Text = word + " ",
                        BackgroundColor = Color.SkyBlue,
                        VerticalTextAlignment = TextAlignment.Center,
                        FontSize = 20,
                        HeightRequest = 45,
                        Margin = 2,
                    });
                }
            }

        }
    }
}
