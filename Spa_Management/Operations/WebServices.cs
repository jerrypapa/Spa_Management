using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Operations
{

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "WebServices")]

    public interface WebServices
    {

        [System.ServiceModel.OperationContract(Action = "https://creditinfo.com/CB5/v5.21/Search", ReplyAction = "")]
        string Search(string IdNumber, string IdNumberType);

        [System.ServiceModel.OperationContract(Action = "https://creditinfo.com/CB5/v5.21/Search", ReplyAction = "")]
        System.Threading.Tasks.Task<string> SearchAsync(string IdNumber, string IdNumberType);

       
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CalculatorSoapChannel : WebServices, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServicesSoapClient : System.ServiceModel.ClientBase<WebServices>, WebServices
    {

        public WebServicesSoapClient()
        {
        }        

        public WebServicesSoapClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public WebServicesSoapClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public WebServicesSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public WebServicesSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {          
        }
        //public WebServicesSoapClient(EndpointConfiguration endpointConfiguration) :
        //    base(WebServicesSoapClient.EndpointConfiguration(endpointConfiguration), WebServicesSoapClient.GetEndpointAddress(endpointConfiguration))
        //{
        //    this.Endpoint.Name = endpointConfiguration.ToString();
        //    ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        //}

        //public WebService1SoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) :
        //        base(WebService1SoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        //{
        //    this.Endpoint.Name = endpointConfiguration.ToString();
        //    ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        //}


        public string Search(string IdNumber, string IdNumberType)
        {
            return base.Channel.Search(IdNumber, IdNumberType);
        }

        public System.Threading.Tasks.Task<string> SearchAsync(string IdNumber, string IdNumberType)
        {
            return base.Channel.SearchAsync(IdNumber, IdNumberType);
        }

      
        public enum EndpointConfiguration
        {

            BasicHttpBinding_IService1,
        }

    }
}
