using System.Reflection;
using Xamarin.Forms;

namespace XFHacks.Triggers
{
    public class ShowPasswordTriggerAction : TriggerAction<Button>
    {
        public string IconImageName { get; set; }

        public string EntryPasswordName { get; set; }

        public string EntryTextName { get; set; }

        protected override void Invoke(Button sender)
        {
            var imageIconView = ((Grid) sender.Parent).FindByName<Image>(IconImageName);
            var entryPasswordView = ((Grid) ((Grid) sender.Parent).Parent).FindByName<Entry>(EntryPasswordName);
            var entryTextView = ((Grid)((Grid)sender.Parent).Parent).FindByName<Entry>(EntryTextName);

            entryPasswordView.IsVisible = !entryPasswordView.IsVisible;
            entryTextView.IsVisible = !entryTextView.IsVisible;

            if (entryPasswordView.IsVisible)
            {
                imageIconView.Source = ImageSource.FromResource("XFHacks.Resources.showpasswordicon.png",
                    Assembly.GetExecutingAssembly());
                entryPasswordView.Focus();
                entryPasswordView.Text = entryTextView.Text;
            }
            else
            {
                imageIconView.Source = ImageSource.FromResource("XFHacks.Resources.hidepasswordicon.png",
                    Assembly.GetExecutingAssembly());
                entryTextView.Focus();
                entryTextView.Text = entryPasswordView.Text;
            }
        }
    }
}