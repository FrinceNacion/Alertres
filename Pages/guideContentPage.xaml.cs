using AlertresVer2.Model;

namespace AlertresVer2.Pages;

public partial class guideContentPage : ContentPage
{
	public guideContent _guideContent;
	public guideContentPage(guideContent guide)
	{
		InitializeComponent();
		_guideContent = guide;
		titleLabel.Text = _guideContent.GuideTitle;
		subtitleLabel.Text = _guideContent.GuideSubTitle;
		languageLabel.Text = _guideContent.GuideLanguage;
		tocLabel.Text = _guideContent.GuideToc;
		firstLabel.Text = _guideContent.GuideParagraphOne;
		secondLabel.Text = _guideContent.GuideParagraphTwo;
		thirdLabel.Text = _guideContent.GuideParagraphThree;
    }
}