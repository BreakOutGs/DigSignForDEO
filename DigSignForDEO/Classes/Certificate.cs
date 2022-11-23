using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigSignForDEO;

public class Certificate
{

    string firstname;

    string secondname;

    DateTime whenGiven;

    DateTime whenExpires;

    string privateKey;

    string publicKey;

    public string FirstName
    {
        get { return firstname; }
        set { firstname = value; }
    }
    public string SecondName
    {
        get { return secondname; }
        set { secondname = value; }
    }
    public DateTime WhenGiven
    {
        get { return whenGiven; }
        set { whenGiven = value; }
    }
    public DateTime WhenExpires
    {
        get { return whenExpires; }
        set { whenExpires = value; }
    }
    public string PrivateKey
    {
        get { return privateKey; }
        set { privateKey = value; }
    }
    public string PublicKey
    {
        get { return publicKey; }
        set { publicKey = value; }
    }

    public Certificate()
    {
        firstname = "Ім'я";
        secondname = "Прізвище";
        whenGiven = DateTime.Now;
        whenExpires = DateTime.Now.AddYears(2);
    }

    private void generateKeysFromRsa()
    {
        GRSAEncoderClass gRSA = GRSAEncoderClass.Instance;
        gRSA.updateCryptoService();
        privateKey = gRSA.PrivateKey;
        publicKey = gRSA.PublicKey;
    }
    public string getCertificateInfoString()
    {
        return $"Сертифікат безпеки:" +
            $"\n Ім'я власника:{this.FirstName}" +
            $"\n Прізвище власника:{this.SecondName}" +
            $"\n Коли створений:{this.WhenGiven.ToString()}" +
            $"\n Коли закінчується:{this.WhenExpires.ToString()}" +
            $"\n Приватний ключ:{this.PrivateKey}" +
            $"\n Публічний клю: {this.PublicKey}";
    }
}
