namespace DigSignForDEO;

public partial class CertificateCreatingPage : ContentPage
{
	CertificateManager certificateManager;
	public CertificateCreatingPage()
	{
		InitializeComponent();
		certificateManager = CertificateManager.Instance;
	}
	private void AddCertificateButtonClicked(Object sender, EventArgs eventArgs)
	{
		string firstName = FirstNameEntry.Text;
		string secondName = SecondNameEntry.Text;

		Certificate certificate = certificateManager.getNewCertificate();
		certificate.FirstName = firstName;
		certificate.SecondName = secondName;
		certificateManager.Certificate = certificate;

		CertificateInfoLabel.Text = certificateManager.Certificate.getCertificateInfoString();
		CertificateInfoContainer.IsVisible = true;

	}

}