using PropertyChanged;

namespace XFShellBackButtonOverride.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseViewModel
    {
        /* 
         * With PropertyChanged.Fody, You can throw out all the excessive boilerplate.
         * 
         * Just decorate your base viewmodel with [AddINotifyPropertyChangedInterface].
         * 
         * It achieves the exact same effect as manually imoplementing INotifyPropertyChanged.
         * 
         * By annotating with [AddINotifyPropertyChangedInterface], all your public getters automatically 
         * have code injected at compile time that implments property-change notifications.
         * 
         * I also frequently annoate my models, even my EF Core models (because EF Core will just ignore
         * the attribute, while my app code will honor it). That way all your model properties also automatically
         * emit property-changed notifications.
         * 
         * 
         * All your base viewmodel needs is this:
         */

        public bool IsBusy { get; protected set; } // You can use the the regular public get/set if you want to. I'm assuming that IsBusy should never be set outside of a viewmodel class.

        public string Title { get; protected set; } // You can use the the regular public get/set if you want to. I'm assuming that Title should never be set outside of a viewmodel class.

        /* You can throw all of this away:
         * 
       bool isBusy = false;
       public bool IsBusy
       {
           get { return isBusy; }
           set { SetProperty(ref isBusy, value); }
       }

       string title = string.Empty;
       public string Title
       {
           get { return title; }
           set { SetProperty(ref title, value); }
       }

       protected bool SetProperty<T>(ref T backingStore, T value,
           [CallerMemberName] string propertyName = "",
           Action onChanged = null)
       {
           if (EqualityComparer<T>.Default.Equals(backingStore, value))
               return false;

           backingStore = value;
           onChanged?.Invoke();
           OnPropertyChanged(propertyName);
           return true;
       }

       #region INotifyPropertyChanged
       public event PropertyChangedEventHandler PropertyChanged;
       protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
       {
           var changed = PropertyChanged;
           if (changed == null)
               return;

           changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
       }
       #endregion

       */
    }
}
