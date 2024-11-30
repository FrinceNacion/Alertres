using Alertres.ApiClient;
using AlertresVer2.Model;
using AlertresVer2.Pages;

namespace AlertresVer2;

public partial class InformattiveLandingPage : ContentPage
{
    private readonly AlertresApiClientService _alertresApiClientService;
    public List<guideContent> Guides { get; set; }
    public InformattiveLandingPage(AlertresApiClientService alertresApiClientService)
	{
		InitializeComponent();
        Guides = new List<guideContent> { 
            new guideContent { GuideLanguage="Tagalog", GuideTitle= "Paano Maghanda para sa mga Kalamidad", GuideSubTitle="Tatlong hakbang sa pagha-handa", GuideToc="Upang ihanda ang iyong sarili at ang iyong pamilya para sa isang sakuna, dapat mong: 1) Alamin ang Iyong Mga Panganib; 2) Gumawa ng Plano; at 3) Kumilos", GuideParagraphOne="1. Alamin ang Iyong Mga Panganib\r\nUnawain ang mga panganib na maaaring kaharapin mo at ng iyong pamilya. Karamihan sa mga komunidad ay nahaharap sa maraming uri ng mga panganib. Mahalagang matutunan ang mga panganib na partikular sa iyong tahanan at ang mga paraan upang masuri ang iyong mga panganib kung wala ka sa bahay. Alamin kung paano at kailan gagawa ng aksyon bago, habang, at pagkatapos ng iba't ibang panganib.", GuideParagraphTwo="1. Alamin ang Iyong Mga Panganib\r\nUnawain ang mga panganib na maaaring kaharapin mo at ng iyong pamilya. Karamihan sa mga komunidad ay nahaharap sa maraming uri ng mga panganib. Mahalagang matutunan ang mga panganib na partikular sa iyong tahanan at ang mga paraan upang masuri ang iyong mga panganib kung wala ka sa bahay. Alamin kung paano at kailan gagawa ng aksyon bago, habang, at pagkatapos ng iba't ibang panganib.", GuideParagraphThree="3. Kumilos\r\nIsagawa ang iyong plano. Maging handa at kayang harapin ang mga sakuna, nasaan ka man at kailan ito mangyari. Mahalagang makuha ang insurance na kailangan mo at maunawaan ang iyong mga opsyon sa coverage. Bukod dito, dapat kang gumawa ng isang listahan ng iyong personal na ari-arian at ang kondisyon nito at protektahan ang iyong ari-arian sa pamamagitan ng pagsasaalang-alang kung paano mabawasan ang pinsala. Isagawa ang iyong mga plano sa sakuna, samantalahin ang mga kasalukuyang sistema ng alerto at babala, at tuklasin ang mga paraan upang mapaglingkuran ang iyong komunidad."},
            new guideContent
            {
                GuideLanguage="English",
                GuideTitle="How to Prepare for Disasters Guide",
                GuideSubTitle="Three steps for preparing",
                GuideParagraphOne="1. Know Your Risks\r\nUnderstand the risks you and your family may face. Most communities face\r\nmany types of hazards. It is important to learn the risks specific to your home\r\nand the ways to assess your risks if you are away from home. Know how and\r\nwhen to take action before, during, and after different hazards",
                GuideParagraphTwo="2. Make a Plan\r\nMake a communications plan and prepare for both evacuating and\r\nsheltering. Prepare for your family’s unique needs with customized plans and\r\nsupplies. In addition, use your social networks to help friends and family\r\nmembers prepare and participate in community-wide disaster preparedness\r\nactivities. Moreover, you should gather emergency supplies and secure the\r\ninformation and important documents you will need to start your recovery",
                GuideParagraphThree="3. Take Action\r\nPut your plan into action. Be ready and able to face disasters, no matter\r\nwhere you are and when they occur. It is important to get the insurance you\r\nneed and understand your coverage options. Moreover, you should make a list\r\nof your personal property and its condition and protect your property by\r\nconsidering how to minimize damage. Practice your disaster plans, take\r\nadvantage of existing alert and warning systems, and explore ways to serve\r\nyour community."
            }

        };
        _alertresApiClientService = alertresApiClientService;
        resList.ItemsSource = Guides;
        
    }

    private async Task load()
    {
        var inf = await _alertresApiClientService.GetGuides();
        resList.ItemsSource = inf;
    }

    private async void resList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var item = (guideContent)e.SelectedItem;
        await Navigation.PushAsync(new guideContentPage(item));
    }
}