using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailKuldo;
using System.ServiceModel;

namespace EmailKuldoHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost h = new ServiceHost(typeof(EmailKuldoService)))
            {
                h.Open();
                Console.WriteLine(h.BaseAddresses.First().AbsoluteUri);
                Console.ReadLine();
            }
        }
    }
}
