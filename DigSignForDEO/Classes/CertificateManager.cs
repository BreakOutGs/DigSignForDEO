using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DigSignForDEO
{
    public partial class CertificateManager
    {
		private Certificate certificate;

		public Certificate Certificate
		{
			get { return certificate; }
			set { certificate = value; }
		}


        static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
        public static string getHashFromString(string sourceString)
        {
            string hashCodeString = "";

            string sSourceData;
            byte[] tmpSource;
            byte[] tmpHash;
            sSourceData = sourceString;
            //Create a byte array from source data
            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);

            //Compute hash based on source data
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            hashCodeString = (ByteArrayToString(tmpHash));

            return hashCodeString;
        }
        public Certificate getNewCertificate()
        {
            Certificate certificate = new Certificate();
            var encoder = GRSAEncoderClass.Instance;
            encoder.updateCryptoService();
            certificate.PublicKey = encoder.PublicKey;
            certificate.PrivateKey = encoder.PrivateKey;
            return certificate;
        }

        
        private CertificateManager()
        {

        }


    }
}
