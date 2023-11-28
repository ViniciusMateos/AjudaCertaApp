namespace AjudaCertaApp.Views.Doador;

public partial class AgendarDoacao : ContentPage
{
	public AgendarDoacao()
	{
		InitializeComponent();
	}

    private void pickerButton_Clicked(object sender, EventArgs e)
    {
        this.Picker.IsOpen = true;
    }

    private void Picker_OkButtonClicked(object sender, EventArgs e)
    {
        
    }
}