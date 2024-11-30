
using Alertres.ApiClient;
using Alertres.ApiClient.Models.ApiModels;
using Microsoft.Maui.Controls;

namespace AlertresVer2;

public partial class MainPage : ContentPage
{
    private readonly AlertresApiClientService _alertresApiClientService;
    public MainPage(AlertresApiClientService alertresApiClientService)
    {
        InitializeComponent();
        _alertresApiClientService = alertresApiClientService;

        string oauthToken = Preferences.Default.Get("setup_token", "Unknown");
        if (oauthToken == "Unknown")
        {
            Navigation.PushAsync(new setupLocation());
        }
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Question?", "Would you like to continue?", "Yes", "No");
        if (answer)
        {
            if (PhoneDialer.Default.IsSupported)
            {
                string num = "911";
                PhoneDialer.Default.Open(num);
            }
        }
    }

    private async void contactsBtn_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new landingPage());
        //await Shell.Current.GoToAsync($"{nameof(landingPage)}");
    }

    private async void settingsBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new setupLocation());
        //await Shell.Current.GoToAsync($"{nameof(setupLocation)}");
    }

    private async void informationBtn_Clicked(object sender, EventArgs e)
    {
        //await load();
        await Navigation.PushAsync(new InformattiveLandingPage(_alertresApiClientService));
    }

}
