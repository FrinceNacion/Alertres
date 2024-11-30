namespace AlertresVer2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(setupLocation), typeof(setupLocation));
            Routing.RegisterRoute(nameof(landingPage), typeof(landingPage));
        }
    }
}
