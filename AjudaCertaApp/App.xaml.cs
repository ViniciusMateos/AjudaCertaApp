namespace AjudaCertaApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjgyMTI5OEAzMjMzMmUzMDJlMzBmNmM3ZjVtQWh2WGtpbDIrWjhaOWd2anM2NUpBVWdrZUdUaTlUWTkxQVBVPQ==");

            MainPage = new NavigationPage(new Views.Doador.AgendarDoacao());
        }
    }
}
