using Alertres.ApiClient;
using Alertres.ApiClient.Models.ApiModels;
using Microsoft.Maui.Layouts;

namespace AlertresVer2;
public class localHotlineList
{
    public string hotlineName { get; set; }
    public string hotlineNumber { get; set; }
}
public partial class landingPage : ContentPage
{
        public List<localHotlineList> bulacanHotlineList { get; set; }
        public List<localHotlineList> pampangaHotlineList { get; set; }
        public List<localHotlineList> auroraHotlineList { get; set; }
        public List<localHotlineList> bataanHotlineList { get; set; }
        public List<localHotlineList> notyetHotlineList { get; set; }
        public List<localHotlineList> nuevaecijaHotlineList { get; set; }
        public ListView LocalHotlineList = new ListView();
        public string emmergencyMessage;
    public landingPage()
    {
        InitializeComponent();
        CheckAndRequestLocationPermissionAsync();

        bulacanHotlineList = new List<localHotlineList> {
            new localHotlineList {hotlineName="Bulacan Rescue:", hotlineNumber="0905-333-3319"},
            new localHotlineList {hotlineName="Meycauayan Rescue:", hotlineNumber="0915-707-7929"},
            new localHotlineList {hotlineName="Meycauayan Rescue 2:", hotlineNumber="0925-707-7929"},
            new localHotlineList {hotlineName="PNP Meycauayan:", hotlineNumber="0922-210-3168"},
            new localHotlineList {hotlineName="Fire Department Meycauayan:", hotlineNumber="0922-210-3168"},
        };
        pampangaHotlineList = new List<localHotlineList> {
            new localHotlineList{hotlineName="Bacolor MDRRMC", hotlineNumber="0917-830-6094"},
            new localHotlineList{hotlineName="San Isidro CDRRMO", hotlineNumber="0917-547-5245"},
            new localHotlineList{hotlineName="Mabalacat CDRRMO", hotlineNumber="0998-999-4357"},
            new localHotlineList{hotlineName="Lubao Disaster", hotlineNumber="0921-454-0594"},
            new localHotlineList{hotlineName="Macabebe BFP", hotlineNumber="0936-344-8184"},
            new localHotlineList{hotlineName="Magalang MDRRMO", hotlineNumber="0915-409-2983"},
            new localHotlineList{hotlineName="Mexico NDRRMC", hotlineNumber="0917-679-4389"},
            new localHotlineList{hotlineName="Porac MDRRMO", hotlineNumber="0929-441-6188"},
            new localHotlineList{hotlineName="San Luis MDRRM0", hotlineNumber="0935-049-1036"}
        };
        auroraHotlineList = new List<localHotlineList> {
            new localHotlineList{hotlineName="Baler MDRRMO", hotlineNumber="0920-594-1906"},
            new localHotlineList{hotlineName="Casiguran MDRRMO", hotlineNumber="0921-760-1240"},
            new localHotlineList{hotlineName="Dilasag MDRRMO", hotlineNumber="0917-810-1080"},
            new localHotlineList{hotlineName="Dipaculao MDRRMO", hotlineNumber="0917-504-1139"},
            new localHotlineList{hotlineName="Dinalungan MDRRMO", hotlineNumber="0998-584-7115"},
            new localHotlineList{hotlineName="Dingalan MDRRMO", hotlineNumber="0938-139-6949"},
            new localHotlineList{hotlineName="Maria Auorora MDRRMO", hotlineNumber="0999-434-2299"},
            new localHotlineList{hotlineName="San Luis MDRRMO", hotlineNumber="0998-282-0885"}
        };
        bataanHotlineList = new List<localHotlineList>
        {
            new localHotlineList{hotlineName="1Bataan Command Center", hotlineNumber="0919-914-6232"},
            new localHotlineList{hotlineName="Abuacay MDRRMO", hotlineNumber="0919-583-4851"},
            new localHotlineList{hotlineName="Balanga CDRRMO", hotlineNumber="0998-997-1419"},
            new localHotlineList{hotlineName="Bagac MDRRMO", hotlineNumber="0999-190-4547"},
            new localHotlineList{hotlineName="Hermosa MDRRMO", hotlineNumber="0977-814-6028"},
            new localHotlineList{hotlineName="Limay MDRRMO", hotlineNumber="0999-311-1921"},
            new localHotlineList{hotlineName="Mariveles MDRRMO", hotlineNumber="0917-634-4474"},
            new localHotlineList{hotlineName="Morong MDRRMO", hotlineNumber="0919-644-6933"},
            new localHotlineList{hotlineName="Orani MDRRMO", hotlineNumber="0949-400-5924"},
            new localHotlineList{hotlineName="Orion MDRRMO", hotlineNumber="0932-239-4031"},
            new localHotlineList{hotlineName="Pilar MDRRMO", hotlineNumber="0908-891-6270"},
            new localHotlineList{hotlineName="Samal MDRRMO", hotlineNumber="0956-498-1892"},
        };

            
            notyetHotlineList = new List<localHotlineList> {
                new localHotlineList {hotlineName="Not yet implemented", hotlineNumber="0905-333-3319"},
                new localHotlineList {hotlineName="Not yet implemented", hotlineNumber="0905-333-3319"},
                new localHotlineList {hotlineName="Not yet implemented", hotlineNumber="0905-333-3319"},
                new localHotlineList {hotlineName="Not yet implemented", hotlineNumber="0905-333-3319"}
            };
            LocalHotlineList.SelectionMode = (ListViewSelectionMode)SelectionMode.None;
            LocalHotlineList.ItemTemplate = new DataTemplate(() =>
            {
                var hotlineCell = new ViewCell();


                var hotlineStack = new FlexLayout
                {
                    Direction = FlexDirection.Row,
                    JustifyContent = FlexJustify.SpaceBetween
                };

                var hotlineInfo = new VerticalStackLayout();
                Label hotlineNameLabel = new Label();
                Label hotlineNumberLabel = new Label();
                hotlineNameLabel.SetBinding(Label.TextProperty, "hotlineName");
                hotlineNumberLabel.SetBinding(Label.TextProperty, "hotlineNumber");
                hotlineNumberLabel.FontSize = 20;
                hotlineInfo.Add(hotlineNameLabel);
                hotlineInfo.Add(hotlineNumberLabel);


                var buttonStack = new HorizontalStackLayout();
                buttonStack.Add(new Button
                {
                    Text = "SMS",
                    Command = new Command(async () =>
                    {
                        bool answer = await DisplayAlert("Question?", "Would you like to continue?", "Yes", "No");
                        if (answer)
                        {
                            if (Sms.Default.IsComposeSupported)
                            {
                                var holder = hotlineNumberLabel.BindingContext as localHotlineList;
                                string num = holder.hotlineNumber;
                                string text;
                                rootLayout.Children.Add(new Label { Text = num });
                                if (emmergencyMessage != null)
                                {
                                    text = emmergencyMessage;
                                }
                                else
                                {
                                    text = "Null";
                                }


                                var message = new SmsMessage(text, num);

                                await Sms.Default.ComposeAsync(message);
                            }
                        }
                    })
                });
                buttonStack.Add(new Button
                {
                    Text = "Call",
                    Command = new Command(async () =>
                    {
                        bool answer = await DisplayAlert("Question?", "Would you like to continue?", "Yes", "No");
                        if (answer)
                        {
                            if (PhoneDialer.Default.IsSupported)
                            {
                                var holder = hotlineNumberLabel.BindingContext as localHotlineList;
                                string num = holder.hotlineNumber;
                                PhoneDialer.Default.Open(num);
                            }
                        }
                    })
                });

                hotlineStack.Children.Add(hotlineInfo);
                hotlineStack.Children.Add(buttonStack);
                hotlineCell.View = hotlineStack;

                return hotlineCell;
            });

            LocalHotlineList.ItemsSource = bulacanHotlineList;
            rootLayout.Children.Add(LocalHotlineList);

        }

