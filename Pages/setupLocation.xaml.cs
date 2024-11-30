using System.Runtime.InteropServices;
using Microsoft.Maui.ApplicationModel.Communication;

namespace AlertresVer2;

public partial class setupLocation : ContentPage
{
    public List<String> auroraCityAndMunicipalityList = new List<String>();
    public List<String> bataanCityAndMunicipalityList = new List<String>();
    public List<String> bulacanCityAndMunicipalityList = new List<String>();
    public List<String> nuevaecijaCityAndMunicipalityList = new List<String>();
    public List<String> pampangaCityAndMunicipalityList = new List<String>();
    public List<String> tarlacCityAndMunicipalityList = new List<String>();
    public List<String> zambalesCityAndMunicipalityList = new List<String>();

    public String selectedProvince { get; set; }
    public String selectedCityMunicipality { get; set; }

    public setupLocation()
    {
        InitializeComponent();
        string oauthToken = Preferences.Default.Get("setup_token", "Unknown");
        if (oauthToken != "Unknown")
        {
            nextButton.Text = "Update";
            nextButton.Clicked += updateUserInfo;
        }
        else
        {
            nextButton.Clicked += nextButton_ClickedAsync;
        }

        var provinceList = new List<String>();
        provinceList.Add("Aurora");
        provinceList.Add("Bataan");
        provinceList.Add("Bulacan");
        provinceList.Add("Nueva Ecija");
        provinceList.Add("Pampanga");
        provinceList.Add("Tarlac");
        provinceList.Add("Zambales");

        auroraCityAndMunicipalityList.Add("Municipality of Baler");
        auroraCityAndMunicipalityList.Add("Municipality of Casiguran");
        auroraCityAndMunicipalityList.Add("Municipality of Dilasag");
        auroraCityAndMunicipalityList.Add("Municipality of Dinalungan");
        auroraCityAndMunicipalityList.Add("Municipality of Dingalan");
        auroraCityAndMunicipalityList.Add("Municipality of Dipaculao");
        auroraCityAndMunicipalityList.Add("Municipality of Maria Aurora");
        auroraCityAndMunicipalityList.Add("Municipality of San Luis");

        bataanCityAndMunicipalityList.Add("Municipality of Abucay");
        bataanCityAndMunicipalityList.Add("Municipality of Bagac");
        bataanCityAndMunicipalityList.Add("City of Balanga");
        bataanCityAndMunicipalityList.Add("Municipality of Dinalupihan");
        bataanCityAndMunicipalityList.Add("Municipality of Hermosa");
        bataanCityAndMunicipalityList.Add("Municipality of Limay");
        bataanCityAndMunicipalityList.Add("Municipality of Mariveles");
        bataanCityAndMunicipalityList.Add("Municipality of Morong");
        bataanCityAndMunicipalityList.Add("Municipality of Oroni");
        bataanCityAndMunicipalityList.Add("Municipality of Orion");
        bataanCityAndMunicipalityList.Add("Municipality of Pilar");
        bataanCityAndMunicipalityList.Add("Municipality of Samal");

        bulacanCityAndMunicipalityList.Add("Municipality of Angat");
        bulacanCityAndMunicipalityList.Add("Municipality of Balagtas");
        bulacanCityAndMunicipalityList.Add("Municipality of Baliwag");
        bulacanCityAndMunicipalityList.Add("Municipality of Bocaue");
        bulacanCityAndMunicipalityList.Add("Municipality of Bulakan");
        bulacanCityAndMunicipalityList.Add("Municipality of Bustos");
        bulacanCityAndMunicipalityList.Add("Municipality of Calumpit");
        bulacanCityAndMunicipalityList.Add("Municipality of Dona Remedios Trinidad");
        bulacanCityAndMunicipalityList.Add("Municipality of Guiguinto");
        bulacanCityAndMunicipalityList.Add("Municipality of Hagonoy");
        bulacanCityAndMunicipalityList.Add("City of Malolos");
        bulacanCityAndMunicipalityList.Add("Municipality of Marilao");
        bulacanCityAndMunicipalityList.Add("City of Meycauayan");
        bulacanCityAndMunicipalityList.Add("Municipality of Norzagaray");
        bulacanCityAndMunicipalityList.Add("Municipality of Obando");
        bulacanCityAndMunicipalityList.Add("Municipality of Pandi");
        bulacanCityAndMunicipalityList.Add("Municipality of Paombong");
        bulacanCityAndMunicipalityList.Add("Municipality of Plaridel");
        bulacanCityAndMunicipalityList.Add("Municipality of Pulilan");
        bulacanCityAndMunicipalityList.Add("Municipality of San Ildefonso");
        bulacanCityAndMunicipalityList.Add("City of San Jose Del Monte");
        bulacanCityAndMunicipalityList.Add("Municipality of San Miguel");
        bulacanCityAndMunicipalityList.Add("Municipality of San Rafael");
        bulacanCityAndMunicipalityList.Add("Municipality of Santa Maria");

        nuevaecijaCityAndMunicipalityList.Add("Municipality of Aliaga");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Bongabon");
        nuevaecijaCityAndMunicipalityList.Add("City of Cabanatuan");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Cabiao");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Carranglan");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Cuyapo");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Gabaldon");
        nuevaecijaCityAndMunicipalityList.Add("City of Gapan");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of General Mamerto Natividad");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of General Tinio");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Guimba");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Jaen");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Licab");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Llanera");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Lupao");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Nampicuan");
        nuevaecijaCityAndMunicipalityList.Add("City of Palayan");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Pantabangan");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Penaranda");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Quezon (NE)");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Rizal (NE)");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of San Antonio (NE)");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of San Isidro (NE)");
        nuevaecijaCityAndMunicipalityList.Add("City of San Jose (NE)");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of San Leonardo");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Santa Rosa (NE)");
        nuevaecijaCityAndMunicipalityList.Add("Municipality ofSanto Domingo (NE)");
        nuevaecijaCityAndMunicipalityList.Add("Science City of Munoz");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Talavera");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Talugtug");
        nuevaecijaCityAndMunicipalityList.Add("Municipality of Zaragoza");

        
        pampangaCityAndMunicipalityList.Add("Municipality of Apalit");
        pampangaCityAndMunicipalityList.Add("Municipality of Arayat");
        pampangaCityAndMunicipalityList.Add("Municipality of Bacolor");
        pampangaCityAndMunicipalityList.Add("Municipality of Candaba");
        pampangaCityAndMunicipalityList.Add("Municipality of Floridablanca");
        pampangaCityAndMunicipalityList.Add("Municipality of Guagua");
        pampangaCityAndMunicipalityList.Add("Municipality of Lubao");
        pampangaCityAndMunicipalityList.Add("City of Mabalacat");
        pampangaCityAndMunicipalityList.Add("Municipality of Macabebe");
        pampangaCityAndMunicipalityList.Add("Municipality of Magalang");
        pampangaCityAndMunicipalityList.Add("Municipality of Masantol");
        pampangaCityAndMunicipalityList.Add("Municipality of Mexico");
        pampangaCityAndMunicipalityList.Add("Municipality of Minalin");
        pampangaCityAndMunicipalityList.Add("Municipality of Porac");
        pampangaCityAndMunicipalityList.Add("City of San Fernando (PA)");
        pampangaCityAndMunicipalityList.Add("Municipality of San Luis (PA)");
        pampangaCityAndMunicipalityList.Add("Municipality of San Simon");
        pampangaCityAndMunicipalityList.Add("Municipality of Santa Ana (PA)");
        pampangaCityAndMunicipalityList.Add("Municipality of Santa Rita (PA)");
        pampangaCityAndMunicipalityList.Add("Municipality of Santo Tomas (PA)");
        pampangaCityAndMunicipalityList.Add("Municipality of Sasmuan");

        tarlacCityAndMunicipalityList.Add("Municipality of Anao");
        tarlacCityAndMunicipalityList.Add("Municipality of Bamban");
        tarlacCityAndMunicipalityList.Add("Municipality of Camiling");
        tarlacCityAndMunicipalityList.Add("Municipality of Capas");
        tarlacCityAndMunicipalityList.Add("Municipality of Concepcion (TC)");
        tarlacCityAndMunicipalityList.Add("Municipality of Gerona");
        tarlacCityAndMunicipalityList.Add("Municipality of La Paz (TC)");
        tarlacCityAndMunicipalityList.Add("Municipality of Mayantoc");
        tarlacCityAndMunicipalityList.Add("Municipality of Moncada");
        tarlacCityAndMunicipalityList.Add("Municipality of Paniqui");
        tarlacCityAndMunicipalityList.Add("Municipality of Pura");
        tarlacCityAndMunicipalityList.Add("Municipality of Ramos");
        tarlacCityAndMunicipalityList.Add("Municipality of San Clemente");
        tarlacCityAndMunicipalityList.Add("Municipality of San Jose (TC)");
        tarlacCityAndMunicipalityList.Add("Municipality of San Manuel (TC)");
        tarlacCityAndMunicipalityList.Add("Municipality of Santa Ignacia");
        tarlacCityAndMunicipalityList.Add("City of Tarlac");
        tarlacCityAndMunicipalityList.Add("Municipality of Victoria (TC)");

        zambalesCityAndMunicipalityList.Add("Municipality of Botolan");
        zambalesCityAndMunicipalityList.Add("Municipality of Cabangan");
        zambalesCityAndMunicipalityList.Add("Municipality of Candelaria (ZA)");
        zambalesCityAndMunicipalityList.Add("Municipality of Castillejos");
        zambalesCityAndMunicipalityList.Add("Municipality of Iba");
        zambalesCityAndMunicipalityList.Add("Municipality of Masinloc");
        zambalesCityAndMunicipalityList.Add("Municipality of Palauig");
        zambalesCityAndMunicipalityList.Add("Municipality of San Antonio (ZA)");
        zambalesCityAndMunicipalityList.Add("Municipality of San Felipe");
        zambalesCityAndMunicipalityList.Add("Municipality of San Marcelino");
        zambalesCityAndMunicipalityList.Add("Municipality of San Narciso (ZA)");
        zambalesCityAndMunicipalityList.Add("Municipality of Santa Cruz (ZA)");
        zambalesCityAndMunicipalityList.Add("Municipality of Subic");

        provincePicker.ItemsSource = provinceList;
        citymunicipalityPicker.IsEnabled = false;

        provincePicker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
        citymunicipalityPicker.SelectedIndexChanged += cityOnPickerSelectedIndexChanged;
    }


    private void cityOnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            selectedCityMunicipality = picker.Items[selectedIndex].ToString();
        }
    }
    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            citymunicipalityPicker.IsEnabled = true;
            selectedProvince = picker.Items[selectedIndex].ToString();
            switch (picker.Items[selectedIndex].ToString())
            {
                case "Aurora":
                    citymunicipalityPicker.ItemsSource = auroraCityAndMunicipalityList;
                    break;
                case "Bataan":
                    citymunicipalityPicker.ItemsSource = bataanCityAndMunicipalityList;
                    break;
                case "Bulacan":
                    citymunicipalityPicker.ItemsSource = bulacanCityAndMunicipalityList;
                    break;
                case "Nueva Ecija":
                    citymunicipalityPicker.ItemsSource = nuevaecijaCityAndMunicipalityList;
                    break;
                case "Pampanga":
                    citymunicipalityPicker.ItemsSource = pampangaCityAndMunicipalityList;
                    break;
                case "Tarlac":
                    citymunicipalityPicker.ItemsSource = tarlacCityAndMunicipalityList;
                    break;
                case "Zambales":
                    citymunicipalityPicker.ItemsSource = zambalesCityAndMunicipalityList;
                    break;
            }
        }
    }

    private async void nextButton_ClickedAsync(object sender, EventArgs e)
    {
        if (checkSetup())
        {
            await SecureStorage.Default.SetAsync("setup_token", "setup-complete");
            Preferences.Default.Set("setup_token", "setup-complete");
            await SecureStorage.Default.SetAsync("default-province", selectedProvince);
            await SecureStorage.Default.SetAsync("default-citymunicipality", selectedCityMunicipality);
            await SecureStorage.Default.SetAsync("default-address", addressEditor.Text);
            await SecureStorage.Default.SetAsync("default-name", $"{lastNameEditor.Text}, {firstNameEditor.Text}");
            await Shell.Current.GoToAsync($"{nameof(landingPage)}");
        }
        else
        {
            await DisplayAlert("Required", "All inputs are required", "OK");
        }      
    }

    private bool checkSetup()
    {
        int provinceSelectedItemHolder = provincePicker.SelectedIndex;
        int citymunicipalitySelectedItemHolder = citymunicipalityPicker.SelectedIndex;
        string oauthToken = Preferences.Default.Get("setup_token", "Unknown");
        if (oauthToken == "Unknown")
        {
            if ((lastNameEditor.Text != string.Empty && firstNameEditor.Text != string.Empty) && (provinceSelectedItemHolder != -1 && citymunicipalitySelectedItemHolder != -1) && addressEditor.Text != string.Empty)
            {
                return true;
            }
        }
        return false;
    }

    private async void updateUserInfo(object sender, EventArgs e)
    {
        int provinceSelectedItemHolder = provincePicker.SelectedIndex;
        int citymunicipalitySelectedItemHolder = citymunicipalityPicker.SelectedIndex;
        string oauthToken = Preferences.Default.Get("setup_token", "Unknown");
        if (oauthToken != "Unknown")
        {
            bool answer = await DisplayAlert("Update User Info?", "This will update your current info", "Yes", "No");

            if (answer)
            {
                if ((lastNameEditor.Text != string.Empty && firstNameEditor.Text != string.Empty) && (provinceSelectedItemHolder != -1 && citymunicipalitySelectedItemHolder != -1) && addressEditor.Text != string.Empty)
                {
                    await SecureStorage.Default.SetAsync("default-province", selectedProvince);
                    await SecureStorage.Default.SetAsync("default-citymunicipality", selectedCityMunicipality);
                    await SecureStorage.Default.SetAsync("default-address", addressEditor.Text);
                    await SecureStorage.Default.SetAsync("default-name", $"{lastNameEditor.Text}, {firstNameEditor.Text}");
                    await Shell.Current.GoToAsync($"{nameof(landingPage)}");
                }
            }
        }
    }

}