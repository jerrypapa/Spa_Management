using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using Spa_Management.Operations;
using Spa_Management.Services;
using ServiceReference1;
//using Serilog;

namespace Spa_Management.Models
{
   
    public class CRBService : CRB
    {
      
        private static readonly EndpointAddress Endpoint = new EndpointAddress(Configuration.CRBServiceEndPoint);
        new ReportPublicServiceClient factory = null;


        ReportPublicServiceClient serviceProxy = null;

        private static readonly BasicHttpsBinding Binding = new BasicHttpsBinding();

        public string SearchIndividual(object IdNumber, string IdNumberType)
        {
            string result = "Null";
         
            using (var proxy = new ReportPublicServiceClient(Binding, Endpoint))
            {
                try
                {         
                    factory = new ReportPublicServiceClient(Binding, Endpoint);
                    factory.ClientCredentials.UserName.UserName = "jgithu@fintech-group.com";
                    factory.ClientCredentials.UserName.Password = "Pass@123$";              
                    Binding.Security.Mode = BasicHttpsSecurityMode.Transport;
                    Binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
                    Binding.MaxBufferSize = int.MaxValue;
                    Binding.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                    Binding.MaxReceivedMessageSize = int.MaxValue;
                    Binding.AllowCookies = true;
                    Binding.TextEncoding = System.Text.Encoding.UTF8;
                    // serviceProxy = factory.CreateChannel();

                    //result = factory.SearchIndividualAsync(query:);
                    
                   //ServiceReference1.ReportPublicServiceClient cl = new ServiceReference1.ReportPublicServiceClient(re);
                   // result = proxy.Execute(c => c.Search("IdNumber", "IdNumberType"));

            
                }
                catch (FaultException ex)
                {
                    throw ex;

                }
                catch (Exception ex)
                {
                    
                
                }

                return result;
            }

        }

        public string SearchIndividual(string IdNumber, string IdNumberType)
        {
            throw new NotImplementedException();
        }
    }
}