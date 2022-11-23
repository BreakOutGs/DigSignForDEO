namespace DigSignForDEO;

public partial class ESignDemonstrationPage : ContentPage
{

	CertificateManager certificateManager;
	string documentText;
	string hashString;
	Certificate currentCertificate;
	public ESignDemonstrationPage()
	{
		InitializeComponent();
		certificateManager = CertificateManager.Instance;
		currentCertificate = certificateManager.getNewCertificate();
	}

	private void SignButtonClicked(Object sender, EventArgs args)
	{
		if (certificateManager.Certificate != null)
		{
			currentCertificate = certificateManager.Certificate;
		}

		documentText = DocumentTextEntry.Text;
		hashString = CertificateManager.getHashFromString(documentText);

		hashString = encryptHash(hashString);
		string esignInfo = getESignInfo();

		string signedText = documentText+esignInfo;
		SignedTextOutput.Text = signedText;
	}
	private void CheckSignButtonClicked(Object sender, EventArgs args)
	{
        if (certificateManager.Certificate != null)
        {
            currentCertificate = certificateManager.Certificate;
        }

        documentText = SignedTextOutput.Text;
		int signIndex = documentText.IndexOf("<ESertificate>")-1;

        documentText = documentText.Substring(0, signIndex);
        string newHashString = CertificateManager.getHashFromString(documentText);

		string oldHashString = decodeHash(hashString);

		bool bCheck = newHashString == oldHashString;
		SignIsApprovedMessage.IsVisible = bCheck;
		SignIsNotApprovedMessage.IsVisible = !bCheck;
    }

	private string getESignInfo()
    {
		return $"\n<ESertificate> Ім'я:{currentCertificate.FirstName} \n" +
			$"Прізвище:{currentCertificate.SecondName} \n" +
			$"Дійсний до:{currentCertificate.WhenExpires.ToString()} \n" +
			$"<Hash>{hashString}</Hash> \n" +
			$"</ESertificate>\n";

    }
	private string encryptHash(string hashString)
	{
		string encryptedHashString = "";
		GRSAEncoderClass rsaEncrypt = GRSAEncoderClass.Instance;
		rsaEncrypt.PublicKey = currentCertificate.PublicKey;
		
		encryptedHashString = rsaEncrypt.Encode(hashString);
		return encryptedHashString;
	}
    private string decodeHash(string hashString)
    {
        string decodedHashString = "";
        GRSAEncoderClass rsaEncrypt = GRSAEncoderClass.Instance;
        rsaEncrypt.PrivateKey = currentCertificate.PrivateKey;
        decodedHashString = rsaEncrypt.Decode(hashString);
        return decodedHashString;
    }
}