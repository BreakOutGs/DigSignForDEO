using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigSignForDEO
{
    public partial class CertificateManager
    {
        private static volatile CertificateManager instance;
        private static object syncRoot = new Object();
        static int instanceCounter;


        public static CertificateManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new CertificateManager();
                    }
                }

                return instance;
            }
        }

        public int getCounter()
        {
            return instanceCounter++;
        }

    }
}
