using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFFillInAnswersLayout
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        static Color[] colors = { Color.Red, Color.Magenta, Color.Blue,
                                  Color.Cyan, Color.Green, Color.Yellow };

        static string[] digitsText = { "", "One", "Two", "Three aksduiwe", "Four", "Five",
                                       "Six", "Seven rasdkj", "Eight", "Nine", "Ten",
                                       "Eleven", "Twelve", "Thirteen", "Fourteen ajshd",
                                       "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

        static string[] decadeText = { "", "", "as Twenty", "Thirty aywue", "Forty", "Fiftyajksd",
                                       "Sixty", "Seventy ajsk asid", "Eighty", "Ninety" };

        public MainPage()
        {
            InitializeComponent();

            //numberStepper.Value = 30;

            //OnNumberStepperValueChanged(flexLayout, new ValueChangedEventArgs(0, numberStepper.Value));
        }

        void OnNumberStepperValueChanged(object sender, ValueChangedEventArgs args)
        {
            int count = (int)args.NewValue;

            while (flexLayout.Children.Count > count)
            {
                flexLayout.Children.RemoveAt(flexLayout.Children.Count - 1);
            }


            while (flexLayout.Children.Count < count)
            {
                int number = flexLayout.Children.Count + 1;
                string text = "";

                if (number < 20)
                {
                    text = digitsText[number];
                }
                else
                {
                    text = decadeText[number / 10] +
                           (number % 10 == 0 ? "" : "-") +
                                digitsText[number % 10];
                }

                Label label = new Label
                {
                    Text = text,
                    FontSize = 16,
                    Margin = new Thickness(5, 5, 5, 5),
                    VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    TextColor = Color.Black,
                    BackgroundColor = Color.White
                };

                Entry entry = new Entry
                {
                    Placeholder = text,
                    FontSize = 16,
                    BackgroundColor = Color.White
                };

                Random rand = new Random();
                int x = rand.Next(2);

                if (x == 0)
                {
                    flexLayout.Children.Add(entry);
                }
                else
                {
                    flexLayout.Children.Add(label);
                }
            }
        }
    }
}
