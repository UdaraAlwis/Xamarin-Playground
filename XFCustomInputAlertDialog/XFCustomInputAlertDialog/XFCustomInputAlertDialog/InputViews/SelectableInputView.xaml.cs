using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFCustomInputAlertDialog.InputViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectableInputView : ContentView
	{
	    // public event handler to expose 
	    // the Save button's click event
	    public EventHandler SaveButtonEventHandler { get; set; }

	    // public event handler to expose 
	    // the Cancel button's click event
	    public EventHandler CancelButtonEventHandler { get; set; }

	    // public string to expose the 
	    // text Entry input's value
	    public string SelectionResult { get; set; }

	    public static readonly BindableProperty IsValidationLabelVisibleProperty =
	        BindableProperty.Create(
	            nameof(IsValidationLabelVisible),
	            typeof(bool),
	            typeof(SelectableInputView),
	            false, BindingMode.OneWay, null,
	            (bindable, value, newValue) =>
	            {
	                if ((bool)newValue)
	                {
	                    ((SelectableInputView)bindable).ValidationLabel
	                        .IsVisible = true;
	                }
	                else
	                {
	                    ((SelectableInputView)bindable).ValidationLabel
	                        .IsVisible = false;
	                }
	            });

	    /// <summary>
	    /// Gets or Sets if the ValidationLabel is visible
	    /// </summary>
	    public bool IsValidationLabelVisible
	    {
	        get
	        {
	            return (bool)GetValue(IsValidationLabelVisibleProperty);
	        }
	        set
	        {
	            SetValue(IsValidationLabelVisibleProperty, value);
	        }
	    }

        public SelectableInputView (string titleText, IList<string> selectiondataSource,
		    string saveButtonText, string cancelButtonText, string validationText)
		{
			InitializeComponent ();

		    // update the Element's textual values
		    TitleLabel.Text = titleText;

            var template = new DataTemplate(typeof(TextCell));
		    template.SetBinding(TextCell.TextProperty, "String");
            
            SelectionListView.ItemsSource = selectiondataSource;
		    SaveButton.Text = saveButtonText;
		    CancelButton.Text = cancelButtonText;
		    ValidationLabel.Text = validationText;

		    // handling events to expose to public
		    SaveButton.Clicked += SaveButton_Clicked;
		    CancelButton.Clicked += CancelButton_Clicked;
		    SelectionListView.ItemSelected += InputEntryOnItemSelected;
        }

	    private void InputEntryOnItemSelected(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
	    {
	        SelectionResult = (string)selectedItemChangedEventArgs.SelectedItem;
	    }

	    private void SaveButton_Clicked(object sender, EventArgs e)
	    {
	        // invoke the event handler if its being subscribed
	        SaveButtonEventHandler?.Invoke(this, e);
	    }

	    private void CancelButton_Clicked(object sender, EventArgs e)
	    {
	        // invoke the event handler if its being subscribed
	        CancelButtonEventHandler?.Invoke(this, e);
	    }

    }
}