    private async Task CheckAndRequestLocationPermissionAsync()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            string[] userInformation = new string[5];
            userInformation[0] = await SecureStorage.Default.GetAsync("default-province");
            userInformation[1] = await SecureStorage.Default.GetAsync("default-citymunicipality");
            userInformation[2] = await SecureStorage.Default.GetAsync("default-citymunicipality");
            userInformation[3] = await SecureStorage.Default.GetAsync("default-name");
            userInformation[4] = await SecureStorage.Default.GetAsync("default-address");

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            if (status == PermissionStatus.Granted)
            {
                // Permission granted, proceed to get location
                GetCurrentLocationAsync();
                if (locationLabel.Text == "Undetected")
                {
                    getProvince(userInformation[0]);
                    string oauthToken = Preferences.Default.Get("setup_token", "Unknown");

                    if (oauthToken != "Unknown")
                    {
                        emmergencyMessage = $"This is an emergency message! \nName: {userInformation[3]} \nLocation: {userInformation[2]} \nAddress: {userInformation[4]} \nAdditional Message: (Insert message here)";
                        rootLayout.Children.Add(new Label { Text = "Message Preview: " + emmergencyMessage });
                        locationLabel.Text = $"Province: {userInformation[0]}\nCity/Municipality: {userInformation[2]}";
                    }
                    else
                    {
                        bool ans = await DisplayAlert("No default location detected", "Would you like to go to Setup page", "Yes", "No");
                        if (ans)
                        {
                            await Navigation.PushAsync(new setupLocation());
                        }
                    }
                }
            }
            else
            {
                bool answer = await DisplayAlert("Permission Denied", "Would you like to manually select your location?", "Yes", "No");
                if (answer)
                {
                    string oauthToken = Preferences.Default.Get("setup_token", "Unknown");

                    if (oauthToken != "Unknown")
                    {
                        emmergencyMessage = $"This is an emergency message! \nName: {userInformation[3]} \nLocation: {userInformation[2]} \nAddress: {userInformation[4]} \nAdditional Message: (Insert message here)";
                        rootLayout.Children.Add(new Label { Text = "Message Preview: " + emmergencyMessage });
                    }
                    else
                    {
                        bool ans = await DisplayAlert("No default location detected", "Would you like to go to Setup page", "Yes", "No");
                        if (ans)
                        {
                            await Navigation.PushAsync(new setupLocation());
                        }
                    }
                }
            }
        }

        private void getProvince(string provinceHolder)
        {
            switch (provinceHolder)
            {
                case "Bulacan":
                    LocalHotlineList.ItemsSource = bulacanHotlineList;
                    break;
                case "Pampanga":
                    LocalHotlineList.ItemsSource = pampangaHotlineList;
                    break;
                case "Aurora":
                    LocalHotlineList.ItemsSource = auroraHotlineList; 
                    break;
                case "Bataan":
                    LocalHotlineList.ItemsSource = bataanHotlineList; 
                    break;
                default:
                    LocalHotlineList.ItemsSource = notyetHotlineList;
                    break;
            }
        }

        private async void GetCurrentLocationAsync()
        {
            try
            {
                Location lkLocation = await Geolocation.Default.GetLastKnownLocationAsync();
                if (lkLocation != null)
                {
                    if (lkLocation != null)
                    {
                        IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(lkLocation.Latitude, lkLocation.Longitude);
                        Placemark placemark = placemarks?.FirstOrDefault();

                        if (placemark != null)
                        {
                            string province = placemark.SubAdminArea;
                            getProvince(province);
                            //loadHotlinesAsync(province);
                            locationLabel.Text =
                                $"Region (AdminArea): {placemark.AdminArea}\n" +
                                $"Province (SubAdminArea): {placemark.SubAdminArea}\n" +
                                $"City / Municipality (Locality): {placemark.Locality}\n";
                        }
                    }
                }
                else
                {
                    var location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium));

                    if (location != null)
                    {
                        IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);

                        Placemark placemark = placemarks?.FirstOrDefault();

                        if (placemark != null)
                        {
                            locationLabel.Text =
                                $"Region (AdminArea): {placemark.AdminArea}\n" +
                                $"Province (SubAdminArea): {placemark.SubAdminArea}\n" +
                                $"City / Municipality (Locality): {placemark.Locality}\n";
                        }
                    }
                };
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
                // Handle other exceptions
            }
        }
    }