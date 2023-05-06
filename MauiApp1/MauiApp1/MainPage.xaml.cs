namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    async void OnButtonClicked(object sender, EventArgs args)
    {
        //string text = OnEntryCompleted(sender, args);

    }

    void OnEntryCompleted(object sender, EventArgs e)
    {
        string text = ((Entry)sender).Text;
        //return text;
    }

    void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        //string oldText = e.OldTextValue;
        //string newText = e.NewTextValue;
        //string myText = entry.Text;
    }
}



