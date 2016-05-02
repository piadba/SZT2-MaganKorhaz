using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmailKuldo
{
   
    [ServiceContract (Name="Email")]
    public interface IEmailKuldoService
    {
        [OperationContract]
        void EmailKuldes(string fromAddress, string fromName, string toAddress, string toName, string subject, string body);



        // TODO: Add your service operations here
    }

  
}
