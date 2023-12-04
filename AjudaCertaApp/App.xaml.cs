namespace AjudaCertaApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF1cWWhIYVJpR2Nbe05xflZEal9SVBYiSV9jS31SdEVhWHxdeHRSQ2RbWQ==");

            MainPage = new NavigationPage(new Views.Login()) ;
        }
    }
}
