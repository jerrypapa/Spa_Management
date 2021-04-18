
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Spa_Management.Operations
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "BasicHttpBinding_IReportPublicService", Namespace = "http://creditinfo.com/CB5")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DataContractKnownTypesBaseOfNilReportInternal0dcikneZ))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Record))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SearchResults))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SmartSearchQuery))]

    public class ReportPublicService
    {

/// <remarks/>
// CODEGEN: The optional WSDL extension element 'PolicyReference' from namespace 'http://schemas.xmlsoap.org/ws/2004/09/policy' was not handled.
   
    public partial class BasicHttpBinding_IReportPublicService : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback SearchIndividualOperationCompleted;

        private System.Threading.SendOrPostCallback SearchCompanyOperationCompleted;

        private System.Threading.SendOrPostCallback PublicSearchIndividualOperationCompleted;

        private System.Threading.SendOrPostCallback PublicSearchCompanyOperationCompleted;

        private System.Threading.SendOrPostCallback SmartSearchIndividualOperationCompleted;

        private System.Threading.SendOrPostCallback SmartSearchCompanyOperationCompleted;

        private System.Threading.SendOrPostCallback GetCustomReportSectionsOperationCompleted;

        private System.Threading.SendOrPostCallback GetCustomReportOperationCompleted;

        private System.Threading.SendOrPostCallback GetExternalReportOperationCompleted;

        private System.Threading.SendOrPostCallback GetExternalReportListOperationCompleted;

        private System.Threading.SendOrPostCallback GetExternalReportSchemaOperationCompleted;

        private System.Threading.SendOrPostCallback GetPdfReportOperationCompleted;

        private System.Threading.SendOrPostCallback GetSupportedLanguagesOperationCompleted;

        private System.Threading.SendOrPostCallback GetSupportedReportsOperationCompleted;

        /// <remarks/>
        public BasicHttpBinding_IReportPublicService()
        {
            this.Url = "https://wstest.creditinfo.co.ke/WsReport/v5.21/service.svc";
        }

        /// <remarks/>
        public event SearchIndividualCompletedEventHandler SearchIndividualCompleted;

        /// <remarks/>
        public event SearchCompanyCompletedEventHandler SearchCompanyCompleted;

        /// <remarks/>
        public event PublicSearchIndividualCompletedEventHandler PublicSearchIndividualCompleted;

        /// <remarks/>
        public event PublicSearchCompanyCompletedEventHandler PublicSearchCompanyCompleted;

        /// <remarks/>
        public event SmartSearchIndividualCompletedEventHandler SmartSearchIndividualCompleted;

        /// <remarks/>
        public event SmartSearchCompanyCompletedEventHandler SmartSearchCompanyCompleted;

        /// <remarks/>
        public event GetCustomReportSectionsCompletedEventHandler GetCustomReportSectionsCompleted;

        /// <remarks/>
        public event GetCustomReportCompletedEventHandler GetCustomReportCompleted;

        /// <remarks/>
        public event GetExternalReportCompletedEventHandler GetExternalReportCompleted;

        /// <remarks/>
        public event GetExternalReportListCompletedEventHandler GetExternalReportListCompleted;

        /// <remarks/>
        public event GetExternalReportSchemaCompletedEventHandler GetExternalReportSchemaCompleted;

        /// <remarks/>
        public event GetPdfReportCompletedEventHandler GetPdfReportCompleted;

        /// <remarks/>
        public event GetSupportedLanguagesCompletedEventHandler GetSupportedLanguagesCompleted;

        /// <remarks/>
        public event GetSupportedReportsCompletedEventHandler GetSupportedReportsCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/SearchIndividual", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SearchIndividualResults SearchIndividual([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] SearchIndividualQuery query)
        {
            object[] results = this.Invoke("SearchIndividual", new object[] {
                    query});
            return ((SearchIndividualResults)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSearchIndividual(SearchIndividualQuery query, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("SearchIndividual", new object[] {
                    query}, callback, asyncState);
        }

        /// <remarks/>
        public SearchIndividualResults EndSearchIndividual(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((SearchIndividualResults)(results[0]));
        }

     

            /// <remarks/>
            public void SearchIndividualAsync(SearchIndividualQuery query)
        {
            this.SearchIndividualAsync(query, null);
        }

        /// <remarks/>
        public void SearchIndividualAsync(SearchIndividualQuery query, object userState)
        {
            if ((this.SearchIndividualOperationCompleted == null))
            {
                this.SearchIndividualOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSearchIndividualOperationCompleted);
            }
            this.InvokeAsync("SearchIndividual", new object[] {
                    query}, this.SearchIndividualOperationCompleted, userState);
        }

        private void OnSearchIndividualOperationCompleted(object arg)
        {
            if ((this.SearchIndividualCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SearchIndividualCompleted(this, new SearchIndividualCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/SearchCompany", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SearchCompanyResults SearchCompany([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] SearchCompanyQuery query)
        {
            object[] results = this.Invoke("SearchCompany", new object[] {
                    query});
            return ((SearchCompanyResults)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSearchCompany(SearchCompanyQuery query, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("SearchCompany", new object[] {
                    query}, callback, asyncState);
        }

        /// <remarks/>
        public SearchCompanyResults EndSearchCompany(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((SearchCompanyResults)(results[0]));
        }

        /// <remarks/>
        public void SearchCompanyAsync(SearchCompanyQuery query)
        {
            this.SearchCompanyAsync(query, null);
        }

        /// <remarks/>
        public void SearchCompanyAsync(SearchCompanyQuery query, object userState)
        {
            if ((this.SearchCompanyOperationCompleted == null))
            {
                this.SearchCompanyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSearchCompanyOperationCompleted);
            }
            this.InvokeAsync("SearchCompany", new object[] {
                    query}, this.SearchCompanyOperationCompleted, userState);
        }

        private void OnSearchCompanyOperationCompleted(object arg)
        {
            if ((this.SearchCompanyCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SearchCompanyCompleted(this, new SearchCompanyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/PublicSearchIndividual", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public PublicSearchIndividualResults PublicSearchIndividual([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] PublicSearchIndividualQuery query)
        {
            object[] results = this.Invoke("PublicSearchIndividual", new object[] {
                    query});
            return ((PublicSearchIndividualResults)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginPublicSearchIndividual(PublicSearchIndividualQuery query, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("PublicSearchIndividual", new object[] {
                    query}, callback, asyncState);
        }

        /// <remarks/>
        public PublicSearchIndividualResults EndPublicSearchIndividual(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((PublicSearchIndividualResults)(results[0]));
        }

        /// <remarks/>
        public void PublicSearchIndividualAsync(PublicSearchIndividualQuery query)
        {
            this.PublicSearchIndividualAsync(query, null);
        }

        /// <remarks/>
        public void PublicSearchIndividualAsync(PublicSearchIndividualQuery query, object userState)
        {
            if ((this.PublicSearchIndividualOperationCompleted == null))
            {
                this.PublicSearchIndividualOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPublicSearchIndividualOperationCompleted);
            }
            this.InvokeAsync("PublicSearchIndividual", new object[] {
                    query}, this.PublicSearchIndividualOperationCompleted, userState);
        }

        private void OnPublicSearchIndividualOperationCompleted(object arg)
        {
            if ((this.PublicSearchIndividualCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PublicSearchIndividualCompleted(this, new PublicSearchIndividualCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/PublicSearchCompany", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public PublicSearchCompanyResults PublicSearchCompany([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] PublicSearchCompanyQuery query)
        {
            object[] results = this.Invoke("PublicSearchCompany", new object[] {
                    query});
            return ((PublicSearchCompanyResults)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginPublicSearchCompany(PublicSearchCompanyQuery query, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("PublicSearchCompany", new object[] {
                    query}, callback, asyncState);
        }

        /// <remarks/>
        public PublicSearchCompanyResults EndPublicSearchCompany(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((PublicSearchCompanyResults)(results[0]));
        }

        /// <remarks/>
        public void PublicSearchCompanyAsync(PublicSearchCompanyQuery query)
        {
            this.PublicSearchCompanyAsync(query, null);
        }

        /// <remarks/>
        public void PublicSearchCompanyAsync(PublicSearchCompanyQuery query, object userState)
        {
            if ((this.PublicSearchCompanyOperationCompleted == null))
            {
                this.PublicSearchCompanyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPublicSearchCompanyOperationCompleted);
            }
            this.InvokeAsync("PublicSearchCompany", new object[] {
                    query}, this.PublicSearchCompanyOperationCompleted, userState);
        }

        private void OnPublicSearchCompanyOperationCompleted(object arg)
        {
            if ((this.PublicSearchCompanyCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PublicSearchCompanyCompleted(this, new PublicSearchCompanyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/SmartSearchIndividual", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SmartSearchIndividualResults SmartSearchIndividual([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] SmartSearchIndividualQuery query)
        {
            object[] results = this.Invoke("SmartSearchIndividual", new object[] {
                    query});
            return ((SmartSearchIndividualResults)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSmartSearchIndividual(SmartSearchIndividualQuery query, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("SmartSearchIndividual", new object[] {
                    query}, callback, asyncState);
        }

        /// <remarks/>
        public SmartSearchIndividualResults EndSmartSearchIndividual(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((SmartSearchIndividualResults)(results[0]));
        }

        /// <remarks/>
        public void SmartSearchIndividualAsync(SmartSearchIndividualQuery query)
        {
            this.SmartSearchIndividualAsync(query, null);
        }

        /// <remarks/>
        public void SmartSearchIndividualAsync(SmartSearchIndividualQuery query, object userState)
        {
            if ((this.SmartSearchIndividualOperationCompleted == null))
            {
                this.SmartSearchIndividualOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSmartSearchIndividualOperationCompleted);
            }
            this.InvokeAsync("SmartSearchIndividual", new object[] {
                    query}, this.SmartSearchIndividualOperationCompleted, userState);
        }

        private void OnSmartSearchIndividualOperationCompleted(object arg)
        {
            if ((this.SmartSearchIndividualCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SmartSearchIndividualCompleted(this, new SmartSearchIndividualCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/SmartSearchCompany", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SmartSearchCompanyResults SmartSearchCompany([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] SmartSearchCompanyQuery query)
        {
            object[] results = this.Invoke("SmartSearchCompany", new object[] {
                    query});
            return ((SmartSearchCompanyResults)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSmartSearchCompany(SmartSearchCompanyQuery query, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("SmartSearchCompany", new object[] {
                    query}, callback, asyncState);
        }

        /// <remarks/>
        public SmartSearchCompanyResults EndSmartSearchCompany(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((SmartSearchCompanyResults)(results[0]));
        }

        /// <remarks/>
        public void SmartSearchCompanyAsync(SmartSearchCompanyQuery query)
        {
            this.SmartSearchCompanyAsync(query, null);
        }

        /// <remarks/>
        public void SmartSearchCompanyAsync(SmartSearchCompanyQuery query, object userState)
        {
            if ((this.SmartSearchCompanyOperationCompleted == null))
            {
                this.SmartSearchCompanyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSmartSearchCompanyOperationCompleted);
            }
            this.InvokeAsync("SmartSearchCompany", new object[] {
                    query}, this.SmartSearchCompanyOperationCompleted, userState);
        }

        private void OnSmartSearchCompanyOperationCompleted(object arg)
        {
            if ((this.SmartSearchCompanyCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SmartSearchCompanyCompleted(this, new SmartSearchCompanyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/GetCustomReportSections", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] GetCustomReportSections()
        {
            object[] results = this.Invoke("GetCustomReportSections", new object[0]);
            return ((string[])(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetCustomReportSections(System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetCustomReportSections", new object[0], callback, asyncState);
        }

        /// <remarks/>
        public string[] EndGetCustomReportSections(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }

        /// <remarks/>
        public void GetCustomReportSectionsAsync()
        {
            this.GetCustomReportSectionsAsync(null);
        }

        /// <remarks/>
        public void GetCustomReportSectionsAsync(object userState)
        {
            if ((this.GetCustomReportSectionsOperationCompleted == null))
            {
                this.GetCustomReportSectionsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCustomReportSectionsOperationCompleted);
            }
            this.InvokeAsync("GetCustomReportSections", new object[0], this.GetCustomReportSectionsOperationCompleted, userState);
        }

        private void OnGetCustomReportSectionsOperationCompleted(object arg)
        {
            if ((this.GetCustomReportSectionsCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCustomReportSectionsCompleted(this, new GetCustomReportSectionsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/GetCustomReport", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public CustomReport GetCustomReport([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] CustomReportParams parameters)
        {
            object[] results = this.Invoke("GetCustomReport", new object[] {
                    parameters});
            return ((CustomReport)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetCustomReport(CustomReportParams parameters, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetCustomReport", new object[] {
                    parameters}, callback, asyncState);
        }

        /// <remarks/>
        public CustomReport EndGetCustomReport(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((CustomReport)(results[0]));
        }

        /// <remarks/>
        public void GetCustomReportAsync(CustomReportParams parameters)
        {
            this.GetCustomReportAsync(parameters, null);
        }

        /// <remarks/>
        public void GetCustomReportAsync(CustomReportParams parameters, object userState)
        {
            if ((this.GetCustomReportOperationCompleted == null))
            {
                this.GetCustomReportOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCustomReportOperationCompleted);
            }
            this.InvokeAsync("GetCustomReport", new object[] {
                    parameters}, this.GetCustomReportOperationCompleted, userState);
        }

        private void OnGetCustomReportOperationCompleted(object arg)
        {
            if ((this.GetCustomReportCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCustomReportCompleted(this, new GetCustomReportCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/GetExternalReport", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Xml.XmlElement GetExternalReport([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string name, [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] System.Xml.XmlElement request)
        {
            object[] results = this.Invoke("GetExternalReport", new object[] {
                    name,
                    request});
            return ((System.Xml.XmlElement)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetExternalReport(string name, System.Xml.XmlElement request, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetExternalReport", new object[] {
                    name,
                    request}, callback, asyncState);
        }

        /// <remarks/>
        public System.Xml.XmlElement EndGetExternalReport(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlElement)(results[0]));
        }

        /// <remarks/>
        public void GetExternalReportAsync(string name, System.Xml.XmlElement request)
        {
            this.GetExternalReportAsync(name, request, null);
        }

        /// <remarks/>
        public void GetExternalReportAsync(string name, System.Xml.XmlElement request, object userState)
        {
            if ((this.GetExternalReportOperationCompleted == null))
            {
                this.GetExternalReportOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetExternalReportOperationCompleted);
            }
            this.InvokeAsync("GetExternalReport", new object[] {
                    name,
                    request}, this.GetExternalReportOperationCompleted, userState);
        }

        private void OnGetExternalReportOperationCompleted(object arg)
        {
            if ((this.GetExternalReportCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetExternalReportCompleted(this, new GetExternalReportCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/GetExternalReportList", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] GetExternalReportList()
        {
            object[] results = this.Invoke("GetExternalReportList", new object[0]);
            return ((string[])(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetExternalReportList(System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetExternalReportList", new object[0], callback, asyncState);
        }

        /// <remarks/>
        public string[] EndGetExternalReportList(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }

        /// <remarks/>
        public void GetExternalReportListAsync()
        {
            this.GetExternalReportListAsync(null);
        }

        /// <remarks/>
        public void GetExternalReportListAsync(object userState)
        {
            if ((this.GetExternalReportListOperationCompleted == null))
            {
                this.GetExternalReportListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetExternalReportListOperationCompleted);
            }
            this.InvokeAsync("GetExternalReportList", new object[0], this.GetExternalReportListOperationCompleted, userState);
        }

        private void OnGetExternalReportListOperationCompleted(object arg)
        {
            if ((this.GetExternalReportListCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetExternalReportListCompleted(this, new GetExternalReportListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/GetExternalReportSchema", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Schemas GetExternalReportSchema([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string name)
        {
            object[] results = this.Invoke("GetExternalReportSchema", new object[] {
                    name});
            return ((Schemas)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetExternalReportSchema(string name, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetExternalReportSchema", new object[] {
                    name}, callback, asyncState);
        }

        /// <remarks/>
        public Schemas EndGetExternalReportSchema(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((Schemas)(results[0]));
        }

        /// <remarks/>
        public void GetExternalReportSchemaAsync(string name)
        {
            this.GetExternalReportSchemaAsync(name, null);
        }

        /// <remarks/>
        public void GetExternalReportSchemaAsync(string name, object userState)
        {
            if ((this.GetExternalReportSchemaOperationCompleted == null))
            {
                this.GetExternalReportSchemaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetExternalReportSchemaOperationCompleted);
            }
            this.InvokeAsync("GetExternalReportSchema", new object[] {
                    name}, this.GetExternalReportSchemaOperationCompleted, userState);
        }

        private void OnGetExternalReportSchemaOperationCompleted(object arg)
        {
            if ((this.GetExternalReportSchemaCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetExternalReportSchemaCompleted(this, new GetExternalReportSchemaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/GetPdfReport", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary", IsNullable = true)]
        public byte[] GetPdfReport([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] PdfReportParameters parameters)
        {
            object[] results = this.Invoke("GetPdfReport", new object[] {
                    parameters});
            return ((byte[])(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetPdfReport(PdfReportParameters parameters, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetPdfReport", new object[] {
                    parameters}, callback, asyncState);
        }

        /// <remarks/>
        public byte[] EndGetPdfReport(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((byte[])(results[0]));
        }

        /// <remarks/>
        public void GetPdfReportAsync(PdfReportParameters parameters)
        {
            this.GetPdfReportAsync(parameters, null);
        }

        /// <remarks/>
        public void GetPdfReportAsync(PdfReportParameters parameters, object userState)
        {
            if ((this.GetPdfReportOperationCompleted == null))
            {
                this.GetPdfReportOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetPdfReportOperationCompleted);
            }
            this.InvokeAsync("GetPdfReport", new object[] {
                    parameters}, this.GetPdfReportOperationCompleted, userState);
        }

        private void OnGetPdfReportOperationCompleted(object arg)
        {
            if ((this.GetPdfReportCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetPdfReportCompleted(this, new GetPdfReportCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/GetSupportedLanguages", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace = "http://schemas.datacontract.org/2004/07/CI.CBS.Contracts.Public.Translation")]
        public LanguageDTO[] GetSupportedLanguages()
        {
            object[] results = this.Invoke("GetSupportedLanguages", new object[0]);
            return ((LanguageDTO[])(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetSupportedLanguages(System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetSupportedLanguages", new object[0], callback, asyncState);
        }

        /// <remarks/>
        public LanguageDTO[] EndGetSupportedLanguages(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((LanguageDTO[])(results[0]));
        }

        /// <remarks/>
        public void GetSupportedLanguagesAsync()
        {
            this.GetSupportedLanguagesAsync(null);
        }

        /// <remarks/>
        public void GetSupportedLanguagesAsync(object userState)
        {
            if ((this.GetSupportedLanguagesOperationCompleted == null))
            {
                this.GetSupportedLanguagesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSupportedLanguagesOperationCompleted);
            }
            this.InvokeAsync("GetSupportedLanguages", new object[0], this.GetSupportedLanguagesOperationCompleted, userState);
        }

        private void OnGetSupportedLanguagesOperationCompleted(object arg)
        {
            if ((this.GetSupportedLanguagesCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSupportedLanguagesCompleted(this, new GetSupportedLanguagesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/GetSupportedReports", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] GetSupportedReports()
        {
            object[] results = this.Invoke("GetSupportedReports", new object[0]);
            return ((string[])(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetSupportedReports(System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetSupportedReports", new object[0], callback, asyncState);
        }

        /// <remarks/>
        public string[] EndGetSupportedReports(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }

        /// <remarks/>
        public void GetSupportedReportsAsync()
        {
            this.GetSupportedReportsAsync(null);
        }

        /// <remarks/>
        public void GetSupportedReportsAsync(object userState)
        {
            if ((this.GetSupportedReportsOperationCompleted == null))
            {
                this.GetSupportedReportsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSupportedReportsOperationCompleted);
            }
            this.InvokeAsync("GetSupportedReports", new object[0], this.GetSupportedReportsOperationCompleted, userState);
        }

        private void OnGetSupportedReportsOperationCompleted(object arg)
        {
            if ((this.GetSupportedReportsCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSupportedReportsCompleted(this, new GetSupportedReportsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "BasicHttpBinding_IReportPublicService1", Namespace = "http://creditinfo.com/CB5")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DataContractKnownTypesBaseOfNilReportInternal0dcikneZ))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Record))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SearchResults))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SmartSearchQuery))]
    public partial class BasicHttpBinding_IReportPublicService1 : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback SearchIndividualOperationCompleted;

        private System.Threading.SendOrPostCallback SearchCompanyOperationCompleted;

        private System.Threading.SendOrPostCallback PublicSearchIndividualOperationCompleted;

        private System.Threading.SendOrPostCallback PublicSearchCompanyOperationCompleted;

        private System.Threading.SendOrPostCallback SmartSearchIndividualOperationCompleted;

        private System.Threading.SendOrPostCallback SmartSearchCompanyOperationCompleted;

        private System.Threading.SendOrPostCallback GetCustomReportSectionsOperationCompleted;

        private System.Threading.SendOrPostCallback GetCustomReportOperationCompleted;

        private System.Threading.SendOrPostCallback GetExternalReportOperationCompleted;

        private System.Threading.SendOrPostCallback GetExternalReportListOperationCompleted;

        private System.Threading.SendOrPostCallback GetExternalReportSchemaOperationCompleted;

        private System.Threading.SendOrPostCallback GetPdfReportOperationCompleted;

        private System.Threading.SendOrPostCallback GetSupportedLanguagesOperationCompleted;

        private System.Threading.SendOrPostCallback GetSupportedReportsOperationCompleted;

        /// <remarks/>
        public BasicHttpBinding_IReportPublicService1()
        {
            this.Url = "http://wstest.creditinfo.co.ke/WsReport/v5.21/service.svc";
        }

        /// <remarks/>
        public event SearchIndividualCompletedEventHandler SearchIndividualCompleted;

        /// <remarks/>
        public event SearchCompanyCompletedEventHandler SearchCompanyCompleted;

        /// <remarks/>
        public event PublicSearchIndividualCompletedEventHandler PublicSearchIndividualCompleted;

        /// <remarks/>
        public event PublicSearchCompanyCompletedEventHandler PublicSearchCompanyCompleted;

        /// <remarks/>
        public event SmartSearchIndividualCompletedEventHandler SmartSearchIndividualCompleted;

        /// <remarks/>
        public event SmartSearchCompanyCompletedEventHandler SmartSearchCompanyCompleted;

        /// <remarks/>
        public event GetCustomReportSectionsCompletedEventHandler GetCustomReportSectionsCompleted;

        /// <remarks/>
        public event GetCustomReportCompletedEventHandler GetCustomReportCompleted;

        /// <remarks/>
        public event GetExternalReportCompletedEventHandler GetExternalReportCompleted;

        /// <remarks/>
        public event GetExternalReportListCompletedEventHandler GetExternalReportListCompleted;

        /// <remarks/>
        public event GetExternalReportSchemaCompletedEventHandler GetExternalReportSchemaCompleted;

        /// <remarks/>
        public event GetPdfReportCompletedEventHandler GetPdfReportCompleted;

        /// <remarks/>
        public event GetSupportedLanguagesCompletedEventHandler GetSupportedLanguagesCompleted;

        /// <remarks/>
        public event GetSupportedReportsCompletedEventHandler GetSupportedReportsCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/SearchIndividual", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SearchIndividualResults SearchIndividual([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] SearchIndividualQuery query)
        {
            object[] results = this.Invoke("SearchIndividual", new object[] {
                    query});
            return ((SearchIndividualResults)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSearchIndividual(SearchIndividualQuery query, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("SearchIndividual", new object[] {
                    query}, callback, asyncState);
        }

        /// <remarks/>
        public SearchIndividualResults EndSearchIndividual(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((SearchIndividualResults)(results[0]));
        }

        /// <remarks/>
        public void SearchIndividualAsync(SearchIndividualQuery query)
        {
            this.SearchIndividualAsync(query, null);
        }

        /// <remarks/>
        public void SearchIndividualAsync(SearchIndividualQuery query, object userState)
        {
            if ((this.SearchIndividualOperationCompleted == null))
            {
                this.SearchIndividualOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSearchIndividualOperationCompleted);
            }
            this.InvokeAsync("SearchIndividual", new object[] {
                    query}, this.SearchIndividualOperationCompleted, userState);
        }

        private void OnSearchIndividualOperationCompleted(object arg)
        {
            if ((this.SearchIndividualCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SearchIndividualCompleted(this, new SearchIndividualCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/SearchCompany", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SearchCompanyResults SearchCompany([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] SearchCompanyQuery query)
        {
            object[] results = this.Invoke("SearchCompany", new object[] {
                    query});
            return ((SearchCompanyResults)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSearchCompany(SearchCompanyQuery query, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("SearchCompany", new object[] {
                    query}, callback, asyncState);
        }

        /// <remarks/>
        public SearchCompanyResults EndSearchCompany(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((SearchCompanyResults)(results[0]));
        }

        /// <remarks/>
        public void SearchCompanyAsync(SearchCompanyQuery query)
        {
            this.SearchCompanyAsync(query, null);
        }

        /// <remarks/>
        public void SearchCompanyAsync(SearchCompanyQuery query, object userState)
        {
            if ((this.SearchCompanyOperationCompleted == null))
            {
                this.SearchCompanyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSearchCompanyOperationCompleted);
            }
            this.InvokeAsync("SearchCompany", new object[] {
                    query}, this.SearchCompanyOperationCompleted, userState);
        }

        private void OnSearchCompanyOperationCompleted(object arg)
        {
            if ((this.SearchCompanyCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SearchCompanyCompleted(this, new SearchCompanyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/PublicSearchIndividual", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public PublicSearchIndividualResults PublicSearchIndividual([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] PublicSearchIndividualQuery query)
        {
            object[] results = this.Invoke("PublicSearchIndividual", new object[] {
                    query});
            return ((PublicSearchIndividualResults)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginPublicSearchIndividual(PublicSearchIndividualQuery query, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("PublicSearchIndividual", new object[] {
                    query}, callback, asyncState);
        }

        /// <remarks/>
        public PublicSearchIndividualResults EndPublicSearchIndividual(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((PublicSearchIndividualResults)(results[0]));
        }

        /// <remarks/>
        public void PublicSearchIndividualAsync(PublicSearchIndividualQuery query)
        {
            this.PublicSearchIndividualAsync(query, null);
        }

        /// <remarks/>
        public void PublicSearchIndividualAsync(PublicSearchIndividualQuery query, object userState)
        {
            if ((this.PublicSearchIndividualOperationCompleted == null))
            {
                this.PublicSearchIndividualOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPublicSearchIndividualOperationCompleted);
            }
            this.InvokeAsync("PublicSearchIndividual", new object[] {
                    query}, this.PublicSearchIndividualOperationCompleted, userState);
        }

        private void OnPublicSearchIndividualOperationCompleted(object arg)
        {
            if ((this.PublicSearchIndividualCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PublicSearchIndividualCompleted(this, new PublicSearchIndividualCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/PublicSearchCompany", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public PublicSearchCompanyResults PublicSearchCompany([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] PublicSearchCompanyQuery query)
        {
            object[] results = this.Invoke("PublicSearchCompany", new object[] {
                    query});
            return ((PublicSearchCompanyResults)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginPublicSearchCompany(PublicSearchCompanyQuery query, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("PublicSearchCompany", new object[] {
                    query}, callback, asyncState);
        }

        /// <remarks/>
        public PublicSearchCompanyResults EndPublicSearchCompany(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((PublicSearchCompanyResults)(results[0]));
        }

        /// <remarks/>
        public void PublicSearchCompanyAsync(PublicSearchCompanyQuery query)
        {
            this.PublicSearchCompanyAsync(query, null);
        }

        /// <remarks/>
        public void PublicSearchCompanyAsync(PublicSearchCompanyQuery query, object userState)
        {
            if ((this.PublicSearchCompanyOperationCompleted == null))
            {
                this.PublicSearchCompanyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPublicSearchCompanyOperationCompleted);
            }
            this.InvokeAsync("PublicSearchCompany", new object[] {
                    query}, this.PublicSearchCompanyOperationCompleted, userState);
        }

        private void OnPublicSearchCompanyOperationCompleted(object arg)
        {
            if ((this.PublicSearchCompanyCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PublicSearchCompanyCompleted(this, new PublicSearchCompanyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/SmartSearchIndividual", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SmartSearchIndividualResults SmartSearchIndividual([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] SmartSearchIndividualQuery query)
        {
            object[] results = this.Invoke("SmartSearchIndividual", new object[] {
                    query});
            return ((SmartSearchIndividualResults)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSmartSearchIndividual(SmartSearchIndividualQuery query, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("SmartSearchIndividual", new object[] {
                    query}, callback, asyncState);
        }

        /// <remarks/>
        public SmartSearchIndividualResults EndSmartSearchIndividual(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((SmartSearchIndividualResults)(results[0]));
        }

        /// <remarks/>
        public void SmartSearchIndividualAsync(SmartSearchIndividualQuery query)
        {
            this.SmartSearchIndividualAsync(query, null);
        }

        /// <remarks/>
        public void SmartSearchIndividualAsync(SmartSearchIndividualQuery query, object userState)
        {
            if ((this.SmartSearchIndividualOperationCompleted == null))
            {
                this.SmartSearchIndividualOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSmartSearchIndividualOperationCompleted);
            }
            this.InvokeAsync("SmartSearchIndividual", new object[] {
                    query}, this.SmartSearchIndividualOperationCompleted, userState);
        }

        private void OnSmartSearchIndividualOperationCompleted(object arg)
        {
            if ((this.SmartSearchIndividualCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SmartSearchIndividualCompleted(this, new SmartSearchIndividualCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/SmartSearchCompany", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SmartSearchCompanyResults SmartSearchCompany([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] SmartSearchCompanyQuery query)
        {
            object[] results = this.Invoke("SmartSearchCompany", new object[] {
                    query});
            return ((SmartSearchCompanyResults)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSmartSearchCompany(SmartSearchCompanyQuery query, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("SmartSearchCompany", new object[] {
                    query}, callback, asyncState);
        }

        /// <remarks/>
        public SmartSearchCompanyResults EndSmartSearchCompany(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((SmartSearchCompanyResults)(results[0]));
        }

        /// <remarks/>
        public void SmartSearchCompanyAsync(SmartSearchCompanyQuery query)
        {
            this.SmartSearchCompanyAsync(query, null);
        }

        /// <remarks/>
        public void SmartSearchCompanyAsync(SmartSearchCompanyQuery query, object userState)
        {
            if ((this.SmartSearchCompanyOperationCompleted == null))
            {
                this.SmartSearchCompanyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSmartSearchCompanyOperationCompleted);
            }
            this.InvokeAsync("SmartSearchCompany", new object[] {
                    query}, this.SmartSearchCompanyOperationCompleted, userState);
        }

        private void OnSmartSearchCompanyOperationCompleted(object arg)
        {
            if ((this.SmartSearchCompanyCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SmartSearchCompanyCompleted(this, new SmartSearchCompanyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/GetCustomReportSections", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] GetCustomReportSections()
        {
            object[] results = this.Invoke("GetCustomReportSections", new object[0]);
            return ((string[])(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetCustomReportSections(System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetCustomReportSections", new object[0], callback, asyncState);
        }

        /// <remarks/>
        public string[] EndGetCustomReportSections(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }

        /// <remarks/>
        public void GetCustomReportSectionsAsync()
        {
            this.GetCustomReportSectionsAsync(null);
        }

        /// <remarks/>
        public void GetCustomReportSectionsAsync(object userState)
        {
            if ((this.GetCustomReportSectionsOperationCompleted == null))
            {
                this.GetCustomReportSectionsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCustomReportSectionsOperationCompleted);
            }
            this.InvokeAsync("GetCustomReportSections", new object[0], this.GetCustomReportSectionsOperationCompleted, userState);
        }

        private void OnGetCustomReportSectionsOperationCompleted(object arg)
        {
            if ((this.GetCustomReportSectionsCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCustomReportSectionsCompleted(this, new GetCustomReportSectionsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/GetCustomReport", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public CustomReport GetCustomReport([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] CustomReportParams parameters)
        {
            object[] results = this.Invoke("GetCustomReport", new object[] {
                    parameters});
            return ((CustomReport)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetCustomReport(CustomReportParams parameters, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetCustomReport", new object[] {
                    parameters}, callback, asyncState);
        }

        /// <remarks/>
        public CustomReport EndGetCustomReport(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((CustomReport)(results[0]));
        }

        /// <remarks/>
        public void GetCustomReportAsync(CustomReportParams parameters)
        {
            this.GetCustomReportAsync(parameters, null);
        }

        /// <remarks/>
        public void GetCustomReportAsync(CustomReportParams parameters, object userState)
        {
            if ((this.GetCustomReportOperationCompleted == null))
            {
                this.GetCustomReportOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCustomReportOperationCompleted);
            }
            this.InvokeAsync("GetCustomReport", new object[] {
                    parameters}, this.GetCustomReportOperationCompleted, userState);
        }

        private void OnGetCustomReportOperationCompleted(object arg)
        {
            if ((this.GetCustomReportCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCustomReportCompleted(this, new GetCustomReportCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/GetExternalReport", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Xml.XmlElement GetExternalReport([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string name, [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] System.Xml.XmlElement request)
        {
            object[] results = this.Invoke("GetExternalReport", new object[] {
                    name,
                    request});
            return ((System.Xml.XmlElement)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetExternalReport(string name, System.Xml.XmlElement request, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetExternalReport", new object[] {
                    name,
                    request}, callback, asyncState);
        }

        /// <remarks/>
        public System.Xml.XmlElement EndGetExternalReport(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlElement)(results[0]));
        }

        /// <remarks/>
        public void GetExternalReportAsync(string name, System.Xml.XmlElement request)
        {
            this.GetExternalReportAsync(name, request, null);
        }

        /// <remarks/>
        public void GetExternalReportAsync(string name, System.Xml.XmlElement request, object userState)
        {
            if ((this.GetExternalReportOperationCompleted == null))
            {
                this.GetExternalReportOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetExternalReportOperationCompleted);
            }
            this.InvokeAsync("GetExternalReport", new object[] {
                    name,
                    request}, this.GetExternalReportOperationCompleted, userState);
        }

        private void OnGetExternalReportOperationCompleted(object arg)
        {
            if ((this.GetExternalReportCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetExternalReportCompleted(this, new GetExternalReportCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/GetExternalReportList", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] GetExternalReportList()
        {
            object[] results = this.Invoke("GetExternalReportList", new object[0]);
            return ((string[])(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetExternalReportList(System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetExternalReportList", new object[0], callback, asyncState);
        }

        /// <remarks/>
        public string[] EndGetExternalReportList(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }

        /// <remarks/>
        public void GetExternalReportListAsync()
        {
            this.GetExternalReportListAsync(null);
        }

        /// <remarks/>
        public void GetExternalReportListAsync(object userState)
        {
            if ((this.GetExternalReportListOperationCompleted == null))
            {
                this.GetExternalReportListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetExternalReportListOperationCompleted);
            }
            this.InvokeAsync("GetExternalReportList", new object[0], this.GetExternalReportListOperationCompleted, userState);
        }

        private void OnGetExternalReportListOperationCompleted(object arg)
        {
            if ((this.GetExternalReportListCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetExternalReportListCompleted(this, new GetExternalReportListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/GetExternalReportSchema", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Schemas GetExternalReportSchema([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string name)
        {
            object[] results = this.Invoke("GetExternalReportSchema", new object[] {
                    name});
            return ((Schemas)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetExternalReportSchema(string name, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetExternalReportSchema", new object[] {
                    name}, callback, asyncState);
        }

        /// <remarks/>
        public Schemas EndGetExternalReportSchema(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((Schemas)(results[0]));
        }

        /// <remarks/>
        public void GetExternalReportSchemaAsync(string name)
        {
            this.GetExternalReportSchemaAsync(name, null);
        }

        /// <remarks/>
        public void GetExternalReportSchemaAsync(string name, object userState)
        {
            if ((this.GetExternalReportSchemaOperationCompleted == null))
            {
                this.GetExternalReportSchemaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetExternalReportSchemaOperationCompleted);
            }
            this.InvokeAsync("GetExternalReportSchema", new object[] {
                    name}, this.GetExternalReportSchemaOperationCompleted, userState);
        }

        private void OnGetExternalReportSchemaOperationCompleted(object arg)
        {
            if ((this.GetExternalReportSchemaCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetExternalReportSchemaCompleted(this, new GetExternalReportSchemaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/GetPdfReport", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary", IsNullable = true)]
        public byte[] GetPdfReport([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] PdfReportParameters parameters)
        {
            object[] results = this.Invoke("GetPdfReport", new object[] {
                    parameters});
            return ((byte[])(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetPdfReport(PdfReportParameters parameters, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetPdfReport", new object[] {
                    parameters}, callback, asyncState);
        }

        /// <remarks/>
        public byte[] EndGetPdfReport(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((byte[])(results[0]));
        }

        /// <remarks/>
        public void GetPdfReportAsync(PdfReportParameters parameters)
        {
            this.GetPdfReportAsync(parameters, null);
        }

        /// <remarks/>
        public void GetPdfReportAsync(PdfReportParameters parameters, object userState)
        {
            if ((this.GetPdfReportOperationCompleted == null))
            {
                this.GetPdfReportOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetPdfReportOperationCompleted);
            }
            this.InvokeAsync("GetPdfReport", new object[] {
                    parameters}, this.GetPdfReportOperationCompleted, userState);
        }

        private void OnGetPdfReportOperationCompleted(object arg)
        {
            if ((this.GetPdfReportCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetPdfReportCompleted(this, new GetPdfReportCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/GetSupportedLanguages", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace = "http://schemas.datacontract.org/2004/07/CI.CBS.Contracts.Public.Translation")]
        public LanguageDTO[] GetSupportedLanguages()
        {
            object[] results = this.Invoke("GetSupportedLanguages", new object[0]);
            return ((LanguageDTO[])(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetSupportedLanguages(System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetSupportedLanguages", new object[0], callback, asyncState);
        }

        /// <remarks/>
        public LanguageDTO[] EndGetSupportedLanguages(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((LanguageDTO[])(results[0]));
        }

        /// <remarks/>
        public void GetSupportedLanguagesAsync()
        {
            this.GetSupportedLanguagesAsync(null);
        }

        /// <remarks/>
        public void GetSupportedLanguagesAsync(object userState)
        {
            if ((this.GetSupportedLanguagesOperationCompleted == null))
            {
                this.GetSupportedLanguagesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSupportedLanguagesOperationCompleted);
            }
            this.InvokeAsync("GetSupportedLanguages", new object[0], this.GetSupportedLanguagesOperationCompleted, userState);
        }

        private void OnGetSupportedLanguagesOperationCompleted(object arg)
        {
            if ((this.GetSupportedLanguagesCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSupportedLanguagesCompleted(this, new GetSupportedLanguagesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://creditinfo.com/CB5/IReportPublicServiceBase/GetSupportedReports", RequestNamespace = "http://creditinfo.com/CB5", ResponseNamespace = "http://creditinfo.com/CB5", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] GetSupportedReports()
        {
            object[] results = this.Invoke("GetSupportedReports", new object[0]);
            return ((string[])(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetSupportedReports(System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetSupportedReports", new object[0], callback, asyncState);
        }

        /// <remarks/>
        public string[] EndGetSupportedReports(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }

        /// <remarks/>
        public void GetSupportedReportsAsync()
        {
            this.GetSupportedReportsAsync(null);
        }

        /// <remarks/>
        public void GetSupportedReportsAsync(object userState)
        {
            if ((this.GetSupportedReportsOperationCompleted == null))
            {
                this.GetSupportedReportsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSupportedReportsOperationCompleted);
            }
            this.InvokeAsync("GetSupportedReports", new object[0], this.GetSupportedReportsOperationCompleted, userState);
        }

        private void OnGetSupportedReportsOperationCompleted(object arg)
        {
            if ((this.GetSupportedReportsCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSupportedReportsCompleted(this, new GetSupportedReportsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public partial class SearchIndividualQuery
    {

        private SearchIndividualParameters parametersField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SearchIndividualParameters Parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public partial class SearchIndividualParameters
    {

        private string idNumberField;

        private IDNumberTypeIndividual idNumberTypeField;

        private bool idNumberTypeFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string IdNumber
        {
            get
            {
                return this.idNumberField;
            }
            set
            {
                this.idNumberField = value;
            }
        }

        /// <remarks/>
        public IDNumberTypeIndividual IdNumberType
        {
            get
            {
                return this.idNumberTypeField;
            }
            set
            {
                this.idNumberTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdNumberTypeSpecified
        {
            get
            {
                return this.idNumberTypeFieldSpecified;
            }
            set
            {
                this.idNumberTypeFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public enum IDNumberTypeIndividual
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        PinNumber,

        /// <remarks/>
        NationalID,

        /// <remarks/>
        PassportNumber,

        /// <remarks/>
        AlienRegistration,

        /// <remarks/>
        ServiceId,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/CI.CBS.Contracts.Public.Translation")]
    public partial class LanguageDTO
    {

        private string languageCodeField;

        private int languageIdField;

        private bool languageIdFieldSpecified;

        private string languageNameField;

        private string localNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string LanguageCode
        {
            get
            {
                return this.languageCodeField;
            }
            set
            {
                this.languageCodeField = value;
            }
        }

        /// <remarks/>
        public int LanguageId
        {
            get
            {
                return this.languageIdField;
            }
            set
            {
                this.languageIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LanguageIdSpecified
        {
            get
            {
                return this.languageIdFieldSpecified;
            }
            set
            {
                this.languageIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string LanguageName
        {
            get
            {
                return this.languageNameField;
            }
            set
            {
                this.languageNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string LocalName
        {
            get
            {
                return this.localNameField;
            }
            set
            {
                this.localNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public partial class PdfReportParameters
    {

        private bool consentField;

        private bool consentFieldSpecified;

        private string iDNumberField;

        private IDNumberTypeResolvable iDNumberTypeField;

        private bool iDNumberTypeFieldSpecified;

        private InquiryReasons inquiryReasonField;

        private bool inquiryReasonFieldSpecified;

        private string inquiryReasonTextField;

        private string languageCodeField;

        private string reportNameField;

        private SubjectType subjectTypeField;

        private bool subjectTypeFieldSpecified;

        /// <remarks/>
        public bool Consent
        {
            get
            {
                return this.consentField;
            }
            set
            {
                this.consentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ConsentSpecified
        {
            get
            {
                return this.consentFieldSpecified;
            }
            set
            {
                this.consentFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string IDNumber
        {
            get
            {
                return this.iDNumberField;
            }
            set
            {
                this.iDNumberField = value;
            }
        }

        /// <remarks/>
        public IDNumberTypeResolvable IDNumberType
        {
            get
            {
                return this.iDNumberTypeField;
            }
            set
            {
                this.iDNumberTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IDNumberTypeSpecified
        {
            get
            {
                return this.iDNumberTypeFieldSpecified;
            }
            set
            {
                this.iDNumberTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public InquiryReasons InquiryReason
        {
            get
            {
                return this.inquiryReasonField;
            }
            set
            {
                this.inquiryReasonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InquiryReasonSpecified
        {
            get
            {
                return this.inquiryReasonFieldSpecified;
            }
            set
            {
                this.inquiryReasonFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string InquiryReasonText
        {
            get
            {
                return this.inquiryReasonTextField;
            }
            set
            {
                this.inquiryReasonTextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string LanguageCode
        {
            get
            {
                return this.languageCodeField;
            }
            set
            {
                this.languageCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ReportName
        {
            get
            {
                return this.reportNameField;
            }
            set
            {
                this.reportNameField = value;
            }
        }

        /// <remarks/>
        public SubjectType SubjectType
        {
            get
            {
                return this.subjectTypeField;
            }
            set
            {
                this.subjectTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubjectTypeSpecified
        {
            get
            {
                return this.subjectTypeFieldSpecified;
            }
            set
            {
                this.subjectTypeFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum IDNumberTypeResolvable
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        CreditinfoId,

        /// <remarks/>
        PinNumber,

        /// <remarks/>
        NationalID,

        /// <remarks/>
        RegistrationNumber,

        /// <remarks/>
        CustomerCode,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public enum InquiryReasons
    {

        /// <remarks/>
        ApplicationForCreditOrAmendmentOfCreditTerms,

        /// <remarks/>
        EvaluationOfCurrentCustomerSupplierPartnerOrOwnEmployee,

        /// <remarks/>
        EvaluationOfSubjectAsGuarantorOfACompanyApplyingForCredit,

        /// <remarks/>
        PaymentAgreement,

        /// <remarks/>
        CollectionOfPublicDues,

        /// <remarks/>
        InitialCollection,

        /// <remarks/>
        IntermediateCollection,

        /// <remarks/>
        LegalCollection,

        /// <remarks/>
        AnotherReason,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum SubjectType
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Individual,

        /// <remarks/>
        Company,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/ExternalReports")]
    public partial class Schemas
    {

        private string nameField;

        private System.Xml.XmlElement requestField;

        private System.Xml.XmlElement responseField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Xml.XmlElement Request
        {
            get
            {
                return this.requestField;
            }
            set
            {
                this.requestField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Xml.XmlElement Response
        {
            get
            {
                return this.responseField;
            }
            set
            {
                this.responseField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Identifications", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/SubjectInfoHistory")]
    public partial class Identifications4
    {

        private string itemField;

        private string subscriberField;

        private System.DateTime validFromField;

        private bool validFromFieldSpecified;

        private System.Nullable<System.DateTime> validToField;

        private bool validToFieldSpecified;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Subscriber
        {
            get
            {
                return this.subscriberField;
            }
            set
            {
                this.subscriberField = value;
            }
        }

        /// <remarks/>
        public System.DateTime ValidFrom
        {
            get
            {
                return this.validFromField;
            }
            set
            {
                this.validFromField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValidFromSpecified
        {
            get
            {
                return this.validFromFieldSpecified;
            }
            set
            {
                this.validFromFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> ValidTo
        {
            get
            {
                return this.validToField;
            }
            set
            {
                this.validToField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValidToSpecified
        {
            get
            {
                return this.validToFieldSpecified;
            }
            set
            {
                this.validToFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "General", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/SubjectInfoHistory")]
    public partial class General4
    {

        private string itemField;

        private string subscriberField;

        private System.DateTime validFromField;

        private bool validFromFieldSpecified;

        private System.Nullable<System.DateTime> validToField;

        private bool validToFieldSpecified;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Subscriber
        {
            get
            {
                return this.subscriberField;
            }
            set
            {
                this.subscriberField = value;
            }
        }

        /// <remarks/>
        public System.DateTime ValidFrom
        {
            get
            {
                return this.validFromField;
            }
            set
            {
                this.validFromField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValidFromSpecified
        {
            get
            {
                return this.validFromFieldSpecified;
            }
            set
            {
                this.validFromFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> ValidTo
        {
            get
            {
                return this.validToField;
            }
            set
            {
                this.validToField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValidToSpecified
        {
            get
            {
                return this.validToFieldSpecified;
            }
            set
            {
                this.validToFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Contact", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/SubjectInfoHistory")]
    public partial class Contact5
    {

        private string itemField;

        private string subscriberField;

        private System.DateTime validFromField;

        private bool validFromFieldSpecified;

        private System.Nullable<System.DateTime> validToField;

        private bool validToFieldSpecified;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Subscriber
        {
            get
            {
                return this.subscriberField;
            }
            set
            {
                this.subscriberField = value;
            }
        }

        /// <remarks/>
        public System.DateTime ValidFrom
        {
            get
            {
                return this.validFromField;
            }
            set
            {
                this.validFromField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValidFromSpecified
        {
            get
            {
                return this.validFromFieldSpecified;
            }
            set
            {
                this.validFromFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> ValidTo
        {
            get
            {
                return this.validToField;
            }
            set
            {
                this.validToField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValidToSpecified
        {
            get
            {
                return this.validToFieldSpecified;
            }
            set
            {
                this.validToFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/SubjectInfoHistory")]
    public partial class Address
    {

        private string itemField;

        private string subscriberField;

        private System.DateTime validFromField;

        private bool validFromFieldSpecified;

        private System.Nullable<System.DateTime> validToField;

        private bool validToFieldSpecified;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Subscriber
        {
            get
            {
                return this.subscriberField;
            }
            set
            {
                this.subscriberField = value;
            }
        }

        /// <remarks/>
        public System.DateTime ValidFrom
        {
            get
            {
                return this.validFromField;
            }
            set
            {
                this.validFromField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValidFromSpecified
        {
            get
            {
                return this.validFromFieldSpecified;
            }
            set
            {
                this.validFromFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> ValidTo
        {
            get
            {
                return this.validToField;
            }
            set
            {
                this.validToField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValidToSpecified
        {
            get
            {
                return this.validToFieldSpecified;
            }
            set
            {
                this.validToFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/SubjectInfoHistory")]
    public partial class SubjectInfoHistory
    {

        private Address[] addressListField;

        private Contact5[] contactListField;

        private General4[] generalListField;

        private Identifications4[] identificationsListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public Address[] AddressList
        {
            get
            {
                return this.addressListField;
            }
            set
            {
                this.addressListField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public Contact5[] ContactList
        {
            get
            {
                return this.contactListField;
            }
            set
            {
                this.contactListField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public General4[] GeneralList
        {
            get
            {
                return this.generalListField;
            }
            set
            {
                this.generalListField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public Identifications4[] IdentificationsList
        {
            get
            {
                return this.identificationsListField;
            }
            set
            {
                this.identificationsListField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/ReportInfo")]
    public partial class ReportInfo
    {

        private System.DateTime createdField;

        private bool createdFieldSpecified;

        private string referenceNumberField;

        private ReportResult reportStatusField;

        private bool reportStatusFieldSpecified;

        private string reportTokenField;

        private string reportVersionField;

        private string requestedByField;

        private string subscriberField;

        private BaseVersion versionField;

        private bool versionFieldSpecified;

        /// <remarks/>
        public System.DateTime Created
        {
            get
            {
                return this.createdField;
            }
            set
            {
                this.createdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreatedSpecified
        {
            get
            {
                return this.createdFieldSpecified;
            }
            set
            {
                this.createdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ReferenceNumber
        {
            get
            {
                return this.referenceNumberField;
            }
            set
            {
                this.referenceNumberField = value;
            }
        }

        /// <remarks/>
        public ReportResult ReportStatus
        {
            get
            {
                return this.reportStatusField;
            }
            set
            {
                this.reportStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReportStatusSpecified
        {
            get
            {
                return this.reportStatusFieldSpecified;
            }
            set
            {
                this.reportStatusFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ReportToken
        {
            get
            {
                return this.reportTokenField;
            }
            set
            {
                this.reportTokenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ReportVersion
        {
            get
            {
                return this.reportVersionField;
            }
            set
            {
                this.reportVersionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string RequestedBy
        {
            get
            {
                return this.requestedByField;
            }
            set
            {
                this.requestedByField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Subscriber
        {
            get
            {
                return this.subscriberField;
            }
            set
            {
                this.subscriberField = value;
            }
        }

        /// <remarks/>
        public BaseVersion Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VersionSpecified
        {
            get
            {
                return this.versionFieldSpecified;
            }
            set
            {
                this.versionFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/CI.CBS.Contracts.Public.Structures.Enums." +
        "Common")]
    public enum ReportResult
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        ReportGenerated,

        /// <remarks/>
        SubjectNotFound,

        /// <remarks/>
        IndividualMatchesConfirmDateOfBirth,

        /// <remarks/>
        ConsentRequired,

        /// <remarks/>
        InquiryReasonRequired,

        /// <remarks/>
        SubjectIdentificationInvalid,

        /// <remarks/>
        SubjectName3CharsRequired,

        /// <remarks/>
        InvalidDateOfBirth,

        /// <remarks/>
        IDNumberIsConnectedWithIndividual,

        /// <remarks/>
        IDNumberIsConnectedWithCompany,

        /// <remarks/>
        InQueue,

        /// <remarks/>
        Processing,

        /// <remarks/>
        Error,

        /// <remarks/>
        Rejected,

        /// <remarks/>
        Timeout,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum BaseVersion
    {

        /// <remarks/>
        v5s18,

        /// <remarks/>
        v5s19,

        /// <remarks/>
        v5s20,

        /// <remarks/>
        v5s21,

        /// <remarks/>
        v5s22,

        /// <remarks/>
        v5s23,

        /// <remarks/>
        v5s24,

        /// <remarks/>
        v5s25,

        /// <remarks/>
        v5s26,

        /// <remarks/>
        v5s27,

        /// <remarks/>
        v5s28,

        /// <remarks/>
        v5s30,

        /// <remarks/>
        v5s31,

        /// <remarks/>
        v5s32,

        /// <remarks/>
        v5s33,

        /// <remarks/>
        v5s35,

        /// <remarks/>
        v5s36,

        /// <remarks/>
        v5s37,

        /// <remarks/>
        v5s38,

        /// <remarks/>
        v5s39,

        /// <remarks/>
        v5s40,

        /// <remarks/>
        v5s41,

        /// <remarks/>
        v5s42,

        /// <remarks/>
        v5s43,

        /// <remarks/>
        v5s44,

        /// <remarks/>
        v5s45,

        /// <remarks/>
        v5s46,

        /// <remarks/>
        v5s47,

        /// <remarks/>
        v5s48,

        /// <remarks/>
        v5s49,

        /// <remarks/>
        v5s50,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/PolicyRulesCheck")]
    public partial class PolicyRule
    {

        private string codeField;

        private Decision decisionField;

        private bool decisionFieldSpecified;

        private string descriptionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public Decision Decision
        {
            get
            {
                return this.decisionField;
            }
            set
            {
                this.decisionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DecisionSpecified
        {
            get
            {
                return this.decisionFieldSpecified;
            }
            set
            {
                this.decisionFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/CI.CBS.Contracts.Public.Structures.Enums." +
        "Common")]
    public enum Decision
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Accept,

        /// <remarks/>
        Refer,

        /// <remarks/>
        Decline,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/PolicyRulesCheck")]
    public partial class PolicyRulesCheck
    {

        private Decision decisionField;

        private bool decisionFieldSpecified;

        private PolicyRule[] policyRuleListField;

        /// <remarks/>
        public Decision Decision
        {
            get
            {
                return this.decisionField;
            }
            set
            {
                this.decisionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DecisionSpecified
        {
            get
            {
                return this.decisionFieldSpecified;
            }
            set
            {
                this.decisionFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public PolicyRule[] PolicyRuleList
        {
            get
            {
                return this.policyRuleListField;
            }
            set
            {
                this.policyRuleListField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Contract", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/NegativeContractList")]
    public partial class Contract2
    {

        private TypeOfContract1 accountProductTypeField;

        private bool accountProductTypeFieldSpecified;

        private ContractStatus accountStatusField;

        private bool accountStatusFieldSpecified;

        private Amount1 currentBalanceField;

        private System.Nullable<System.DateTime> dateAccountOpenedField;

        private bool dateAccountOpenedFieldSpecified;

        private int daysInArrearsField;

        private bool daysInArrearsFieldSpecified;

        private Amount1 originalAmountField;

        private Amount1 overdueBalanceField;

        private PhaseOfContract phaseOfContractField;

        private bool phaseOfContractFieldSpecified;

        private RoleOfCustomer roleOfClientField;

        private bool roleOfClientFieldSpecified;

        private Sector1 sectorField;

        private bool sectorFieldSpecified;

        /// <remarks/>
        public TypeOfContract1 AccountProductType
        {
            get
            {
                return this.accountProductTypeField;
            }
            set
            {
                this.accountProductTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AccountProductTypeSpecified
        {
            get
            {
                return this.accountProductTypeFieldSpecified;
            }
            set
            {
                this.accountProductTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public ContractStatus AccountStatus
        {
            get
            {
                return this.accountStatusField;
            }
            set
            {
                this.accountStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AccountStatusSpecified
        {
            get
            {
                return this.accountStatusFieldSpecified;
            }
            set
            {
                this.accountStatusFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 CurrentBalance
        {
            get
            {
                return this.currentBalanceField;
            }
            set
            {
                this.currentBalanceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DateAccountOpened
        {
            get
            {
                return this.dateAccountOpenedField;
            }
            set
            {
                this.dateAccountOpenedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateAccountOpenedSpecified
        {
            get
            {
                return this.dateAccountOpenedFieldSpecified;
            }
            set
            {
                this.dateAccountOpenedFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int DaysInArrears
        {
            get
            {
                return this.daysInArrearsField;
            }
            set
            {
                this.daysInArrearsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DaysInArrearsSpecified
        {
            get
            {
                return this.daysInArrearsFieldSpecified;
            }
            set
            {
                this.daysInArrearsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 OriginalAmount
        {
            get
            {
                return this.originalAmountField;
            }
            set
            {
                this.originalAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 OverdueBalance
        {
            get
            {
                return this.overdueBalanceField;
            }
            set
            {
                this.overdueBalanceField = value;
            }
        }

        /// <remarks/>
        public PhaseOfContract PhaseOfContract
        {
            get
            {
                return this.phaseOfContractField;
            }
            set
            {
                this.phaseOfContractField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PhaseOfContractSpecified
        {
            get
            {
                return this.phaseOfContractFieldSpecified;
            }
            set
            {
                this.phaseOfContractFieldSpecified = value;
            }
        }

        /// <remarks/>
        public RoleOfCustomer RoleOfClient
        {
            get
            {
                return this.roleOfClientField;
            }
            set
            {
                this.roleOfClientField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RoleOfClientSpecified
        {
            get
            {
                return this.roleOfClientFieldSpecified;
            }
            set
            {
                this.roleOfClientFieldSpecified = value;
            }
        }

        /// <remarks/>
        public Sector1 Sector
        {
            get
            {
                return this.sectorField;
            }
            set
            {
                this.sectorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SectorSpecified
        {
            get
            {
                return this.sectorFieldSpecified;
            }
            set
            {
                this.sectorFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "TypeOfContract", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum TypeOfContract1
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        CreditCard,

        /// <remarks/>
        Other,

        /// <remarks/>
        Overdraft,

        /// <remarks/>
        BusinessWorkingCapitalLoans,

        /// <remarks/>
        BusinessExpansionLoans,

        /// <remarks/>
        MortgageLoans,

        /// <remarks/>
        AssetFinanceLoans,

        /// <remarks/>
        TradeFinanceFacilities,

        /// <remarks/>
        PersonalLoans,

        /// <remarks/>
        MobileBankingLoan,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum ContractStatus
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        GrantedButNotActivated,

        /// <remarks/>
        GrantedAndActivated,

        /// <remarks/>
        Rescheduled,

        /// <remarks/>
        SettledOnTime,

        /// <remarks/>
        SettledInAdvance,

        /// <remarks/>
        WithArrearsNoRepossession,

        /// <remarks/>
        WithArrearsAndRepossession,

        /// <remarks/>
        Cancelled,

        /// <remarks/>
        SoldToThirdParty,

        /// <remarks/>
        WrittenOff,

        /// <remarks/>
        Prolonged,

        /// <remarks/>
        SettledLate,

        /// <remarks/>
        Disconnected,

        /// <remarks/>
        Closed,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Amount", Namespace = "http://creditinfo.com/CB5/Common")]
    public partial class Amount1
    {

        private Currency currencyField;

        private bool currencyFieldSpecified;

        private decimal localValueField;

        private bool localValueFieldSpecified;

        private decimal valueField;

        private bool valueFieldSpecified;

        /// <remarks/>
        public Currency Currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CurrencySpecified
        {
            get
            {
                return this.currencyFieldSpecified;
            }
            set
            {
                this.currencyFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal LocalValue
        {
            get
            {
                return this.localValueField;
            }
            set
            {
                this.localValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LocalValueSpecified
        {
            get
            {
                return this.localValueFieldSpecified;
            }
            set
            {
                this.localValueFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValueSpecified
        {
            get
            {
                return this.valueFieldSpecified;
            }
            set
            {
                this.valueFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/CI.CBS.Contracts.Public.Structures.Enums." +
        "Common")]
    public enum Currency
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        AED,

        /// <remarks/>
        AFN,

        /// <remarks/>
        ALL,

        /// <remarks/>
        AMD,

        /// <remarks/>
        ANG,

        /// <remarks/>
        AOA,

        /// <remarks/>
        ARS,

        /// <remarks/>
        AUD,

        /// <remarks/>
        AWG,

        /// <remarks/>
        AZN,

        /// <remarks/>
        BAM,

        /// <remarks/>
        BBD,

        /// <remarks/>
        BDT,

        /// <remarks/>
        BGN,

        /// <remarks/>
        BHD,

        /// <remarks/>
        BIF,

        /// <remarks/>
        BMD,

        /// <remarks/>
        BND,

        /// <remarks/>
        BOB,

        /// <remarks/>
        BOV,

        /// <remarks/>
        BRL,

        /// <remarks/>
        BSD,

        /// <remarks/>
        BTN,

        /// <remarks/>
        BWP,

        /// <remarks/>
        BYR,

        /// <remarks/>
        BZD,

        /// <remarks/>
        CAD,

        /// <remarks/>
        CDF,

        /// <remarks/>
        CHE,

        /// <remarks/>
        CHF,

        /// <remarks/>
        CHW,

        /// <remarks/>
        CLF,

        /// <remarks/>
        CLP,

        /// <remarks/>
        CNY,

        /// <remarks/>
        COP,

        /// <remarks/>
        COU,

        /// <remarks/>
        CRC,

        /// <remarks/>
        CUC,

        /// <remarks/>
        CUP,

        /// <remarks/>
        CVE,

        /// <remarks/>
        CZK,

        /// <remarks/>
        DJF,

        /// <remarks/>
        DKK,

        /// <remarks/>
        DOP,

        /// <remarks/>
        DZD,

        /// <remarks/>
        EEK,

        /// <remarks/>
        EGP,

        /// <remarks/>
        ERN,

        /// <remarks/>
        ETB,

        /// <remarks/>
        EUR,

        /// <remarks/>
        FJD,

        /// <remarks/>
        FKP,

        /// <remarks/>
        GBP,

        /// <remarks/>
        GEL,

        /// <remarks/>
        GHS,

        /// <remarks/>
        GIP,

        /// <remarks/>
        GMD,

        /// <remarks/>
        GNF,

        /// <remarks/>
        GTQ,

        /// <remarks/>
        GYD,

        /// <remarks/>
        HKD,

        /// <remarks/>
        HNL,

        /// <remarks/>
        HRK,

        /// <remarks/>
        HTG,

        /// <remarks/>
        HUF,

        /// <remarks/>
        IDR,

        /// <remarks/>
        ILS,

        /// <remarks/>
        INR,

        /// <remarks/>
        IQD,

        /// <remarks/>
        IRR,

        /// <remarks/>
        ISK,

        /// <remarks/>
        JMD,

        /// <remarks/>
        JOD,

        /// <remarks/>
        JPY,

        /// <remarks/>
        KES,

        /// <remarks/>
        KGS,

        /// <remarks/>
        KHR,

        /// <remarks/>
        KMF,

        /// <remarks/>
        KPW,

        /// <remarks/>
        KRW,

        /// <remarks/>
        KWD,

        /// <remarks/>
        KYD,

        /// <remarks/>
        KZT,

        /// <remarks/>
        LAK,

        /// <remarks/>
        LBP,

        /// <remarks/>
        LKR,

        /// <remarks/>
        LRD,

        /// <remarks/>
        LSL,

        /// <remarks/>
        LTL,

        /// <remarks/>
        LVL,

        /// <remarks/>
        LYD,

        /// <remarks/>
        MAD,

        /// <remarks/>
        MDL,

        /// <remarks/>
        MGA,

        /// <remarks/>
        MKD,

        /// <remarks/>
        MMK,

        /// <remarks/>
        MNT,

        /// <remarks/>
        MOP,

        /// <remarks/>
        MRO,

        /// <remarks/>
        MUR,

        /// <remarks/>
        MVR,

        /// <remarks/>
        MWK,

        /// <remarks/>
        MXN,

        /// <remarks/>
        MXV,

        /// <remarks/>
        MYR,

        /// <remarks/>
        MZN,

        /// <remarks/>
        NAD,

        /// <remarks/>
        NGN,

        /// <remarks/>
        NIO,

        /// <remarks/>
        NOK,

        /// <remarks/>
        NPR,

        /// <remarks/>
        NZD,

        /// <remarks/>
        OMR,

        /// <remarks/>
        PAB,

        /// <remarks/>
        PEN,

        /// <remarks/>
        PGK,

        /// <remarks/>
        PHP,

        /// <remarks/>
        PKR,

        /// <remarks/>
        PLN,

        /// <remarks/>
        PYG,

        /// <remarks/>
        QAR,

        /// <remarks/>
        RON,

        /// <remarks/>
        RSD,

        /// <remarks/>
        RUB,

        /// <remarks/>
        RWF,

        /// <remarks/>
        SAR,

        /// <remarks/>
        SBD,

        /// <remarks/>
        SCR,

        /// <remarks/>
        SDG,

        /// <remarks/>
        SEK,

        /// <remarks/>
        SGD,

        /// <remarks/>
        SHP,

        /// <remarks/>
        SLL,

        /// <remarks/>
        SOS,

        /// <remarks/>
        SRD,

        /// <remarks/>
        STD,

        /// <remarks/>
        SYP,

        /// <remarks/>
        SZL,

        /// <remarks/>
        THB,

        /// <remarks/>
        TJS,

        /// <remarks/>
        TMT,

        /// <remarks/>
        TND,

        /// <remarks/>
        TOP,

        /// <remarks/>
        TRY,

        /// <remarks/>
        TTD,

        /// <remarks/>
        TWD,

        /// <remarks/>
        TZS,

        /// <remarks/>
        UAH,

        /// <remarks/>
        UGX,

        /// <remarks/>
        USD,

        /// <remarks/>
        USN,

        /// <remarks/>
        USS,

        /// <remarks/>
        UYU,

        /// <remarks/>
        UZS,

        /// <remarks/>
        VEF,

        /// <remarks/>
        VND,

        /// <remarks/>
        VUV,

        /// <remarks/>
        WST,

        /// <remarks/>
        XAF,

        /// <remarks/>
        XAG,

        /// <remarks/>
        XAU,

        /// <remarks/>
        XBA,

        /// <remarks/>
        XBB,

        /// <remarks/>
        XBC,

        /// <remarks/>
        XBD,

        /// <remarks/>
        XCD,

        /// <remarks/>
        XDR,

        /// <remarks/>
        XFU,

        /// <remarks/>
        XOF,

        /// <remarks/>
        XPD,

        /// <remarks/>
        XPF,

        /// <remarks/>
        XPT,

        /// <remarks/>
        XTS,

        /// <remarks/>
        XXX,

        /// <remarks/>
        YER,

        /// <remarks/>
        ZAR,

        /// <remarks/>
        ZMK,

        /// <remarks/>
        ZWD,

        /// <remarks/>
        SSP,

        /// <remarks/>
        ADP,

        /// <remarks/>
        ATS,

        /// <remarks/>
        BEF,

        /// <remarks/>
        BEN,

        /// <remarks/>
        CDZ,

        /// <remarks/>
        CYP,

        /// <remarks/>
        DEM,

        /// <remarks/>
        ECS,

        /// <remarks/>
        ESB,

        /// <remarks/>
        ESP,

        /// <remarks/>
        ESS,

        /// <remarks/>
        FIM,

        /// <remarks/>
        FRF,

        /// <remarks/>
        GEK,

        /// <remarks/>
        GNS,

        /// <remarks/>
        GQE,

        /// <remarks/>
        GRD,

        /// <remarks/>
        GWP,

        /// <remarks/>
        HRD,

        /// <remarks/>
        IEP,

        /// <remarks/>
        ISS,

        /// <remarks/>
        ITL,

        /// <remarks/>
        KTS,

        /// <remarks/>
        KYS,

        /// <remarks/>
        LSM,

        /// <remarks/>
        LTT,

        /// <remarks/>
        LUF,

        /// <remarks/>
        LVR,

        /// <remarks/>
        MGF,

        /// <remarks/>
        MLF,

        /// <remarks/>
        MTL,

        /// <remarks/>
        MVS,

        /// <remarks/>
        N11,

        /// <remarks/>
        NIC,

        /// <remarks/>
        NLG,

        /// <remarks/>
        PEI,

        /// <remarks/>
        PLZ,

        /// <remarks/>
        PSS,

        /// <remarks/>
        PTE,

        /// <remarks/>
        SDD,

        /// <remarks/>
        SIT,

        /// <remarks/>
        SKK,

        /// <remarks/>
        SRG,

        /// <remarks/>
        SUR,

        /// <remarks/>
        SVC,

        /// <remarks/>
        TJR,

        /// <remarks/>
        UAK,

        /// <remarks/>
        UGS,

        /// <remarks/>
        USP,

        /// <remarks/>
        UYP,

        /// <remarks/>
        YUD,

        /// <remarks/>
        YUN,

        /// <remarks/>
        ZAL,

        /// <remarks/>
        XEU,

        /// <remarks/>
        MRU,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/CI.CBS.Contracts.Public.Structures.Enums." +
        "Contract")]
    public enum PhaseOfContract
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Open,

        /// <remarks/>
        Closed,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum RoleOfCustomer
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        MainDebtor,

        /// <remarks/>
        CoDebtor,

        /// <remarks/>
        Guarantor,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Sector", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum Sector1
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        MyCreditBureau,

        /// <remarks/>
        Banks,

        /// <remarks/>
        MFIDonor,

        /// <remarks/>
        MFIOther,

        /// <remarks/>
        Leasing,

        /// <remarks/>
        Building,

        /// <remarks/>
        CreditUnions,

        /// <remarks/>
        HirePurchaseCompanies,

        /// <remarks/>
        Insurance,

        /// <remarks/>
        Telecom,

        /// <remarks/>
        Utilities,

        /// <remarks/>
        OtherCB,

        /// <remarks/>
        NationalBank,

        /// <remarks/>
        Others,

        /// <remarks/>
        Pawnshop,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/NegativeContractList")]
    public partial class NegativeContractList
    {

        private Contract2[] contractListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public Contract2[] ContractList
        {
            get
            {
                return this.contractListField;
            }
            set
            {
                this.contractListField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Summary", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Inquiries")]
    public partial class Summary2
    {

        private int numberOfInquiriesLast12MonthsField;

        private bool numberOfInquiriesLast12MonthsFieldSpecified;

        private int numberOfInquiriesLast1MonthField;

        private bool numberOfInquiriesLast1MonthFieldSpecified;

        private int numberOfInquiriesLast24MonthsField;

        private bool numberOfInquiriesLast24MonthsFieldSpecified;

        private int numberOfInquiriesLast3MonthsField;

        private bool numberOfInquiriesLast3MonthsFieldSpecified;

        private int numberOfInquiriesLast6MonthsField;

        private bool numberOfInquiriesLast6MonthsFieldSpecified;

        /// <remarks/>
        public int NumberOfInquiriesLast12Months
        {
            get
            {
                return this.numberOfInquiriesLast12MonthsField;
            }
            set
            {
                this.numberOfInquiriesLast12MonthsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfInquiriesLast12MonthsSpecified
        {
            get
            {
                return this.numberOfInquiriesLast12MonthsFieldSpecified;
            }
            set
            {
                this.numberOfInquiriesLast12MonthsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfInquiriesLast1Month
        {
            get
            {
                return this.numberOfInquiriesLast1MonthField;
            }
            set
            {
                this.numberOfInquiriesLast1MonthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfInquiriesLast1MonthSpecified
        {
            get
            {
                return this.numberOfInquiriesLast1MonthFieldSpecified;
            }
            set
            {
                this.numberOfInquiriesLast1MonthFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfInquiriesLast24Months
        {
            get
            {
                return this.numberOfInquiriesLast24MonthsField;
            }
            set
            {
                this.numberOfInquiriesLast24MonthsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfInquiriesLast24MonthsSpecified
        {
            get
            {
                return this.numberOfInquiriesLast24MonthsFieldSpecified;
            }
            set
            {
                this.numberOfInquiriesLast24MonthsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfInquiriesLast3Months
        {
            get
            {
                return this.numberOfInquiriesLast3MonthsField;
            }
            set
            {
                this.numberOfInquiriesLast3MonthsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfInquiriesLast3MonthsSpecified
        {
            get
            {
                return this.numberOfInquiriesLast3MonthsFieldSpecified;
            }
            set
            {
                this.numberOfInquiriesLast3MonthsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfInquiriesLast6Months
        {
            get
            {
                return this.numberOfInquiriesLast6MonthsField;
            }
            set
            {
                this.numberOfInquiriesLast6MonthsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfInquiriesLast6MonthsSpecified
        {
            get
            {
                return this.numberOfInquiriesLast6MonthsFieldSpecified;
            }
            set
            {
                this.numberOfInquiriesLast6MonthsFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Inquiries")]
    public partial class Inquiry
    {

        private System.DateTime dateOfInquiryField;

        private bool dateOfInquiryFieldSpecified;

        private string productField;

        private InquiryReasonsNotSpecified reasonField;

        private bool reasonFieldSpecified;

        private Sector1 sectorField;

        private bool sectorFieldSpecified;

        private string subscriberField;

        /// <remarks/>
        public System.DateTime DateOfInquiry
        {
            get
            {
                return this.dateOfInquiryField;
            }
            set
            {
                this.dateOfInquiryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOfInquirySpecified
        {
            get
            {
                return this.dateOfInquiryFieldSpecified;
            }
            set
            {
                this.dateOfInquiryFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Product
        {
            get
            {
                return this.productField;
            }
            set
            {
                this.productField = value;
            }
        }

        /// <remarks/>
        public InquiryReasonsNotSpecified Reason
        {
            get
            {
                return this.reasonField;
            }
            set
            {
                this.reasonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReasonSpecified
        {
            get
            {
                return this.reasonFieldSpecified;
            }
            set
            {
                this.reasonFieldSpecified = value;
            }
        }

        /// <remarks/>
        public Sector1 Sector
        {
            get
            {
                return this.sectorField;
            }
            set
            {
                this.sectorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SectorSpecified
        {
            get
            {
                return this.sectorFieldSpecified;
            }
            set
            {
                this.sectorFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Subscriber
        {
            get
            {
                return this.subscriberField;
            }
            set
            {
                this.subscriberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public enum InquiryReasonsNotSpecified
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        ApplicationForCreditOrAmendmentOfCreditTerms,

        /// <remarks/>
        EvaluationOfCurrentCustomerSupplierPartnerOrOwnEmployee,

        /// <remarks/>
        EvaluationOfSubjectAsGuarantorOfACompanyApplyingForCredit,

        /// <remarks/>
        PaymentAgreement,

        /// <remarks/>
        CollectionOfPublicDues,

        /// <remarks/>
        InitialCollection,

        /// <remarks/>
        IntermediateCollection,

        /// <remarks/>
        LegalCollection,

        /// <remarks/>
        AnotherReason,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Inquiries", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Inquiries")]
    public partial class Inquiries1
    {

        private Inquiry[] inquiryListField;

        private Summary2 summaryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public Inquiry[] InquiryList
        {
            get
            {
                return this.inquiryListField;
            }
            set
            {
                this.inquiryListField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Summary2 Summary
        {
            get
            {
                return this.summaryField;
            }
            set
            {
                this.summaryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Identifications", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/IndividualSimple")]
    public partial class Identifications3
    {

        private string alienRegistrationField;

        private string nationalIDField;

        private string passportNumberField;

        private string pinNumberField;

        private string serviceIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AlienRegistration
        {
            get
            {
                return this.alienRegistrationField;
            }
            set
            {
                this.alienRegistrationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string NationalID
        {
            get
            {
                return this.nationalIDField;
            }
            set
            {
                this.nationalIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PassportNumber
        {
            get
            {
                return this.passportNumberField;
            }
            set
            {
                this.passportNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PinNumber
        {
            get
            {
                return this.pinNumberField;
            }
            set
            {
                this.pinNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ServiceId
        {
            get
            {
                return this.serviceIdField;
            }
            set
            {
                this.serviceIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "General", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/IndividualSimple")]
    public partial class General3
    {

        private ClassificationOfIndividual1 classificationOfIndividualField;

        private bool classificationOfIndividualFieldSpecified;

        private System.Nullable<System.DateTime> dateOfBirthField;

        private bool dateOfBirthFieldSpecified;

        private string forename1Field;

        private string forename2Field;

        private string fullNameField;

        private Gender genderField;

        private bool genderFieldSpecified;

        private string presentSurnameField;

        /// <remarks/>
        public ClassificationOfIndividual1 ClassificationOfIndividual
        {
            get
            {
                return this.classificationOfIndividualField;
            }
            set
            {
                this.classificationOfIndividualField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ClassificationOfIndividualSpecified
        {
            get
            {
                return this.classificationOfIndividualFieldSpecified;
            }
            set
            {
                this.classificationOfIndividualFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                return this.dateOfBirthField;
            }
            set
            {
                this.dateOfBirthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOfBirthSpecified
        {
            get
            {
                return this.dateOfBirthFieldSpecified;
            }
            set
            {
                this.dateOfBirthFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Forename1
        {
            get
            {
                return this.forename1Field;
            }
            set
            {
                this.forename1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Forename2
        {
            get
            {
                return this.forename2Field;
            }
            set
            {
                this.forename2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FullName
        {
            get
            {
                return this.fullNameField;
            }
            set
            {
                this.fullNameField = value;
            }
        }

        /// <remarks/>
        public Gender Gender
        {
            get
            {
                return this.genderField;
            }
            set
            {
                this.genderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GenderSpecified
        {
            get
            {
                return this.genderFieldSpecified;
            }
            set
            {
                this.genderFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PresentSurname
        {
            get
            {
                return this.presentSurnameField;
            }
            set
            {
                this.presentSurnameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "ClassificationOfIndividual", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum ClassificationOfIndividual1
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Individual,

        /// <remarks/>
        SoleTrader,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum Gender
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Male,

        /// <remarks/>
        Female,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/IndividualSimple")]
    public partial class IndividualSimple
    {

        private General3 generalField;

        private Identifications3 identificationsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public General3 General
        {
            get
            {
                return this.generalField;
            }
            set
            {
                this.generalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Identifications3 Identifications
        {
            get
            {
                return this.identificationsField;
            }
            set
            {
                this.identificationsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "SecondaryAddress", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Individual")]
    public partial class SecondaryAddress1
    {

        private string addressLineField;

        private CountryCode countryField;

        private bool countryFieldSpecified;

        private string districtField;

        private string plotNumberField;

        private string postalCodeField;

        private string regionField;

        private string streetField;

        private string townField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AddressLine
        {
            get
            {
                return this.addressLineField;
            }
            set
            {
                this.addressLineField = value;
            }
        }

        /// <remarks/>
        public CountryCode Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountrySpecified
        {
            get
            {
                return this.countryFieldSpecified;
            }
            set
            {
                this.countryFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string District
        {
            get
            {
                return this.districtField;
            }
            set
            {
                this.districtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PlotNumber
        {
            get
            {
                return this.plotNumberField;
            }
            set
            {
                this.plotNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Region
        {
            get
            {
                return this.regionField;
            }
            set
            {
                this.regionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Street
        {
            get
            {
                return this.streetField;
            }
            set
            {
                this.streetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Town
        {
            get
            {
                return this.townField;
            }
            set
            {
                this.townField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/CI.CBS.Contracts.Public.Structures.Enums." +
        "Common")]
    public enum CountryCode
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        AD,

        /// <remarks/>
        AE,

        /// <remarks/>
        AF,

        /// <remarks/>
        AG,

        /// <remarks/>
        AI,

        /// <remarks/>
        AL,

        /// <remarks/>
        AM,

        /// <remarks/>
        AN,

        /// <remarks/>
        AO,

        /// <remarks/>
        AQ,

        /// <remarks/>
        AR,

        /// <remarks/>
        AS,

        /// <remarks/>
        AT,

        /// <remarks/>
        AU,

        /// <remarks/>
        AW,

        /// <remarks/>
        AZ,

        /// <remarks/>
        BA,

        /// <remarks/>
        BB,

        /// <remarks/>
        BD,

        /// <remarks/>
        BE,

        /// <remarks/>
        BF,

        /// <remarks/>
        BG,

        /// <remarks/>
        BH,

        /// <remarks/>
        BI,

        /// <remarks/>
        BJ,

        /// <remarks/>
        BM,

        /// <remarks/>
        BN,

        /// <remarks/>
        BO,

        /// <remarks/>
        BR,

        /// <remarks/>
        BS,

        /// <remarks/>
        BT,

        /// <remarks/>
        BV,

        /// <remarks/>
        BW,

        /// <remarks/>
        BY,

        /// <remarks/>
        BZ,

        /// <remarks/>
        CA,

        /// <remarks/>
        CC,

        /// <remarks/>
        CD,

        /// <remarks/>
        CF,

        /// <remarks/>
        CG,

        /// <remarks/>
        CI,

        /// <remarks/>
        CK,

        /// <remarks/>
        CL,

        /// <remarks/>
        CM,

        /// <remarks/>
        CN,

        /// <remarks/>
        CO,

        /// <remarks/>
        CR,

        /// <remarks/>
        CU,

        /// <remarks/>
        CV,

        /// <remarks/>
        CX,

        /// <remarks/>
        CY,

        /// <remarks/>
        CZ,

        /// <remarks/>
        DE,

        /// <remarks/>
        DJ,

        /// <remarks/>
        DK,

        /// <remarks/>
        DM,

        /// <remarks/>
        DO,

        /// <remarks/>
        DZ,

        /// <remarks/>
        EC,

        /// <remarks/>
        EE,

        /// <remarks/>
        EG,

        /// <remarks/>
        EH,

        /// <remarks/>
        ER,

        /// <remarks/>
        ES,

        /// <remarks/>
        ET,

        /// <remarks/>
        FI,

        /// <remarks/>
        FJ,

        /// <remarks/>
        FK,

        /// <remarks/>
        FM,

        /// <remarks/>
        FO,

        /// <remarks/>
        FR,

        /// <remarks/>
        GA,

        /// <remarks/>
        GB,

        /// <remarks/>
        GD,

        /// <remarks/>
        GE,

        /// <remarks/>
        GF,

        /// <remarks/>
        GH,

        /// <remarks/>
        GI,

        /// <remarks/>
        GL,

        /// <remarks/>
        GM,

        /// <remarks/>
        GN,

        /// <remarks/>
        GP,

        /// <remarks/>
        GQ,

        /// <remarks/>
        GR,

        /// <remarks/>
        GS,

        /// <remarks/>
        GT,

        /// <remarks/>
        GU,

        /// <remarks/>
        GW,

        /// <remarks/>
        GY,

        /// <remarks/>
        HK,

        /// <remarks/>
        HM,

        /// <remarks/>
        HN,

        /// <remarks/>
        HR,

        /// <remarks/>
        HT,

        /// <remarks/>
        HU,

        /// <remarks/>
        CH,

        /// <remarks/>
        ID,

        /// <remarks/>
        IE,

        /// <remarks/>
        IL,

        /// <remarks/>
        IN,

        /// <remarks/>
        IO,

        /// <remarks/>
        IQ,

        /// <remarks/>
        IR,

        /// <remarks/>
        IS,

        /// <remarks/>
        IT,

        /// <remarks/>
        JM,

        /// <remarks/>
        JO,

        /// <remarks/>
        JP,

        /// <remarks/>
        KE,

        /// <remarks/>
        KG,

        /// <remarks/>
        KH,

        /// <remarks/>
        KI,

        /// <remarks/>
        KM,

        /// <remarks/>
        KN,

        /// <remarks/>
        KP,

        /// <remarks/>
        KR,

        /// <remarks/>
        KW,

        /// <remarks/>
        KY,

        /// <remarks/>
        KZ,

        /// <remarks/>
        LA,

        /// <remarks/>
        LB,

        /// <remarks/>
        LC,

        /// <remarks/>
        LI,

        /// <remarks/>
        LK,

        /// <remarks/>
        LR,

        /// <remarks/>
        LS,

        /// <remarks/>
        LT,

        /// <remarks/>
        LU,

        /// <remarks/>
        LV,

        /// <remarks/>
        LY,

        /// <remarks/>
        MA,

        /// <remarks/>
        MC,

        /// <remarks/>
        MD,

        /// <remarks/>
        MG,

        /// <remarks/>
        MH,

        /// <remarks/>
        MK,

        /// <remarks/>
        ML,

        /// <remarks/>
        MM,

        /// <remarks/>
        MN,

        /// <remarks/>
        MO,

        /// <remarks/>
        MP,

        /// <remarks/>
        MQ,

        /// <remarks/>
        MR,

        /// <remarks/>
        MS,

        /// <remarks/>
        MT,

        /// <remarks/>
        MU,

        /// <remarks/>
        MV,

        /// <remarks/>
        MW,

        /// <remarks/>
        MX,

        /// <remarks/>
        MY,

        /// <remarks/>
        MZ,

        /// <remarks/>
        NA,

        /// <remarks/>
        NC,

        /// <remarks/>
        NE,

        /// <remarks/>
        NF,

        /// <remarks/>
        NG,

        /// <remarks/>
        NI,

        /// <remarks/>
        NL,

        /// <remarks/>
        NO,

        /// <remarks/>
        NP,

        /// <remarks/>
        NR,

        /// <remarks/>
        NU,

        /// <remarks/>
        NZ,

        /// <remarks/>
        OM,

        /// <remarks/>
        PA,

        /// <remarks/>
        PE,

        /// <remarks/>
        PF,

        /// <remarks/>
        PG,

        /// <remarks/>
        PH,

        /// <remarks/>
        PK,

        /// <remarks/>
        PL,

        /// <remarks/>
        PM,

        /// <remarks/>
        PN,

        /// <remarks/>
        PR,

        /// <remarks/>
        PS,

        /// <remarks/>
        PT,

        /// <remarks/>
        PW,

        /// <remarks/>
        PY,

        /// <remarks/>
        QA,

        /// <remarks/>
        RE,

        /// <remarks/>
        RO,

        /// <remarks/>
        RU,

        /// <remarks/>
        RW,

        /// <remarks/>
        SA,

        /// <remarks/>
        SB,

        /// <remarks/>
        SC,

        /// <remarks/>
        SD,

        /// <remarks/>
        SE,

        /// <remarks/>
        SG,

        /// <remarks/>
        SH,

        /// <remarks/>
        SI,

        /// <remarks/>
        SJ,

        /// <remarks/>
        SK,

        /// <remarks/>
        SL,

        /// <remarks/>
        SM,

        /// <remarks/>
        SN,

        /// <remarks/>
        SO,

        /// <remarks/>
        SR,

        /// <remarks/>
        ST,

        /// <remarks/>
        SV,

        /// <remarks/>
        SY,

        /// <remarks/>
        SZ,

        /// <remarks/>
        TC,

        /// <remarks/>
        TD,

        /// <remarks/>
        TF,

        /// <remarks/>
        TG,

        /// <remarks/>
        TH,

        /// <remarks/>
        TJ,

        /// <remarks/>
        TK,

        /// <remarks/>
        TM,

        /// <remarks/>
        TN,

        /// <remarks/>
        TO,

        /// <remarks/>
        TP,

        /// <remarks/>
        TR,

        /// <remarks/>
        TT,

        /// <remarks/>
        TV,

        /// <remarks/>
        TW,

        /// <remarks/>
        TZ,

        /// <remarks/>
        UA,

        /// <remarks/>
        UG,

        /// <remarks/>
        UM,

        /// <remarks/>
        US,

        /// <remarks/>
        UY,

        /// <remarks/>
        UZ,

        /// <remarks/>
        VA,

        /// <remarks/>
        VC,

        /// <remarks/>
        VE,

        /// <remarks/>
        VG,

        /// <remarks/>
        VI,

        /// <remarks/>
        VN,

        /// <remarks/>
        VU,

        /// <remarks/>
        WF,

        /// <remarks/>
        WS,

        /// <remarks/>
        YE,

        /// <remarks/>
        YT,

        /// <remarks/>
        YU,

        /// <remarks/>
        ZA,

        /// <remarks/>
        ZM,

        /// <remarks/>
        ZW,

        /// <remarks/>
        MF,

        /// <remarks/>
        IM,

        /// <remarks/>
        AX,

        /// <remarks/>
        GG,

        /// <remarks/>
        JE,

        /// <remarks/>
        ME,

        /// <remarks/>
        BL,

        /// <remarks/>
        RS,

        /// <remarks/>
        TL,

        /// <remarks/>
        SS,

        /// <remarks/>
        SU,

        /// <remarks/>
        CS,

        /// <remarks/>
        BQ,

        /// <remarks/>
        CW,

        /// <remarks/>
        SX,

        /// <remarks/>
        EU,

        /// <remarks/>
        FX,

        /// <remarks/>
        N1,

        /// <remarks/>
        XO,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "MainAddress", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Individual")]
    public partial class MainAddress4
    {

        private string addressLineField;

        private CountryCode countryField;

        private bool countryFieldSpecified;

        private string districtField;

        private string plotNumberField;

        private string postalCodeField;

        private string regionField;

        private string streetField;

        private string townField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AddressLine
        {
            get
            {
                return this.addressLineField;
            }
            set
            {
                this.addressLineField = value;
            }
        }

        /// <remarks/>
        public CountryCode Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountrySpecified
        {
            get
            {
                return this.countryFieldSpecified;
            }
            set
            {
                this.countryFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string District
        {
            get
            {
                return this.districtField;
            }
            set
            {
                this.districtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PlotNumber
        {
            get
            {
                return this.plotNumberField;
            }
            set
            {
                this.plotNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Region
        {
            get
            {
                return this.regionField;
            }
            set
            {
                this.regionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Street
        {
            get
            {
                return this.streetField;
            }
            set
            {
                this.streetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Town
        {
            get
            {
                return this.townField;
            }
            set
            {
                this.townField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Identifications", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Individual")]
    public partial class Identifications2
    {

        private string alienRegistrationField;

        private string nationalIDField;

        private string passportNumberField;

        private string pinNumberField;

        private string serviceIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AlienRegistration
        {
            get
            {
                return this.alienRegistrationField;
            }
            set
            {
                this.alienRegistrationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string NationalID
        {
            get
            {
                return this.nationalIDField;
            }
            set
            {
                this.nationalIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PassportNumber
        {
            get
            {
                return this.passportNumberField;
            }
            set
            {
                this.passportNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PinNumber
        {
            get
            {
                return this.pinNumberField;
            }
            set
            {
                this.pinNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ServiceId
        {
            get
            {
                return this.serviceIdField;
            }
            set
            {
                this.serviceIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "General", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Individual")]
    public partial class General2
    {

        private string aliasField;

        private string businessNameField;

        private ClassificationOfIndividual1 classificationOfIndividualField;

        private bool classificationOfIndividualFieldSpecified;

        private System.Nullable<System.DateTime> dateOfBirthField;

        private bool dateOfBirthFieldSpecified;

        private Employment employmentField;

        private bool employmentFieldSpecified;

        private string forename1Field;

        private string forename2Field;

        private string fullNameField;

        private Gender genderField;

        private bool genderFieldSpecified;

        private MaritalStatus1 maritalStatusField;

        private bool maritalStatusFieldSpecified;

        private string surnameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Alias
        {
            get
            {
                return this.aliasField;
            }
            set
            {
                this.aliasField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string BusinessName
        {
            get
            {
                return this.businessNameField;
            }
            set
            {
                this.businessNameField = value;
            }
        }

        /// <remarks/>
        public ClassificationOfIndividual1 ClassificationOfIndividual
        {
            get
            {
                return this.classificationOfIndividualField;
            }
            set
            {
                this.classificationOfIndividualField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ClassificationOfIndividualSpecified
        {
            get
            {
                return this.classificationOfIndividualFieldSpecified;
            }
            set
            {
                this.classificationOfIndividualFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                return this.dateOfBirthField;
            }
            set
            {
                this.dateOfBirthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOfBirthSpecified
        {
            get
            {
                return this.dateOfBirthFieldSpecified;
            }
            set
            {
                this.dateOfBirthFieldSpecified = value;
            }
        }

        /// <remarks/>
        public Employment Employment
        {
            get
            {
                return this.employmentField;
            }
            set
            {
                this.employmentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EmploymentSpecified
        {
            get
            {
                return this.employmentFieldSpecified;
            }
            set
            {
                this.employmentFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Forename1
        {
            get
            {
                return this.forename1Field;
            }
            set
            {
                this.forename1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Forename2
        {
            get
            {
                return this.forename2Field;
            }
            set
            {
                this.forename2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FullName
        {
            get
            {
                return this.fullNameField;
            }
            set
            {
                this.fullNameField = value;
            }
        }

        /// <remarks/>
        public Gender Gender
        {
            get
            {
                return this.genderField;
            }
            set
            {
                this.genderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GenderSpecified
        {
            get
            {
                return this.genderFieldSpecified;
            }
            set
            {
                this.genderFieldSpecified = value;
            }
        }

        /// <remarks/>
        public MaritalStatus1 MaritalStatus
        {
            get
            {
                return this.maritalStatusField;
            }
            set
            {
                this.maritalStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaritalStatusSpecified
        {
            get
            {
                return this.maritalStatusFieldSpecified;
            }
            set
            {
                this.maritalStatusFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Surname
        {
            get
            {
                return this.surnameField;
            }
            set
            {
                this.surnameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum Employment
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Farmer,

        /// <remarks/>
        ManualIndustryWorker,

        /// <remarks/>
        Merchant,

        /// <remarks/>
        Accountant,

        /// <remarks/>
        Pharmacist,

        /// <remarks/>
        Policeman,

        /// <remarks/>
        Lawyer,

        /// <remarks/>
        Jurist,

        /// <remarks/>
        Teacher,

        /// <remarks/>
        Engineer,

        /// <remarks/>
        ArmedForces,

        /// <remarks/>
        MiddleManager,

        /// <remarks/>
        HighManager,

        /// <remarks/>
        CEO,

        /// <remarks/>
        BoardMember,

        /// <remarks/>
        CompanyOwner,

        /// <remarks/>
        StateMiddleOfficer,

        /// <remarks/>
        StateHighOfficer,

        /// <remarks/>
        MemberOfParliament,

        /// <remarks/>
        MemberOfGovernment,

        /// <remarks/>
        Pensioner,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "MaritalStatus", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum MaritalStatus1
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Single,

        /// <remarks/>
        Married,

        /// <remarks/>
        Divorced,

        /// <remarks/>
        Spouse,

        /// <remarks/>
        Widowed,

        /// <remarks/>
        Engaged,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Contact", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Individual")]
    public partial class Contact4
    {

        private string emailField;

        private string homeTelephoneNumberField;

        private string mobileTelephoneNumberField;

        private string workTelephoneNumberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string HomeTelephoneNumber
        {
            get
            {
                return this.homeTelephoneNumberField;
            }
            set
            {
                this.homeTelephoneNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string MobileTelephoneNumber
        {
            get
            {
                return this.mobileTelephoneNumberField;
            }
            set
            {
                this.mobileTelephoneNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string WorkTelephoneNumber
        {
            get
            {
                return this.workTelephoneNumberField;
            }
            set
            {
                this.workTelephoneNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Individual")]
    public partial class Individual
    {

        private Contact4 contactField;

        private General2 generalField;

        private Identifications2 identificationsField;

        private MainAddress4 mainAddressField;

        private SecondaryAddress1 secondaryAddressField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Contact4 Contact
        {
            get
            {
                return this.contactField;
            }
            set
            {
                this.contactField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public General2 General
        {
            get
            {
                return this.generalField;
            }
            set
            {
                this.generalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Identifications2 Identifications
        {
            get
            {
                return this.identificationsField;
            }
            set
            {
                this.identificationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public MainAddress4 MainAddress
        {
            get
            {
                return this.mainAddressField;
            }
            set
            {
                this.mainAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SecondaryAddress1 SecondaryAddress
        {
            get
            {
                return this.secondaryAddressField;
            }
            set
            {
                this.secondaryAddressField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Summary", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Disputes")]
    public partial class Summary1
    {

        private int numberOfActiveDisputesContractsField;

        private bool numberOfActiveDisputesContractsFieldSpecified;

        private int numberOfActiveDisputesInCourtField;

        private bool numberOfActiveDisputesInCourtFieldSpecified;

        private int numberOfActiveDisputesSubjectDataField;

        private bool numberOfActiveDisputesSubjectDataFieldSpecified;

        private int numberOfClosedDisputesContractsField;

        private bool numberOfClosedDisputesContractsFieldSpecified;

        private int numberOfClosedDisputesSubjectDataField;

        private bool numberOfClosedDisputesSubjectDataFieldSpecified;

        private int numberOfFalseDisputesField;

        private bool numberOfFalseDisputesFieldSpecified;

        /// <remarks/>
        public int NumberOfActiveDisputesContracts
        {
            get
            {
                return this.numberOfActiveDisputesContractsField;
            }
            set
            {
                this.numberOfActiveDisputesContractsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfActiveDisputesContractsSpecified
        {
            get
            {
                return this.numberOfActiveDisputesContractsFieldSpecified;
            }
            set
            {
                this.numberOfActiveDisputesContractsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfActiveDisputesInCourt
        {
            get
            {
                return this.numberOfActiveDisputesInCourtField;
            }
            set
            {
                this.numberOfActiveDisputesInCourtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfActiveDisputesInCourtSpecified
        {
            get
            {
                return this.numberOfActiveDisputesInCourtFieldSpecified;
            }
            set
            {
                this.numberOfActiveDisputesInCourtFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfActiveDisputesSubjectData
        {
            get
            {
                return this.numberOfActiveDisputesSubjectDataField;
            }
            set
            {
                this.numberOfActiveDisputesSubjectDataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfActiveDisputesSubjectDataSpecified
        {
            get
            {
                return this.numberOfActiveDisputesSubjectDataFieldSpecified;
            }
            set
            {
                this.numberOfActiveDisputesSubjectDataFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfClosedDisputesContracts
        {
            get
            {
                return this.numberOfClosedDisputesContractsField;
            }
            set
            {
                this.numberOfClosedDisputesContractsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfClosedDisputesContractsSpecified
        {
            get
            {
                return this.numberOfClosedDisputesContractsFieldSpecified;
            }
            set
            {
                this.numberOfClosedDisputesContractsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfClosedDisputesSubjectData
        {
            get
            {
                return this.numberOfClosedDisputesSubjectDataField;
            }
            set
            {
                this.numberOfClosedDisputesSubjectDataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfClosedDisputesSubjectDataSpecified
        {
            get
            {
                return this.numberOfClosedDisputesSubjectDataFieldSpecified;
            }
            set
            {
                this.numberOfClosedDisputesSubjectDataFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfFalseDisputes
        {
            get
            {
                return this.numberOfFalseDisputesField;
            }
            set
            {
                this.numberOfFalseDisputesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfFalseDisputesSpecified
        {
            get
            {
                return this.numberOfFalseDisputesFieldSpecified;
            }
            set
            {
                this.numberOfFalseDisputesFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Dispute", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Disputes")]
    public partial class Dispute1
    {

        private string commentField;

        private System.Nullable<System.DateTime> createdField;

        private bool createdFieldSpecified;

        private bool inCourtField;

        private bool inCourtFieldSpecified;

        private DisputeResolution resolutionField;

        private bool resolutionFieldSpecified;

        private DisputeStatus statusField;

        private bool statusFieldSpecified;

        private DisputeType typeField;

        private bool typeFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> Created
        {
            get
            {
                return this.createdField;
            }
            set
            {
                this.createdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreatedSpecified
        {
            get
            {
                return this.createdFieldSpecified;
            }
            set
            {
                this.createdFieldSpecified = value;
            }
        }

        /// <remarks/>
        public bool InCourt
        {
            get
            {
                return this.inCourtField;
            }
            set
            {
                this.inCourtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InCourtSpecified
        {
            get
            {
                return this.inCourtFieldSpecified;
            }
            set
            {
                this.inCourtFieldSpecified = value;
            }
        }

        /// <remarks/>
        public DisputeResolution Resolution
        {
            get
            {
                return this.resolutionField;
            }
            set
            {
                this.resolutionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ResolutionSpecified
        {
            get
            {
                return this.resolutionFieldSpecified;
            }
            set
            {
                this.resolutionFieldSpecified = value;
            }
        }

        /// <remarks/>
        public DisputeStatus Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatusSpecified
        {
            get
            {
                return this.statusFieldSpecified;
            }
            set
            {
                this.statusFieldSpecified = value;
            }
        }

        /// <remarks/>
        public DisputeType Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TypeSpecified
        {
            get
            {
                return this.typeFieldSpecified;
            }
            set
            {
                this.typeFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum DisputeResolution
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Fixed,

        /// <remarks/>
        FalseDispute,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum DisputeStatus
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Closed,

        /// <remarks/>
        Active,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum DisputeType
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        ContractDispute,

        /// <remarks/>
        SubjectDispute,

        /// <remarks/>
        UtilityDispute,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Disputes", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Disputes")]
    public partial class Disputes2
    {

        private Dispute1[] disputeListField;

        private Summary1 summaryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public Dispute1[] DisputeList
        {
            get
            {
                return this.disputeListField;
            }
            set
            {
                this.disputeListField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Summary1 Summary
        {
            get
            {
                return this.summaryField;
            }
            set
            {
                this.summaryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Dashboard")]
    public partial class Relations
    {

        private int numberOfInvolvementsField;

        private bool numberOfInvolvementsFieldSpecified;

        private int numberOfRelationsField;

        private bool numberOfRelationsFieldSpecified;

        /// <remarks/>
        public int NumberOfInvolvements
        {
            get
            {
                return this.numberOfInvolvementsField;
            }
            set
            {
                this.numberOfInvolvementsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfInvolvementsSpecified
        {
            get
            {
                return this.numberOfInvolvementsFieldSpecified;
            }
            set
            {
                this.numberOfInvolvementsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfRelations
        {
            get
            {
                return this.numberOfRelationsField;
            }
            set
            {
                this.numberOfRelationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfRelationsSpecified
        {
            get
            {
                return this.numberOfRelationsFieldSpecified;
            }
            set
            {
                this.numberOfRelationsFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Dashboard")]
    public partial class PaymentsProfile
    {

        private Amount1 installmentAmountSumField;

        private int numberOfDifferentSubscribersField;

        private bool numberOfDifferentSubscribersFieldSpecified;

        private Amount1 pastDueAmountSumField;

        private int worstPastDueDaysCurrentField;

        private bool worstPastDueDaysCurrentFieldSpecified;

        private int worstPastDueDaysForLast12MonthsField;

        private bool worstPastDueDaysForLast12MonthsFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 InstallmentAmountSum
        {
            get
            {
                return this.installmentAmountSumField;
            }
            set
            {
                this.installmentAmountSumField = value;
            }
        }

        /// <remarks/>
        public int NumberOfDifferentSubscribers
        {
            get
            {
                return this.numberOfDifferentSubscribersField;
            }
            set
            {
                this.numberOfDifferentSubscribersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfDifferentSubscribersSpecified
        {
            get
            {
                return this.numberOfDifferentSubscribersFieldSpecified;
            }
            set
            {
                this.numberOfDifferentSubscribersFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 PastDueAmountSum
        {
            get
            {
                return this.pastDueAmountSumField;
            }
            set
            {
                this.pastDueAmountSumField = value;
            }
        }

        /// <remarks/>
        public int WorstPastDueDaysCurrent
        {
            get
            {
                return this.worstPastDueDaysCurrentField;
            }
            set
            {
                this.worstPastDueDaysCurrentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WorstPastDueDaysCurrentSpecified
        {
            get
            {
                return this.worstPastDueDaysCurrentFieldSpecified;
            }
            set
            {
                this.worstPastDueDaysCurrentFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int WorstPastDueDaysForLast12Months
        {
            get
            {
                return this.worstPastDueDaysForLast12MonthsField;
            }
            set
            {
                this.worstPastDueDaysForLast12MonthsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WorstPastDueDaysForLast12MonthsSpecified
        {
            get
            {
                return this.worstPastDueDaysForLast12MonthsFieldSpecified;
            }
            set
            {
                this.worstPastDueDaysForLast12MonthsFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Dashboard")]
    public partial class Inquiries
    {

        private int inquiriesForLast12MonthsField;

        private bool inquiriesForLast12MonthsFieldSpecified;

        private int subscribersInLast12MonthsField;

        private bool subscribersInLast12MonthsFieldSpecified;

        /// <remarks/>
        public int InquiriesForLast12Months
        {
            get
            {
                return this.inquiriesForLast12MonthsField;
            }
            set
            {
                this.inquiriesForLast12MonthsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InquiriesForLast12MonthsSpecified
        {
            get
            {
                return this.inquiriesForLast12MonthsFieldSpecified;
            }
            set
            {
                this.inquiriesForLast12MonthsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int SubscribersInLast12Months
        {
            get
            {
                return this.subscribersInLast12MonthsField;
            }
            set
            {
                this.subscribersInLast12MonthsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubscribersInLast12MonthsSpecified
        {
            get
            {
                return this.subscribersInLast12MonthsFieldSpecified;
            }
            set
            {
                this.subscribersInLast12MonthsFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Disputes", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Dashboard")]
    public partial class Disputes1
    {

        private int activeContractDisputesField;

        private bool activeContractDisputesFieldSpecified;

        private int activeSubjectDisputesField;

        private bool activeSubjectDisputesFieldSpecified;

        private int closedContractDisputesField;

        private bool closedContractDisputesFieldSpecified;

        private int closedSubjectDisputesField;

        private bool closedSubjectDisputesFieldSpecified;

        private int falseDisputesField;

        private bool falseDisputesFieldSpecified;

        private int numberOfCourtRegisteredDisputesField;

        private bool numberOfCourtRegisteredDisputesFieldSpecified;

        /// <remarks/>
        public int ActiveContractDisputes
        {
            get
            {
                return this.activeContractDisputesField;
            }
            set
            {
                this.activeContractDisputesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActiveContractDisputesSpecified
        {
            get
            {
                return this.activeContractDisputesFieldSpecified;
            }
            set
            {
                this.activeContractDisputesFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int ActiveSubjectDisputes
        {
            get
            {
                return this.activeSubjectDisputesField;
            }
            set
            {
                this.activeSubjectDisputesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActiveSubjectDisputesSpecified
        {
            get
            {
                return this.activeSubjectDisputesFieldSpecified;
            }
            set
            {
                this.activeSubjectDisputesFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int ClosedContractDisputes
        {
            get
            {
                return this.closedContractDisputesField;
            }
            set
            {
                this.closedContractDisputesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ClosedContractDisputesSpecified
        {
            get
            {
                return this.closedContractDisputesFieldSpecified;
            }
            set
            {
                this.closedContractDisputesFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int ClosedSubjectDisputes
        {
            get
            {
                return this.closedSubjectDisputesField;
            }
            set
            {
                this.closedSubjectDisputesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ClosedSubjectDisputesSpecified
        {
            get
            {
                return this.closedSubjectDisputesFieldSpecified;
            }
            set
            {
                this.closedSubjectDisputesFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int FalseDisputes
        {
            get
            {
                return this.falseDisputesField;
            }
            set
            {
                this.falseDisputesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FalseDisputesSpecified
        {
            get
            {
                return this.falseDisputesFieldSpecified;
            }
            set
            {
                this.falseDisputesFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfCourtRegisteredDisputes
        {
            get
            {
                return this.numberOfCourtRegisteredDisputesField;
            }
            set
            {
                this.numberOfCourtRegisteredDisputesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfCourtRegisteredDisputesSpecified
        {
            get
            {
                return this.numberOfCourtRegisteredDisputesFieldSpecified;
            }
            set
            {
                this.numberOfCourtRegisteredDisputesFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Dashboard")]
    public partial class Collaterals
    {

        private Amount1 highestCollateralValueField;

        private CollateralType highestCollateralValueTypeField;

        private bool highestCollateralValueTypeFieldSpecified;

        private int numberOfCollateralsField;

        private bool numberOfCollateralsFieldSpecified;

        private Amount1 totalCollateralValueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 HighestCollateralValue
        {
            get
            {
                return this.highestCollateralValueField;
            }
            set
            {
                this.highestCollateralValueField = value;
            }
        }

        /// <remarks/>
        public CollateralType HighestCollateralValueType
        {
            get
            {
                return this.highestCollateralValueTypeField;
            }
            set
            {
                this.highestCollateralValueTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HighestCollateralValueTypeSpecified
        {
            get
            {
                return this.highestCollateralValueTypeFieldSpecified;
            }
            set
            {
                this.highestCollateralValueTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfCollaterals
        {
            get
            {
                return this.numberOfCollateralsField;
            }
            set
            {
                this.numberOfCollateralsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfCollateralsSpecified
        {
            get
            {
                return this.numberOfCollateralsFieldSpecified;
            }
            set
            {
                this.numberOfCollateralsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 TotalCollateralValue
        {
            get
            {
                return this.totalCollateralValueField;
            }
            set
            {
                this.totalCollateralValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum CollateralType
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Land,

        /// <remarks/>
        RealEstate,

        /// <remarks/>
        MotorVehicle,

        /// <remarks/>
        CashSecurity,

        /// <remarks/>
        Shares,

        /// <remarks/>
        SavingsDeposits,

        /// <remarks/>
        Machinery,

        /// <remarks/>
        InsurancePolicy,

        /// <remarks/>
        OtherIndividualProperty,

        /// <remarks/>
        PersonalGuarantees,

        /// <remarks/>
        StateGuarantees,

        /// <remarks/>
        Financial,

        /// <remarks/>
        NonFinancial,

        /// <remarks/>
        Building,

        /// <remarks/>
        Bonds,

        /// <remarks/>
        Debentures,

        /// <remarks/>
        Chattels,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "CIQ", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Dashboard")]
    public partial class CIQ1
    {

        private int fraudAlertsField;

        private bool fraudAlertsFieldSpecified;

        private int fraudAlertsThirdPartyField;

        private bool fraudAlertsThirdPartyFieldSpecified;

        /// <remarks/>
        public int FraudAlerts
        {
            get
            {
                return this.fraudAlertsField;
            }
            set
            {
                this.fraudAlertsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FraudAlertsSpecified
        {
            get
            {
                return this.fraudAlertsFieldSpecified;
            }
            set
            {
                this.fraudAlertsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int FraudAlertsThirdParty
        {
            get
            {
                return this.fraudAlertsThirdPartyField;
            }
            set
            {
                this.fraudAlertsThirdPartyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FraudAlertsThirdPartySpecified
        {
            get
            {
                return this.fraudAlertsThirdPartyFieldSpecified;
            }
            set
            {
                this.fraudAlertsThirdPartyFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "CIP", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Dashboard")]
    public partial class CIP1
    {

        private RiskGrade gradeField;

        private bool gradeFieldSpecified;

        private decimal scoreField;

        private bool scoreFieldSpecified;

        private Trend trendField;

        private bool trendFieldSpecified;

        /// <remarks/>
        public RiskGrade Grade
        {
            get
            {
                return this.gradeField;
            }
            set
            {
                this.gradeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GradeSpecified
        {
            get
            {
                return this.gradeFieldSpecified;
            }
            set
            {
                this.gradeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal Score
        {
            get
            {
                return this.scoreField;
            }
            set
            {
                this.scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ScoreSpecified
        {
            get
            {
                return this.scoreFieldSpecified;
            }
            set
            {
                this.scoreFieldSpecified = value;
            }
        }

        /// <remarks/>
        public Trend Trend
        {
            get
            {
                return this.trendField;
            }
            set
            {
                this.trendField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TrendSpecified
        {
            get
            {
                return this.trendFieldSpecified;
            }
            set
            {
                this.trendFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/CI.CBS.Contracts.Public.Structures.Enums." +
        "Common")]
    public enum RiskGrade
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        A1,

        /// <remarks/>
        A2,

        /// <remarks/>
        A3,

        /// <remarks/>
        B1,

        /// <remarks/>
        B2,

        /// <remarks/>
        B3,

        /// <remarks/>
        C1,

        /// <remarks/>
        C2,

        /// <remarks/>
        C3,

        /// <remarks/>
        D1,

        /// <remarks/>
        D2,

        /// <remarks/>
        D3,

        /// <remarks/>
        E1,

        /// <remarks/>
        E2,

        /// <remarks/>
        E3,

        /// <remarks/>
        XX,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/CI.CBS.Contracts.Public.Structures.Enums." +
        "Common")]
    public enum Trend
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Up,

        /// <remarks/>
        Down,

        /// <remarks/>
        NoChange,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "BouncedCheques", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Dashboard")]
    public partial class BouncedCheques1
    {

        private int numberOfChequesField;

        private bool numberOfChequesFieldSpecified;

        private Amount1 totalValueField;

        private int weekSinceLastChequeField;

        private bool weekSinceLastChequeFieldSpecified;

        /// <remarks/>
        public int NumberOfCheques
        {
            get
            {
                return this.numberOfChequesField;
            }
            set
            {
                this.numberOfChequesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfChequesSpecified
        {
            get
            {
                return this.numberOfChequesFieldSpecified;
            }
            set
            {
                this.numberOfChequesFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 TotalValue
        {
            get
            {
                return this.totalValueField;
            }
            set
            {
                this.totalValueField = value;
            }
        }

        /// <remarks/>
        public int WeekSinceLastCheque
        {
            get
            {
                return this.weekSinceLastChequeField;
            }
            set
            {
                this.weekSinceLastChequeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WeekSinceLastChequeSpecified
        {
            get
            {
                return this.weekSinceLastChequeFieldSpecified;
            }
            set
            {
                this.weekSinceLastChequeFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Dashboard")]
    public partial class Dashboard
    {

        private BouncedCheques1 bouncedChequesField;

        private CIP1 cIPField;

        private CIQ1 cIQField;

        private Collaterals collateralsField;

        private Disputes1 disputesField;

        private Inquiries inquiriesField;

        private PaymentsProfile paymentsProfileField;

        private Relations relationsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public BouncedCheques1 BouncedCheques
        {
            get
            {
                return this.bouncedChequesField;
            }
            set
            {
                this.bouncedChequesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public CIP1 CIP
        {
            get
            {
                return this.cIPField;
            }
            set
            {
                this.cIPField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public CIQ1 CIQ
        {
            get
            {
                return this.cIQField;
            }
            set
            {
                this.cIQField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Collaterals Collaterals
        {
            get
            {
                return this.collateralsField;
            }
            set
            {
                this.collateralsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Disputes1 Disputes
        {
            get
            {
                return this.disputesField;
            }
            set
            {
                this.disputesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Inquiries Inquiries
        {
            get
            {
                return this.inquiriesField;
            }
            set
            {
                this.inquiriesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public PaymentsProfile PaymentsProfile
        {
            get
            {
                return this.paymentsProfileField;
            }
            set
            {
                this.paymentsProfileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Relations Relations
        {
            get
            {
                return this.relationsField;
            }
            set
            {
                this.relationsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "MainAddress", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CurrentRelations/RelPar")]
    public partial class MainAddress3
    {

        private string addressLineField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AddressLine
        {
            get
            {
                return this.addressLineField;
            }
            set
            {
                this.addressLineField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Contact", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CurrentRelations/RelPar")]
    public partial class Contact3
    {

        private string mobileTelephoneNumberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string MobileTelephoneNumber
        {
            get
            {
                return this.mobileTelephoneNumberField;
            }
            set
            {
                this.mobileTelephoneNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CurrentRelations")]
    public partial class RelatedParty
    {

        private string additionalInformationField;

        private Contact3 contactField;

        private string fullNameField;

        private string iDNumberField;

        private IDNumberTypeAll iDNumberTypeField;

        private bool iDNumberTypeFieldSpecified;

        private MainAddress3 mainAddressField;

        private SubjectType subjectTypeField;

        private bool subjectTypeFieldSpecified;

        private RelationType typeOfRelationField;

        private bool typeOfRelationFieldSpecified;

        private System.Nullable<System.DateTime> validFromField;

        private bool validFromFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AdditionalInformation
        {
            get
            {
                return this.additionalInformationField;
            }
            set
            {
                this.additionalInformationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Contact3 Contact
        {
            get
            {
                return this.contactField;
            }
            set
            {
                this.contactField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FullName
        {
            get
            {
                return this.fullNameField;
            }
            set
            {
                this.fullNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string IDNumber
        {
            get
            {
                return this.iDNumberField;
            }
            set
            {
                this.iDNumberField = value;
            }
        }

        /// <remarks/>
        public IDNumberTypeAll IDNumberType
        {
            get
            {
                return this.iDNumberTypeField;
            }
            set
            {
                this.iDNumberTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IDNumberTypeSpecified
        {
            get
            {
                return this.iDNumberTypeFieldSpecified;
            }
            set
            {
                this.iDNumberTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public MainAddress3 MainAddress
        {
            get
            {
                return this.mainAddressField;
            }
            set
            {
                this.mainAddressField = value;
            }
        }

        /// <remarks/>
        public SubjectType SubjectType
        {
            get
            {
                return this.subjectTypeField;
            }
            set
            {
                this.subjectTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubjectTypeSpecified
        {
            get
            {
                return this.subjectTypeFieldSpecified;
            }
            set
            {
                this.subjectTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public RelationType TypeOfRelation
        {
            get
            {
                return this.typeOfRelationField;
            }
            set
            {
                this.typeOfRelationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TypeOfRelationSpecified
        {
            get
            {
                return this.typeOfRelationFieldSpecified;
            }
            set
            {
                this.typeOfRelationFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> ValidFrom
        {
            get
            {
                return this.validFromField;
            }
            set
            {
                this.validFromField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValidFromSpecified
        {
            get
            {
                return this.validFromFieldSpecified;
            }
            set
            {
                this.validFromFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum IDNumberTypeAll
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        CreditinfoId,

        /// <remarks/>
        PinNumber,

        /// <remarks/>
        NationalID,

        /// <remarks/>
        RegistrationNumber,

        /// <remarks/>
        PassportNumber,

        /// <remarks/>
        IDCardNumber,

        /// <remarks/>
        DrivingLicenseNumber,

        /// <remarks/>
        VotersID,

        /// <remarks/>
        ForeignUniqueID,

        /// <remarks/>
        AlienRegistration,

        /// <remarks/>
        ServiceId,

        /// <remarks/>
        BusinessLicense,

        /// <remarks/>
        SocialSecurityNumber,

        /// <remarks/>
        PreviousPassport,

        /// <remarks/>
        BankingID,

        /// <remarks/>
        ArtificialID,

        /// <remarks/>
        CustomIdNumber3,

        /// <remarks/>
        AssociationIdNumber,

        /// <remarks/>
        OtherIdNumber,

        /// <remarks/>
        CustomerCode,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum RelationType
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Shareholder,

        /// <remarks/>
        CEO,

        /// <remarks/>
        Owner,

        /// <remarks/>
        Guarantor,

        /// <remarks/>
        Partner,

        /// <remarks/>
        TrustBeneficiary,

        /// <remarks/>
        PowerOfAttorney,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "MainAddress", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CurrentRelations/Inv")]
    public partial class MainAddress2
    {

        private string addressLineField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AddressLine
        {
            get
            {
                return this.addressLineField;
            }
            set
            {
                this.addressLineField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Contact", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CurrentRelations/Inv")]
    public partial class Contact2
    {

        private string mobileTelephoneNumberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string MobileTelephoneNumber
        {
            get
            {
                return this.mobileTelephoneNumberField;
            }
            set
            {
                this.mobileTelephoneNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CurrentRelations")]
    public partial class Involvement
    {

        private string additionalInformationField;

        private Contact2 contactField;

        private string fullNameField;

        private string iDNumberField;

        private IDNumberTypeAll iDNumberTypeField;

        private bool iDNumberTypeFieldSpecified;

        private MainAddress2 mainAddressField;

        private SubjectType subjectTypeField;

        private bool subjectTypeFieldSpecified;

        private RelationType typeOfRelationField;

        private bool typeOfRelationFieldSpecified;

        private System.Nullable<System.DateTime> validFromField;

        private bool validFromFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AdditionalInformation
        {
            get
            {
                return this.additionalInformationField;
            }
            set
            {
                this.additionalInformationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Contact2 Contact
        {
            get
            {
                return this.contactField;
            }
            set
            {
                this.contactField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FullName
        {
            get
            {
                return this.fullNameField;
            }
            set
            {
                this.fullNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string IDNumber
        {
            get
            {
                return this.iDNumberField;
            }
            set
            {
                this.iDNumberField = value;
            }
        }

        /// <remarks/>
        public IDNumberTypeAll IDNumberType
        {
            get
            {
                return this.iDNumberTypeField;
            }
            set
            {
                this.iDNumberTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IDNumberTypeSpecified
        {
            get
            {
                return this.iDNumberTypeFieldSpecified;
            }
            set
            {
                this.iDNumberTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public MainAddress2 MainAddress
        {
            get
            {
                return this.mainAddressField;
            }
            set
            {
                this.mainAddressField = value;
            }
        }

        /// <remarks/>
        public SubjectType SubjectType
        {
            get
            {
                return this.subjectTypeField;
            }
            set
            {
                this.subjectTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubjectTypeSpecified
        {
            get
            {
                return this.subjectTypeFieldSpecified;
            }
            set
            {
                this.subjectTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public RelationType TypeOfRelation
        {
            get
            {
                return this.typeOfRelationField;
            }
            set
            {
                this.typeOfRelationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TypeOfRelationSpecified
        {
            get
            {
                return this.typeOfRelationFieldSpecified;
            }
            set
            {
                this.typeOfRelationFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> ValidFrom
        {
            get
            {
                return this.validFromField;
            }
            set
            {
                this.validFromField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValidFromSpecified
        {
            get
            {
                return this.validFromFieldSpecified;
            }
            set
            {
                this.validFromFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "MainAddress", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CurrentRelations/ContRel")]
    public partial class MainAddress1
    {

        private string addressLineField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AddressLine
        {
            get
            {
                return this.addressLineField;
            }
            set
            {
                this.addressLineField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Contact", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CurrentRelations/ContRel")]
    public partial class Contact1
    {

        private string mobileTelephoneNumberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string MobileTelephoneNumber
        {
            get
            {
                return this.mobileTelephoneNumberField;
            }
            set
            {
                this.mobileTelephoneNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CurrentRelations")]
    public partial class ContractRelation
    {

        private Contact1 contactField;

        private string fullNameField;

        private string iDNumberField;

        private IDNumberTypeAll iDNumberTypeField;

        private bool iDNumberTypeFieldSpecified;

        private MainAddress1 mainAddressField;

        private RoleOfCustomer roleOfCustomerField;

        private bool roleOfCustomerFieldSpecified;

        private SubjectType subjectTypeField;

        private bool subjectTypeFieldSpecified;

        private System.Nullable<System.DateTime> validFromField;

        private bool validFromFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Contact1 Contact
        {
            get
            {
                return this.contactField;
            }
            set
            {
                this.contactField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FullName
        {
            get
            {
                return this.fullNameField;
            }
            set
            {
                this.fullNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string IDNumber
        {
            get
            {
                return this.iDNumberField;
            }
            set
            {
                this.iDNumberField = value;
            }
        }

        /// <remarks/>
        public IDNumberTypeAll IDNumberType
        {
            get
            {
                return this.iDNumberTypeField;
            }
            set
            {
                this.iDNumberTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IDNumberTypeSpecified
        {
            get
            {
                return this.iDNumberTypeFieldSpecified;
            }
            set
            {
                this.iDNumberTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public MainAddress1 MainAddress
        {
            get
            {
                return this.mainAddressField;
            }
            set
            {
                this.mainAddressField = value;
            }
        }

        /// <remarks/>
        public RoleOfCustomer RoleOfCustomer
        {
            get
            {
                return this.roleOfCustomerField;
            }
            set
            {
                this.roleOfCustomerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RoleOfCustomerSpecified
        {
            get
            {
                return this.roleOfCustomerFieldSpecified;
            }
            set
            {
                this.roleOfCustomerFieldSpecified = value;
            }
        }

        /// <remarks/>
        public SubjectType SubjectType
        {
            get
            {
                return this.subjectTypeField;
            }
            set
            {
                this.subjectTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubjectTypeSpecified
        {
            get
            {
                return this.subjectTypeFieldSpecified;
            }
            set
            {
                this.subjectTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> ValidFrom
        {
            get
            {
                return this.validFromField;
            }
            set
            {
                this.validFromField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValidFromSpecified
        {
            get
            {
                return this.validFromFieldSpecified;
            }
            set
            {
                this.validFromFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CurrentRelations")]
    public partial class CurrentRelations
    {

        private ContractRelation[] contractRelationListField;

        private Involvement[] involvementListField;

        private RelatedParty[] relatedPartyListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public ContractRelation[] ContractRelationList
        {
            get
            {
                return this.contractRelationListField;
            }
            set
            {
                this.contractRelationListField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public Involvement[] InvolvementList
        {
            get
            {
                return this.involvementListField;
            }
            set
            {
                this.involvementListField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public RelatedParty[] RelatedPartyList
        {
            get
            {
                return this.relatedPartyListField;
            }
            set
            {
                this.relatedPartyListField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Contracts")]
    public partial class RelatedSubject
    {

        private string alienRegistrationField;

        private string nameField;

        private string nationalIDField;

        private string passportNumberField;

        private string pinNumberField;

        private string registrationNumberField;

        private RoleOfCustomer roleOfClientField;

        private bool roleOfClientFieldSpecified;

        private string serviceIdField;

        private SubjectType subjectTypeField;

        private bool subjectTypeFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AlienRegistration
        {
            get
            {
                return this.alienRegistrationField;
            }
            set
            {
                this.alienRegistrationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string NationalID
        {
            get
            {
                return this.nationalIDField;
            }
            set
            {
                this.nationalIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PassportNumber
        {
            get
            {
                return this.passportNumberField;
            }
            set
            {
                this.passportNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PinNumber
        {
            get
            {
                return this.pinNumberField;
            }
            set
            {
                this.pinNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumberField;
            }
            set
            {
                this.registrationNumberField = value;
            }
        }

        /// <remarks/>
        public RoleOfCustomer RoleOfClient
        {
            get
            {
                return this.roleOfClientField;
            }
            set
            {
                this.roleOfClientField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RoleOfClientSpecified
        {
            get
            {
                return this.roleOfClientFieldSpecified;
            }
            set
            {
                this.roleOfClientFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ServiceId
        {
            get
            {
                return this.serviceIdField;
            }
            set
            {
                this.serviceIdField = value;
            }
        }

        /// <remarks/>
        public SubjectType SubjectType
        {
            get
            {
                return this.subjectTypeField;
            }
            set
            {
                this.subjectTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubjectTypeSpecified
        {
            get
            {
                return this.subjectTypeFieldSpecified;
            }
            set
            {
                this.subjectTypeFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Contracts")]
    public partial class CalendarItem
    {

        private System.DateTime dateField;

        private bool dateFieldSpecified;

        private DelinquencyStatus delinquencyStatusField;

        private bool delinquencyStatusFieldSpecified;

        private Amount1 monthlyPaymentField;

        private Amount1 outstandingAmountField;

        private Amount1 pastDueAmountField;

        private System.Nullable<int> pastDueDaysField;

        private bool pastDueDaysFieldSpecified;

        private System.Nullable<int> pastDueInstallmentsField;

        private bool pastDueInstallmentsFieldSpecified;

        /// <remarks/>
        public System.DateTime Date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateSpecified
        {
            get
            {
                return this.dateFieldSpecified;
            }
            set
            {
                this.dateFieldSpecified = value;
            }
        }

        /// <remarks/>
        public DelinquencyStatus DelinquencyStatus
        {
            get
            {
                return this.delinquencyStatusField;
            }
            set
            {
                this.delinquencyStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DelinquencyStatusSpecified
        {
            get
            {
                return this.delinquencyStatusFieldSpecified;
            }
            set
            {
                this.delinquencyStatusFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 MonthlyPayment
        {
            get
            {
                return this.monthlyPaymentField;
            }
            set
            {
                this.monthlyPaymentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 OutstandingAmount
        {
            get
            {
                return this.outstandingAmountField;
            }
            set
            {
                this.outstandingAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 PastDueAmount
        {
            get
            {
                return this.pastDueAmountField;
            }
            set
            {
                this.pastDueAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> PastDueDays
        {
            get
            {
                return this.pastDueDaysField;
            }
            set
            {
                this.pastDueDaysField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PastDueDaysSpecified
        {
            get
            {
                return this.pastDueDaysFieldSpecified;
            }
            set
            {
                this.pastDueDaysFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> PastDueInstallments
        {
            get
            {
                return this.pastDueInstallmentsField;
            }
            set
            {
                this.pastDueInstallmentsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PastDueInstallmentsSpecified
        {
            get
            {
                return this.pastDueInstallmentsFieldSpecified;
            }
            set
            {
                this.pastDueInstallmentsFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/CI.CBS.Contracts.Public.Structures.Enums." +
        "Common")]
    public enum DelinquencyStatus
    {

        /// <remarks/>
        NotAvailable,

        /// <remarks/>
        Ok,

        /// <remarks/>
        Warning,

        /// <remarks/>
        Default,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Contracts")]
    public partial class Dispute
    {

        private string commentField;

        private System.Nullable<System.DateTime> createdField;

        private bool createdFieldSpecified;

        private System.Nullable<bool> inCourtField;

        private bool inCourtFieldSpecified;

        private DisputeResolution resolutionField;

        private bool resolutionFieldSpecified;

        private DisputeStatus statusField;

        private bool statusFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> Created
        {
            get
            {
                return this.createdField;
            }
            set
            {
                this.createdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreatedSpecified
        {
            get
            {
                return this.createdFieldSpecified;
            }
            set
            {
                this.createdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> InCourt
        {
            get
            {
                return this.inCourtField;
            }
            set
            {
                this.inCourtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InCourtSpecified
        {
            get
            {
                return this.inCourtFieldSpecified;
            }
            set
            {
                this.inCourtFieldSpecified = value;
            }
        }

        /// <remarks/>
        public DisputeResolution Resolution
        {
            get
            {
                return this.resolutionField;
            }
            set
            {
                this.resolutionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ResolutionSpecified
        {
            get
            {
                return this.resolutionFieldSpecified;
            }
            set
            {
                this.resolutionFieldSpecified = value;
            }
        }

        /// <remarks/>
        public DisputeStatus Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatusSpecified
        {
            get
            {
                return this.statusFieldSpecified;
            }
            set
            {
                this.statusFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Contracts")]
    public partial class Disputes
    {

        private int closedDisputesField;

        private bool closedDisputesFieldSpecified;

        private Dispute[] disputeListField;

        private int falseDisputesField;

        private bool falseDisputesFieldSpecified;

        /// <remarks/>
        public int ClosedDisputes
        {
            get
            {
                return this.closedDisputesField;
            }
            set
            {
                this.closedDisputesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ClosedDisputesSpecified
        {
            get
            {
                return this.closedDisputesFieldSpecified;
            }
            set
            {
                this.closedDisputesFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public Dispute[] DisputeList
        {
            get
            {
                return this.disputeListField;
            }
            set
            {
                this.disputeListField = value;
            }
        }

        /// <remarks/>
        public int FalseDisputes
        {
            get
            {
                return this.falseDisputesField;
            }
            set
            {
                this.falseDisputesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FalseDisputesSpecified
        {
            get
            {
                return this.falseDisputesFieldSpecified;
            }
            set
            {
                this.falseDisputesFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Contracts")]
    public partial class Collateral
    {

        private string collateralCodeField;

        private string collateralDescriptionField;

        private CollateralType collateralTypeField;

        private bool collateralTypeFieldSpecified;

        private Amount1 collateralValueField;

        private System.Nullable<System.DateTime> valuationDateField;

        private bool valuationDateFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string CollateralCode
        {
            get
            {
                return this.collateralCodeField;
            }
            set
            {
                this.collateralCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string CollateralDescription
        {
            get
            {
                return this.collateralDescriptionField;
            }
            set
            {
                this.collateralDescriptionField = value;
            }
        }

        /// <remarks/>
        public CollateralType CollateralType
        {
            get
            {
                return this.collateralTypeField;
            }
            set
            {
                this.collateralTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CollateralTypeSpecified
        {
            get
            {
                return this.collateralTypeFieldSpecified;
            }
            set
            {
                this.collateralTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 CollateralValue
        {
            get
            {
                return this.collateralValueField;
            }
            set
            {
                this.collateralValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> ValuationDate
        {
            get
            {
                return this.valuationDateField;
            }
            set
            {
                this.valuationDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValuationDateSpecified
        {
            get
            {
                return this.valuationDateFieldSpecified;
            }
            set
            {
                this.valuationDateFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Contract", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Contracts")]
    public partial class Contract1
    {

        private TypeOfContract1 accountProductTypeField;

        private bool accountProductTypeFieldSpecified;

        private ContractStatus accountStatusField;

        private bool accountStatusFieldSpecified;

        private string branchField;

        private Collateral[] collateralsListField;

        private string contractCodeField;

        private Currency currencyOfFacilityField;

        private bool currencyOfFacilityFieldSpecified;

        private System.Nullable<System.DateTime> dateAccountOpenedField;

        private bool dateAccountOpenedFieldSpecified;

        private System.Nullable<System.DateTime> dateOfLastPaymentField;

        private bool dateOfLastPaymentFieldSpecified;

        private int daysInArrearsField;

        private bool daysInArrearsFieldSpecified;

        private Disputes disputesField;

        private System.Nullable<System.DateTime> expectedEndDateField;

        private bool expectedEndDateFieldSpecified;

        private Amount1 installmentAmountField;

        private int installmentsInArrearsField;

        private bool installmentsInArrearsFieldSpecified;

        private NegativeStatusOfContract negativeStatusOfContractField;

        private bool negativeStatusOfContractFieldSpecified;

        private Amount1 originalAmountField;

        private Amount1 outstandingAmountField;

        private Amount1 overdueBalanceField;

        private CalendarItem[] paymentCalendarListField;

        private PaymentPeriodicity paymentFrequencyField;

        private bool paymentFrequencyFieldSpecified;

        private PhaseOfContract phaseOfContractField;

        private bool phaseOfContractFieldSpecified;

        private System.Nullable<System.DateTime> realEndDateField;

        private bool realEndDateFieldSpecified;

        private RelatedSubject[] relatedSubjectsListField;

        private RoleOfCustomer roleOfClientField;

        private bool roleOfClientFieldSpecified;

        private string subscriberField;

        private Sector1 subscriberTypeField;

        private bool subscriberTypeFieldSpecified;

        /// <remarks/>
        public TypeOfContract1 AccountProductType
        {
            get
            {
                return this.accountProductTypeField;
            }
            set
            {
                this.accountProductTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AccountProductTypeSpecified
        {
            get
            {
                return this.accountProductTypeFieldSpecified;
            }
            set
            {
                this.accountProductTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public ContractStatus AccountStatus
        {
            get
            {
                return this.accountStatusField;
            }
            set
            {
                this.accountStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AccountStatusSpecified
        {
            get
            {
                return this.accountStatusFieldSpecified;
            }
            set
            {
                this.accountStatusFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Branch
        {
            get
            {
                return this.branchField;
            }
            set
            {
                this.branchField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public Collateral[] CollateralsList
        {
            get
            {
                return this.collateralsListField;
            }
            set
            {
                this.collateralsListField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ContractCode
        {
            get
            {
                return this.contractCodeField;
            }
            set
            {
                this.contractCodeField = value;
            }
        }

        /// <remarks/>
        public Currency CurrencyOfFacility
        {
            get
            {
                return this.currencyOfFacilityField;
            }
            set
            {
                this.currencyOfFacilityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CurrencyOfFacilitySpecified
        {
            get
            {
                return this.currencyOfFacilityFieldSpecified;
            }
            set
            {
                this.currencyOfFacilityFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DateAccountOpened
        {
            get
            {
                return this.dateAccountOpenedField;
            }
            set
            {
                this.dateAccountOpenedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateAccountOpenedSpecified
        {
            get
            {
                return this.dateAccountOpenedFieldSpecified;
            }
            set
            {
                this.dateAccountOpenedFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DateOfLastPayment
        {
            get
            {
                return this.dateOfLastPaymentField;
            }
            set
            {
                this.dateOfLastPaymentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOfLastPaymentSpecified
        {
            get
            {
                return this.dateOfLastPaymentFieldSpecified;
            }
            set
            {
                this.dateOfLastPaymentFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int DaysInArrears
        {
            get
            {
                return this.daysInArrearsField;
            }
            set
            {
                this.daysInArrearsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DaysInArrearsSpecified
        {
            get
            {
                return this.daysInArrearsFieldSpecified;
            }
            set
            {
                this.daysInArrearsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Disputes Disputes
        {
            get
            {
                return this.disputesField;
            }
            set
            {
                this.disputesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> ExpectedEndDate
        {
            get
            {
                return this.expectedEndDateField;
            }
            set
            {
                this.expectedEndDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ExpectedEndDateSpecified
        {
            get
            {
                return this.expectedEndDateFieldSpecified;
            }
            set
            {
                this.expectedEndDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 InstallmentAmount
        {
            get
            {
                return this.installmentAmountField;
            }
            set
            {
                this.installmentAmountField = value;
            }
        }

        /// <remarks/>
        public int InstallmentsInArrears
        {
            get
            {
                return this.installmentsInArrearsField;
            }
            set
            {
                this.installmentsInArrearsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InstallmentsInArrearsSpecified
        {
            get
            {
                return this.installmentsInArrearsFieldSpecified;
            }
            set
            {
                this.installmentsInArrearsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public NegativeStatusOfContract NegativeStatusOfContract
        {
            get
            {
                return this.negativeStatusOfContractField;
            }
            set
            {
                this.negativeStatusOfContractField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NegativeStatusOfContractSpecified
        {
            get
            {
                return this.negativeStatusOfContractFieldSpecified;
            }
            set
            {
                this.negativeStatusOfContractFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 OriginalAmount
        {
            get
            {
                return this.originalAmountField;
            }
            set
            {
                this.originalAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 OutstandingAmount
        {
            get
            {
                return this.outstandingAmountField;
            }
            set
            {
                this.outstandingAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 OverdueBalance
        {
            get
            {
                return this.overdueBalanceField;
            }
            set
            {
                this.overdueBalanceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public CalendarItem[] PaymentCalendarList
        {
            get
            {
                return this.paymentCalendarListField;
            }
            set
            {
                this.paymentCalendarListField = value;
            }
        }

        /// <remarks/>
        public PaymentPeriodicity PaymentFrequency
        {
            get
            {
                return this.paymentFrequencyField;
            }
            set
            {
                this.paymentFrequencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PaymentFrequencySpecified
        {
            get
            {
                return this.paymentFrequencyFieldSpecified;
            }
            set
            {
                this.paymentFrequencyFieldSpecified = value;
            }
        }

        /// <remarks/>
        public PhaseOfContract PhaseOfContract
        {
            get
            {
                return this.phaseOfContractField;
            }
            set
            {
                this.phaseOfContractField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PhaseOfContractSpecified
        {
            get
            {
                return this.phaseOfContractFieldSpecified;
            }
            set
            {
                this.phaseOfContractFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> RealEndDate
        {
            get
            {
                return this.realEndDateField;
            }
            set
            {
                this.realEndDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RealEndDateSpecified
        {
            get
            {
                return this.realEndDateFieldSpecified;
            }
            set
            {
                this.realEndDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public RelatedSubject[] RelatedSubjectsList
        {
            get
            {
                return this.relatedSubjectsListField;
            }
            set
            {
                this.relatedSubjectsListField = value;
            }
        }

        /// <remarks/>
        public RoleOfCustomer RoleOfClient
        {
            get
            {
                return this.roleOfClientField;
            }
            set
            {
                this.roleOfClientField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RoleOfClientSpecified
        {
            get
            {
                return this.roleOfClientFieldSpecified;
            }
            set
            {
                this.roleOfClientFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Subscriber
        {
            get
            {
                return this.subscriberField;
            }
            set
            {
                this.subscriberField = value;
            }
        }

        /// <remarks/>
        public Sector1 SubscriberType
        {
            get
            {
                return this.subscriberTypeField;
            }
            set
            {
                this.subscriberTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubscriberTypeSpecified
        {
            get
            {
                return this.subscriberTypeFieldSpecified;
            }
            set
            {
                this.subscriberTypeFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum NegativeStatusOfContract
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        NoNegativeStatus,

        /// <remarks/>
        Blocked,

        /// <remarks/>
        LoanWrittenOff,

        /// <remarks/>
        Deferred,

        /// <remarks/>
        Dormant,

        /// <remarks/>
        LegalAction,

        /// <remarks/>
        Suspended,

        /// <remarks/>
        NotUpdated,

        /// <remarks/>
        Collection,

        /// <remarks/>
        Revoked,

        /// <remarks/>
        DisabilityDeceased,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum PaymentPeriodicity
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        FinalDay,

        /// <remarks/>
        Days7,

        /// <remarks/>
        Days15,

        /// <remarks/>
        Days30,

        /// <remarks/>
        Days60,

        /// <remarks/>
        Days90,

        /// <remarks/>
        Days120,

        /// <remarks/>
        Days150,

        /// <remarks/>
        Days180,

        /// <remarks/>
        Days360,

        /// <remarks/>
        Irregular,

        /// <remarks/>
        Days210,

        /// <remarks/>
        Days240,

        /// <remarks/>
        Days270,

        /// <remarks/>
        Days300,

        /// <remarks/>
        Days330,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Contracts")]
    public partial class Contracts
    {

        private Contract1[] contractListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public Contract1[] ContractList
        {
            get
            {
                return this.contractListField;
            }
            set
            {
                this.contractListField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/ContractSummary")]
    public partial class SectorInfo
    {

        private int debtorClosedContractsField;

        private bool debtorClosedContractsFieldSpecified;

        private Amount1 debtorCurrentBalanceSumField;

        private Amount1 debtorMonthlyPaymentSumField;

        private int debtorOpenContractsField;

        private bool debtorOpenContractsFieldSpecified;

        private Amount1 debtorOriginalAmountSumField;

        private Amount1 debtorOverdueBalanceSumField;

        private int guarantorClosedContractsField;

        private bool guarantorClosedContractsFieldSpecified;

        private Amount1 guarantorCurrentBalanceSumField;

        private Amount1 guarantorMonthlyPaymentSumField;

        private int guarantorOpenContractsField;

        private bool guarantorOpenContractsFieldSpecified;

        private Amount1 guarantorOriginalAmountSumField;

        private Amount1 guarantorOverdueBalanceSumField;

        private Sector1 sectorField;

        private bool sectorFieldSpecified;

        /// <remarks/>
        public int DebtorClosedContracts
        {
            get
            {
                return this.debtorClosedContractsField;
            }
            set
            {
                this.debtorClosedContractsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DebtorClosedContractsSpecified
        {
            get
            {
                return this.debtorClosedContractsFieldSpecified;
            }
            set
            {
                this.debtorClosedContractsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 DebtorCurrentBalanceSum
        {
            get
            {
                return this.debtorCurrentBalanceSumField;
            }
            set
            {
                this.debtorCurrentBalanceSumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 DebtorMonthlyPaymentSum
        {
            get
            {
                return this.debtorMonthlyPaymentSumField;
            }
            set
            {
                this.debtorMonthlyPaymentSumField = value;
            }
        }

        /// <remarks/>
        public int DebtorOpenContracts
        {
            get
            {
                return this.debtorOpenContractsField;
            }
            set
            {
                this.debtorOpenContractsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DebtorOpenContractsSpecified
        {
            get
            {
                return this.debtorOpenContractsFieldSpecified;
            }
            set
            {
                this.debtorOpenContractsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 DebtorOriginalAmountSum
        {
            get
            {
                return this.debtorOriginalAmountSumField;
            }
            set
            {
                this.debtorOriginalAmountSumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 DebtorOverdueBalanceSum
        {
            get
            {
                return this.debtorOverdueBalanceSumField;
            }
            set
            {
                this.debtorOverdueBalanceSumField = value;
            }
        }

        /// <remarks/>
        public int GuarantorClosedContracts
        {
            get
            {
                return this.guarantorClosedContractsField;
            }
            set
            {
                this.guarantorClosedContractsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GuarantorClosedContractsSpecified
        {
            get
            {
                return this.guarantorClosedContractsFieldSpecified;
            }
            set
            {
                this.guarantorClosedContractsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 GuarantorCurrentBalanceSum
        {
            get
            {
                return this.guarantorCurrentBalanceSumField;
            }
            set
            {
                this.guarantorCurrentBalanceSumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 GuarantorMonthlyPaymentSum
        {
            get
            {
                return this.guarantorMonthlyPaymentSumField;
            }
            set
            {
                this.guarantorMonthlyPaymentSumField = value;
            }
        }

        /// <remarks/>
        public int GuarantorOpenContracts
        {
            get
            {
                return this.guarantorOpenContractsField;
            }
            set
            {
                this.guarantorOpenContractsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GuarantorOpenContractsSpecified
        {
            get
            {
                return this.guarantorOpenContractsFieldSpecified;
            }
            set
            {
                this.guarantorOpenContractsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 GuarantorOriginalAmountSum
        {
            get
            {
                return this.guarantorOriginalAmountSumField;
            }
            set
            {
                this.guarantorOriginalAmountSumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 GuarantorOverdueBalanceSum
        {
            get
            {
                return this.guarantorOverdueBalanceSumField;
            }
            set
            {
                this.guarantorOverdueBalanceSumField = value;
            }
        }

        /// <remarks/>
        public Sector1 Sector
        {
            get
            {
                return this.sectorField;
            }
            set
            {
                this.sectorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SectorSpecified
        {
            get
            {
                return this.sectorFieldSpecified;
            }
            set
            {
                this.sectorFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/ContractSummary")]
    public partial class PaymentCalendar
    {

        private int contractsSubmittedField;

        private bool contractsSubmittedFieldSpecified;

        private Amount1 currentBalanceField;

        private System.DateTime dateField;

        private bool dateFieldSpecified;

        private System.Nullable<int> daysInArrearsField;

        private bool daysInArrearsFieldSpecified;

        private System.Nullable<int> installmentsInArrearsField;

        private bool installmentsInArrearsFieldSpecified;

        private Amount1 monthlyPaymentField;

        private Amount1 overdueBalanceField;

        /// <remarks/>
        public int ContractsSubmitted
        {
            get
            {
                return this.contractsSubmittedField;
            }
            set
            {
                this.contractsSubmittedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ContractsSubmittedSpecified
        {
            get
            {
                return this.contractsSubmittedFieldSpecified;
            }
            set
            {
                this.contractsSubmittedFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 CurrentBalance
        {
            get
            {
                return this.currentBalanceField;
            }
            set
            {
                this.currentBalanceField = value;
            }
        }

        /// <remarks/>
        public System.DateTime Date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateSpecified
        {
            get
            {
                return this.dateFieldSpecified;
            }
            set
            {
                this.dateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> DaysInArrears
        {
            get
            {
                return this.daysInArrearsField;
            }
            set
            {
                this.daysInArrearsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DaysInArrearsSpecified
        {
            get
            {
                return this.daysInArrearsFieldSpecified;
            }
            set
            {
                this.daysInArrearsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> InstallmentsInArrears
        {
            get
            {
                return this.installmentsInArrearsField;
            }
            set
            {
                this.installmentsInArrearsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InstallmentsInArrearsSpecified
        {
            get
            {
                return this.installmentsInArrearsFieldSpecified;
            }
            set
            {
                this.installmentsInArrearsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 MonthlyPayment
        {
            get
            {
                return this.monthlyPaymentField;
            }
            set
            {
                this.monthlyPaymentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 OverdueBalance
        {
            get
            {
                return this.overdueBalanceField;
            }
            set
            {
                this.overdueBalanceField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/ContractSummary")]
    public partial class Overall
    {

        private System.Nullable<System.DateTime> lastDelinquency90PlusDaysField;

        private bool lastDelinquency90PlusDaysFieldSpecified;

        private int maxDueInstallmentsClosedContractsField;

        private bool maxDueInstallmentsClosedContractsFieldSpecified;

        private int maxDueInstallmentsOpenContractsField;

        private bool maxDueInstallmentsOpenContractsFieldSpecified;

        private int worstDaysInArrearsField;

        private bool worstDaysInArrearsFieldSpecified;

        private Amount1 worstOverdueBalanceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> LastDelinquency90PlusDays
        {
            get
            {
                return this.lastDelinquency90PlusDaysField;
            }
            set
            {
                this.lastDelinquency90PlusDaysField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastDelinquency90PlusDaysSpecified
        {
            get
            {
                return this.lastDelinquency90PlusDaysFieldSpecified;
            }
            set
            {
                this.lastDelinquency90PlusDaysFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int MaxDueInstallmentsClosedContracts
        {
            get
            {
                return this.maxDueInstallmentsClosedContractsField;
            }
            set
            {
                this.maxDueInstallmentsClosedContractsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaxDueInstallmentsClosedContractsSpecified
        {
            get
            {
                return this.maxDueInstallmentsClosedContractsFieldSpecified;
            }
            set
            {
                this.maxDueInstallmentsClosedContractsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int MaxDueInstallmentsOpenContracts
        {
            get
            {
                return this.maxDueInstallmentsOpenContractsField;
            }
            set
            {
                this.maxDueInstallmentsOpenContractsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaxDueInstallmentsOpenContractsSpecified
        {
            get
            {
                return this.maxDueInstallmentsOpenContractsFieldSpecified;
            }
            set
            {
                this.maxDueInstallmentsOpenContractsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int WorstDaysInArrears
        {
            get
            {
                return this.worstDaysInArrearsField;
            }
            set
            {
                this.worstDaysInArrearsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WorstDaysInArrearsSpecified
        {
            get
            {
                return this.worstDaysInArrearsFieldSpecified;
            }
            set
            {
                this.worstDaysInArrearsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 WorstOverdueBalance
        {
            get
            {
                return this.worstOverdueBalanceField;
            }
            set
            {
                this.worstOverdueBalanceField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/ContractSummary")]
    public partial class Guarantor
    {

        private int closedContractsField;

        private bool closedContractsFieldSpecified;

        private Amount1 currentBalanceSumField;

        private Amount1 monthlyPaymentSumField;

        private int openContractsField;

        private bool openContractsFieldSpecified;

        private Amount1 originalAmountSumField;

        private Amount1 overdueBalanceSumField;

        /// <remarks/>
        public int ClosedContracts
        {
            get
            {
                return this.closedContractsField;
            }
            set
            {
                this.closedContractsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ClosedContractsSpecified
        {
            get
            {
                return this.closedContractsFieldSpecified;
            }
            set
            {
                this.closedContractsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 CurrentBalanceSum
        {
            get
            {
                return this.currentBalanceSumField;
            }
            set
            {
                this.currentBalanceSumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 MonthlyPaymentSum
        {
            get
            {
                return this.monthlyPaymentSumField;
            }
            set
            {
                this.monthlyPaymentSumField = value;
            }
        }

        /// <remarks/>
        public int OpenContracts
        {
            get
            {
                return this.openContractsField;
            }
            set
            {
                this.openContractsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OpenContractsSpecified
        {
            get
            {
                return this.openContractsFieldSpecified;
            }
            set
            {
                this.openContractsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 OriginalAmountSum
        {
            get
            {
                return this.originalAmountSumField;
            }
            set
            {
                this.originalAmountSumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 OverdueBalanceSum
        {
            get
            {
                return this.overdueBalanceSumField;
            }
            set
            {
                this.overdueBalanceSumField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/ContractSummary")]
    public partial class Debtor
    {

        private int closedContractsField;

        private bool closedContractsFieldSpecified;

        private Amount1 currentBalanceSumField;

        private Amount1 monthlyPaymentSumField;

        private int openContractsField;

        private bool openContractsFieldSpecified;

        private Amount1 originalAmountSumField;

        private Amount1 overdueBalanceSumField;

        /// <remarks/>
        public int ClosedContracts
        {
            get
            {
                return this.closedContractsField;
            }
            set
            {
                this.closedContractsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ClosedContractsSpecified
        {
            get
            {
                return this.closedContractsFieldSpecified;
            }
            set
            {
                this.closedContractsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 CurrentBalanceSum
        {
            get
            {
                return this.currentBalanceSumField;
            }
            set
            {
                this.currentBalanceSumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 MonthlyPaymentSum
        {
            get
            {
                return this.monthlyPaymentSumField;
            }
            set
            {
                this.monthlyPaymentSumField = value;
            }
        }

        /// <remarks/>
        public int OpenContracts
        {
            get
            {
                return this.openContractsField;
            }
            set
            {
                this.openContractsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OpenContractsSpecified
        {
            get
            {
                return this.openContractsFieldSpecified;
            }
            set
            {
                this.openContractsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 OriginalAmountSum
        {
            get
            {
                return this.originalAmountSumField;
            }
            set
            {
                this.originalAmountSumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 OverdueBalanceSum
        {
            get
            {
                return this.overdueBalanceSumField;
            }
            set
            {
                this.overdueBalanceSumField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/ContractSummary")]
    public partial class AffordabilitySummary
    {

        private Amount1 monthlyAffordabilityField;

        private System.Nullable<decimal> monthlyInstallmentToIncomeRatioField;

        private bool monthlyInstallmentToIncomeRatioFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 MonthlyAffordability
        {
            get
            {
                return this.monthlyAffordabilityField;
            }
            set
            {
                this.monthlyAffordabilityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> MonthlyInstallmentToIncomeRatio
        {
            get
            {
                return this.monthlyInstallmentToIncomeRatioField;
            }
            set
            {
                this.monthlyInstallmentToIncomeRatioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MonthlyInstallmentToIncomeRatioSpecified
        {
            get
            {
                return this.monthlyInstallmentToIncomeRatioFieldSpecified;
            }
            set
            {
                this.monthlyInstallmentToIncomeRatioFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/ContractSummary")]
    public partial class AffordabilityHistory
    {

        private int monthField;

        private bool monthFieldSpecified;

        private Amount1 monthlyAffordabilityField;

        private int yearField;

        private bool yearFieldSpecified;

        /// <remarks/>
        public int Month
        {
            get
            {
                return this.monthField;
            }
            set
            {
                this.monthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MonthSpecified
        {
            get
            {
                return this.monthFieldSpecified;
            }
            set
            {
                this.monthFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 MonthlyAffordability
        {
            get
            {
                return this.monthlyAffordabilityField;
            }
            set
            {
                this.monthlyAffordabilityField = value;
            }
        }

        /// <remarks/>
        public int Year
        {
            get
            {
                return this.yearField;
            }
            set
            {
                this.yearField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool YearSpecified
        {
            get
            {
                return this.yearFieldSpecified;
            }
            set
            {
                this.yearFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/ContractSummary")]
    public partial class ContractSummary
    {

        private AffordabilityHistory[] affordabilityHistoryListField;

        private AffordabilitySummary affordabilitySummaryField;

        private Debtor debtorField;

        private Guarantor guarantorField;

        private Overall overallField;

        private PaymentCalendar[] paymentCalendarListField;

        private SectorInfo[] sectorInfoListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public AffordabilityHistory[] AffordabilityHistoryList
        {
            get
            {
                return this.affordabilityHistoryListField;
            }
            set
            {
                this.affordabilityHistoryListField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public AffordabilitySummary AffordabilitySummary
        {
            get
            {
                return this.affordabilitySummaryField;
            }
            set
            {
                this.affordabilitySummaryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Debtor Debtor
        {
            get
            {
                return this.debtorField;
            }
            set
            {
                this.debtorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Guarantor Guarantor
        {
            get
            {
                return this.guarantorField;
            }
            set
            {
                this.guarantorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Overall Overall
        {
            get
            {
                return this.overallField;
            }
            set
            {
                this.overallField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public PaymentCalendar[] PaymentCalendarList
        {
            get
            {
                return this.paymentCalendarListField;
            }
            set
            {
                this.paymentCalendarListField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public SectorInfo[] SectorInfoList
        {
            get
            {
                return this.sectorInfoListField;
            }
            set
            {
                this.sectorInfoListField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/ContractOverview")]
    public partial class Contract
    {

        private TypeOfContract1 accountProductTypeField;

        private bool accountProductTypeFieldSpecified;

        private ContractStatus accountStatusField;

        private bool accountStatusFieldSpecified;

        private Amount1 currentBalanceField;

        private System.Nullable<System.DateTime> dateAccountOpenedField;

        private bool dateAccountOpenedFieldSpecified;

        private int daysInArrearsField;

        private bool daysInArrearsFieldSpecified;

        private Amount1 originalAmountField;

        private Amount1 overdueBalanceField;

        private PhaseOfContract phaseOfContractField;

        private bool phaseOfContractFieldSpecified;

        private RoleOfCustomer roleOfClientField;

        private bool roleOfClientFieldSpecified;

        private Sector1 sectorField;

        private bool sectorFieldSpecified;

        /// <remarks/>
        public TypeOfContract1 AccountProductType
        {
            get
            {
                return this.accountProductTypeField;
            }
            set
            {
                this.accountProductTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AccountProductTypeSpecified
        {
            get
            {
                return this.accountProductTypeFieldSpecified;
            }
            set
            {
                this.accountProductTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public ContractStatus AccountStatus
        {
            get
            {
                return this.accountStatusField;
            }
            set
            {
                this.accountStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AccountStatusSpecified
        {
            get
            {
                return this.accountStatusFieldSpecified;
            }
            set
            {
                this.accountStatusFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 CurrentBalance
        {
            get
            {
                return this.currentBalanceField;
            }
            set
            {
                this.currentBalanceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DateAccountOpened
        {
            get
            {
                return this.dateAccountOpenedField;
            }
            set
            {
                this.dateAccountOpenedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateAccountOpenedSpecified
        {
            get
            {
                return this.dateAccountOpenedFieldSpecified;
            }
            set
            {
                this.dateAccountOpenedFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int DaysInArrears
        {
            get
            {
                return this.daysInArrearsField;
            }
            set
            {
                this.daysInArrearsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DaysInArrearsSpecified
        {
            get
            {
                return this.daysInArrearsFieldSpecified;
            }
            set
            {
                this.daysInArrearsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 OriginalAmount
        {
            get
            {
                return this.originalAmountField;
            }
            set
            {
                this.originalAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 OverdueBalance
        {
            get
            {
                return this.overdueBalanceField;
            }
            set
            {
                this.overdueBalanceField = value;
            }
        }

        /// <remarks/>
        public PhaseOfContract PhaseOfContract
        {
            get
            {
                return this.phaseOfContractField;
            }
            set
            {
                this.phaseOfContractField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PhaseOfContractSpecified
        {
            get
            {
                return this.phaseOfContractFieldSpecified;
            }
            set
            {
                this.phaseOfContractFieldSpecified = value;
            }
        }

        /// <remarks/>
        public RoleOfCustomer RoleOfClient
        {
            get
            {
                return this.roleOfClientField;
            }
            set
            {
                this.roleOfClientField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RoleOfClientSpecified
        {
            get
            {
                return this.roleOfClientFieldSpecified;
            }
            set
            {
                this.roleOfClientFieldSpecified = value;
            }
        }

        /// <remarks/>
        public Sector1 Sector
        {
            get
            {
                return this.sectorField;
            }
            set
            {
                this.sectorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SectorSpecified
        {
            get
            {
                return this.sectorFieldSpecified;
            }
            set
            {
                this.sectorFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/ContractOverview")]
    public partial class ContractOverview
    {

        private Contract[] contractListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public Contract[] ContractList
        {
            get
            {
                return this.contractListField;
            }
            set
            {
                this.contractListField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Identifications", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CompanySimple")]
    public partial class Identifications1
    {

        private string pinNumberField;

        private string registrationNumberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PinNumber
        {
            get
            {
                return this.pinNumberField;
            }
            set
            {
                this.pinNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumberField;
            }
            set
            {
                this.registrationNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "General", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CompanySimple")]
    public partial class General1
    {

        private LegalForm1 companyTypeField;

        private bool companyTypeFieldSpecified;

        private string registeredNameField;

        private System.Nullable<System.DateTime> registrationDateField;

        private bool registrationDateFieldSpecified;

        private string tradingNameField;

        private BusinessStatus1 tradingStatusField;

        private bool tradingStatusFieldSpecified;

        /// <remarks/>
        public LegalForm1 CompanyType
        {
            get
            {
                return this.companyTypeField;
            }
            set
            {
                this.companyTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CompanyTypeSpecified
        {
            get
            {
                return this.companyTypeFieldSpecified;
            }
            set
            {
                this.companyTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string RegisteredName
        {
            get
            {
                return this.registeredNameField;
            }
            set
            {
                this.registeredNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> RegistrationDate
        {
            get
            {
                return this.registrationDateField;
            }
            set
            {
                this.registrationDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RegistrationDateSpecified
        {
            get
            {
                return this.registrationDateFieldSpecified;
            }
            set
            {
                this.registrationDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string TradingName
        {
            get
            {
                return this.tradingNameField;
            }
            set
            {
                this.tradingNameField = value;
            }
        }

        /// <remarks/>
        public BusinessStatus1 TradingStatus
        {
            get
            {
                return this.tradingStatusField;
            }
            set
            {
                this.tradingStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TradingStatusSpecified
        {
            get
            {
                return this.tradingStatusFieldSpecified;
            }
            set
            {
                this.tradingStatusFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "LegalForm", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum LegalForm1
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        JointLiabilityCompany,

        /// <remarks/>
        SpecialPartnershipCompany,

        /// <remarks/>
        LimitedLiabilityCompanyPublic,

        /// <remarks/>
        LimitedLiabilityCompanyPrivate,

        /// <remarks/>
        JointStockCompany,

        /// <remarks/>
        Cooperative,

        /// <remarks/>
        Foundations,

        /// <remarks/>
        Association,

        /// <remarks/>
        Audit,

        /// <remarks/>
        Notary,

        /// <remarks/>
        CoPartnership,

        /// <remarks/>
        NonRegisteredAssociation,

        /// <remarks/>
        ReligiousOrganization,

        /// <remarks/>
        GovernmentalInstitution,

        /// <remarks/>
        Political,

        /// <remarks/>
        PublicInstitution,

        /// <remarks/>
        Entrepreneur,

        /// <remarks/>
        SoleProprietor,

        /// <remarks/>
        Society,

        /// <remarks/>
        InvestmentGroup,

        /// <remarks/>
        NongovernmentalOrganization,

        /// <remarks/>
        School,

        /// <remarks/>
        LimitedLiabilityCompany,

        /// <remarks/>
        RuralBusinessEntity,

        /// <remarks/>
        CV,

        /// <remarks/>
        GroupDebtor,

        /// <remarks/>
        SeaTransport,

        /// <remarks/>
        Firm,

        /// <remarks/>
        CooperativeAssociation,

        /// <remarks/>
        ParentCooperative,

        /// <remarks/>
        VillageCooperative,

        /// <remarks/>
        Limited,

        /// <remarks/>
        MaskapaiAndilIndonesia,

        /// <remarks/>
        NV,

        /// <remarks/>
        RegionalCompany,

        /// <remarks/>
        StateOwnedCompany,

        /// <remarks/>
        Other,

        /// <remarks/>
        CivilFellowship,

        /// <remarks/>
        CivicCompany,

        /// <remarks/>
        PrimaryCooperative,

        /// <remarks/>
        CooperativeCenter,

        /// <remarks/>
        VillageCooperativeCenter,

        /// <remarks/>
        TradeEnterprise,

        /// <remarks/>
        RuralLoanTradeUnit,

        /// <remarks/>
        GovernmentOrStateOrganization,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "BusinessStatus", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum BusinessStatus1
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Active,

        /// <remarks/>
        Closed,

        /// <remarks/>
        SupervisoryCrisisAdministration,

        /// <remarks/>
        Liquidation,

        /// <remarks/>
        Dormant,

        /// <remarks/>
        Liquidated,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CompanySimple")]
    public partial class CompanySimple
    {

        private General1 generalField;

        private Identifications1 identificationsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public General1 General
        {
            get
            {
                return this.generalField;
            }
            set
            {
                this.generalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Identifications1 Identifications
        {
            get
            {
                return this.identificationsField;
            }
            set
            {
                this.identificationsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Company")]
    public partial class SecondaryAddress
    {

        private string addressLineField;

        private CountryCode countryField;

        private bool countryFieldSpecified;

        private string districtField;

        private string plotNumberField;

        private string postalCodeField;

        private string regionField;

        private string streetField;

        private string townField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AddressLine
        {
            get
            {
                return this.addressLineField;
            }
            set
            {
                this.addressLineField = value;
            }
        }

        /// <remarks/>
        public CountryCode Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountrySpecified
        {
            get
            {
                return this.countryFieldSpecified;
            }
            set
            {
                this.countryFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string District
        {
            get
            {
                return this.districtField;
            }
            set
            {
                this.districtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PlotNumber
        {
            get
            {
                return this.plotNumberField;
            }
            set
            {
                this.plotNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Region
        {
            get
            {
                return this.regionField;
            }
            set
            {
                this.regionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Street
        {
            get
            {
                return this.streetField;
            }
            set
            {
                this.streetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Town
        {
            get
            {
                return this.townField;
            }
            set
            {
                this.townField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Company")]
    public partial class MainAddress
    {

        private string addressLineField;

        private CountryCode countryField;

        private bool countryFieldSpecified;

        private string districtField;

        private string plotNumberField;

        private string postalCodeField;

        private string regionField;

        private string streetField;

        private string townField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AddressLine
        {
            get
            {
                return this.addressLineField;
            }
            set
            {
                this.addressLineField = value;
            }
        }

        /// <remarks/>
        public CountryCode Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountrySpecified
        {
            get
            {
                return this.countryFieldSpecified;
            }
            set
            {
                this.countryFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string District
        {
            get
            {
                return this.districtField;
            }
            set
            {
                this.districtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PlotNumber
        {
            get
            {
                return this.plotNumberField;
            }
            set
            {
                this.plotNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Region
        {
            get
            {
                return this.regionField;
            }
            set
            {
                this.regionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Street
        {
            get
            {
                return this.streetField;
            }
            set
            {
                this.streetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Town
        {
            get
            {
                return this.townField;
            }
            set
            {
                this.townField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Company")]
    public partial class Identifications
    {

        private System.Nullable<System.DateTime> businessLicenseExpirationDateField;

        private bool businessLicenseExpirationDateFieldSpecified;

        private string pinNumberField;

        private string registrationNumberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> BusinessLicenseExpirationDate
        {
            get
            {
                return this.businessLicenseExpirationDateField;
            }
            set
            {
                this.businessLicenseExpirationDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BusinessLicenseExpirationDateSpecified
        {
            get
            {
                return this.businessLicenseExpirationDateFieldSpecified;
            }
            set
            {
                this.businessLicenseExpirationDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PinNumber
        {
            get
            {
                return this.pinNumberField;
            }
            set
            {
                this.pinNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumberField;
            }
            set
            {
                this.registrationNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Company")]
    public partial class General
    {

        private LegalForm1 companyTypeField;

        private bool companyTypeFieldSpecified;

        private IndustrySector1 industryCodeField;

        private bool industryCodeFieldSpecified;

        private string registeredNameField;

        private System.Nullable<System.DateTime> registrationDateField;

        private bool registrationDateFieldSpecified;

        private string tradingNameField;

        private BusinessStatus1 tradingStatusField;

        private bool tradingStatusFieldSpecified;

        /// <remarks/>
        public LegalForm1 CompanyType
        {
            get
            {
                return this.companyTypeField;
            }
            set
            {
                this.companyTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CompanyTypeSpecified
        {
            get
            {
                return this.companyTypeFieldSpecified;
            }
            set
            {
                this.companyTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public IndustrySector1 IndustryCode
        {
            get
            {
                return this.industryCodeField;
            }
            set
            {
                this.industryCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IndustryCodeSpecified
        {
            get
            {
                return this.industryCodeFieldSpecified;
            }
            set
            {
                this.industryCodeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string RegisteredName
        {
            get
            {
                return this.registeredNameField;
            }
            set
            {
                this.registeredNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> RegistrationDate
        {
            get
            {
                return this.registrationDateField;
            }
            set
            {
                this.registrationDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RegistrationDateSpecified
        {
            get
            {
                return this.registrationDateFieldSpecified;
            }
            set
            {
                this.registrationDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string TradingName
        {
            get
            {
                return this.tradingNameField;
            }
            set
            {
                this.tradingNameField = value;
            }
        }

        /// <remarks/>
        public BusinessStatus1 TradingStatus
        {
            get
            {
                return this.tradingStatusField;
            }
            set
            {
                this.tradingStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TradingStatusSpecified
        {
            get
            {
                return this.tradingStatusFieldSpecified;
            }
            set
            {
                this.tradingStatusFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "IndustrySector", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum IndustrySector1
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Agriculture,

        /// <remarks/>
        FinancialIntermediaries,

        /// <remarks/>
        MiningAndQuarrying,

        /// <remarks/>
        BuildingAndConstruction,

        /// <remarks/>
        HotelsAndRestaurants,

        /// <remarks/>
        Manufacturing,

        /// <remarks/>
        OtherServices,

        /// <remarks/>
        RealEstate,

        /// <remarks/>
        Trade,

        /// <remarks/>
        TransportAndCommunication,

        /// <remarks/>
        Water,

        /// <remarks/>
        Government,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Company")]
    public partial class Contact
    {

        private string mainTelephoneNumberField;

        private string otherTelephoneNumberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string MainTelephoneNumber
        {
            get
            {
                return this.mainTelephoneNumberField;
            }
            set
            {
                this.mainTelephoneNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string OtherTelephoneNumber
        {
            get
            {
                return this.otherTelephoneNumberField;
            }
            set
            {
                this.otherTelephoneNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/Company")]
    public partial class Company
    {

        private Contact contactField;

        private General generalField;

        private Identifications identificationsField;

        private MainAddress mainAddressField;

        private SecondaryAddress secondaryAddressField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Contact Contact
        {
            get
            {
                return this.contactField;
            }
            set
            {
                this.contactField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public General General
        {
            get
            {
                return this.generalField;
            }
            set
            {
                this.generalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Identifications Identifications
        {
            get
            {
                return this.identificationsField;
            }
            set
            {
                this.identificationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public MainAddress MainAddress
        {
            get
            {
                return this.mainAddressField;
            }
            set
            {
                this.mainAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SecondaryAddress SecondaryAddress
        {
            get
            {
                return this.secondaryAddressField;
            }
            set
            {
                this.secondaryAddressField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CIQ")]
    public partial class Summary
    {

        private System.Nullable<System.DateTime> dateOfLastFraudRegistrationPrimarySubjectField;

        private bool dateOfLastFraudRegistrationPrimarySubjectFieldSpecified;

        private System.Nullable<System.DateTime> dateOfLastFraudRegistrationThirdPartyField;

        private bool dateOfLastFraudRegistrationThirdPartyFieldSpecified;

        private int numberOfFraudAlertsPrimarySubjectField;

        private bool numberOfFraudAlertsPrimarySubjectFieldSpecified;

        private int numberOfFraudAlertsThirdPartyField;

        private bool numberOfFraudAlertsThirdPartyFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DateOfLastFraudRegistrationPrimarySubject
        {
            get
            {
                return this.dateOfLastFraudRegistrationPrimarySubjectField;
            }
            set
            {
                this.dateOfLastFraudRegistrationPrimarySubjectField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOfLastFraudRegistrationPrimarySubjectSpecified
        {
            get
            {
                return this.dateOfLastFraudRegistrationPrimarySubjectFieldSpecified;
            }
            set
            {
                this.dateOfLastFraudRegistrationPrimarySubjectFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DateOfLastFraudRegistrationThirdParty
        {
            get
            {
                return this.dateOfLastFraudRegistrationThirdPartyField;
            }
            set
            {
                this.dateOfLastFraudRegistrationThirdPartyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOfLastFraudRegistrationThirdPartySpecified
        {
            get
            {
                return this.dateOfLastFraudRegistrationThirdPartyFieldSpecified;
            }
            set
            {
                this.dateOfLastFraudRegistrationThirdPartyFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfFraudAlertsPrimarySubject
        {
            get
            {
                return this.numberOfFraudAlertsPrimarySubjectField;
            }
            set
            {
                this.numberOfFraudAlertsPrimarySubjectField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfFraudAlertsPrimarySubjectSpecified
        {
            get
            {
                return this.numberOfFraudAlertsPrimarySubjectFieldSpecified;
            }
            set
            {
                this.numberOfFraudAlertsPrimarySubjectFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfFraudAlertsThirdParty
        {
            get
            {
                return this.numberOfFraudAlertsThirdPartyField;
            }
            set
            {
                this.numberOfFraudAlertsThirdPartyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfFraudAlertsThirdPartySpecified
        {
            get
            {
                return this.numberOfFraudAlertsThirdPartyFieldSpecified;
            }
            set
            {
                this.numberOfFraudAlertsThirdPartyFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CIQ")]
    public partial class Detail
    {

        private int lostStolenRecordsFoundField;

        private bool lostStolenRecordsFoundFieldSpecified;

        private int numberOfCancelledClosedContractsField;

        private bool numberOfCancelledClosedContractsFieldSpecified;

        /// <remarks/>
        public int LostStolenRecordsFound
        {
            get
            {
                return this.lostStolenRecordsFoundField;
            }
            set
            {
                this.lostStolenRecordsFoundField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LostStolenRecordsFoundSpecified
        {
            get
            {
                return this.lostStolenRecordsFoundFieldSpecified;
            }
            set
            {
                this.lostStolenRecordsFoundFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfCancelledClosedContracts
        {
            get
            {
                return this.numberOfCancelledClosedContractsField;
            }
            set
            {
                this.numberOfCancelledClosedContractsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfCancelledClosedContractsSpecified
        {
            get
            {
                return this.numberOfCancelledClosedContractsFieldSpecified;
            }
            set
            {
                this.numberOfCancelledClosedContractsFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CIQ")]
    public partial class CIQ
    {

        private Detail detailField;

        private Summary summaryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Detail Detail
        {
            get
            {
                return this.detailField;
            }
            set
            {
                this.detailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Summary Summary
        {
            get
            {
                return this.summaryField;
            }
            set
            {
                this.summaryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CIP")]
    public partial class Reason
    {

        private string codeField;

        private string descriptionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "Record", Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CIP")]
    public partial class Record1
    {

        private System.DateTime dateField;

        private bool dateFieldSpecified;

        private RiskGrade gradeField;

        private bool gradeFieldSpecified;

        private decimal probabilityOfDefaultField;

        private bool probabilityOfDefaultFieldSpecified;

        private Reason[] reasonsListField;

        private decimal scoreField;

        private bool scoreFieldSpecified;

        private Trend trendField;

        private bool trendFieldSpecified;

        /// <remarks/>
        public System.DateTime Date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateSpecified
        {
            get
            {
                return this.dateFieldSpecified;
            }
            set
            {
                this.dateFieldSpecified = value;
            }
        }

        /// <remarks/>
        public RiskGrade Grade
        {
            get
            {
                return this.gradeField;
            }
            set
            {
                this.gradeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GradeSpecified
        {
            get
            {
                return this.gradeFieldSpecified;
            }
            set
            {
                this.gradeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal ProbabilityOfDefault
        {
            get
            {
                return this.probabilityOfDefaultField;
            }
            set
            {
                this.probabilityOfDefaultField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ProbabilityOfDefaultSpecified
        {
            get
            {
                return this.probabilityOfDefaultFieldSpecified;
            }
            set
            {
                this.probabilityOfDefaultFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public Reason[] ReasonsList
        {
            get
            {
                return this.reasonsListField;
            }
            set
            {
                this.reasonsListField = value;
            }
        }

        /// <remarks/>
        public decimal Score
        {
            get
            {
                return this.scoreField;
            }
            set
            {
                this.scoreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ScoreSpecified
        {
            get
            {
                return this.scoreFieldSpecified;
            }
            set
            {
                this.scoreFieldSpecified = value;
            }
        }

        /// <remarks/>
        public Trend Trend
        {
            get
            {
                return this.trendField;
            }
            set
            {
                this.trendField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TrendSpecified
        {
            get
            {
                return this.trendFieldSpecified;
            }
            set
            {
                this.trendFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/CIP")]
    public partial class CIP
    {

        private Record1[] recordListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public Record1[] RecordList
        {
            get
            {
                return this.recordListField;
            }
            set
            {
                this.recordListField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/BouncedCheques")]
    public partial class ChequeSubject
    {

        private string alienRegistrationField;

        private ClientClassification clientClassificationField;

        private bool clientClassificationFieldSpecified;

        private string nameField;

        private string nationalIDField;

        private string passportNumberField;

        private string pinNumberField;

        private BouncedChequeRoleOfCustomer roleOfCustomerField;

        private bool roleOfCustomerFieldSpecified;

        private string serviceIdField;

        private SubjectType subjectTypeField;

        private bool subjectTypeFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AlienRegistration
        {
            get
            {
                return this.alienRegistrationField;
            }
            set
            {
                this.alienRegistrationField = value;
            }
        }

        /// <remarks/>
        public ClientClassification ClientClassification
        {
            get
            {
                return this.clientClassificationField;
            }
            set
            {
                this.clientClassificationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ClientClassificationSpecified
        {
            get
            {
                return this.clientClassificationFieldSpecified;
            }
            set
            {
                this.clientClassificationFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string NationalID
        {
            get
            {
                return this.nationalIDField;
            }
            set
            {
                this.nationalIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PassportNumber
        {
            get
            {
                return this.passportNumberField;
            }
            set
            {
                this.passportNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PinNumber
        {
            get
            {
                return this.pinNumberField;
            }
            set
            {
                this.pinNumberField = value;
            }
        }

        /// <remarks/>
        public BouncedChequeRoleOfCustomer RoleOfCustomer
        {
            get
            {
                return this.roleOfCustomerField;
            }
            set
            {
                this.roleOfCustomerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RoleOfCustomerSpecified
        {
            get
            {
                return this.roleOfCustomerFieldSpecified;
            }
            set
            {
                this.roleOfCustomerFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ServiceId
        {
            get
            {
                return this.serviceIdField;
            }
            set
            {
                this.serviceIdField = value;
            }
        }

        /// <remarks/>
        public SubjectType SubjectType
        {
            get
            {
                return this.subjectTypeField;
            }
            set
            {
                this.subjectTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubjectTypeSpecified
        {
            get
            {
                return this.subjectTypeFieldSpecified;
            }
            set
            {
                this.subjectTypeFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum ClientClassification
    {

        /// <remarks/>
        NotSpecified,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum BouncedChequeRoleOfCustomer
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Issuer,

        /// <remarks/>
        Beneficiary,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/BouncedCheques")]
    public partial class Cheque
    {

        private string accountNumberField;

        private AccountStatus accountStatusField;

        private bool accountStatusFieldSpecified;

        private ChequeAccountType accountTypeField;

        private bool accountTypeFieldSpecified;

        private string additionalInformationField;

        private System.Nullable<System.DateTime> bounceDateField;

        private bool bounceDateFieldSpecified;

        private ChequeBounceReason bounceReasonField;

        private bool bounceReasonFieldSpecified;

        private string branchCodeField;

        private Amount1 chequeAmountField;

        private string chequeNumberField;

        private ChequeSubject[] chequeSubjectsListField;

        private string informationSourceContactField;

        private string informationSourceNameField;

        private InformationSourceType informationSourceTypeField;

        private bool informationSourceTypeFieldSpecified;

        private System.Nullable<System.DateTime> issueDateField;

        private bool issueDateFieldSpecified;

        private string subscriberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AccountNumber
        {
            get
            {
                return this.accountNumberField;
            }
            set
            {
                this.accountNumberField = value;
            }
        }

        /// <remarks/>
        public AccountStatus AccountStatus
        {
            get
            {
                return this.accountStatusField;
            }
            set
            {
                this.accountStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AccountStatusSpecified
        {
            get
            {
                return this.accountStatusFieldSpecified;
            }
            set
            {
                this.accountStatusFieldSpecified = value;
            }
        }

        /// <remarks/>
        public ChequeAccountType AccountType
        {
            get
            {
                return this.accountTypeField;
            }
            set
            {
                this.accountTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AccountTypeSpecified
        {
            get
            {
                return this.accountTypeFieldSpecified;
            }
            set
            {
                this.accountTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AdditionalInformation
        {
            get
            {
                return this.additionalInformationField;
            }
            set
            {
                this.additionalInformationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> BounceDate
        {
            get
            {
                return this.bounceDateField;
            }
            set
            {
                this.bounceDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BounceDateSpecified
        {
            get
            {
                return this.bounceDateFieldSpecified;
            }
            set
            {
                this.bounceDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        public ChequeBounceReason BounceReason
        {
            get
            {
                return this.bounceReasonField;
            }
            set
            {
                this.bounceReasonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BounceReasonSpecified
        {
            get
            {
                return this.bounceReasonFieldSpecified;
            }
            set
            {
                this.bounceReasonFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string BranchCode
        {
            get
            {
                return this.branchCodeField;
            }
            set
            {
                this.branchCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 ChequeAmount
        {
            get
            {
                return this.chequeAmountField;
            }
            set
            {
                this.chequeAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ChequeNumber
        {
            get
            {
                return this.chequeNumberField;
            }
            set
            {
                this.chequeNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public ChequeSubject[] ChequeSubjectsList
        {
            get
            {
                return this.chequeSubjectsListField;
            }
            set
            {
                this.chequeSubjectsListField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string InformationSourceContact
        {
            get
            {
                return this.informationSourceContactField;
            }
            set
            {
                this.informationSourceContactField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string InformationSourceName
        {
            get
            {
                return this.informationSourceNameField;
            }
            set
            {
                this.informationSourceNameField = value;
            }
        }

        /// <remarks/>
        public InformationSourceType InformationSourceType
        {
            get
            {
                return this.informationSourceTypeField;
            }
            set
            {
                this.informationSourceTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InformationSourceTypeSpecified
        {
            get
            {
                return this.informationSourceTypeFieldSpecified;
            }
            set
            {
                this.informationSourceTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> IssueDate
        {
            get
            {
                return this.issueDateField;
            }
            set
            {
                this.issueDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IssueDateSpecified
        {
            get
            {
                return this.issueDateFieldSpecified;
            }
            set
            {
                this.issueDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Subscriber
        {
            get
            {
                return this.subscriberField;
            }
            set
            {
                this.subscriberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum AccountStatus
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Active,

        /// <remarks/>
        Closed,

        /// <remarks/>
        WrittenOff,

        /// <remarks/>
        Legal,

        /// <remarks/>
        Collection,

        /// <remarks/>
        Dormant,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum ChequeAccountType
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Corporate,

        /// <remarks/>
        Personal,

        /// <remarks/>
        Dividend,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum ChequeBounceReason
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        InsufficientFunds,

        /// <remarks/>
        Other,

        /// <remarks/>
        NonTechnicalReasons,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public enum InformationSourceType
    {

        /// <remarks/>
        NotSpecified,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport/BouncedCheques")]
    public partial class BouncedCheques
    {

        private Cheque[] chequeListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public Cheque[] ChequeList
        {
            get
            {
                return this.chequeListField;
            }
            set
            {
                this.chequeListField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public partial class CustomReport
    {

        private BouncedCheques bouncedChequesField;

        private CIP cIPField;

        private CIQ cIQField;

        private Company companyField;

        private CompanySimple companySimpleField;

        private ContractOverview contractOverviewField;

        private ContractSummary contractSummaryField;

        private Contracts contractsField;

        private CurrentRelations currentRelationsField;

        private Dashboard dashboardField;

        private Disputes2 disputesField;

        private Individual individualField;

        private IndividualSimple individualSimpleField;

        private Inquiries1 inquiriesField;

        private NegativeContractList negativeContractListField;

        private CustomReportParams parametersField;

        private PolicyRulesCheck policyRulesCheckField;

        private ReportInfo reportInfoField;

        private SubjectInfoHistory subjectInfoHistoryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public BouncedCheques BouncedCheques
        {
            get
            {
                return this.bouncedChequesField;
            }
            set
            {
                this.bouncedChequesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public CIP CIP
        {
            get
            {
                return this.cIPField;
            }
            set
            {
                this.cIPField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public CIQ CIQ
        {
            get
            {
                return this.cIQField;
            }
            set
            {
                this.cIQField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Company Company
        {
            get
            {
                return this.companyField;
            }
            set
            {
                this.companyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public CompanySimple CompanySimple
        {
            get
            {
                return this.companySimpleField;
            }
            set
            {
                this.companySimpleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public ContractOverview ContractOverview
        {
            get
            {
                return this.contractOverviewField;
            }
            set
            {
                this.contractOverviewField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public ContractSummary ContractSummary
        {
            get
            {
                return this.contractSummaryField;
            }
            set
            {
                this.contractSummaryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Contracts Contracts
        {
            get
            {
                return this.contractsField;
            }
            set
            {
                this.contractsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public CurrentRelations CurrentRelations
        {
            get
            {
                return this.currentRelationsField;
            }
            set
            {
                this.currentRelationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Dashboard Dashboard
        {
            get
            {
                return this.dashboardField;
            }
            set
            {
                this.dashboardField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Disputes2 Disputes
        {
            get
            {
                return this.disputesField;
            }
            set
            {
                this.disputesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Individual Individual
        {
            get
            {
                return this.individualField;
            }
            set
            {
                this.individualField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public IndividualSimple IndividualSimple
        {
            get
            {
                return this.individualSimpleField;
            }
            set
            {
                this.individualSimpleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Inquiries1 Inquiries
        {
            get
            {
                return this.inquiriesField;
            }
            set
            {
                this.inquiriesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public NegativeContractList NegativeContractList
        {
            get
            {
                return this.negativeContractListField;
            }
            set
            {
                this.negativeContractListField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public CustomReportParams Parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public PolicyRulesCheck PolicyRulesCheck
        {
            get
            {
                return this.policyRulesCheckField;
            }
            set
            {
                this.policyRulesCheckField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public ReportInfo ReportInfo
        {
            get
            {
                return this.reportInfoField;
            }
            set
            {
                this.reportInfoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SubjectInfoHistory SubjectInfoHistory
        {
            get
            {
                return this.subjectInfoHistoryField;
            }
            set
            {
                this.subjectInfoHistoryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/CustomReport")]
    public partial class CustomReportParams
    {

        private bool consentField;

        private bool consentFieldSpecified;

        private string iDNumberField;

        private IDNumberTypeResolvable iDNumberTypeField;

        private bool iDNumberTypeFieldSpecified;

        private InquiryReasons inquiryReasonField;

        private bool inquiryReasonFieldSpecified;

        private string inquiryReasonTextField;

        private string[] sectionsField;

        private SubjectType subjectTypeField;

        private bool subjectTypeFieldSpecified;

        /// <remarks/>
        public bool Consent
        {
            get
            {
                return this.consentField;
            }
            set
            {
                this.consentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ConsentSpecified
        {
            get
            {
                return this.consentFieldSpecified;
            }
            set
            {
                this.consentFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string IDNumber
        {
            get
            {
                return this.iDNumberField;
            }
            set
            {
                this.iDNumberField = value;
            }
        }

        /// <remarks/>
        public IDNumberTypeResolvable IDNumberType
        {
            get
            {
                return this.iDNumberTypeField;
            }
            set
            {
                this.iDNumberTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IDNumberTypeSpecified
        {
            get
            {
                return this.iDNumberTypeFieldSpecified;
            }
            set
            {
                this.iDNumberTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public InquiryReasons InquiryReason
        {
            get
            {
                return this.inquiryReasonField;
            }
            set
            {
                this.inquiryReasonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InquiryReasonSpecified
        {
            get
            {
                return this.inquiryReasonFieldSpecified;
            }
            set
            {
                this.inquiryReasonFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string InquiryReasonText
        {
            get
            {
                return this.inquiryReasonTextField;
            }
            set
            {
                this.inquiryReasonTextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] Sections
        {
            get
            {
                return this.sectionsField;
            }
            set
            {
                this.sectionsField = value;
            }
        }

        /// <remarks/>
        public SubjectType SubjectType
        {
            get
            {
                return this.subjectTypeField;
            }
            set
            {
                this.subjectTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubjectTypeSpecified
        {
            get
            {
                return this.subjectTypeFieldSpecified;
            }
            set
            {
                this.subjectTypeFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class SearchParameters
    {

        private string cityField;

        private CountryCode countryField;

        private bool countryFieldSpecified;

        private System.Nullable<System.DateTime> dateOfBirthField;

        private bool dateOfBirthFieldSpecified;

        private string firstNameField;

        private string idNumberField;

        private IDNumberType idNumberTypeField;

        private bool idNumberTypeFieldSpecified;

        private string lastNameField;

        private string middleNamesField;

        private string phoneNumberField;

        private string postalCodeField;

        private System.Nullable<int> postalCodeLookupField;

        private bool postalCodeLookupFieldSpecified;

        private string regionField;

        private string streetField;

        private string subjectNameField;

        private string webPageField;

        private System.Nullable<int> yearOfEstablishmentField;

        private bool yearOfEstablishmentFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public CountryCode Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountrySpecified
        {
            get
            {
                return this.countryFieldSpecified;
            }
            set
            {
                this.countryFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                return this.dateOfBirthField;
            }
            set
            {
                this.dateOfBirthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOfBirthSpecified
        {
            get
            {
                return this.dateOfBirthFieldSpecified;
            }
            set
            {
                this.dateOfBirthFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string IdNumber
        {
            get
            {
                return this.idNumberField;
            }
            set
            {
                this.idNumberField = value;
            }
        }

        /// <remarks/>
        public IDNumberType IdNumberType
        {
            get
            {
                return this.idNumberTypeField;
            }
            set
            {
                this.idNumberTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdNumberTypeSpecified
        {
            get
            {
                return this.idNumberTypeFieldSpecified;
            }
            set
            {
                this.idNumberTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string LastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string MiddleNames
        {
            get
            {
                return this.middleNamesField;
            }
            set
            {
                this.middleNamesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumberField;
            }
            set
            {
                this.phoneNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> PostalCodeLookup
        {
            get
            {
                return this.postalCodeLookupField;
            }
            set
            {
                this.postalCodeLookupField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PostalCodeLookupSpecified
        {
            get
            {
                return this.postalCodeLookupFieldSpecified;
            }
            set
            {
                this.postalCodeLookupFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Region
        {
            get
            {
                return this.regionField;
            }
            set
            {
                this.regionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Street
        {
            get
            {
                return this.streetField;
            }
            set
            {
                this.streetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string SubjectName
        {
            get
            {
                return this.subjectNameField;
            }
            set
            {
                this.subjectNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string WebPage
        {
            get
            {
                return this.webPageField;
            }
            set
            {
                this.webPageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> YearOfEstablishment
        {
            get
            {
                return this.yearOfEstablishmentField;
            }
            set
            {
                this.yearOfEstablishmentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool YearOfEstablishmentSpecified
        {
            get
            {
                return this.yearOfEstablishmentFieldSpecified;
            }
            set
            {
                this.yearOfEstablishmentFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum IDNumberType
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        CreditinfoId,

        /// <remarks/>
        TaxNumber,

        /// <remarks/>
        NationalID,

        /// <remarks/>
        RegistrationNumber,

        /// <remarks/>
        PassportNumber,

        /// <remarks/>
        IDCardNumber,

        /// <remarks/>
        DrivingLicenseNumber,

        /// <remarks/>
        VotersID,

        /// <remarks/>
        ForeignUniqueID,

        /// <remarks/>
        CustomIdNumber1,

        /// <remarks/>
        CustomIdNumber2,

        /// <remarks/>
        BusinessLicense,

        /// <remarks/>
        SocialSecurityNumber,

        /// <remarks/>
        PreviousPassport,

        /// <remarks/>
        BankingID,

        /// <remarks/>
        ArtificialID,

        /// <remarks/>
        CustomIdNumber3,

        /// <remarks/>
        AssociationIdNumber,

        /// <remarks/>
        OtherIdNumber,

        /// <remarks/>
        CustomerCode,
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CoremetrixReportSection))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(IPRSReportCustomSection))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class ReportCustomSection
    {

        private string sectionErrorMessageField;

        private ReportCustomSectionStatus sectionStatusField;

        private bool sectionStatusFieldSpecified;

        private string[] usageDetailField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string SectionErrorMessage
        {
            get
            {
                return this.sectionErrorMessageField;
            }
            set
            {
                this.sectionErrorMessageField = value;
            }
        }

        /// <remarks/>
        public ReportCustomSectionStatus SectionStatus
        {
            get
            {
                return this.sectionStatusField;
            }
            set
            {
                this.sectionStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SectionStatusSpecified
        {
            get
            {
                return this.sectionStatusFieldSpecified;
            }
            set
            {
                this.sectionStatusFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] UsageDetail
        {
            get
            {
                return this.usageDetailField;
            }
            set
            {
                this.usageDetailField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/CI.CBS.Contracts.Public.Structures")]
    public enum ReportCustomSectionStatus
    {

        /// <remarks/>
        None,

        /// <remarks/>
        Ok,

        /// <remarks/>
        Failed,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/Coremetrix")]
    public partial class CoremetrixReportSection : ReportCustomSection
    {

        private string modelField;

        private string quizUrlField;

        private System.Nullable<double> scoreValueField;

        private bool scoreValueFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Model
        {
            get
            {
                return this.modelField;
            }
            set
            {
                this.modelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string QuizUrl
        {
            get
            {
                return this.quizUrlField;
            }
            set
            {
                this.quizUrlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<double> ScoreValue
        {
            get
            {
                return this.scoreValueField;
            }
            set
            {
                this.scoreValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ScoreValueSpecified
        {
            get
            {
                return this.scoreValueFieldSpecified;
            }
            set
            {
                this.scoreValueFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class IPRSReportCustomSection : ReportCustomSection
    {

        private string firstNameField;

        private string fullNameField;

        private string nationalIDField;

        private byte[] pictureBytesField;

        private string pictureMimeTypeField;

        private string surnameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FullName
        {
            get
            {
                return this.fullNameField;
            }
            set
            {
                this.fullNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string NationalID
        {
            get
            {
                return this.nationalIDField;
            }
            set
            {
                this.nationalIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary", IsNullable = true)]
        public byte[] PictureBytes
        {
            get
            {
                return this.pictureBytesField;
            }
            set
            {
                this.pictureBytesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PictureMimeType
        {
            get
            {
                return this.pictureMimeTypeField;
            }
            set
            {
                this.pictureMimeTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Surname
        {
            get
            {
                return this.surnameField;
            }
            set
            {
                this.surnameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/Applications")]
    public partial class CurrentApplication
    {

        private string addressLineField;

        private string associationIdNumberField;

        private string businessLicenseField;

        private string cityField;

        private ClassificationOfIndividual classificationOfIndividualField;

        private bool classificationOfIndividualFieldSpecified;

        private string companyNameField;

        private ContractSubtype contractSubtypeField;

        private bool contractSubtypeFieldSpecified;

        private CountryCode countryField;

        private bool countryFieldSpecified;

        private CourtCode courtCodeField;

        private bool courtCodeFieldSpecified;

        private Currency currencyOfContractField;

        private bool currencyOfContractFieldSpecified;

        private string customIdNumber1Field;

        private string customIdNumber3Field;

        private System.Nullable<System.DateTime> dateOfBirthField;

        private bool dateOfBirthFieldSpecified;

        private System.Nullable<System.DateTime> dateSinceAtAddressField;

        private bool dateSinceAtAddressFieldSpecified;

        private string deliveredReportField;

        private System.Nullable<System.DateTime> establishmentDateField;

        private bool establishmentDateFieldSpecified;

        private string firstNameField;

        private string foreignUniqueIDField;

        private Gender genderField;

        private bool genderFieldSpecified;

        private int inquiryReasonField;

        private bool inquiryReasonFieldSpecified;

        private string nationalIDField;

        private string otherIdField;

        private string passportNumberField;

        private string postalCodeField;

        private string presentSurnameField;

        private PurposeOfFinancing purposeOfFinancingField;

        private bool purposeOfFinancingFieldSpecified;

        private string referenceNumberField;

        private Region regionLookupField;

        private bool regionLookupFieldSpecified;

        private string registrationNumberField;

        private System.DateTime reportDateField;

        private bool reportDateFieldSpecified;

        private System.Nullable<System.DateTime> requestDateField;

        private bool requestDateFieldSpecified;

        private Amount1 requestedAmountField;

        private RoleOfCustomer roleOfCustomerField;

        private bool roleOfCustomerFieldSpecified;

        private string subscriberNameField;

        private string taxNumberField;

        private TypeOfContract typeOfContractField;

        private bool typeOfContractFieldSpecified;

        private string usageIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AddressLine
        {
            get
            {
                return this.addressLineField;
            }
            set
            {
                this.addressLineField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AssociationIdNumber
        {
            get
            {
                return this.associationIdNumberField;
            }
            set
            {
                this.associationIdNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string BusinessLicense
        {
            get
            {
                return this.businessLicenseField;
            }
            set
            {
                this.businessLicenseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public ClassificationOfIndividual ClassificationOfIndividual
        {
            get
            {
                return this.classificationOfIndividualField;
            }
            set
            {
                this.classificationOfIndividualField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ClassificationOfIndividualSpecified
        {
            get
            {
                return this.classificationOfIndividualFieldSpecified;
            }
            set
            {
                this.classificationOfIndividualFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string CompanyName
        {
            get
            {
                return this.companyNameField;
            }
            set
            {
                this.companyNameField = value;
            }
        }

        /// <remarks/>
        public ContractSubtype ContractSubtype
        {
            get
            {
                return this.contractSubtypeField;
            }
            set
            {
                this.contractSubtypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ContractSubtypeSpecified
        {
            get
            {
                return this.contractSubtypeFieldSpecified;
            }
            set
            {
                this.contractSubtypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public CountryCode Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountrySpecified
        {
            get
            {
                return this.countryFieldSpecified;
            }
            set
            {
                this.countryFieldSpecified = value;
            }
        }

        /// <remarks/>
        public CourtCode CourtCode
        {
            get
            {
                return this.courtCodeField;
            }
            set
            {
                this.courtCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CourtCodeSpecified
        {
            get
            {
                return this.courtCodeFieldSpecified;
            }
            set
            {
                this.courtCodeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public Currency CurrencyOfContract
        {
            get
            {
                return this.currencyOfContractField;
            }
            set
            {
                this.currencyOfContractField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CurrencyOfContractSpecified
        {
            get
            {
                return this.currencyOfContractFieldSpecified;
            }
            set
            {
                this.currencyOfContractFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string CustomIdNumber1
        {
            get
            {
                return this.customIdNumber1Field;
            }
            set
            {
                this.customIdNumber1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string CustomIdNumber3
        {
            get
            {
                return this.customIdNumber3Field;
            }
            set
            {
                this.customIdNumber3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                return this.dateOfBirthField;
            }
            set
            {
                this.dateOfBirthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOfBirthSpecified
        {
            get
            {
                return this.dateOfBirthFieldSpecified;
            }
            set
            {
                this.dateOfBirthFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DateSinceAtAddress
        {
            get
            {
                return this.dateSinceAtAddressField;
            }
            set
            {
                this.dateSinceAtAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateSinceAtAddressSpecified
        {
            get
            {
                return this.dateSinceAtAddressFieldSpecified;
            }
            set
            {
                this.dateSinceAtAddressFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string DeliveredReport
        {
            get
            {
                return this.deliveredReportField;
            }
            set
            {
                this.deliveredReportField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> EstablishmentDate
        {
            get
            {
                return this.establishmentDateField;
            }
            set
            {
                this.establishmentDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EstablishmentDateSpecified
        {
            get
            {
                return this.establishmentDateFieldSpecified;
            }
            set
            {
                this.establishmentDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ForeignUniqueID
        {
            get
            {
                return this.foreignUniqueIDField;
            }
            set
            {
                this.foreignUniqueIDField = value;
            }
        }

        /// <remarks/>
        public Gender Gender
        {
            get
            {
                return this.genderField;
            }
            set
            {
                this.genderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GenderSpecified
        {
            get
            {
                return this.genderFieldSpecified;
            }
            set
            {
                this.genderFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int InquiryReason
        {
            get
            {
                return this.inquiryReasonField;
            }
            set
            {
                this.inquiryReasonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InquiryReasonSpecified
        {
            get
            {
                return this.inquiryReasonFieldSpecified;
            }
            set
            {
                this.inquiryReasonFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string NationalID
        {
            get
            {
                return this.nationalIDField;
            }
            set
            {
                this.nationalIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string OtherId
        {
            get
            {
                return this.otherIdField;
            }
            set
            {
                this.otherIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PassportNumber
        {
            get
            {
                return this.passportNumberField;
            }
            set
            {
                this.passportNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PresentSurname
        {
            get
            {
                return this.presentSurnameField;
            }
            set
            {
                this.presentSurnameField = value;
            }
        }

        /// <remarks/>
        public PurposeOfFinancing PurposeOfFinancing
        {
            get
            {
                return this.purposeOfFinancingField;
            }
            set
            {
                this.purposeOfFinancingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PurposeOfFinancingSpecified
        {
            get
            {
                return this.purposeOfFinancingFieldSpecified;
            }
            set
            {
                this.purposeOfFinancingFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ReferenceNumber
        {
            get
            {
                return this.referenceNumberField;
            }
            set
            {
                this.referenceNumberField = value;
            }
        }

        /// <remarks/>
        public Region RegionLookup
        {
            get
            {
                return this.regionLookupField;
            }
            set
            {
                this.regionLookupField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RegionLookupSpecified
        {
            get
            {
                return this.regionLookupFieldSpecified;
            }
            set
            {
                this.regionLookupFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumberField;
            }
            set
            {
                this.registrationNumberField = value;
            }
        }

        /// <remarks/>
        public System.DateTime ReportDate
        {
            get
            {
                return this.reportDateField;
            }
            set
            {
                this.reportDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReportDateSpecified
        {
            get
            {
                return this.reportDateFieldSpecified;
            }
            set
            {
                this.reportDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> RequestDate
        {
            get
            {
                return this.requestDateField;
            }
            set
            {
                this.requestDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RequestDateSpecified
        {
            get
            {
                return this.requestDateFieldSpecified;
            }
            set
            {
                this.requestDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 RequestedAmount
        {
            get
            {
                return this.requestedAmountField;
            }
            set
            {
                this.requestedAmountField = value;
            }
        }

        /// <remarks/>
        public RoleOfCustomer RoleOfCustomer
        {
            get
            {
                return this.roleOfCustomerField;
            }
            set
            {
                this.roleOfCustomerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RoleOfCustomerSpecified
        {
            get
            {
                return this.roleOfCustomerFieldSpecified;
            }
            set
            {
                this.roleOfCustomerFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string SubscriberName
        {
            get
            {
                return this.subscriberNameField;
            }
            set
            {
                this.subscriberNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string TaxNumber
        {
            get
            {
                return this.taxNumberField;
            }
            set
            {
                this.taxNumberField = value;
            }
        }

        /// <remarks/>
        public TypeOfContract TypeOfContract
        {
            get
            {
                return this.typeOfContractField;
            }
            set
            {
                this.typeOfContractField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TypeOfContractSpecified
        {
            get
            {
                return this.typeOfContractFieldSpecified;
            }
            set
            {
                this.typeOfContractFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string UsageID
        {
            get
            {
                return this.usageIDField;
            }
            set
            {
                this.usageIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum ClassificationOfIndividual
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Individual,

        /// <remarks/>
        SoleTrader,

        /// <remarks/>
        Group,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum ContractSubtype
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        ConsumerLoan,

        /// <remarks/>
        BusinessLoan,

        /// <remarks/>
        MortgageLoan,

        /// <remarks/>
        LeasingFinancial,

        /// <remarks/>
        LeasingOperational,

        /// <remarks/>
        OtherInstalmentOperation,

        /// <remarks/>
        PawnLoan,

        /// <remarks/>
        Overdraft,

        /// <remarks/>
        LineOfCreditOnCurrentAccount,

        /// <remarks/>
        AllowedDebitOnCurrentAccount,

        /// <remarks/>
        OtherNoninstalmentOperation,

        /// <remarks/>
        CreditCard,

        /// <remarks/>
        CreditCardWithRegularInstalments,

        /// <remarks/>
        CreditCardOverdrafts,

        /// <remarks/>
        RevolvingCredit,

        /// <remarks/>
        OtherCreditCardOperation,

        /// <remarks/>
        RealEstateLoan,

        /// <remarks/>
        CarLoan,

        /// <remarks/>
        ConsolidatedLoan,

        /// <remarks/>
        LeasinfIndividual,

        /// <remarks/>
        OtherIndividual,

        /// <remarks/>
        OverdraftIndividual,

        /// <remarks/>
        SPOTcredit,

        /// <remarks/>
        OtherCashLoans,

        /// <remarks/>
        SeasonalLoan,

        /// <remarks/>
        AdvanceGoods,

        /// <remarks/>
        PrefinancingLocalCurrency,

        /// <remarks/>
        PrefinancingOtherCurrency,

        /// <remarks/>
        OtherStockFinancing,

        /// <remarks/>
        AdvancePublicMarket,

        /// <remarks/>
        DiscountCaisseMARDesMarches,

        /// <remarks/>
        ProvisionalGuarantees,

        /// <remarks/>
        DefinitiveGuarantees,

        /// <remarks/>
        HoldbackGuarantees,

        /// <remarks/>
        AdvancePaymentBond,

        /// <remarks/>
        OtherInvestmentCredits,

        /// <remarks/>
        AdvanceForCommercialPaper,

        /// <remarks/>
        AdvanceForeignDebt,

        /// <remarks/>
        OtherLinesInStockFinancing,

        /// <remarks/>
        MediumOrLongTermCredit,

        /// <remarks/>
        LeasingForBusiness,

        /// <remarks/>
        OtherInvestmentLoans,

        /// <remarks/>
        PreRentContract,

        /// <remarks/>
        CreditLetterImport,

        /// <remarks/>
        CreditLetterExport,

        /// <remarks/>
        GuaranteeInterTransactions,

        /// <remarks/>
        OtherLoanForForeignTrade,

        /// <remarks/>
        InvestmentLoans,

        /// <remarks/>
        OperatingCredit,

        /// <remarks/>
        OperatingAndInvestmentLoans,

        /// <remarks/>
        CapitalLease,

        /// <remarks/>
        LetterOfCredit,

        /// <remarks/>
        Guarantee,

        /// <remarks/>
        WholesaleFinancing,

        /// <remarks/>
        Bill,

        /// <remarks/>
        Invoice,

        /// <remarks/>
        Factoring,

        /// <remarks/>
        Conventional,

        /// <remarks/>
        Murabahah,

        /// <remarks/>
        Istishna,

        /// <remarks/>
        Salam,

        /// <remarks/>
        Qard,

        /// <remarks/>
        Mudharabah,

        /// <remarks/>
        Musyarakah,

        /// <remarks/>
        Ijarah,

        /// <remarks/>
        MudharabahMuqayyah,

        /// <remarks/>
        IjarahMuntahiyaBitamlik,

        /// <remarks/>
        Rahn,

        /// <remarks/>
        MurabahaHomeFinancing,

        /// <remarks/>
        MurabahaCar,

        /// <remarks/>
        MurabahaEquipment,

        /// <remarks/>
        OtherMurabahaFinancingProduct,

        /// <remarks/>
        IjaraHomeFinancing,

        /// <remarks/>
        IjaraCar,

        /// <remarks/>
        IjaraEquipment,

        /// <remarks/>
        OtherIjaraFinancingProduct,

        /// <remarks/>
        OtherSalamFinancingProduct,

        /// <remarks/>
        ConstantMusharaka,

        /// <remarks/>
        DiminishingMusharakaHomeFinance,

        /// <remarks/>
        OtherDiminishingMusharakaFinance,

        /// <remarks/>
        OtherMusharakaFinancingProduct,

        /// <remarks/>
        MudarabaShortTermFinancing,

        /// <remarks/>
        MudarabaExport,

        /// <remarks/>
        MudarabaImport,

        /// <remarks/>
        OtherMudarabaFinancingProduct,

        /// <remarks/>
        OtherIstisnaaFinancingProduct,

        /// <remarks/>
        OtherIsmalicFinancingProduct,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum CourtCode
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("013")]
        Item013,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5")]
        Item5,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("7")]
        Item7,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("77")]
        Item77,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("79")]
        Item79,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("9")]
        Item9,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("13")]
        Item13,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("15")]
        Item15,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("17")]
        Item17,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("175")]
        Item175,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("19")]
        Item19,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("197")]
        Item197,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("21")]
        Item21,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("23")]
        Item23,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("25")]
        Item25,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("27")]
        Item27,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("273")]
        Item273,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("293")]
        Item293,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("31")]
        Item31,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("35")]
        Item35,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("358")]
        Item358,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("359")]
        Item359,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("37")]
        Item37,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("375")]
        Item375,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("39")]
        Item39,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("395")]
        Item395,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41")]
        Item41,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("411")]
        Item411,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("415")]
        Item415,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("43")]
        Item43,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("44")]
        Item44,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("443")]
        Item443,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("45")]
        Item45,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("455")]
        Item455,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("47")]
        Item47,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("471")]
        Item471,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("49")]
        Item49,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("51")]
        Item51,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("517")]
        Item517,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("53")]
        Item53,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("55")]
        Item55,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("551")]
        Item551,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("552")]
        Item552,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("57")]
        Item57,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("573")]
        Item573,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("59")]
        Item59,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("591")]
        Item591,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("593")]
        Item593,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("60")]
        Item60,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("605")]
        Item605,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("61")]
        Item61,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("611")]
        Item611,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("63")]
        Item63,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("65")]
        Item65,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("66")]
        Item66,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("67")]
        Item67,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("69")]
        Item69,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("693")]
        Item693,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("71")]
        Item71,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("73")]
        Item73,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("81")]
        Item81,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("83")]
        Item83,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("85")]
        Item85,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("87")]
        Item87,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("89")]
        Item89,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum PurposeOfFinancing
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        PersonalLoan,

        /// <remarks/>
        PersonalLoanForExactPurpose,

        /// <remarks/>
        Mortgage,

        /// <remarks/>
        Leasing,

        /// <remarks/>
        Overdraft,

        /// <remarks/>
        Development,

        /// <remarks/>
        WorkingCapital,

        /// <remarks/>
        Repair,

        /// <remarks/>
        TelecomServices,

        /// <remarks/>
        Construct,

        /// <remarks/>
        PurchaseOfBuilding,

        /// <remarks/>
        PurchaseOfPersonalConsumingProducts,

        /// <remarks/>
        SyndicatedLoan,

        /// <remarks/>
        StudentLoan,

        /// <remarks/>
        HomePurchase,

        /// <remarks/>
        EducationExpense,

        /// <remarks/>
        EquityInjection,

        /// <remarks/>
        FinancingConsolOfExistingDebts,

        /// <remarks/>
        TravelExpenses,

        /// <remarks/>
        InvestmentLine,

        /// <remarks/>
        PersonalMotorVehicle,

        /// <remarks/>
        CommercialMotorVehicle,

        /// <remarks/>
        ImportedHouseholdGoods,

        /// <remarks/>
        AgriculturalIndustrialScientificCommercialEquipment,

        /// <remarks/>
        LocalProducts,

        /// <remarks/>
        RealEstate,

        /// <remarks/>
        BusinessFarming,

        /// <remarks/>
        HomeImprovement,

        /// <remarks/>
        BidSecurity,

        /// <remarks/>
        PerformanceSecurity,

        /// <remarks/>
        Import,

        /// <remarks/>
        AdvancePayment,

        /// <remarks/>
        Murabaha,

        /// <remarks/>
        Muzaraaa,

        /// <remarks/>
        Musharaka,

        /// <remarks/>
        Mudaraba,

        /// <remarks/>
        Mogawala,

        /// <remarks/>
        Istisnaa,

        /// <remarks/>
        DeferredLetterOfCredit,

        /// <remarks/>
        LetterOfGuaranteeGoodExecution,

        /// <remarks/>
        LetterOfGuaranteePleminary,

        /// <remarks/>
        LetterOfGuaranteeCorrespondents,

        /// <remarks/>
        LetterOfGuarantee,

        /// <remarks/>
        Salam,

        /// <remarks/>
        QarzAlHassaneh,

        /// <remarks/>
        Portfolios,

        /// <remarks/>
        PurchaseOfFixedAssets,

        /// <remarks/>
        AssetFinance,

        /// <remarks/>
        TradeFinanceFacility,

        /// <remarks/>
        MobileBankingLoan,

        /// <remarks/>
        Utility,

        /// <remarks/>
        BusinessExpansion,

        /// <remarks/>
        PurchaseMarineEquipmentNew,

        /// <remarks/>
        PurchaseMarineEquipmentUsed,

        /// <remarks/>
        PurchasePrivateCarsNewPers,

        /// <remarks/>
        PurchasePrivateCarsUsedPers,

        /// <remarks/>
        PurchaseTaxisNew,

        /// <remarks/>
        PurchaseTaxisUsed,

        /// <remarks/>
        PurchaseRentedCarsNew,

        /// <remarks/>
        PurchaseRentedCarsUsed,

        /// <remarks/>
        PurchaseCommercialVehicleNew,

        /// <remarks/>
        PurchaseCommercialVehicleUsed,

        /// <remarks/>
        PurchaseMotorcycles,

        /// <remarks/>
        PurchaseFurnitureAndDomesticAppliances,

        /// <remarks/>
        PurchaseRevProdEquipmentNew,

        /// <remarks/>
        PurchaseRevProdEquipmentUsed,

        /// <remarks/>
        Refinancing,

        /// <remarks/>
        Consolidations,

        /// <remarks/>
        LandPurchase,

        /// <remarks/>
        IndirectRegularIntRate,

        /// <remarks/>
        IndirectRateUpsell,

        /// <remarks/>
        NonAccrualOverdrafts,

        /// <remarks/>
        ConstructionsHblStartUp,

        /// <remarks/>
        PermanentWorkingCapital,

        /// <remarks/>
        GeneralRuralCredit,

        /// <remarks/>
        ManagedCredit,

        /// <remarks/>
        PrivateNationalPlantationCredit,

        /// <remarks/>
        ExportCredit,

        /// <remarks/>
        FarmerCooperativeCredit,

        /// <remarks/>
        RuralCooperativeCredit,

        /// <remarks/>
        CooperativeCreditMember,

        /// <remarks/>
        CooperativeCreditOther,

        /// <remarks/>
        WorkingCapitalOther,

        /// <remarks/>
        InvestmentSmall,

        /// <remarks/>
        InvestmentPlantationCoreEstate,

        /// <remarks/>
        InvestmentPlantationPlasmaEstate,

        /// <remarks/>
        InvestmentPostPIRBunConversion,

        /// <remarks/>
        InvestmentUPPPRPTE,

        /// <remarks/>
        InvestmentUPPPostPRPTE,

        /// <remarks/>
        InvestmentUPPOther,

        /// <remarks/>
        InvestmentPIRTransCoreEstate,

        /// <remarks/>
        InvestmentPIRTransPlasmaEstate,

        /// <remarks/>
        InvestmentPIRTransPostConversion,

        /// <remarks/>
        InvestmentPrivatePlantation,

        /// <remarks/>
        InvestmentProjAsstHedging,

        /// <remarks/>
        InvestmentProjAsstLocalFundFee,

        /// <remarks/>
        InvestmentProjAsstLocalBankFee,

        /// <remarks/>
        InvestManagedCreditExclProjAsst,

        /// <remarks/>
        Other,

        /// <remarks/>
        InvestmentGeneralRuralCoopCredit,

        /// <remarks/>
        InvestmentCoopCreditMember,

        /// <remarks/>
        InvestmentCoopCreditOther,

        /// <remarks/>
        InvestmentDLBSHedging,

        /// <remarks/>
        InvestmentDLBSRupiahCredit,

        /// <remarks/>
        InvestmentUpTo75Mil,

        /// <remarks/>
        InvestmentOrdinaryInvestLoan,

        /// <remarks/>
        InvestmentExportCredit,

        /// <remarks/>
        InvestmentOther,

        /// <remarks/>
        MortgageBasicHousingReadyPlot,

        /// <remarks/>
        MortgageUpTo21SQM,

        /// <remarks/>
        MortgageBetween21To70SQM,

        /// <remarks/>
        MortgageAbove70SQM,

        /// <remarks/>
        HomeRepair,

        /// <remarks/>
        MotorcycleForTeacher,

        /// <remarks/>
        ShopHouseCredit,

        /// <remarks/>
        OtherConsumerCredit,

        /// <remarks/>
        ForeignLoan,

        /// <remarks/>
        DomesticLoan,

        /// <remarks/>
        InternationalTradeTransaction,

        /// <remarks/>
        DomesticTradeTransaction,

        /// <remarks/>
        NewCar,

        /// <remarks/>
        UsedCar,

        /// <remarks/>
        BigVehicles,

        /// <remarks/>
        Motorcycles,

        /// <remarks/>
        OtherLeisureVehicle,

        /// <remarks/>
        HiFiTV,

        /// <remarks/>
        DomesticAppliances,

        /// <remarks/>
        Clothes,

        /// <remarks/>
        HouseAppartement,

        /// <remarks/>
        DebtSettlement,

        /// <remarks/>
        Wedding,

        /// <remarks/>
        PersonalComputer,

        /// <remarks/>
        Rent,

        /// <remarks/>
        HealthAndMedicalExpenses,

        /// <remarks/>
        Leisure,

        /// <remarks/>
        CommercialAffairsGoods,

        /// <remarks/>
        MobilePhone,

        /// <remarks/>
        MuzaraaaMachinery,

        /// <remarks/>
        LeasingFinancial,

        /// <remarks/>
        LeasingOperating,

        /// <remarks/>
        PromissoryNote,

        /// <remarks/>
        Tourism,

        /// <remarks/>
        MachineryAndEquipment,

        /// <remarks/>
        MedicalEquipment,

        /// <remarks/>
        OperatingAdvanceOfGuaranteeLetter,

        /// <remarks/>
        SocialServices,

        /// <remarks/>
        Industry,

        /// <remarks/>
        Agriculture,

        /// <remarks/>
        PreparationAndProcessing,

        /// <remarks/>
        Transport,

        /// <remarks/>
        SightLC,

        /// <remarks/>
        UsanceLC,

        /// <remarks/>
        AcceptanceLC,

        /// <remarks/>
        NegotiationLC,

        /// <remarks/>
        CommitmentLC,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum Region
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        BDS,

        /// <remarks/>
        BDG,

        /// <remarks/>
        BGL,

        /// <remarks/>
        BLK,

        /// <remarks/>
        BAM,

        /// <remarks/>
        DAK,

        /// <remarks/>
        FRH,

        /// <remarks/>
        FYB,

        /// <remarks/>
        GHZ,

        /// <remarks/>
        GHW,

        /// <remarks/>
        HLM,

        /// <remarks/>
        HRT,

        /// <remarks/>
        JWJ,

        /// <remarks/>
        KBL,

        /// <remarks/>
        KDH,

        /// <remarks/>
        KAP,

        /// <remarks/>
        KHW,

        /// <remarks/>
        KNR,

        /// <remarks/>
        KDZ,

        /// <remarks/>
        LGM,

        /// <remarks/>
        LWG,

        /// <remarks/>
        NGH,

        /// <remarks/>
        NIM,

        /// <remarks/>
        NUR,

        /// <remarks/>
        ORU,

        /// <remarks/>
        PTK,

        /// <remarks/>
        PTY,

        /// <remarks/>
        PNJ,

        /// <remarks/>
        PWN,

        /// <remarks/>
        SMG,

        /// <remarks/>
        SPL,

        /// <remarks/>
        TKR,

        /// <remarks/>
        WRD,

        /// <remarks/>
        ZAB,

        /// <remarks/>
        AltaiTerritory,

        /// <remarks/>
        AmurRegion,

        /// <remarks/>
        ArkhangelskRegion,

        /// <remarks/>
        AstrakhanRegion,

        /// <remarks/>
        BelgorodRegion,

        /// <remarks/>
        BryanskRegion,

        /// <remarks/>
        ChechenRepublic,

        /// <remarks/>
        ChelyabinskRegion,

        /// <remarks/>
        ChukotkaAutonomousArea,

        /// <remarks/>
        ChuvashRepublic,

        /// <remarks/>
        IrkutskRegion,

        /// <remarks/>
        IvanovoRegion,

        /// <remarks/>
        JewishAutonomousRegion,

        /// <remarks/>
        KabardinoBalkarianRepublic,

        /// <remarks/>
        KaliningradRegion,

        /// <remarks/>
        KalugaRegion,

        /// <remarks/>
        KamchatkaTerritory,

        /// <remarks/>
        KarachayevoCircassianRepublic,

        /// <remarks/>
        KemerovoRegion,

        /// <remarks/>
        KhabarovskTerritory,

        /// <remarks/>
        KhantyMansiAutonomousAreaYugra,

        /// <remarks/>
        KirovRegion,

        /// <remarks/>
        KomiRepublic,

        /// <remarks/>
        KostromaRegion,

        /// <remarks/>
        KrasnodarTerritory,

        /// <remarks/>
        KrasnoyarskTerritory,

        /// <remarks/>
        KurganRegion,

        /// <remarks/>
        KurskRegion,

        /// <remarks/>
        LeningradRegion,

        /// <remarks/>
        LipetskRegion,

        /// <remarks/>
        MagadanRegion,

        /// <remarks/>
        Moscow,

        /// <remarks/>
        MoscowRegion,

        /// <remarks/>
        MurmanskRegion,

        /// <remarks/>
        NenetsAutonomousArea,

        /// <remarks/>
        NizhnyNovgorodRegion,

        /// <remarks/>
        NovgorodRegion,

        /// <remarks/>
        NovosibirskRegion,

        /// <remarks/>
        OmskRegion,

        /// <remarks/>
        OrelRegion,

        /// <remarks/>
        OrenburgRegion,

        /// <remarks/>
        PenzaRegion,

        /// <remarks/>
        PermTerritory,

        /// <remarks/>
        PrimoryeTerritory,

        /// <remarks/>
        PskovRegion,

        /// <remarks/>
        RepublicOfAdygeya,

        /// <remarks/>
        RepublicOfAltai,

        /// <remarks/>
        RepublicOfBashkortostan,

        /// <remarks/>
        RepublicOfBuryatia,

        /// <remarks/>
        RepublicOfDaghestan,

        /// <remarks/>
        RepublicOfIngushetia,

        /// <remarks/>
        RepublicOfKalmykia,

        /// <remarks/>
        RepublicOfKarelia,

        /// <remarks/>
        RepublicOfKhakassia,

        /// <remarks/>
        RepublicOfMariEl,

        /// <remarks/>
        RepublicOfMordovia,

        /// <remarks/>
        RepublicOfNorthOssetiaAlania,

        /// <remarks/>
        RepublicOfSakha,

        /// <remarks/>
        RepublicOfTatarstan,

        /// <remarks/>
        RepublicOfTuva,

        /// <remarks/>
        RostovRegion,

        /// <remarks/>
        RyazanRegion,

        /// <remarks/>
        SakhalinRegion,

        /// <remarks/>
        SamaraRegion,

        /// <remarks/>
        SaratovRegion,

        /// <remarks/>
        SmolenskRegion,

        /// <remarks/>
        SaintPetersburg,

        /// <remarks/>
        StavropolTerritory,

        /// <remarks/>
        SverdlovskRegion,

        /// <remarks/>
        TambovRegion,

        /// <remarks/>
        TomskRegion,

        /// <remarks/>
        TransBaikalTerritory,

        /// <remarks/>
        TulaRegion,

        /// <remarks/>
        TverRegion,

        /// <remarks/>
        TyumenRegion,

        /// <remarks/>
        UdmurtianRepublic,

        /// <remarks/>
        UlyanovskRegion,

        /// <remarks/>
        VladimirRegion,

        /// <remarks/>
        VolgogradRegion,

        /// <remarks/>
        VologdaRegion,

        /// <remarks/>
        VoronezhRegion,

        /// <remarks/>
        YamalNenetsAutonomousArea,

        /// <remarks/>
        YaroslavlRegion,

        /// <remarks/>
        Baghdad,

        /// <remarks/>
        Dohuk,

        /// <remarks/>
        Erbil,

        /// <remarks/>
        Kirkuk,

        /// <remarks/>
        Sulaymaniyah,

        /// <remarks/>
        Saladin,

        /// <remarks/>
        AlAnbar,

        /// <remarks/>
        Diyala,

        /// <remarks/>
        Karbala,

        /// <remarks/>
        Babil,

        /// <remarks/>
        Wasit,

        /// <remarks/>
        Najaf,

        /// <remarks/>
        AlQadisiyyah,

        /// <remarks/>
        Maysan,

        /// <remarks/>
        Muthana,

        /// <remarks/>
        DhiQar,

        /// <remarks/>
        Basra,

        /// <remarks/>
        Halabja,

        /// <remarks/>
        Nineveh,

        /// <remarks/>
        Agadir,

        /// <remarks/>
        Biougra,

        /// <remarks/>
        AitBaha,

        /// <remarks/>
        BelfaaHadAitBelfaa,

        /// <remarks/>
        IdaOugnidifKhemisIddaOuGnidif,

        /// <remarks/>
        Massa,

        /// <remarks/>
        Tanalt,

        /// <remarks/>
        Aourir,

        /// <remarks/>
        Lqliaa,

        /// <remarks/>
        Drargua,

        /// <remarks/>
        DcheiraElJihadia,

        /// <remarks/>
        Inezgane,

        /// <remarks/>
        AitMelloul,

        /// <remarks/>
        ImouzzerIdaOutanane,

        /// <remarks/>
        Tamri,

        /// <remarks/>
        Irherm,

        /// <remarks/>
        AitAbdellah,

        /// <remarks/>
        AdarTnineAddar,

        /// <remarks/>
        OuladTeima,

        /// <remarks/>
        Argana,

        /// <remarks/>
        Temsia,

        /// <remarks/>
        ElGuerdaneSebtGuerdane,

        /// <remarks/>
        SidiBibi,

        /// <remarks/>
        Inchaden,

        /// <remarks/>
        Taroudannt,

        /// <remarks/>
        AhmarLaglalchaAhmer,

        /// <remarks/>
        Aoulouz,

        /// <remarks/>
        Freija,

        /// <remarks/>
        OuladBerhil,

        /// <remarks/>
        Tafingoult,

        /// <remarks/>
        AitIazza,

        /// <remarks/>
        AlHoceima,

        /// <remarks/>
        BniBoufrah,

        /// <remarks/>
        BniGmilBniGmilMestassa,

        /// <remarks/>
        BniOuriarhelCercle,

        /// <remarks/>
        ArbaaTaourirt,

        /// <remarks/>
        BniBouayach,

        /// <remarks/>
        BniHadifa,

        /// <remarks/>
        Imzouren,

        /// <remarks/>
        Izemmouren,

        /// <remarks/>
        Issaguen,

        /// <remarks/>
        Targuist,

        /// <remarks/>
        BniAmmart,

        /// <remarks/>
        Ketama,

        /// <remarks/>
        TabarrantCercleTarguist,

        /// <remarks/>
        Azilal,

        /// <remarks/>
        AitMHamed,

        /// <remarks/>
        Tabant,

        /// <remarks/>
        ZaouiatAhansal,

        /// <remarks/>
        Bzou,

        /// <remarks/>
        AitAatabCercleDeBzou,

        /// <remarks/>
        Tanant,

        /// <remarks/>
        Demnate,

        /// <remarks/>
        Ouaoula,

        /// <remarks/>
        FetouakaCercleDeDemnate,

        /// <remarks/>
        Ouaouizarth,

        /// <remarks/>
        AfourarAfourer,

        /// <remarks/>
        Anergui,

        /// <remarks/>
        Tagleft,

        /// <remarks/>
        Tilougguite,

        /// <remarks/>
        BeniMellal,

        /// <remarks/>
        OuledMbarek,

        /// <remarks/>
        OuledYaiche,

        /// <remarks/>
        HadBouMoussaHadOuladBenMoussa,

        /// <remarks/>
        DarOuldZidouh,

        /// <remarks/>
        SebtOuledNemma,

        /// <remarks/>
        ElKsiba,

        /// <remarks/>
        Aghbala,

        /// <remarks/>
        Taghzirt,

        /// <remarks/>
        ZaouiatCheikh,

        /// <remarks/>
        OuladAyad,

        /// <remarks/>
        FkihBenSalah,

        /// <remarks/>
        BeniAmirCercleDeFkihBenSaleh,

        /// <remarks/>
        BeniOukil,

        /// <remarks/>
        Kasba,

        /// <remarks/>
        Guettaya,

        /// <remarks/>
        Semguet,

        /// <remarks/>
        OuledSaidLoued,

        /// <remarks/>
        BradiaHadBradia,

        /// <remarks/>
        OuledZmam,

        /// <remarks/>
        BenSlimane,

        /// <remarks/>
        Fdalate,

        /// <remarks/>
        Mellila,

        /// <remarks/>
        Ziaida,

        /// <remarks/>
        Bouznika,

        /// <remarks/>
        BniYakhlef,

        /// <remarks/>
        SidiMoussaBenAli,

        /// <remarks/>
        SidiYahiaZaer,

        /// <remarks/>
        Boujdour,

        /// <remarks/>
        GueltatZemmour,

        /// <remarks/>
        Boulemane,

        /// <remarks/>
        ImouzzerMarmoucha,

        /// <remarks/>
        SkouraMDaz,

        /// <remarks/>
        Missour,

        /// <remarks/>
        KsabiMoulouya,

        /// <remarks/>
        OutatElHaj,

        /// <remarks/>
        OuladAliYoussef,

        /// <remarks/>
        Fritissa,

        /// <remarks/>
        Chefchaouen,

        /// <remarks/>
        BabBerredBabBerret,

        /// <remarks/>
        BniAhmedCherquiaGharbiaBeniAhm,

        /// <remarks/>
        JebhaCercleBabBerred,

        /// <remarks/>
        BabTaza,

        /// <remarks/>
        Fifi,

        /// <remarks/>
        Tanaqoub,

        /// <remarks/>
        BouAhmedCercle,

        /// <remarks/>
        AssifaneCaïadat,

        /// <remarks/>
        Talambote,

        /// <remarks/>
        Moqrissat,

        /// <remarks/>
        Brikcha,

        /// <remarks/>
        Zoumi,

        /// <remarks/>
        ElJadida,

        /// <remarks/>
        MyAbdellah,

        /// <remarks/>
        OuledHcine,

        /// <remarks/>
        OuladAissa,

        /// <remarks/>
        OuledGhanem,

        /// <remarks/>
        SidiBouzid,

        /// <remarks/>
        Azemmour,

        /// <remarks/>
        BirJdid,

        /// <remarks/>
        Chtouka,

        /// <remarks/>
        SidiBennour,

        /// <remarks/>
        BniHilalBeniHlal,

        /// <remarks/>
        Laaounate,

        /// <remarks/>
        OuladAmrane,

        /// <remarks/>
        SidiSmail,

        /// <remarks/>
        OuladFrej,

        /// <remarks/>
        Zmamra,

        /// <remarks/>
        LoualidiaOualidiya,

        /// <remarks/>
        LgharbiaTnineRharbia,

        /// <remarks/>
        SaniatBerguig,

        /// <remarks/>
        ElKelaaDesSrghna,

        /// <remarks/>
        AhlElGhabaCaïdat,

        /// <remarks/>
        BeniAmeurCercleDElKelaaDessra,

        /// <remarks/>
        LounasdaOunasdasOuladYacoub,

        /// <remarks/>
        LaattaouiaEchChaibiaAttaouiaEc,

        /// <remarks/>
        LaattaouiaKhemisAttaouia,

        /// <remarks/>
        SidiRahal,

        /// <remarks/>
        SidiBouOthmane,

        /// <remarks/>
        LoutaSidiBouOthmane,

        /// <remarks/>
        RasAinRhamna,

        /// <remarks/>
        BenGuerir,

        /// <remarks/>
        OuladTmimCercleRehamna,

        /// <remarks/>
        SkhourRhamna,

        /// <remarks/>
        BouchaneTnineBouchane,

        /// <remarks/>
        Tamallalt,

        /// <remarks/>
        Errachidia,

        /// <remarks/>
        Aoufous,

        /// <remarks/>
        Boudnib,

        /// <remarks/>
        ChorfaMDaghraMdarhraKheng,

        /// <remarks/>
        Lkheng,

        /// <remarks/>
        Assoul,

        /// <remarks/>
        AitHani,

        /// <remarks/>
        Amellago,

        /// <remarks/>
        Erfoud,

        /// <remarks/>
        Alnif,

        /// <remarks/>
        AarabSebbahZizArbaaSebbahZiz,

        /// <remarks/>
        Jorf,

        /// <remarks/>
        Goulmima,

        /// <remarks/>
        AghbalouNKerdous,

        /// <remarks/>
        Melaab,

        /// <remarks/>
        Tinejdad,

        /// <remarks/>
        Imilchil,

        /// <remarks/>
        Amouguer,

        /// <remarks/>
        Outerbat,

        /// <remarks/>
        Rich,

        /// <remarks/>
        AitIzdeg,

        /// <remarks/>
        Gourrama,

        /// <remarks/>
        Rissani,

        /// <remarks/>
        EtTaousTaouz,

        /// <remarks/>
        Essaouira,

        /// <remarks/>
        MRamerHadMramer,

        /// <remarks/>
        TakateKemisTakate,

        /// <remarks/>
        Tafetaechte,

        /// <remarks/>
        HadDra,

        /// <remarks/>
        KorimateSebtKorimate,

        /// <remarks/>
        ElHanchaneTlataHanchane,

        /// <remarks/>
        Talmest,

        /// <remarks/>
        Tamanar,

        /// <remarks/>
        AitDaoud,

        /// <remarks/>
        Smimou,

        /// <remarks/>
        EsSemara,

        /// <remarks/>
        JdiriyaAlJdiria,

        /// <remarks/>
        Amgala,

        /// <remarks/>
        Haouza,

        /// <remarks/>
        Tifariti,

        /// <remarks/>
        Fes,

        /// <remarks/>
        AinChkef,

        /// <remarks/>
        AinCheggag,

        /// <remarks/>
        SidiHarazem,

        /// <remarks/>
        MoulayYacoub,

        /// <remarks/>
        OuledJemaaLemtaZOuaghaMyYacoub,

        /// <remarks/>
        Sefrou,

        /// <remarks/>
        AitYoussiCercleDeSefrou,

        /// <remarks/>
        RasTabouda,

        /// <remarks/>
        BeniYazrhaCercleDElMenzel,

        /// <remarks/>
        Bhalil,

        /// <remarks/>
        AdrejElAdrej,

        /// <remarks/>
        ImouzzerKandar,

        /// <remarks/>
        Figuig,

        /// <remarks/>
        KsarZenasaFiguig,

        /// <remarks/>
        Bouarfa,

        /// <remarks/>
        Tendrara,

        /// <remarks/>
        BniTadjitBeniTajjit,

        /// <remarks/>
        Bouanane,

        /// <remarks/>
        DouimniaaCercleDeBniTadjite,

        /// <remarks/>
        Talsint,

        /// <remarks/>
        Guelmim,

        /// <remarks/>
        Asrir,

        /// <remarks/>
        LaqksabiTagoustKsabi,

        /// <remarks/>
        Assa,

        /// <remarks/>
        Zag,

        /// <remarks/>
        Bouizakarne,

        /// <remarks/>
        IfraneAtlasSaghir,

        /// <remarks/>
        Taghjijt,

        /// <remarks/>
        AinDorij,

        /// <remarks/>
        Kenitra,

        /// <remarks/>
        MoulayBouselham,

        /// <remarks/>
        SidiYahiaElGharb,

        /// <remarks/>
        HadKourt,

        /// <remarks/>
        AinDfaliAinDefali,

        /// <remarks/>
        Khnichet,

        /// <remarks/>
        MechraBelKsiri,

        /// <remarks/>
        DarGueddariDarElGueddari,

        /// <remarks/>
        AlHaouafateHouafat,

        /// <remarks/>
        Nouirate,

        /// <remarks/>
        SidiAllalTazi,

        /// <remarks/>
        Ouazzane,

        /// <remarks/>
        Mzefroun,

        /// <remarks/>
        SidiBousber,

        /// <remarks/>
        SidiRedouane,

        /// <remarks/>
        Teroual,

        /// <remarks/>
        SidiKacem,

        /// <remarks/>
        Lamjaara,

        /// <remarks/>
        Zirara,

        /// <remarks/>
        SidiSlimane,

        /// <remarks/>
        Boumaiz,

        /// <remarks/>
        KceibyaKsibiaDarBelAmri,

        /// <remarks/>
        SoukArbaaElRharb,

        /// <remarks/>
        Arbaoua,

        /// <remarks/>
        KariatBenAouda,

        /// <remarks/>
        LallaMimouna,

        /// <remarks/>
        SidiBoubkerElHaj,

        /// <remarks/>
        SidiMohamedLahmar,

        /// <remarks/>
        SoukTletElGharb,

        /// <remarks/>
        Khemisset,

        /// <remarks/>
        AitMimoune,

        /// <remarks/>
        AitOuribel,

        /// <remarks/>
        AitYadineMsaghraAitYadine,

        /// <remarks/>
        SidiElRhabdourRhandorMsedder,

        /// <remarks/>
        Oulmes,

        /// <remarks/>
        Maaziz,

        /// <remarks/>
        Tiddas,

        /// <remarks/>
        Rommani,

        /// <remarks/>
        BrachouaHadBrachoua,

        /// <remarks/>
        LaghoualemHadRhoualem,

        /// <remarks/>
        SidiBettache,

        /// <remarks/>
        Ezzhiliga,

        /// <remarks/>
        Tiflet,

        /// <remarks/>
        SidiAbderrazzak,

        /// <remarks/>
        SidiAllalElBahraoui,

        /// <remarks/>
        Haddada,

        /// <remarks/>
        Khenifra,

        /// <remarks/>
        Aguelmous,

        /// <remarks/>
        KafNsourCercleKhenifra,

        /// <remarks/>
        MohaOuHammouZayani,

        /// <remarks/>
        MoulayBouazza,

        /// <remarks/>
        ElKebab,

        /// <remarks/>
        AitIshaqAitIshak,

        /// <remarks/>
        Kerrouchen,

        /// <remarks/>
        MRirt,

        /// <remarks/>
        Zaida,

        /// <remarks/>
        Midelt,

        /// <remarks/>
        AitOufellaCercleDeMidelt,

        /// <remarks/>
        Boumia,

        /// <remarks/>
        Itzer,

        /// <remarks/>
        Tounfite,

        /// <remarks/>
        Khouribga,

        /// <remarks/>
        Boujniba,

        /// <remarks/>
        Hattane,

        /// <remarks/>
        Boujad,

        /// <remarks/>
        Chougrane,

        /// <remarks/>
        OuladYoussefCercleBejaad,

        /// <remarks/>
        OuedZem,

        /// <remarks/>
        BeniKhiraneCercleDOuedZem,

        /// <remarks/>
        BniSmirBeniSmir,

        /// <remarks/>
        MaadnaArbaaMaadna,

        /// <remarks/>
        OuladFennaneHadOuladFennane,

        /// <remarks/>
        BraksaSebtDechraBraksa,

        /// <remarks/>
        Ifrane,

        /// <remarks/>
        DayatAoua,

        /// <remarks/>
        Tizguite,

        /// <remarks/>
        Azrou,

        /// <remarks/>
        IrklaouenTimahdite,

        /// <remarks/>
        Laayoune,

        /// <remarks/>
        Boukraa,

        /// <remarks/>
        Dchira,

        /// <remarks/>
        ElMarsa,

        /// <remarks/>
        DaouraDawra,

        /// <remarks/>
        ElHagouniaAlHagounia,

        /// <remarks/>
        Tarfaya,

        /// <remarks/>
        Marrakech,

        /// <remarks/>
        Tamansourt,

        /// <remarks/>
        BourCercle,

        /// <remarks/>
        LoudayaOudaya,

        /// <remarks/>
        AitOurir,

        /// <remarks/>
        Abadou,

        /// <remarks/>
        MesfiouaCercleAitOurir,

        /// <remarks/>
        GhmateRhmate,

        /// <remarks/>
        Touama,

        /// <remarks/>
        Amizmiz,

        /// <remarks/>
        TletNYaaqoub,

        /// <remarks/>
        AssifElMal,

        /// <remarks/>
        Ouazguita,

        /// <remarks/>
        Chichaoua,

        /// <remarks/>
        FrougaCercleDeMajjat,

        /// <remarks/>
        DouiraneMzoudaDouirane,

        /// <remarks/>
        SidLMokhtar,

        /// <remarks/>
        ImiNTanoute,

        /// <remarks/>
        DemsiraCercleDImintanoute,

        /// <remarks/>
        MtougaChichaoua,

        /// <remarks/>
        SeksaouaCercleImintanoute,

        /// <remarks/>
        Tahannaout,

        /// <remarks/>
        Ourika,

        /// <remarks/>
        TameslohteTamslouhtAitImour,

        /// <remarks/>
        Asni,

        /// <remarks/>
        Meknes,

        /// <remarks/>
        Boufakrane,

        /// <remarks/>
        SaisArbaaSais,

        /// <remarks/>
        MyDrissZerhoune,

        /// <remarks/>
        AinLeuh,

        /// <remarks/>
        MHaya,

        /// <remarks/>
        ElHajeb,

        /// <remarks/>
        AinTaoujdate,

        /// <remarks/>
        Agourai,

        /// <remarks/>
        SabaaAiyoun,

        /// <remarks/>
        Nador,

        /// <remarks/>
        Driouch,

        /// <remarks/>
        AinZohra,

        /// <remarks/>
        DarKebdani,

        /// <remarks/>
        Farkhana,

        /// <remarks/>
        Iaazzanene,

        /// <remarks/>
        BniBouifrour,

        /// <remarks/>
        Zegangane,

        /// <remarks/>
        HadBniChiker,

        /// <remarks/>
        BniSidel,

        /// <remarks/>
        BeniAnsar,

        /// <remarks/>
        Selouane,

        /// <remarks/>
        Tazzarine,

        /// <remarks/>
        SidiBouafif,

        /// <remarks/>
        AlAarouiMontArouit,

        /// <remarks/>
        BeniBouYahiaCaïdat,

        /// <remarks/>
        KebdanaCaîadat,

        /// <remarks/>
        RasElMa,

        /// <remarks/>
        Zaio,

        /// <remarks/>
        KariatArekmane,

        /// <remarks/>
        HassiBerkane,

        /// <remarks/>
        IjermaouasAjermounass,

        /// <remarks/>
        BenTib,

        /// <remarks/>
        Midar,

        /// <remarks/>
        Tamsamane,

        /// <remarks/>
        Trougout,

        /// <remarks/>
        Boudinar,

        /// <remarks/>
        Tafersit,

        /// <remarks/>
        Azlaf,

        /// <remarks/>
        Dakhla,

        /// <remarks/>
        AousserdAwserd,

        /// <remarks/>
        AghouinitAghwinit,

        /// <remarks/>
        Tichla,

        /// <remarks/>
        Zoug,

        /// <remarks/>
        BirAnzarane,

        /// <remarks/>
        GleibatElFoula,

        /// <remarks/>
        Mijik,

        /// <remarks/>
        OumDreyga,

        /// <remarks/>
        BirGandouz,

        /// <remarks/>
        ElArgoub,

        /// <remarks/>
        Imlili,

        /// <remarks/>
        Lagouira,

        /// <remarks/>
        Ouarzazate,

        /// <remarks/>
        AhlOuarzazateCaïdat,

        /// <remarks/>
        IghremNOugdal,

        /// <remarks/>
        SkouraAhlElOust,

        /// <remarks/>
        BoumalneDades,

        /// <remarks/>
        ElKelaaMGouna,

        /// <remarks/>
        Ikniouen,

        /// <remarks/>
        MSemrir,

        /// <remarks/>
        Tineghir,

        /// <remarks/>
        Taliouine,

        /// <remarks/>
        Askaoun,

        /// <remarks/>
        Taznakht,

        /// <remarks/>
        Zagora,

        /// <remarks/>
        AgdzAgdez,

        /// <remarks/>
        MHamidElGhizlane,

        /// <remarks/>
        Tagounite,

        /// <remarks/>
        Tazarine,

        /// <remarks/>
        Oujda,

        /// <remarks/>
        BeniDrar,

        /// <remarks/>
        SidiYahiaOrientalOujda,

        /// <remarks/>
        Touissit,

        /// <remarks/>
        Berkane,

        /// <remarks/>
        Ahfir,

        /// <remarks/>
        Aklim,

        /// <remarks/>
        BniAttigCercleDAklim,

        /// <remarks/>
        Saidia,

        /// <remarks/>
        Madagh,

        /// <remarks/>
        Tafoughalt,

        /// <remarks/>
        Jerada,

        /// <remarks/>
        AinBniMathar,

        /// <remarks/>
        BniYaalaCercleJeradaBanlieu,

        /// <remarks/>
        Taourirt,

        /// <remarks/>
        Debdou,

        /// <remarks/>
        ElAiounElAiounSidiMellouk,

        /// <remarks/>
        Safi,

        /// <remarks/>
        KhatazakaneArbaaKhattazakarne,

        /// <remarks/>
        SebtGzoula,

        /// <remarks/>
        ElGhiateRhiate,

        /// <remarks/>
        BouguedraTletaSidiBouguedra,

        /// <remarks/>
        JemaaShaim,

        /// <remarks/>
        LabkhatiHadBekhati,

        /// <remarks/>
        Hrara,

        /// <remarks/>
        Chemaia,

        /// <remarks/>
        RasElAinProvinceDeSafi,

        /// <remarks/>
        SidiChiker,

        /// <remarks/>
        Youssoufia,

        /// <remarks/>
        Settat,

        /// <remarks/>
        SidiElAidi,

        /// <remarks/>
        OuladBenDaoudCercleSettat,

        /// <remarks/>
        OuladBouziriCercleSettat,

        /// <remarks/>
        OuladSaid,

        /// <remarks/>
        BenAhmed,

        /// <remarks/>
        OuledMHamedMaarifOuladMhamed,

        /// <remarks/>
        MlalCercleBenAhmed,

        /// <remarks/>
        RasElAinChaouia,

        /// <remarks/>
        SidiHajjaj,

        /// <remarks/>
        Loulad,

        /// <remarks/>
        Berrechid,

        /// <remarks/>
        ElGara,

        /// <remarks/>
        OuladAbbou,

        /// <remarks/>
        OuladHarrizCharquiaGharbia,

        /// <remarks/>
        SidiRahalChatai,

        /// <remarks/>
        ElBoroujElBrouj,

        /// <remarks/>
        BeniMeskineCharquiaCercleDElBo,

        /// <remarks/>
        BeniMeskineGharbiaCercleDElBor,

        /// <remarks/>
        SoualemTrifia,

        /// <remarks/>
        Tanger,

        /// <remarks/>
        Assilah,

        /// <remarks/>
        DarChaoui,

        /// <remarks/>
        RharbiaCercleAssila,

        /// <remarks/>
        SidiLyamaniTninSidiLyamani,

        /// <remarks/>
        KsarSeghir,

        /// <remarks/>
        GueznaiaCaîadat,

        /// <remarks/>
        Malloussa,

        /// <remarks/>
        TanTan,

        /// <remarks/>
        AbtehAbetehAb,

        /// <remarks/>
        Msied,

        /// <remarks/>
        TanTanPlage,

        /// <remarks/>
        Taounate,

        /// <remarks/>
        AinMediouna,

        /// <remarks/>
        BniOulid,

        /// <remarks/>
        BouhoudaBohouda,

        /// <remarks/>
        TharEsSouk,

        /// <remarks/>
        KariaBaMohamed,

        /// <remarks/>
        ChragaCercleKariaBaMohamed,

        /// <remarks/>
        OuladAissaHjaouaKariaBamohamed,

        /// <remarks/>
        Rhafsai,

        /// <remarks/>
        Ourtzarh,

        /// <remarks/>
        Tafrant,

        /// <remarks/>
        Tissa,

        /// <remarks/>
        OuladAlianeCercleTissa,

        /// <remarks/>
        AinAicha,

        /// <remarks/>
        Bouarouss,

        /// <remarks/>
        OuladRiyabCercleTissa,

        /// <remarks/>
        Tata,

        /// <remarks/>
        Akka,

        /// <remarks/>
        FamElHisn,

        /// <remarks/>
        IssafenKhemisDIssafen,

        /// <remarks/>
        TagmoutTletaTagmout,

        /// <remarks/>
        FoumZguid,

        /// <remarks/>
        AkkaIghaneAkkaIguiren,

        /// <remarks/>
        Tissint,

        /// <remarks/>
        Taza,

        /// <remarks/>
        BabMarzouka,

        /// <remarks/>
        BeniFrassen,

        /// <remarks/>
        BeniLent,

        /// <remarks/>
        MeknassaAcharqiaAlGharbia,

        /// <remarks/>
        OuedAmlil,

        /// <remarks/>
        Aknoul,

        /// <remarks/>
        Ajdir,

        /// <remarks/>
        BourdBoured,

        /// <remarks/>
        MazguitamMezguitem,

        /// <remarks/>
        TiziOusli,

        /// <remarks/>
        Guercif,

        /// <remarks/>
        Barkine,

        /// <remarks/>
        HouaraOuladRahou,

        /// <remarks/>
        LamrijaMahirija,

        /// <remarks/>
        Saka,

        /// <remarks/>
        Tahla,

        /// <remarks/>
        BouzemlaneCercleDeTahla,

        /// <remarks/>
        Maghraoua,

        /// <remarks/>
        RibatElKheir,

        /// <remarks/>
        Zrarda,

        /// <remarks/>
        Tainast,

        /// <remarks/>
        BabElMroujCercleDeTainasteBab,

        /// <remarks/>
        KafElGhar,

        /// <remarks/>
        Tetouan,

        /// <remarks/>
        BniHassanCercleDeTetouan,

        /// <remarks/>
        DarBniKarrichBniKarrich,

        /// <remarks/>
        BniSaid,

        /// <remarks/>
        JbelLahbibTletaJbelElHabib,

        /// <remarks/>
        Anjra,

        /// <remarks/>
        Fnidek,

        /// <remarks/>
        Martil,

        /// <remarks/>
        MDiq,

        /// <remarks/>
        OuedLaou,

        /// <remarks/>
        KsarElKebir,

        /// <remarks/>
        AlAaouamra,

        /// <remarks/>
        Tatoft,

        /// <remarks/>
        SoukTolbaTolba,

        /// <remarks/>
        Larache,

        /// <remarks/>
        BniAroussBniAarous,

        /// <remarks/>
        BniGarfett,

        /// <remarks/>
        SahelKhemisSahel,

        /// <remarks/>
        Tiznit,

        /// <remarks/>
        ArbaaRasmouka,

        /// <remarks/>
        OuladJerrarCercleTiznit,

        /// <remarks/>
        Anzi,

        /// <remarks/>
        ArbaaAitAhmed,

        /// <remarks/>
        IdaOuGougmar,

        /// <remarks/>
        SidiAhmedOuMoussa,

        /// <remarks/>
        IfniSidiIfni,

        /// <remarks/>
        Mesti,

        /// <remarks/>
        Mirleft,

        /// <remarks/>
        Tafraoute,

        /// <remarks/>
        AfellaIghirAffelaIrhir,

        /// <remarks/>
        IrighNTahalaHadTahala,

        /// <remarks/>
        TlataAkhssass,

        /// <remarks/>
        AitErkha,

        /// <remarks/>
        TighirtJemaaNTirhit,

        /// <remarks/>
        Casablanca,

        /// <remarks/>
        Mohammedia,

        /// <remarks/>
        Bouskoura,

        /// <remarks/>
        DarBouazza,

        /// <remarks/>
        Mediouna,

        /// <remarks/>
        Nouaceur,

        /// <remarks/>
        OuladSalah,

        /// <remarks/>
        AinHarouda,

        /// <remarks/>
        TitMellil,

        /// <remarks/>
        Rabat,

        /// <remarks/>
        Sale,

        /// <remarks/>
        Touarga,

        /// <remarks/>
        Tamesna,

        /// <remarks/>
        Skhirate,

        /// <remarks/>
        AinElAouda,

        /// <remarks/>
        Shoul,

        /// <remarks/>
        SidiBouknadel,

        /// <remarks/>
        Temara,

        /// <remarks/>
        Harhoura,

        /// <remarks/>
        AinAttig,

        /// <remarks/>
        JorfElMelha,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41702205000000")]
        Item41702205000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41702210000000")]
        Item41702210000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41702215000000")]
        Item41702215000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41702220000000")]
        Item41702220000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41702225000000")]
        Item41702225000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41702410000010")]
        Item41702410000010,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41702420000010")]
        Item41702420000010,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41703204000000")]
        Item41703204000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41703207000000")]
        Item41703207000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41703211000000")]
        Item41703211000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41703215000000")]
        Item41703215000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41703220000000")]
        Item41703220000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41703223000000")]
        Item41703223000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41703225000000")]
        Item41703225000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41703230000000")]
        Item41703230000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41703410000010")]
        Item41703410000010,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41703420000010")]
        Item41703420000010,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41703430000010")]
        Item41703430000010,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41703440000010")]
        Item41703440000010,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41704210000000")]
        Item41704210000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41704220000000")]
        Item41704220000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41704230000000")]
        Item41704230000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41704235000000")]
        Item41704235000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41704245000000")]
        Item41704245000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41704400000010")]
        Item41704400000010,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41705214000000")]
        Item41705214000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41705236000000")]
        Item41705236000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41705258000000")]
        Item41705258000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41705410000010")]
        Item41705410000010,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41705420000010")]
        Item41705420000010,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41705430000010")]
        Item41705430000010,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41706207000000")]
        Item41706207000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41706211000000")]
        Item41706211000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41706226000000")]
        Item41706226000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41706242000000")]
        Item41706242000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41706246000000")]
        Item41706246000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41706255000000")]
        Item41706255000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41706259000000")]
        Item41706259000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41707215000000")]
        Item41707215000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41707220000000")]
        Item41707220000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41707225000000")]
        Item41707225000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41707232000000")]
        Item41707232000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41707400000010")]
        Item41707400000010,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41708203000000")]
        Item41708203000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41708206000000")]
        Item41708206000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41708209000000")]
        Item41708209000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41708213000000")]
        Item41708213000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41708217000000")]
        Item41708217000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41708219000000")]
        Item41708219000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41708222000000")]
        Item41708222000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41708223000000")]
        Item41708223000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41708400000010")]
        Item41708400000010,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41711201000000")]
        Item41711201000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41711202000000")]
        Item41711202000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41711203000000")]
        Item41711203000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41711204000000")]
        Item41711204000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41702000000000")]
        Item41702000000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41703000000000")]
        Item41703000000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41704000000000")]
        Item41704000000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41705000000000")]
        Item41705000000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41706000000000")]
        Item41706000000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41707000000000")]
        Item41707000000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41708000000000")]
        Item41708000000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41711000000000")]
        Item41711000000000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41721000000000")]
        Item41721000000000,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum TypeOfContract
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Installment,

        /// <remarks/>
        NonInstallment,

        /// <remarks/>
        CreditCard,

        /// <remarks/>
        RevolvingCredit,

        /// <remarks/>
        Invoice,

        /// <remarks/>
        BankGuarantee,

        /// <remarks/>
        LetterOfCredit,

        /// <remarks/>
        DocumentaryCollection,

        /// <remarks/>
        IslamicFinance,

        /// <remarks/>
        MicroFinance,

        /// <remarks/>
        Other,

        /// <remarks/>
        CommercialCredit,

        /// <remarks/>
        IndustrialCredit,

        /// <remarks/>
        ReverseRepoTransaction,

        /// <remarks/>
        PromissoryNote,

        /// <remarks/>
        ConsumerCredit,

        /// <remarks/>
        HousePurchase,

        /// <remarks/>
        RealEstatePurchase,

        /// <remarks/>
        Factoring,

        /// <remarks/>
        LeasingFinancial,

        /// <remarks/>
        LeasingOperating,

        /// <remarks/>
        CoFinancing,

        /// <remarks/>
        LoanRestructuring,

        /// <remarks/>
        ChannelingLoan,

        /// <remarks/>
        CreditTakeover,

        /// <remarks/>
        Securities,

        /// <remarks/>
        Musyarakah,

        /// <remarks/>
        Mudharabah,

        /// <remarks/>
        Murabahah,

        /// <remarks/>
        Salam,

        /// <remarks/>
        Istishna,

        /// <remarks/>
        OtherWithLoanAgreement,

        /// <remarks/>
        CheckingAccount,

        /// <remarks/>
        TradeReceivables,

        /// <remarks/>
        OtherWithoutLoanAgreement,

        /// <remarks/>
        KUKExtractedFromBI,

        /// <remarks/>
        KUKOther,

        /// <remarks/>
        ManagedCredit,

        /// <remarks/>
        NonKUKExtractedFromBI,

        /// <remarks/>
        ProjectAssistance,

        /// <remarks/>
        MudharabahMuqayyadah,

        /// <remarks/>
        IrrevocableForeignLC,

        /// <remarks/>
        IrrevocableDomesticLC,

        /// <remarks/>
        ShippingGuarantee,

        /// <remarks/>
        RiskSharing,

        /// <remarks/>
        StandbyLC,

        /// <remarks/>
        Endorsement,

        /// <remarks/>
        RevocableForeignLC,

        /// <remarks/>
        RevocableDomesticLC,

        /// <remarks/>
        DerivativeNettingAgreement,

        /// <remarks/>
        DerivativeOther,

        /// <remarks/>
        AcceptanceReceivables,

        /// <remarks/>
        Overdraft,

        /// <remarks/>
        BusinessWorkingCapitalLoans,

        /// <remarks/>
        BusinessExpansionLoans,

        /// <remarks/>
        MortgageLoans,

        /// <remarks/>
        AssetFinanceLoans,

        /// <remarks/>
        TradeFinanceFacilities,

        /// <remarks/>
        PersonalLoans,

        /// <remarks/>
        MobileBankingLoan,

        /// <remarks/>
        CarLoan,

        /// <remarks/>
        ConsolidatedLoan,

        /// <remarks/>
        RevolvingCreditCard,

        /// <remarks/>
        LeasingForIndividuals,

        /// <remarks/>
        OtherLoansForIndividuals,

        /// <remarks/>
        OverdraftFacilities,

        /// <remarks/>
        overdraft,

        /// <remarks/>
        SPOTCredit,

        /// <remarks/>
        OtherCashLoans,

        /// <remarks/>
        SeasonalCredit,

        /// <remarks/>
        AdvanceOnGoods,

        /// <remarks/>
        PrefinancingInDirhamsForExport,

        /// <remarks/>
        PrefinancingCurrenciesOfExports,

        /// <remarks/>
        OtherStockFinancing,

        /// <remarks/>
        AdvancesOnPublicMarket,

        /// <remarks/>
        DiscountOnCaisseMarocaine,

        /// <remarks/>
        ProvisionalGuarantees,

        /// <remarks/>
        DefinitiveGuarantees,

        /// <remarks/>
        HoldbackGuarantees,

        /// <remarks/>
        AdvancePaymentBond,

        /// <remarks/>
        OtherFinancingLines,

        /// <remarks/>
        TheDiscountOfCommercialPaper,

        /// <remarks/>
        TheMobilizationOfForeignDebt,

        /// <remarks/>
        OtherLinesOfStockFinancing,

        /// <remarks/>
        TheMediumAndLongtermCredit,

        /// <remarks/>
        LeasingForBusiness,

        /// <remarks/>
        OtherInvestmentLoans,

        /// <remarks/>
        PrerentContract,

        /// <remarks/>
        ImportDocumentaryCredits,

        /// <remarks/>
        ExportDocumentaryCredit,

        /// <remarks/>
        CustomsBond,

        /// <remarks/>
        OtherTradeFinance,

        /// <remarks/>
        HirePurchase,

        /// <remarks/>
        SmallProjectsLoan,

        /// <remarks/>
        MidProjectsLoan,

        /// <remarks/>
        LetterOfGuarantee,

        /// <remarks/>
        OverDraft,

        /// <remarks/>
        OutOfTheList,

        /// <remarks/>
        Qardh,

        /// <remarks/>
        Ijarah,

        /// <remarks/>
        IjarahMuntahiyahBittamlik,

        /// <remarks/>
        FactoringDomesticResource,

        /// <remarks/>
        FactoringInternationalResourse,

        /// <remarks/>
        FactoringNoDomesticResource,

        /// <remarks/>
        FactoringNoInternationalResourse,

        /// <remarks/>
        LineOfCredit,

        /// <remarks/>
        Guaranty,

        /// <remarks/>
        MultiOptionFacility,

        /// <remarks/>
        Acceptance,

        /// <remarks/>
        CommitmentAccount,

        /// <remarks/>
        ClaimsDueReverseRepo,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/Applications")]
    public partial class ApplicationHistory
    {

        private ClassificationOfIndividual classificationOfIndividualField;

        private bool classificationOfIndividualFieldSpecified;

        private ContractSubtype contractSubtypeField;

        private bool contractSubtypeFieldSpecified;

        private Currency currencyOfContractField;

        private bool currencyOfContractFieldSpecified;

        private System.Nullable<System.DateTime> requestDateField;

        private bool requestDateFieldSpecified;

        private Amount1 requestedAmountField;

        private RoleOfCustomer roleOfCustomerField;

        private bool roleOfCustomerFieldSpecified;

        private string subscriberCodeField;

        private string usageIDField;

        /// <remarks/>
        public ClassificationOfIndividual ClassificationOfIndividual
        {
            get
            {
                return this.classificationOfIndividualField;
            }
            set
            {
                this.classificationOfIndividualField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ClassificationOfIndividualSpecified
        {
            get
            {
                return this.classificationOfIndividualFieldSpecified;
            }
            set
            {
                this.classificationOfIndividualFieldSpecified = value;
            }
        }

        /// <remarks/>
        public ContractSubtype ContractSubtype
        {
            get
            {
                return this.contractSubtypeField;
            }
            set
            {
                this.contractSubtypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ContractSubtypeSpecified
        {
            get
            {
                return this.contractSubtypeFieldSpecified;
            }
            set
            {
                this.contractSubtypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public Currency CurrencyOfContract
        {
            get
            {
                return this.currencyOfContractField;
            }
            set
            {
                this.currencyOfContractField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CurrencyOfContractSpecified
        {
            get
            {
                return this.currencyOfContractFieldSpecified;
            }
            set
            {
                this.currencyOfContractFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> RequestDate
        {
            get
            {
                return this.requestDateField;
            }
            set
            {
                this.requestDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RequestDateSpecified
        {
            get
            {
                return this.requestDateFieldSpecified;
            }
            set
            {
                this.requestDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount1 RequestedAmount
        {
            get
            {
                return this.requestedAmountField;
            }
            set
            {
                this.requestedAmountField = value;
            }
        }

        /// <remarks/>
        public RoleOfCustomer RoleOfCustomer
        {
            get
            {
                return this.roleOfCustomerField;
            }
            set
            {
                this.roleOfCustomerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RoleOfCustomerSpecified
        {
            get
            {
                return this.roleOfCustomerFieldSpecified;
            }
            set
            {
                this.roleOfCustomerFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string SubscriberCode
        {
            get
            {
                return this.subscriberCodeField;
            }
            set
            {
                this.subscriberCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string UsageID
        {
            get
            {
                return this.usageIDField;
            }
            set
            {
                this.usageIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/Applications")]
    public partial class Applications
    {

        private ApplicationHistory[] applicationHistoryField;

        private CurrentApplication currentApplicationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public ApplicationHistory[] ApplicationHistory
        {
            get
            {
                return this.applicationHistoryField;
            }
            set
            {
                this.applicationHistoryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public CurrentApplication CurrentApplication
        {
            get
            {
                return this.currentApplicationField;
            }
            set
            {
                this.currentApplicationField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NilReportInternal))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class DataContractKnownTypesBaseOfNilReportInternal0dcikneZ
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class NilReportInternal : DataContractKnownTypesBaseOfNilReportInternal0dcikneZ
    {

        private Applications applicationsField;

        private ReportCustomSection[] customSectionsField;

        private NilReportRecord[] recordsField;

        private NilReportSum summaryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Applications Applications
        {
            get
            {
                return this.applicationsField;
            }
            set
            {
                this.applicationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public ReportCustomSection[] CustomSections
        {
            get
            {
                return this.customSectionsField;
            }
            set
            {
                this.customSectionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public NilReportRecord[] Records
        {
            get
            {
                return this.recordsField;
            }
            set
            {
                this.recordsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public NilReportSum Summary
        {
            get
            {
                return this.summaryField;
            }
            set
            {
                this.summaryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class NilReportRecord
    {

        private System.DateTime dateOfInquiryField;

        private bool dateOfInquiryFieldSpecified;

        private string productField;

        private int reasonField;

        private bool reasonFieldSpecified;

        private string reasonTextField;

        private Sector sectorField;

        private bool sectorFieldSpecified;

        private string subscriberField;

        /// <remarks/>
        public System.DateTime DateOfInquiry
        {
            get
            {
                return this.dateOfInquiryField;
            }
            set
            {
                this.dateOfInquiryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOfInquirySpecified
        {
            get
            {
                return this.dateOfInquiryFieldSpecified;
            }
            set
            {
                this.dateOfInquiryFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Product
        {
            get
            {
                return this.productField;
            }
            set
            {
                this.productField = value;
            }
        }

        /// <remarks/>
        public int Reason
        {
            get
            {
                return this.reasonField;
            }
            set
            {
                this.reasonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReasonSpecified
        {
            get
            {
                return this.reasonFieldSpecified;
            }
            set
            {
                this.reasonFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ReasonText
        {
            get
            {
                return this.reasonTextField;
            }
            set
            {
                this.reasonTextField = value;
            }
        }

        /// <remarks/>
        public Sector Sector
        {
            get
            {
                return this.sectorField;
            }
            set
            {
                this.sectorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SectorSpecified
        {
            get
            {
                return this.sectorFieldSpecified;
            }
            set
            {
                this.sectorFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Subscriber
        {
            get
            {
                return this.subscriberField;
            }
            set
            {
                this.subscriberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum Sector
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        MyCreditBureau,

        /// <remarks/>
        Banks,

        /// <remarks/>
        MFIDonor,

        /// <remarks/>
        MFIOther,

        /// <remarks/>
        Leasing,

        /// <remarks/>
        Building,

        /// <remarks/>
        CreditUnions,

        /// <remarks/>
        HirePurchaseCompanies,

        /// <remarks/>
        Insurance,

        /// <remarks/>
        Telecom,

        /// <remarks/>
        Utilities,

        /// <remarks/>
        OtherCB,

        /// <remarks/>
        NationalBank,

        /// <remarks/>
        Others,

        /// <remarks/>
        Pawnshop,

        /// <remarks/>
        BPR,

        /// <remarks/>
        NonBankingFinancialInstitutions,

        /// <remarks/>
        Ministry,

        /// <remarks/>
        Courts,

        /// <remarks/>
        HealthServices,

        /// <remarks/>
        EnergySupply,

        /// <remarks/>
        Education,

        /// <remarks/>
        WaterSupply,

        /// <remarks/>
        WasteManagement,

        /// <remarks/>
        InformationServices,

        /// <remarks/>
        Transportation,

        /// <remarks/>
        Manufacturing,

        /// <remarks/>
        WholesaleAndRetail,

        /// <remarks/>
        CollectionAgency,

        /// <remarks/>
        OperatingLeasing,

        /// <remarks/>
        FinancialInstitutions,

        /// <remarks/>
        NGO,

        /// <remarks/>
        PrivateCreditBureaus,

        /// <remarks/>
        CreditStores,

        /// <remarks/>
        DPFBBanks,

        /// <remarks/>
        TradeCreditor,

        /// <remarks/>
        StateBank,

        /// <remarks/>
        PrivateBank,

        /// <remarks/>
        MFICatA,

        /// <remarks/>
        MFICatB,

        /// <remarks/>
        MFICatC,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class NilReportSum
    {

        private int numberOfInquiriesLast12MonthsField;

        private bool numberOfInquiriesLast12MonthsFieldSpecified;

        private int numberOfInquiriesLast1MonthField;

        private bool numberOfInquiriesLast1MonthFieldSpecified;

        private int numberOfInquiriesLast24MonthsField;

        private bool numberOfInquiriesLast24MonthsFieldSpecified;

        private int numberOfInquiriesLast3MonthsField;

        private bool numberOfInquiriesLast3MonthsFieldSpecified;

        private int numberOfInquiriesLast6MonthsField;

        private bool numberOfInquiriesLast6MonthsFieldSpecified;

        /// <remarks/>
        public int NumberOfInquiriesLast12Months
        {
            get
            {
                return this.numberOfInquiriesLast12MonthsField;
            }
            set
            {
                this.numberOfInquiriesLast12MonthsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfInquiriesLast12MonthsSpecified
        {
            get
            {
                return this.numberOfInquiriesLast12MonthsFieldSpecified;
            }
            set
            {
                this.numberOfInquiriesLast12MonthsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfInquiriesLast1Month
        {
            get
            {
                return this.numberOfInquiriesLast1MonthField;
            }
            set
            {
                this.numberOfInquiriesLast1MonthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfInquiriesLast1MonthSpecified
        {
            get
            {
                return this.numberOfInquiriesLast1MonthFieldSpecified;
            }
            set
            {
                this.numberOfInquiriesLast1MonthFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfInquiriesLast24Months
        {
            get
            {
                return this.numberOfInquiriesLast24MonthsField;
            }
            set
            {
                this.numberOfInquiriesLast24MonthsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfInquiriesLast24MonthsSpecified
        {
            get
            {
                return this.numberOfInquiriesLast24MonthsFieldSpecified;
            }
            set
            {
                this.numberOfInquiriesLast24MonthsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfInquiriesLast3Months
        {
            get
            {
                return this.numberOfInquiriesLast3MonthsField;
            }
            set
            {
                this.numberOfInquiriesLast3MonthsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfInquiriesLast3MonthsSpecified
        {
            get
            {
                return this.numberOfInquiriesLast3MonthsFieldSpecified;
            }
            set
            {
                this.numberOfInquiriesLast3MonthsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int NumberOfInquiriesLast6Months
        {
            get
            {
                return this.numberOfInquiriesLast6MonthsField;
            }
            set
            {
                this.numberOfInquiriesLast6MonthsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfInquiriesLast6MonthsSpecified
        {
            get
            {
                return this.numberOfInquiriesLast6MonthsFieldSpecified;
            }
            set
            {
                this.numberOfInquiriesLast6MonthsFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(IndividualRecord))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CompanyRecord))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class Record
    {

        private string addressField;

        private string businessLicenseField;

        private long creditinfoIdField;

        private bool creditinfoIdFieldSpecified;

        private string customIdNumber1Field;

        private string customIdNumber2Field;

        private string customIdNumber3Field;

        private string customIdNumber3IssueAuthorityField;

        private CountryCode customIdNumber3IssuerCountryField;

        private bool customIdNumber3IssuerCountryFieldSpecified;

        private string drivingLicenseNumberField;

        private string fixedLineField;

        private string foreignUniqueIDField;

        private string iDCardNumberField;

        private bool isMatchAgainstCriteriaField;

        private bool isMatchAgainstCriteriaFieldSpecified;

        private string mobilePhoneField;

        private string nationalIDField;

        private string passportNumberField;

        private string registrationNumberField;

        private string socialSecurityNumberField;

        private string subjectNameField;

        private string subjectNameLocalField;

        private string taxNumberField;

        private string votersIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string BusinessLicense
        {
            get
            {
                return this.businessLicenseField;
            }
            set
            {
                this.businessLicenseField = value;
            }
        }

        /// <remarks/>
        public long CreditinfoId
        {
            get
            {
                return this.creditinfoIdField;
            }
            set
            {
                this.creditinfoIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreditinfoIdSpecified
        {
            get
            {
                return this.creditinfoIdFieldSpecified;
            }
            set
            {
                this.creditinfoIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string CustomIdNumber1
        {
            get
            {
                return this.customIdNumber1Field;
            }
            set
            {
                this.customIdNumber1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string CustomIdNumber2
        {
            get
            {
                return this.customIdNumber2Field;
            }
            set
            {
                this.customIdNumber2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string CustomIdNumber3
        {
            get
            {
                return this.customIdNumber3Field;
            }
            set
            {
                this.customIdNumber3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string CustomIdNumber3IssueAuthority
        {
            get
            {
                return this.customIdNumber3IssueAuthorityField;
            }
            set
            {
                this.customIdNumber3IssueAuthorityField = value;
            }
        }

        /// <remarks/>
        public CountryCode CustomIdNumber3IssuerCountry
        {
            get
            {
                return this.customIdNumber3IssuerCountryField;
            }
            set
            {
                this.customIdNumber3IssuerCountryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CustomIdNumber3IssuerCountrySpecified
        {
            get
            {
                return this.customIdNumber3IssuerCountryFieldSpecified;
            }
            set
            {
                this.customIdNumber3IssuerCountryFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string DrivingLicenseNumber
        {
            get
            {
                return this.drivingLicenseNumberField;
            }
            set
            {
                this.drivingLicenseNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FixedLine
        {
            get
            {
                return this.fixedLineField;
            }
            set
            {
                this.fixedLineField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ForeignUniqueID
        {
            get
            {
                return this.foreignUniqueIDField;
            }
            set
            {
                this.foreignUniqueIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string IDCardNumber
        {
            get
            {
                return this.iDCardNumberField;
            }
            set
            {
                this.iDCardNumberField = value;
            }
        }

        /// <remarks/>
        public bool IsMatchAgainstCriteria
        {
            get
            {
                return this.isMatchAgainstCriteriaField;
            }
            set
            {
                this.isMatchAgainstCriteriaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsMatchAgainstCriteriaSpecified
        {
            get
            {
                return this.isMatchAgainstCriteriaFieldSpecified;
            }
            set
            {
                this.isMatchAgainstCriteriaFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string MobilePhone
        {
            get
            {
                return this.mobilePhoneField;
            }
            set
            {
                this.mobilePhoneField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string NationalID
        {
            get
            {
                return this.nationalIDField;
            }
            set
            {
                this.nationalIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PassportNumber
        {
            get
            {
                return this.passportNumberField;
            }
            set
            {
                this.passportNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumberField;
            }
            set
            {
                this.registrationNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string SocialSecurityNumber
        {
            get
            {
                return this.socialSecurityNumberField;
            }
            set
            {
                this.socialSecurityNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string SubjectName
        {
            get
            {
                return this.subjectNameField;
            }
            set
            {
                this.subjectNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string SubjectNameLocal
        {
            get
            {
                return this.subjectNameLocalField;
            }
            set
            {
                this.subjectNameLocalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string TaxNumber
        {
            get
            {
                return this.taxNumberField;
            }
            set
            {
                this.taxNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string VotersID
        {
            get
            {
                return this.votersIDField;
            }
            set
            {
                this.votersIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class IndividualRecord : Record
    {

        private System.Nullable<System.DateTime> dateOfBirthField;

        private bool dateOfBirthFieldSpecified;

        private string firstNameField;

        private string firstNameLocalField;

        private string presentSurnameField;

        private string presentSurnameLocalField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                return this.dateOfBirthField;
            }
            set
            {
                this.dateOfBirthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOfBirthSpecified
        {
            get
            {
                return this.dateOfBirthFieldSpecified;
            }
            set
            {
                this.dateOfBirthFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FirstNameLocal
        {
            get
            {
                return this.firstNameLocalField;
            }
            set
            {
                this.firstNameLocalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PresentSurname
        {
            get
            {
                return this.presentSurnameField;
            }
            set
            {
                this.presentSurnameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PresentSurnameLocal
        {
            get
            {
                return this.presentSurnameLocalField;
            }
            set
            {
                this.presentSurnameLocalField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class CompanyRecord : Record
    {

        private BusinessStatus businessStatusField;

        private bool businessStatusFieldSpecified;

        private System.Nullable<System.DateTime> establishmentDateField;

        private bool establishmentDateFieldSpecified;

        private string secondaryAddressField;

        /// <remarks/>
        public BusinessStatus BusinessStatus
        {
            get
            {
                return this.businessStatusField;
            }
            set
            {
                this.businessStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BusinessStatusSpecified
        {
            get
            {
                return this.businessStatusFieldSpecified;
            }
            set
            {
                this.businessStatusFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> EstablishmentDate
        {
            get
            {
                return this.establishmentDateField;
            }
            set
            {
                this.establishmentDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EstablishmentDateSpecified
        {
            get
            {
                return this.establishmentDateFieldSpecified;
            }
            set
            {
                this.establishmentDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string SecondaryAddress
        {
            get
            {
                return this.secondaryAddressField;
            }
            set
            {
                this.secondaryAddressField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum BusinessStatus
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Active,

        /// <remarks/>
        Closed,

        /// <remarks/>
        InBankrupcy,

        /// <remarks/>
        SupervisoryCrisisAdministration,

        /// <remarks/>
        OtherCourtActionByBank,

        /// <remarks/>
        BankruptcyPetitionByBank,

        /// <remarks/>
        Liquidation,

        /// <remarks/>
        AssetsFrozenOrSeized,

        /// <remarks/>
        Cancelled,

        /// <remarks/>
        Converted,

        /// <remarks/>
        Dissolved,

        /// <remarks/>
        PreRegistered,

        /// <remarks/>
        Receivership,

        /// <remarks/>
        Removed,

        /// <remarks/>
        Suspend,

        /// <remarks/>
        Renewed,

        /// <remarks/>
        Registered,

        /// <remarks/>
        Expired,

        /// <remarks/>
        Reorganized,

        /// <remarks/>
        Dormant,

        /// <remarks/>
        Liquidated,

        /// <remarks/>
        Suspended,

        /// <remarks/>
        BankruptcyProceedings,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SmartSearchCompanyResults))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SmartSearchIndividualResults))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class SearchResults
    {

        private CompanyRecord[] companyRecordsField;

        private System.Nullable<long> creditinfoIdField;

        private bool creditinfoIdFieldSpecified;

        private IndividualRecord[] individualRecordsField;

        private NilReportInternal nilReportField;

        private SearchParameters parametersField;

        private string searchRuleAppliedField;

        private SmartSearchParameters smartParametersField;

        private SubjectSearchStatus statusField;

        private bool statusFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public CompanyRecord[] CompanyRecords
        {
            get
            {
                return this.companyRecordsField;
            }
            set
            {
                this.companyRecordsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<long> CreditinfoId
        {
            get
            {
                return this.creditinfoIdField;
            }
            set
            {
                this.creditinfoIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreditinfoIdSpecified
        {
            get
            {
                return this.creditinfoIdFieldSpecified;
            }
            set
            {
                this.creditinfoIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public IndividualRecord[] IndividualRecords
        {
            get
            {
                return this.individualRecordsField;
            }
            set
            {
                this.individualRecordsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public NilReportInternal NilReport
        {
            get
            {
                return this.nilReportField;
            }
            set
            {
                this.nilReportField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SearchParameters Parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string SearchRuleApplied
        {
            get
            {
                return this.searchRuleAppliedField;
            }
            set
            {
                this.searchRuleAppliedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SmartSearchParameters SmartParameters
        {
            get
            {
                return this.smartParametersField;
            }
            set
            {
                this.smartParametersField = value;
            }
        }

        /// <remarks/>
        public SubjectSearchStatus Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatusSpecified
        {
            get
            {
                return this.statusFieldSpecified;
            }
            set
            {
                this.statusFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class SmartSearchParameters
    {

        private string addressLineField;

        private string associationIdNumberField;

        private string branchField;

        private Region branchRegionLookupField;

        private bool branchRegionLookupFieldSpecified;

        private string businessLicenseField;

        private string businessNameField;

        private Category categoryField;

        private bool categoryFieldSpecified;

        private CountryCode citizenshipField;

        private bool citizenshipFieldSpecified;

        private string cityField;

        private ClassificationOfIndividual classificationOfIndividualField;

        private bool classificationOfIndividualFieldSpecified;

        private string companyNameField;

        private ContractSubtype contractSubtypeField;

        private bool contractSubtypeFieldSpecified;

        private CountryCode countryField;

        private bool countryFieldSpecified;

        private CountryCode countryOfBirthField;

        private bool countryOfBirthFieldSpecified;

        private CourtCode courtCodeField;

        private bool courtCodeFieldSpecified;

        private Currency currencyOfContractField;

        private bool currencyOfContractFieldSpecified;

        private string customIdNumber1Field;

        private System.Nullable<System.DateTime> customIdNumber1ExpirationDateField;

        private bool customIdNumber1ExpirationDateFieldSpecified;

        private System.Nullable<System.DateTime> customIdNumber1IssueDateField;

        private bool customIdNumber1IssueDateFieldSpecified;

        private CountryCode customIdNumber1IssuerCountryField;

        private bool customIdNumber1IssuerCountryFieldSpecified;

        private string customIdNumber2Field;

        private string customIdNumber3Field;

        private System.Nullable<System.DateTime> dateOfBirthField;

        private bool dateOfBirthFieldSpecified;

        private System.Nullable<System.DateTime> dateSinceAtAddressField;

        private bool dateSinceAtAddressFieldSpecified;

        private Amount disposableIncomeField;

        private string districtField;

        private string drivingLicenseNumberField;

        private EducationLevel educationField;

        private bool educationFieldSpecified;

        private string emailField;

        private System.Nullable<System.DateTime> employmentDateField;

        private bool employmentDateFieldSpecified;

        private System.Nullable<System.DateTime> establishmentDateField;

        private bool establishmentDateFieldSpecified;

        private Amount firstInstallmentAmountField;

        private System.Nullable<System.DateTime> firstInstallmentDateField;

        private bool firstInstallmentDateFieldSpecified;

        private string firstNameField;

        private string fixedLineField;

        private string fixedLine2Field;

        private string foreignUniqueIDField;

        private System.Nullable<System.DateTime> foreignUniqueIDExpirationDateField;

        private bool foreignUniqueIDExpirationDateFieldSpecified;

        private System.Nullable<System.DateTime> foreignUniqueIDIssueDateField;

        private bool foreignUniqueIDIssueDateFieldSpecified;

        private CountryCode foreignUniqueIDIssuerCountryField;

        private bool foreignUniqueIDIssuerCountryFieldSpecified;

        private string fullNameField;

        private Gender genderField;

        private bool genderFieldSpecified;

        private string iDCardNumberField;

        private IdNumberPair[] idNumbersField;

        private IndustrySector industrySectorField;

        private bool industrySectorFieldSpecified;

        private Amount installmentAmountField;

        private LegalForm legalFormField;

        private bool legalFormFieldSpecified;

        private MaritalStatus maritalStatusField;

        private bool maritalStatusFieldSpecified;

        private MethodOfPayment methodOfPaymentField;

        private bool methodOfPaymentFieldSpecified;

        private string middleNamesField;

        private string mobilePhoneField;

        private Amount monthlyExpensesField;

        private Amount monthlyIncomeField;

        private string nationalIDField;

        private System.Nullable<System.DateTime> nationalIDExpirationDateField;

        private bool nationalIDExpirationDateFieldSpecified;

        private System.Nullable<System.DateTime> nationalIDIssueDateField;

        private bool nationalIDIssueDateFieldSpecified;

        private CountryCode nationalIDIssuerCountryField;

        private bool nationalIDIssuerCountryFieldSpecified;

        private CountryCode nationalityField;

        private bool nationalityFieldSpecified;

        private string numberOfBuildingField;

        private System.Nullable<int> numberOfDependentsField;

        private bool numberOfDependentsFieldSpecified;

        private System.Nullable<int> numberOfInstallmentsField;

        private bool numberOfInstallmentsFieldSpecified;

        private int occupationIndustryField;

        private bool occupationIndustryFieldSpecified;

        private int occupationStatusField;

        private bool occupationStatusFieldSpecified;

        private string otherIdNumberField;

        private OwnershipType ownershipTypeField;

        private bool ownershipTypeFieldSpecified;

        private System.Nullable<System.DateTime> passportExpirationDateField;

        private bool passportExpirationDateFieldSpecified;

        private System.Nullable<System.DateTime> passportIssueDateField;

        private bool passportIssueDateFieldSpecified;

        private CountryCode passportIssuerCountryField;

        private bool passportIssuerCountryFieldSpecified;

        private string passportNumberField;

        private PaymentPeriodicity paymentPeriodicityField;

        private bool paymentPeriodicityFieldSpecified;

        private Amount personalGuarancyAmountField;

        private string[] phoneNumbersField;

        private Region placeOfBirthLookupField;

        private bool placeOfBirthLookupFieldSpecified;

        private string postalCodeField;

        private string presentSurnameField;

        private string provinceField;

        private PurposeOfFinancing purposeOfFinancingField;

        private bool purposeOfFinancingFieldSpecified;

        private int realEstateOwnershipField;

        private bool realEstateOwnershipFieldSpecified;

        private Amount realGuarancyAmountField;

        private string referenceNumberField;

        private string regionField;

        private Region regionLookupField;

        private bool regionLookupFieldSpecified;

        private string registrationNumberField;

        private Amount requestedAmountField;

        private System.Nullable<System.DateTime> requestedDateField;

        private bool requestedDateFieldSpecified;

        private Resident residencyField;

        private bool residencyFieldSpecified;

        private RoleOfCustomer roleOfCustomerField;

        private bool roleOfCustomerFieldSpecified;

        private SocialStatus socialStatusField;

        private bool socialStatusFieldSpecified;

        private System.Nullable<System.DateTime> startDateField;

        private bool startDateFieldSpecified;

        private string streetField;

        private string subjectNameField;

        private System.Nullable<int> subscriberDebitAccountField;

        private bool subscriberDebitAccountFieldSpecified;

        private System.Nullable<System.DateTime> subscriberDebitAccountDateField;

        private bool subscriberDebitAccountDateFieldSpecified;

        private System.Nullable<int> subscriberEmployeeField;

        private bool subscriberEmployeeFieldSpecified;

        private string subscriberReferenceNumberField;

        private string taxNumberField;

        private string tradeNameField;

        private TypeOfContract typeOfContractField;

        private bool typeOfContractFieldSpecified;

        private string votersIDField;

        private string workPhoneField;

        private System.Nullable<int> yearOfEstablishmentField;

        private bool yearOfEstablishmentFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AddressLine
        {
            get
            {
                return this.addressLineField;
            }
            set
            {
                this.addressLineField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string AssociationIdNumber
        {
            get
            {
                return this.associationIdNumberField;
            }
            set
            {
                this.associationIdNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Branch
        {
            get
            {
                return this.branchField;
            }
            set
            {
                this.branchField = value;
            }
        }

        /// <remarks/>
        public Region BranchRegionLookup
        {
            get
            {
                return this.branchRegionLookupField;
            }
            set
            {
                this.branchRegionLookupField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BranchRegionLookupSpecified
        {
            get
            {
                return this.branchRegionLookupFieldSpecified;
            }
            set
            {
                this.branchRegionLookupFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string BusinessLicense
        {
            get
            {
                return this.businessLicenseField;
            }
            set
            {
                this.businessLicenseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string BusinessName
        {
            get
            {
                return this.businessNameField;
            }
            set
            {
                this.businessNameField = value;
            }
        }

        /// <remarks/>
        public Category Category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CategorySpecified
        {
            get
            {
                return this.categoryFieldSpecified;
            }
            set
            {
                this.categoryFieldSpecified = value;
            }
        }

        /// <remarks/>
        public CountryCode Citizenship
        {
            get
            {
                return this.citizenshipField;
            }
            set
            {
                this.citizenshipField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CitizenshipSpecified
        {
            get
            {
                return this.citizenshipFieldSpecified;
            }
            set
            {
                this.citizenshipFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public ClassificationOfIndividual ClassificationOfIndividual
        {
            get
            {
                return this.classificationOfIndividualField;
            }
            set
            {
                this.classificationOfIndividualField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ClassificationOfIndividualSpecified
        {
            get
            {
                return this.classificationOfIndividualFieldSpecified;
            }
            set
            {
                this.classificationOfIndividualFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string CompanyName
        {
            get
            {
                return this.companyNameField;
            }
            set
            {
                this.companyNameField = value;
            }
        }

        /// <remarks/>
        public ContractSubtype ContractSubtype
        {
            get
            {
                return this.contractSubtypeField;
            }
            set
            {
                this.contractSubtypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ContractSubtypeSpecified
        {
            get
            {
                return this.contractSubtypeFieldSpecified;
            }
            set
            {
                this.contractSubtypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public CountryCode Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountrySpecified
        {
            get
            {
                return this.countryFieldSpecified;
            }
            set
            {
                this.countryFieldSpecified = value;
            }
        }

        /// <remarks/>
        public CountryCode CountryOfBirth
        {
            get
            {
                return this.countryOfBirthField;
            }
            set
            {
                this.countryOfBirthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountryOfBirthSpecified
        {
            get
            {
                return this.countryOfBirthFieldSpecified;
            }
            set
            {
                this.countryOfBirthFieldSpecified = value;
            }
        }

        /// <remarks/>
        public CourtCode CourtCode
        {
            get
            {
                return this.courtCodeField;
            }
            set
            {
                this.courtCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CourtCodeSpecified
        {
            get
            {
                return this.courtCodeFieldSpecified;
            }
            set
            {
                this.courtCodeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public Currency CurrencyOfContract
        {
            get
            {
                return this.currencyOfContractField;
            }
            set
            {
                this.currencyOfContractField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CurrencyOfContractSpecified
        {
            get
            {
                return this.currencyOfContractFieldSpecified;
            }
            set
            {
                this.currencyOfContractFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string CustomIdNumber1
        {
            get
            {
                return this.customIdNumber1Field;
            }
            set
            {
                this.customIdNumber1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> CustomIdNumber1ExpirationDate
        {
            get
            {
                return this.customIdNumber1ExpirationDateField;
            }
            set
            {
                this.customIdNumber1ExpirationDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CustomIdNumber1ExpirationDateSpecified
        {
            get
            {
                return this.customIdNumber1ExpirationDateFieldSpecified;
            }
            set
            {
                this.customIdNumber1ExpirationDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> CustomIdNumber1IssueDate
        {
            get
            {
                return this.customIdNumber1IssueDateField;
            }
            set
            {
                this.customIdNumber1IssueDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CustomIdNumber1IssueDateSpecified
        {
            get
            {
                return this.customIdNumber1IssueDateFieldSpecified;
            }
            set
            {
                this.customIdNumber1IssueDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        public CountryCode CustomIdNumber1IssuerCountry
        {
            get
            {
                return this.customIdNumber1IssuerCountryField;
            }
            set
            {
                this.customIdNumber1IssuerCountryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CustomIdNumber1IssuerCountrySpecified
        {
            get
            {
                return this.customIdNumber1IssuerCountryFieldSpecified;
            }
            set
            {
                this.customIdNumber1IssuerCountryFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string CustomIdNumber2
        {
            get
            {
                return this.customIdNumber2Field;
            }
            set
            {
                this.customIdNumber2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string CustomIdNumber3
        {
            get
            {
                return this.customIdNumber3Field;
            }
            set
            {
                this.customIdNumber3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                return this.dateOfBirthField;
            }
            set
            {
                this.dateOfBirthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOfBirthSpecified
        {
            get
            {
                return this.dateOfBirthFieldSpecified;
            }
            set
            {
                this.dateOfBirthFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DateSinceAtAddress
        {
            get
            {
                return this.dateSinceAtAddressField;
            }
            set
            {
                this.dateSinceAtAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateSinceAtAddressSpecified
        {
            get
            {
                return this.dateSinceAtAddressFieldSpecified;
            }
            set
            {
                this.dateSinceAtAddressFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount DisposableIncome
        {
            get
            {
                return this.disposableIncomeField;
            }
            set
            {
                this.disposableIncomeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string District
        {
            get
            {
                return this.districtField;
            }
            set
            {
                this.districtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string DrivingLicenseNumber
        {
            get
            {
                return this.drivingLicenseNumberField;
            }
            set
            {
                this.drivingLicenseNumberField = value;
            }
        }

        /// <remarks/>
        public EducationLevel Education
        {
            get
            {
                return this.educationField;
            }
            set
            {
                this.educationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EducationSpecified
        {
            get
            {
                return this.educationFieldSpecified;
            }
            set
            {
                this.educationFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> EmploymentDate
        {
            get
            {
                return this.employmentDateField;
            }
            set
            {
                this.employmentDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EmploymentDateSpecified
        {
            get
            {
                return this.employmentDateFieldSpecified;
            }
            set
            {
                this.employmentDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> EstablishmentDate
        {
            get
            {
                return this.establishmentDateField;
            }
            set
            {
                this.establishmentDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EstablishmentDateSpecified
        {
            get
            {
                return this.establishmentDateFieldSpecified;
            }
            set
            {
                this.establishmentDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount FirstInstallmentAmount
        {
            get
            {
                return this.firstInstallmentAmountField;
            }
            set
            {
                this.firstInstallmentAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> FirstInstallmentDate
        {
            get
            {
                return this.firstInstallmentDateField;
            }
            set
            {
                this.firstInstallmentDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FirstInstallmentDateSpecified
        {
            get
            {
                return this.firstInstallmentDateFieldSpecified;
            }
            set
            {
                this.firstInstallmentDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FixedLine
        {
            get
            {
                return this.fixedLineField;
            }
            set
            {
                this.fixedLineField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FixedLine2
        {
            get
            {
                return this.fixedLine2Field;
            }
            set
            {
                this.fixedLine2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ForeignUniqueID
        {
            get
            {
                return this.foreignUniqueIDField;
            }
            set
            {
                this.foreignUniqueIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> ForeignUniqueIDExpirationDate
        {
            get
            {
                return this.foreignUniqueIDExpirationDateField;
            }
            set
            {
                this.foreignUniqueIDExpirationDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForeignUniqueIDExpirationDateSpecified
        {
            get
            {
                return this.foreignUniqueIDExpirationDateFieldSpecified;
            }
            set
            {
                this.foreignUniqueIDExpirationDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> ForeignUniqueIDIssueDate
        {
            get
            {
                return this.foreignUniqueIDIssueDateField;
            }
            set
            {
                this.foreignUniqueIDIssueDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForeignUniqueIDIssueDateSpecified
        {
            get
            {
                return this.foreignUniqueIDIssueDateFieldSpecified;
            }
            set
            {
                this.foreignUniqueIDIssueDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        public CountryCode ForeignUniqueIDIssuerCountry
        {
            get
            {
                return this.foreignUniqueIDIssuerCountryField;
            }
            set
            {
                this.foreignUniqueIDIssuerCountryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForeignUniqueIDIssuerCountrySpecified
        {
            get
            {
                return this.foreignUniqueIDIssuerCountryFieldSpecified;
            }
            set
            {
                this.foreignUniqueIDIssuerCountryFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FullName
        {
            get
            {
                return this.fullNameField;
            }
            set
            {
                this.fullNameField = value;
            }
        }

        /// <remarks/>
        public Gender Gender
        {
            get
            {
                return this.genderField;
            }
            set
            {
                this.genderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GenderSpecified
        {
            get
            {
                return this.genderFieldSpecified;
            }
            set
            {
                this.genderFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string IDCardNumber
        {
            get
            {
                return this.iDCardNumberField;
            }
            set
            {
                this.iDCardNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public IdNumberPair[] IdNumbers
        {
            get
            {
                return this.idNumbersField;
            }
            set
            {
                this.idNumbersField = value;
            }
        }

        /// <remarks/>
        public IndustrySector IndustrySector
        {
            get
            {
                return this.industrySectorField;
            }
            set
            {
                this.industrySectorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IndustrySectorSpecified
        {
            get
            {
                return this.industrySectorFieldSpecified;
            }
            set
            {
                this.industrySectorFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount InstallmentAmount
        {
            get
            {
                return this.installmentAmountField;
            }
            set
            {
                this.installmentAmountField = value;
            }
        }

        /// <remarks/>
        public LegalForm LegalForm
        {
            get
            {
                return this.legalFormField;
            }
            set
            {
                this.legalFormField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LegalFormSpecified
        {
            get
            {
                return this.legalFormFieldSpecified;
            }
            set
            {
                this.legalFormFieldSpecified = value;
            }
        }

        /// <remarks/>
        public MaritalStatus MaritalStatus
        {
            get
            {
                return this.maritalStatusField;
            }
            set
            {
                this.maritalStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaritalStatusSpecified
        {
            get
            {
                return this.maritalStatusFieldSpecified;
            }
            set
            {
                this.maritalStatusFieldSpecified = value;
            }
        }

        /// <remarks/>
        public MethodOfPayment MethodOfPayment
        {
            get
            {
                return this.methodOfPaymentField;
            }
            set
            {
                this.methodOfPaymentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MethodOfPaymentSpecified
        {
            get
            {
                return this.methodOfPaymentFieldSpecified;
            }
            set
            {
                this.methodOfPaymentFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string MiddleNames
        {
            get
            {
                return this.middleNamesField;
            }
            set
            {
                this.middleNamesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string MobilePhone
        {
            get
            {
                return this.mobilePhoneField;
            }
            set
            {
                this.mobilePhoneField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount MonthlyExpenses
        {
            get
            {
                return this.monthlyExpensesField;
            }
            set
            {
                this.monthlyExpensesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount MonthlyIncome
        {
            get
            {
                return this.monthlyIncomeField;
            }
            set
            {
                this.monthlyIncomeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string NationalID
        {
            get
            {
                return this.nationalIDField;
            }
            set
            {
                this.nationalIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> NationalIDExpirationDate
        {
            get
            {
                return this.nationalIDExpirationDateField;
            }
            set
            {
                this.nationalIDExpirationDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NationalIDExpirationDateSpecified
        {
            get
            {
                return this.nationalIDExpirationDateFieldSpecified;
            }
            set
            {
                this.nationalIDExpirationDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> NationalIDIssueDate
        {
            get
            {
                return this.nationalIDIssueDateField;
            }
            set
            {
                this.nationalIDIssueDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NationalIDIssueDateSpecified
        {
            get
            {
                return this.nationalIDIssueDateFieldSpecified;
            }
            set
            {
                this.nationalIDIssueDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        public CountryCode NationalIDIssuerCountry
        {
            get
            {
                return this.nationalIDIssuerCountryField;
            }
            set
            {
                this.nationalIDIssuerCountryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NationalIDIssuerCountrySpecified
        {
            get
            {
                return this.nationalIDIssuerCountryFieldSpecified;
            }
            set
            {
                this.nationalIDIssuerCountryFieldSpecified = value;
            }
        }

        /// <remarks/>
        public CountryCode Nationality
        {
            get
            {
                return this.nationalityField;
            }
            set
            {
                this.nationalityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NationalitySpecified
        {
            get
            {
                return this.nationalityFieldSpecified;
            }
            set
            {
                this.nationalityFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string NumberOfBuilding
        {
            get
            {
                return this.numberOfBuildingField;
            }
            set
            {
                this.numberOfBuildingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> NumberOfDependents
        {
            get
            {
                return this.numberOfDependentsField;
            }
            set
            {
                this.numberOfDependentsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfDependentsSpecified
        {
            get
            {
                return this.numberOfDependentsFieldSpecified;
            }
            set
            {
                this.numberOfDependentsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> NumberOfInstallments
        {
            get
            {
                return this.numberOfInstallmentsField;
            }
            set
            {
                this.numberOfInstallmentsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfInstallmentsSpecified
        {
            get
            {
                return this.numberOfInstallmentsFieldSpecified;
            }
            set
            {
                this.numberOfInstallmentsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int OccupationIndustry
        {
            get
            {
                return this.occupationIndustryField;
            }
            set
            {
                this.occupationIndustryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OccupationIndustrySpecified
        {
            get
            {
                return this.occupationIndustryFieldSpecified;
            }
            set
            {
                this.occupationIndustryFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int OccupationStatus
        {
            get
            {
                return this.occupationStatusField;
            }
            set
            {
                this.occupationStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OccupationStatusSpecified
        {
            get
            {
                return this.occupationStatusFieldSpecified;
            }
            set
            {
                this.occupationStatusFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string OtherIdNumber
        {
            get
            {
                return this.otherIdNumberField;
            }
            set
            {
                this.otherIdNumberField = value;
            }
        }

        /// <remarks/>
        public OwnershipType OwnershipType
        {
            get
            {
                return this.ownershipTypeField;
            }
            set
            {
                this.ownershipTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OwnershipTypeSpecified
        {
            get
            {
                return this.ownershipTypeFieldSpecified;
            }
            set
            {
                this.ownershipTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> PassportExpirationDate
        {
            get
            {
                return this.passportExpirationDateField;
            }
            set
            {
                this.passportExpirationDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PassportExpirationDateSpecified
        {
            get
            {
                return this.passportExpirationDateFieldSpecified;
            }
            set
            {
                this.passportExpirationDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> PassportIssueDate
        {
            get
            {
                return this.passportIssueDateField;
            }
            set
            {
                this.passportIssueDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PassportIssueDateSpecified
        {
            get
            {
                return this.passportIssueDateFieldSpecified;
            }
            set
            {
                this.passportIssueDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        public CountryCode PassportIssuerCountry
        {
            get
            {
                return this.passportIssuerCountryField;
            }
            set
            {
                this.passportIssuerCountryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PassportIssuerCountrySpecified
        {
            get
            {
                return this.passportIssuerCountryFieldSpecified;
            }
            set
            {
                this.passportIssuerCountryFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PassportNumber
        {
            get
            {
                return this.passportNumberField;
            }
            set
            {
                this.passportNumberField = value;
            }
        }

        /// <remarks/>
        public PaymentPeriodicity PaymentPeriodicity
        {
            get
            {
                return this.paymentPeriodicityField;
            }
            set
            {
                this.paymentPeriodicityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PaymentPeriodicitySpecified
        {
            get
            {
                return this.paymentPeriodicityFieldSpecified;
            }
            set
            {
                this.paymentPeriodicityFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount PersonalGuarancyAmount
        {
            get
            {
                return this.personalGuarancyAmountField;
            }
            set
            {
                this.personalGuarancyAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] PhoneNumbers
        {
            get
            {
                return this.phoneNumbersField;
            }
            set
            {
                this.phoneNumbersField = value;
            }
        }

        /// <remarks/>
        public Region PlaceOfBirthLookup
        {
            get
            {
                return this.placeOfBirthLookupField;
            }
            set
            {
                this.placeOfBirthLookupField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PlaceOfBirthLookupSpecified
        {
            get
            {
                return this.placeOfBirthLookupFieldSpecified;
            }
            set
            {
                this.placeOfBirthLookupFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string PresentSurname
        {
            get
            {
                return this.presentSurnameField;
            }
            set
            {
                this.presentSurnameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Province
        {
            get
            {
                return this.provinceField;
            }
            set
            {
                this.provinceField = value;
            }
        }

        /// <remarks/>
        public PurposeOfFinancing PurposeOfFinancing
        {
            get
            {
                return this.purposeOfFinancingField;
            }
            set
            {
                this.purposeOfFinancingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PurposeOfFinancingSpecified
        {
            get
            {
                return this.purposeOfFinancingFieldSpecified;
            }
            set
            {
                this.purposeOfFinancingFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int RealEstateOwnership
        {
            get
            {
                return this.realEstateOwnershipField;
            }
            set
            {
                this.realEstateOwnershipField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RealEstateOwnershipSpecified
        {
            get
            {
                return this.realEstateOwnershipFieldSpecified;
            }
            set
            {
                this.realEstateOwnershipFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount RealGuarancyAmount
        {
            get
            {
                return this.realGuarancyAmountField;
            }
            set
            {
                this.realGuarancyAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string ReferenceNumber
        {
            get
            {
                return this.referenceNumberField;
            }
            set
            {
                this.referenceNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Region
        {
            get
            {
                return this.regionField;
            }
            set
            {
                this.regionField = value;
            }
        }

        /// <remarks/>
        public Region RegionLookup
        {
            get
            {
                return this.regionLookupField;
            }
            set
            {
                this.regionLookupField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RegionLookupSpecified
        {
            get
            {
                return this.regionLookupFieldSpecified;
            }
            set
            {
                this.regionLookupFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumberField;
            }
            set
            {
                this.registrationNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Amount RequestedAmount
        {
            get
            {
                return this.requestedAmountField;
            }
            set
            {
                this.requestedAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> RequestedDate
        {
            get
            {
                return this.requestedDateField;
            }
            set
            {
                this.requestedDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RequestedDateSpecified
        {
            get
            {
                return this.requestedDateFieldSpecified;
            }
            set
            {
                this.requestedDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        public Resident Residency
        {
            get
            {
                return this.residencyField;
            }
            set
            {
                this.residencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ResidencySpecified
        {
            get
            {
                return this.residencyFieldSpecified;
            }
            set
            {
                this.residencyFieldSpecified = value;
            }
        }

        /// <remarks/>
        public RoleOfCustomer RoleOfCustomer
        {
            get
            {
                return this.roleOfCustomerField;
            }
            set
            {
                this.roleOfCustomerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RoleOfCustomerSpecified
        {
            get
            {
                return this.roleOfCustomerFieldSpecified;
            }
            set
            {
                this.roleOfCustomerFieldSpecified = value;
            }
        }

        /// <remarks/>
        public SocialStatus SocialStatus
        {
            get
            {
                return this.socialStatusField;
            }
            set
            {
                this.socialStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SocialStatusSpecified
        {
            get
            {
                return this.socialStatusFieldSpecified;
            }
            set
            {
                this.socialStatusFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> StartDate
        {
            get
            {
                return this.startDateField;
            }
            set
            {
                this.startDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartDateSpecified
        {
            get
            {
                return this.startDateFieldSpecified;
            }
            set
            {
                this.startDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Street
        {
            get
            {
                return this.streetField;
            }
            set
            {
                this.streetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string SubjectName
        {
            get
            {
                return this.subjectNameField;
            }
            set
            {
                this.subjectNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> SubscriberDebitAccount
        {
            get
            {
                return this.subscriberDebitAccountField;
            }
            set
            {
                this.subscriberDebitAccountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubscriberDebitAccountSpecified
        {
            get
            {
                return this.subscriberDebitAccountFieldSpecified;
            }
            set
            {
                this.subscriberDebitAccountFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> SubscriberDebitAccountDate
        {
            get
            {
                return this.subscriberDebitAccountDateField;
            }
            set
            {
                this.subscriberDebitAccountDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubscriberDebitAccountDateSpecified
        {
            get
            {
                return this.subscriberDebitAccountDateFieldSpecified;
            }
            set
            {
                this.subscriberDebitAccountDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> SubscriberEmployee
        {
            get
            {
                return this.subscriberEmployeeField;
            }
            set
            {
                this.subscriberEmployeeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubscriberEmployeeSpecified
        {
            get
            {
                return this.subscriberEmployeeFieldSpecified;
            }
            set
            {
                this.subscriberEmployeeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string SubscriberReferenceNumber
        {
            get
            {
                return this.subscriberReferenceNumberField;
            }
            set
            {
                this.subscriberReferenceNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string TaxNumber
        {
            get
            {
                return this.taxNumberField;
            }
            set
            {
                this.taxNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string TradeName
        {
            get
            {
                return this.tradeNameField;
            }
            set
            {
                this.tradeNameField = value;
            }
        }

        /// <remarks/>
        public TypeOfContract TypeOfContract
        {
            get
            {
                return this.typeOfContractField;
            }
            set
            {
                this.typeOfContractField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TypeOfContractSpecified
        {
            get
            {
                return this.typeOfContractFieldSpecified;
            }
            set
            {
                this.typeOfContractFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string VotersID
        {
            get
            {
                return this.votersIDField;
            }
            set
            {
                this.votersIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string WorkPhone
        {
            get
            {
                return this.workPhoneField;
            }
            set
            {
                this.workPhoneField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> YearOfEstablishment
        {
            get
            {
                return this.yearOfEstablishmentField;
            }
            set
            {
                this.yearOfEstablishmentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool YearOfEstablishmentSpecified
        {
            get
            {
                return this.yearOfEstablishmentFieldSpecified;
            }
            set
            {
                this.yearOfEstablishmentFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum Category
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Government,

        /// <remarks/>
        FinancialInstitution,

        /// <remarks/>
        FinancialAuxiliary,

        /// <remarks/>
        PensionFund,

        /// <remarks/>
        InsuranceCorporation,

        /// <remarks/>
        OtherFinancialIntermediary,

        /// <remarks/>
        InvestmentFund,

        /// <remarks/>
        NonProfitInstitution,

        /// <remarks/>
        MicroEnterprise,

        /// <remarks/>
        SmallEnterprise,

        /// <remarks/>
        MediumEnterprise,

        /// <remarks/>
        LargeEnterprise,

        /// <remarks/>
        CentralGovernment,

        /// <remarks/>
        StateTreasuryOffice,

        /// <remarks/>
        MinistryOfFinance,

        /// <remarks/>
        MinistryOfDefense,

        /// <remarks/>
        MinistryOfForestry,

        /// <remarks/>
        MinistryOfAgriculture,

        /// <remarks/>
        MinistryOfMinesAndEnergy,

        /// <remarks/>
        MinistryOfReligion,

        /// <remarks/>
        MinistryOfStateEnterprises,

        /// <remarks/>
        MinistryOther,

        /// <remarks/>
        LocalGovernment,

        /// <remarks/>
        ProvincialGovernment,

        /// <remarks/>
        CityGovernment,

        /// <remarks/>
        CountyGovernment,

        /// <remarks/>
        LogisticsCoordinationAgency,

        /// <remarks/>
        IDNBankRestructuringAgency,

        /// <remarks/>
        GovernmentAgenciesOther,

        /// <remarks/>
        StateOwnedEnterprise,

        /// <remarks/>
        StateOwnedNBFI,

        /// <remarks/>
        SocialSecurity,

        /// <remarks/>
        StateOfficerPensionFund,

        /// <remarks/>
        JiwasrayaInsurance,

        /// <remarks/>
        JasaRaharjaInsurance,

        /// <remarks/>
        JasindoInsurance,

        /// <remarks/>
        MilitaryOfficerInsurance,

        /// <remarks/>
        StateOwnedInsuranceOther,

        /// <remarks/>
        StateOwnedPensionFund,

        /// <remarks/>
        StateOwnedVentureCapital,

        /// <remarks/>
        StateOwnedFinancingCo,

        /// <remarks/>
        PTDanareksa,

        /// <remarks/>
        StateOwnedSecFirmExclFundMgmt,

        /// <remarks/>
        StateOwnedSecFirmInclFundMgmt,

        /// <remarks/>
        StateOwnedMutualFundMgmtCo,

        /// <remarks/>
        PerumPegadaian,

        /// <remarks/>
        PTPosIndonesia,

        /// <remarks/>
        StateOwnedNBFIOther,

        /// <remarks/>
        StateOwnedNonFinancialCo,

        /// <remarks/>
        Kai,

        /// <remarks/>
        Pelni,

        /// <remarks/>
        Pelindo,

        /// <remarks/>
        ASDP,

        /// <remarks/>
        AngkasaPura,

        /// <remarks/>
        PerkebunanNusantara,

        /// <remarks/>
        Pertamina,

        /// <remarks/>
        PLN,

        /// <remarks/>
        KrakatauSteel,

        /// <remarks/>
        GarudaIndonesia,

        /// <remarks/>
        Telkom,

        /// <remarks/>
        Indosat,

        /// <remarks/>
        JasaMarga,

        /// <remarks/>
        Timah,

        /// <remarks/>
        AnekaTambang,

        /// <remarks/>
        StateOwnedConstructionCo,

        /// <remarks/>
        StateOwnedNonFinInstitutionOther,

        /// <remarks/>
        RegionallyOwnedCo,

        /// <remarks/>
        RegionallyOwnedNBFI,

        /// <remarks/>
        RegionallyOwnedInsuranceCo,

        /// <remarks/>
        RegionallyOwnedPensionFund,

        /// <remarks/>
        RegionallyOwnedFinancingCo,

        /// <remarks/>
        RegionallyOwnedVentureCapital,

        /// <remarks/>
        RegOwnedSecFirmExclFundMgmt,

        /// <remarks/>
        RegOwnedSecFirmInclFundMgmt,

        /// <remarks/>
        RegionallyOwnedMutualFundMgmtCo,

        /// <remarks/>
        RegionallyOwnedNBFIOther,

        /// <remarks/>
        RegionallyOwnedNonFinancialCo,

        /// <remarks/>
        RegionallyOwnedWaterCompany,

        /// <remarks/>
        RegionallyOwnedPDMarket,

        /// <remarks/>
        RegionallyOwnedOther,

        /// <remarks/>
        PrivateNBFI,

        /// <remarks/>
        PrivateInsuranceCo,

        /// <remarks/>
        PrivatePensionFund,

        /// <remarks/>
        PrivateMultiFinance,

        /// <remarks/>
        VentureCapital,

        /// <remarks/>
        SecFirmExclFundMgmt,

        /// <remarks/>
        SecFirmInclFundMgmt,

        /// <remarks/>
        PrivateMutualFundMgmtCo,

        /// <remarks/>
        PrivateNBFIPensionFund,

        /// <remarks/>
        SyariahOrganization,

        /// <remarks/>
        PrimarySaveAndLoanCooperative,

        /// <remarks/>
        OtherSaveAndLoanCooperative,

        /// <remarks/>
        ForeignBankRepresentativeOffice,

        /// <remarks/>
        PrivateNBFIOther,

        /// <remarks/>
        PrivateNonFinancialInstitution,

        /// <remarks/>
        PrivateAutomotiveCo,

        /// <remarks/>
        PrivateOilCo,

        /// <remarks/>
        PrivateTextileCo,

        /// <remarks/>
        PrivateTimberCo,

        /// <remarks/>
        PrivateConstructionServicesCo,

        /// <remarks/>
        PrivateTobaccoCo,

        /// <remarks/>
        PrivateFoodCo,

        /// <remarks/>
        PrivateAgrobusinessCo,

        /// <remarks/>
        PrivateCoOther,

        /// <remarks/>
        PrimaryNonSaveAndLoanCooperative,

        /// <remarks/>
        OtherNonSaveAndLoanCooperative,

        /// <remarks/>
        IslamicCharityOrganization,

        /// <remarks/>
        PrivateEducationInstitution,

        /// <remarks/>
        OrganizationOther,

        /// <remarks/>
        ForeignCoRepresentativeOffice,

        /// <remarks/>
        PrivateNonFinInstitutionOther,

        /// <remarks/>
        GovernmentRepresentativeOverseas,

        /// <remarks/>
        ForeignRepresentativeAndStaff,

        /// <remarks/>
        ForeignCountryOwnedCo,

        /// <remarks/>
        NBFIOperatingOutOfIDN,

        /// <remarks/>
        PrivateCoOverseas,

        /// <remarks/>
        IslamicDevelopmentBank,

        /// <remarks/>
        AsianDevelopmentBank,

        /// <remarks/>
        WorldBank,

        /// <remarks/>
        BankIndonesia,

        /// <remarks/>
        MultilateralDevelopmentBank,

        /// <remarks/>
        InternationalOrganization,

        /// <remarks/>
        CentralBank,

        /// <remarks/>
        ForeignCentralBanks,

        /// <remarks/>
        PublicTreasury,

        /// <remarks/>
        PostalServicesVouchers,

        /// <remarks/>
        BanksOperatingInInstance,

        /// <remarks/>
        FinanceCompaniesOperatingInInstance,

        /// <remarks/>
        DepositAndManagementFund,

        /// <remarks/>
        CentralGuaranteeFund,

        /// <remarks/>
        NationalSavingsBank,

        /// <remarks/>
        OffshoreBanksInInstance,

        /// <remarks/>
        MicrocreditInstitutions,

        /// <remarks/>
        ForeignCreditInstitution,

        /// <remarks/>
        MultilateralDevelopmentBanks,

        /// <remarks/>
        InternationalFinancialOrganizations,

        /// <remarks/>
        OtherBacker,

        /// <remarks/>
        InsuranceAndReinsuranceCompany,

        /// <remarks/>
        RetirementAndProvidentSociety,

        /// <remarks/>
        MonetaryUCITS,

        /// <remarks/>
        DiversifiedUCITS,

        /// <remarks/>
        NonMonetaryUCITS,

        /// <remarks/>
        NonDdiversifiedUCITS,

        /// <remarks/>
        SecuritizationTrust,

        /// <remarks/>
        BrokerageFirms,

        /// <remarks/>
        AssetManagementAndPortofolioCompanies,

        /// <remarks/>
        FinancialCompany,

        /// <remarks/>
        OtherFinancialCustomers,

        /// <remarks/>
        NonFinancialPublicEntreprises,

        /// <remarks/>
        NonFinancialPrivateDocieties,

        /// <remarks/>
        IndividualEntrepreneur,

        /// <remarks/>
        InstitutionalStaff,

        /// <remarks/>
        OtherParticulier,

        /// <remarks/>
        CentralAdministration,

        /// <remarks/>
        LocalAdministration,

        /// <remarks/>
        PublicInstitutionalUnits,

        /// <remarks/>
        Corporate,

        /// <remarks/>
        SME,

        /// <remarks/>
        NGOChurchSociety,

        /// <remarks/>
        NotResidencyIndividual,

        /// <remarks/>
        ResidencyIndividual,

        /// <remarks/>
        CreditInstitution,

        /// <remarks/>
        StateGovernment,

        /// <remarks/>
        DepositingCompany,

        /// <remarks/>
        MoneyMarketFund,

        /// <remarks/>
        FinancialVehicleCorporation,

        /// <remarks/>
        PublicHealthServiceAgency,

        /// <remarks/>
        PublicServiceBoardOfEducation,

        /// <remarks/>
        OtherPublicServiceAgencies,

        /// <remarks/>
        RegionalPublicSAProvince,

        /// <remarks/>
        RegionalPublicSAKotaKabupaten,

        /// <remarks/>
        DepositInsuranceAgency,

        /// <remarks/>
        FinancialServicesAuthority,

        /// <remarks/>
        MutualFundCompany,

        /// <remarks/>
        InvestmentManager,

        /// <remarks/>
        LembagaPembiayaanEksporInd,

        /// <remarks/>
        PTDirgantaraIndonesia,

        /// <remarks/>
        PTIndustriKapalIndonesia,

        /// <remarks/>
        PTRajawaliNusantaraIndonesia,

        /// <remarks/>
        PTPerusahaanGasNegara,

        /// <remarks/>
        PTBukitAsamTbk,

        /// <remarks/>
        PTPupukSriwijaya,

        /// <remarks/>
        ROwnedCompanyInvestManager,

        /// <remarks/>
        ROwnedCompanyOthers,

        /// <remarks/>
        NPSectorNonBankFinInstitution,

        /// <remarks/>
        NPSectorOtherNonBankFinInst,

        /// <remarks/>
        NPSectorOther,

        /// <remarks/>
        PSectorMixedInsuranceCompany,

        /// <remarks/>
        PSectorMixedPensionFund,

        /// <remarks/>
        PSectorMixedVentureCapital,

        /// <remarks/>
        PMixedEnterpriseFinSector,

        /// <remarks/>
        PSectorMixedCompsNotEngaged,

        /// <remarks/>
        PSectorMixedCompsConduct,

        /// <remarks/>
        PSectorMixedMutualFundComps,

        /// <remarks/>
        PSectorMixedInvestManager,

        /// <remarks/>
        PSectorMixedSecuritiesOthers,

        /// <remarks/>
        PSectorMixBaitulMaalWaTamwil,

        /// <remarks/>
        PSectorForeignInsurCompany,

        /// <remarks/>
        PSectorForeignVentureCapital,

        /// <remarks/>
        PSectorForeignFinancingCo,

        /// <remarks/>
        PSectorForeignCompsNotEngage,

        /// <remarks/>
        PSectorForeignCompsCondact,

        /// <remarks/>
        PSectorForeignMutualFundComps,

        /// <remarks/>
        PSectorForeignSecuritiesOthers,

        /// <remarks/>
        FPSectorBaitulMaalWaTamwil,

        /// <remarks/>
        FPSectorRepresentativeOffice,

        /// <remarks/>
        FPSectorOtherNonBank,

        /// <remarks/>
        NPSectorCompanyTelekom,

        /// <remarks/>
        PSNationalPropertyRealEstate,

        /// <remarks/>
        PSectorMixedTelecom,

        /// <remarks/>
        PSectorMixedPropertyRealEstate,

        /// <remarks/>
        PSectorMixedOthers,

        /// <remarks/>
        PSectorMixedRepsOthers,

        /// <remarks/>
        PSectorForeignPropertyRealEstate,

        /// <remarks/>
        FPSectorOtherConst,

        /// <remarks/>
        PSectorForeignOthers,

        /// <remarks/>
        FPSectorRepresOthers,

        /// <remarks/>
        OPSector,

        /// <remarks/>
        NonStateForeignInstitutions,

        /// <remarks/>
        PPatuanganIndonesia,

        /// <remarks/>
        PrivateOwnedIndonesia,

        /// <remarks/>
        PrivateOther,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class Amount
    {

        private Currency currencyField;

        private bool currencyFieldSpecified;

        private decimal valueField;

        private bool valueFieldSpecified;

        /// <remarks/>
        public Currency Currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CurrencySpecified
        {
            get
            {
                return this.currencyFieldSpecified;
            }
            set
            {
                this.currencyFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValueSpecified
        {
            get
            {
                return this.valueFieldSpecified;
            }
            set
            {
                this.valueFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum EducationLevel
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        NoEducation,

        /// <remarks/>
        Primary,

        /// <remarks/>
        Secondary,

        /// <remarks/>
        HigherEducation,

        /// <remarks/>
        AcademicDegree,

        /// <remarks/>
        Diploma1,

        /// <remarks/>
        Diploma2,

        /// <remarks/>
        Diploma3,

        /// <remarks/>
        Bachelor,

        /// <remarks/>
        Master,

        /// <remarks/>
        Doctorate,

        /// <remarks/>
        TechnicalEducation,

        /// <remarks/>
        Diploma,

        /// <remarks/>
        HighDiploma,

        /// <remarks/>
        Unlettered,

        /// <remarks/>
        HigherNationalDiploma,

        /// <remarks/>
        EarlyChildhoodDevelopment,

        /// <remarks/>
        PrePrimary,

        /// <remarks/>
        LowerSecondary,

        /// <remarks/>
        UpperSecondary,

        /// <remarks/>
        PostSecondaryNonTertiary,

        /// <remarks/>
        ShortCycleTertiary,

        /// <remarks/>
        HigherProfessionalSchool,

        /// <remarks/>
        SecondaryEducationWithoutMatura,

        /// <remarks/>
        SecondaryEducationWithMatura,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class IdNumberPair
    {

        private string idNumberField;

        private CountryCode idNumberIssuerCountryField;

        private bool idNumberIssuerCountryFieldSpecified;

        private IDNumberType idNumberTypeField;

        private bool idNumberTypeFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string IdNumber
        {
            get
            {
                return this.idNumberField;
            }
            set
            {
                this.idNumberField = value;
            }
        }

        /// <remarks/>
        public CountryCode IdNumberIssuerCountry
        {
            get
            {
                return this.idNumberIssuerCountryField;
            }
            set
            {
                this.idNumberIssuerCountryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdNumberIssuerCountrySpecified
        {
            get
            {
                return this.idNumberIssuerCountryFieldSpecified;
            }
            set
            {
                this.idNumberIssuerCountryFieldSpecified = value;
            }
        }

        /// <remarks/>
        public IDNumberType IdNumberType
        {
            get
            {
                return this.idNumberTypeField;
            }
            set
            {
                this.idNumberTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdNumberTypeSpecified
        {
            get
            {
                return this.idNumberTypeFieldSpecified;
            }
            set
            {
                this.idNumberTypeFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum IndustrySector
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Agriculture,

        /// <remarks/>
        FinancialIntermediaries,

        /// <remarks/>
        Fishing,

        /// <remarks/>
        Forest,

        /// <remarks/>
        Hunting,

        /// <remarks/>
        MiningAndQuarrying,

        /// <remarks/>
        BuildingAndConstruction,

        /// <remarks/>
        Education,

        /// <remarks/>
        Electricity,

        /// <remarks/>
        Gas,

        /// <remarks/>
        Health,

        /// <remarks/>
        HotelsAndRestaurants,

        /// <remarks/>
        Leasing,

        /// <remarks/>
        Manufacturing,

        /// <remarks/>
        OtherServices,

        /// <remarks/>
        RealEstate,

        /// <remarks/>
        Tourism,

        /// <remarks/>
        Trade,

        /// <remarks/>
        TransportAndCommunication,

        /// <remarks/>
        WarehousingAndStorage,

        /// <remarks/>
        Water,

        /// <remarks/>
        Government,

        /// <remarks/>
        InformationServices,

        /// <remarks/>
        ScientificAndTechnical,

        /// <remarks/>
        AdministrativeServices,

        /// <remarks/>
        PublicServices,

        /// <remarks/>
        ArtsEntertainmentRecreation,

        /// <remarks/>
        AgricultureAndHunting,

        /// <remarks/>
        Forestry,

        /// <remarks/>
        CoalMining,

        /// <remarks/>
        CrudeOilAndNaturalGasProduction,

        /// <remarks/>
        Mining,

        /// <remarks/>
        OtherMining,

        /// <remarks/>
        ManufactureOfFoodProductsBeveragesAndTobacco,

        /// <remarks/>
        TextilesIndustriesClothingAndLeather,

        /// <remarks/>
        WoodIndustryAndandManufacturing,

        /// <remarks/>
        PaperManufacturingPrintingAndPublishing,

        /// <remarks/>
        ChemicalIndustryAndChemicalManufacturing,

        /// <remarks/>
        NonMetallicMineral,

        /// <remarks/>
        BasicMetalIndustries,

        /// <remarks/>
        MetalManufacturingProductMachineryAndEquipment,

        /// <remarks/>
        OtherManufacturingIndustries,

        /// <remarks/>
        ElectricityGasAndSteam,

        /// <remarks/>
        WaterDistributionFacilitiesAndPublicWaterSupplyOtherThanForAgriculture,

        /// <remarks/>
        Wholesale,

        /// <remarks/>
        Retail,

        /// <remarks/>
        HotelsRestaurantsAndTourism,

        /// <remarks/>
        TransportWarehousingAndStorage,

        /// <remarks/>
        Communication,

        /// <remarks/>
        Insurances,

        /// <remarks/>
        PublicAdministrationAndNationalDefence,

        /// <remarks/>
        HealthAndSimilarServices,

        /// <remarks/>
        SocialAndRelatedServicesProvidedToTheCommunity,

        /// <remarks/>
        RecreationAndCultureServices,

        /// <remarks/>
        ServicesProvidedToHouseholdsAndIndividuals,

        /// <remarks/>
        InternationalAndOtherExtraTerritorialOrganizations,

        /// <remarks/>
        CommitmentToBeTheSubjectOfSubsequentCharging,

        /// <remarks/>
        Individuals,

        /// <remarks/>
        EmployeesAndIndividualsNotInBusinessActivity,

        /// <remarks/>
        Culture,

        /// <remarks/>
        Arboriculture,

        /// <remarks/>
        Livestock,

        /// <remarks/>
        CulturAndFarmingAssociated,

        /// <remarks/>
        ServicesIncidentalToAgriculture,

        /// <remarks/>
        ForestryLoggingAndRelatedService,

        /// <remarks/>
        FishingAquaculture,

        /// <remarks/>
        ExtractionOfCoalLigniteAndPeat,

        /// <remarks/>
        ExtractionOfOil,

        /// <remarks/>
        ServicesIncidentalToOilAndGasExtraction,

        /// <remarks/>
        IronOres,

        /// <remarks/>
        OtherNonFerrousMetalOres,

        /// <remarks/>
        ExtractionOfStone,

        /// <remarks/>
        ExtractionOfSandAndClay,

        /// <remarks/>
        NaturalPhosphates,

        /// <remarks/>
        OtherMinerals,

        /// <remarks/>
        MeatIndustry,

        /// <remarks/>
        FishIndustry,

        /// <remarks/>
        FruitAndVegetableIndustry,

        /// <remarks/>
        FatsIndustry,

        /// <remarks/>
        DairyIndustry,

        /// <remarks/>
        GrainProcessing,

        /// <remarks/>
        FlourAndGroatsTransformartion,

        /// <remarks/>
        OtherFoodIndustries,

        /// <remarks/>
        BeverageIndustries,

        /// <remarks/>
        TobaccoIndustry,

        /// <remarks/>
        Spinning,

        /// <remarks/>
        Weaving,

        /// <remarks/>
        FinishingOfTextiles,

        /// <remarks/>
        ManufactureOfTextiles,

        /// <remarks/>
        ManufactureOfCarpetsAndOther,

        /// <remarks/>
        ManufactureOfKnittedFabrics,

        /// <remarks/>
        KnitManufacture,

        /// <remarks/>
        ManufactureOfLeatherClothes,

        /// <remarks/>
        ProductioOfTextileGarments,

        /// <remarks/>
        FurIndustry,

        /// <remarks/>
        TanningAndLeatherDressing,

        /// <remarks/>
        ManufactureOfLuggageAndLeatherGoods,

        /// <remarks/>
        FootwearManufacturing,

        /// <remarks/>
        SawingPlaningAndImpregnationOfWood,

        /// <remarks/>
        ManufactureOfWoodPanels,

        /// <remarks/>
        ManufactureOfArpentryAndJoinery,

        /// <remarks/>
        ManufactureOfWoodenContainers,

        /// <remarks/>
        ManufactureOfOtherProductsOfWood,

        /// <remarks/>
        PulpPaperBoradProduction,

        /// <remarks/>
        ManufactureOfPaperAndPaperboard,

        /// <remarks/>
        Edition,

        /// <remarks/>
        Publishing,

        /// <remarks/>
        ReproductionOfRecordedMedia,

        /// <remarks/>
        Cooking,

        /// <remarks/>
        OilRefining,

        /// <remarks/>
        DevelopmentAndTransformationOfMaterials,

        /// <remarks/>
        ManufactureOfBasicChemicals,

        /// <remarks/>
        ManufactureOfAgrochemicals,

        /// <remarks/>
        ProductionOfPaints,

        /// <remarks/>
        PharmaceuticalIndustry,

        /// <remarks/>
        SoapPerfumesCleaningProducts,

        /// <remarks/>
        ManufactureOfOtherChemicals,

        /// <remarks/>
        ManufactureOfHandcraftFibers,

        /// <remarks/>
        RubberIndustry,

        /// <remarks/>
        PlasticsProcessing,

        /// <remarks/>
        ManufactureOfGlass,

        /// <remarks/>
        ManufactureOfCeramicProducts,

        /// <remarks/>
        ProductionOfCeramicTiles,

        /// <remarks/>
        ManufactureOfTilesAndClayBricks,

        /// <remarks/>
        ManufactureOfCementLimeAndPlaster,

        /// <remarks/>
        ManufactureOfConcreteOrPlasterArticles,

        /// <remarks/>
        StoneProduction,

        /// <remarks/>
        ManufactureOfMiscellaneousMineralProducts,

        /// <remarks/>
        SteelWorksAndFerroalloyProduction,

        /// <remarks/>
        ManufactureOfCastIronOrSteelTubes,

        /// <remarks/>
        PrimaryProcessingOfSteel,

        /// <remarks/>
        NonFerrousMetalProduction,

        /// <remarks/>
        Foundry,

        /// <remarks/>
        ManufactureOfmetalElementsForTheConstruction,

        /// <remarks/>
        ManufactureOfMetalTanksAndBoilersForCentralHeating,

        /// <remarks/>
        Chaudronnerie,

        /// <remarks/>
        ForgingStampingPowderMetallurgy,

        /// <remarks/>
        MetalProcessingAndMechanicalEngineering,

        /// <remarks/>
        ManufactureOfCutleryToolsAndGeneralHardware,

        /// <remarks/>
        ManufactureOfOtherFabricatedMetalProducts,

        /// <remarks/>
        ManufactureOfMechanicalEquipment,

        /// <remarks/>
        GeneralPurposeMachineryManufacturing,

        /// <remarks/>
        AgriculturalImplementManufacturing,

        /// <remarks/>
        ManufactureOfMachineTools,

        /// <remarks/>
        ManufactureOfOtherSpecialPurposeMachinery,

        /// <remarks/>
        ManufactureOfWeaponsAndAmmunition,

        /// <remarks/>
        ManufactureOfDomesticAppliances,

        /// <remarks/>
        ManufactureOfOfficeMachAndComputerEquipment,

        /// <remarks/>
        ManufactureOfElectricMotorsGeneratorsAndTransformers,

        /// <remarks/>
        ManufactureOfDistributionAndPowerEquipment,

        /// <remarks/>
        ManufactureOfInsulatedCables,

        /// <remarks/>
        ManufactureOfAccumulatorsAndBatteries,

        /// <remarks/>
        ManufactureOfLampsAndLlightingEquipment,

        /// <remarks/>
        ManufactureOfOtherElectricalEquipment,

        /// <remarks/>
        ManufactureOfElectronicComponents,

        /// <remarks/>
        ManufactureOfEmissionAndTransmissionApparatus,

        /// <remarks/>
        ManufactureOfRecordingMechanisms,

        /// <remarks/>
        ManufactureOfMedicalEquipment,

        /// <remarks/>
        ManufactureOfMeasuringAndControlInstruments,

        /// <remarks/>
        ManufactureOfUndueProcessControlEquipment,

        /// <remarks/>
        ManufactureOfOpticalInstrumentsAndPhotographicEquipment,

        /// <remarks/>
        Watchmaking,

        /// <remarks/>
        ManufactureOfMotorVehicles,

        /// <remarks/>
        ManufactureOfTrailers,

        /// <remarks/>
        AutomotiveEquipmentManufacturing,

        /// <remarks/>
        Shipbuilding,

        /// <remarks/>
        ConstructionOfRailwayRollingStock,

        /// <remarks/>
        AerospaceConstruction,

        /// <remarks/>
        ManufactureOfMotorcyclesAndBicycles,

        /// <remarks/>
        ManufactureOfOtherTransportEquipment,

        /// <remarks/>
        ManufactureOfFurniture,

        /// <remarks/>
        Jewelery,

        /// <remarks/>
        ManufactureOfMusicalInstruments,

        /// <remarks/>
        ManufactureOfSportsEquipment,

        /// <remarks/>
        ManufactureOfGamesAndToys,

        /// <remarks/>
        OtherDiverseIndustries,

        /// <remarks/>
        RecyclingOfMetallicMaterials,

        /// <remarks/>
        RecyclingOfNonMetallicMaterials,

        /// <remarks/>
        ProductionAndDistributionOfElectricity,

        /// <remarks/>
        ProductionAndDistributionOfGaseousFuels,

        /// <remarks/>
        ProductionAndDistributionOfHeat,

        /// <remarks/>
        CollectionPurificationDistributionOfwater,

        /// <remarks/>
        SitePreparation,

        /// <remarks/>
        BuildingOfCompleteConstructionOrCivilEngineering,

        /// <remarks/>
        InstallationServices,

        /// <remarks/>
        FinishingWork,

        /// <remarks/>
        RentalOfConstructionEquipment,

        /// <remarks/>
        SaleOfMotorVehicles,

        /// <remarks/>
        MotorVehicleMaintenanceAndRepair,

        /// <remarks/>
        SaleOfMotorVehicle,

        /// <remarks/>
        TradeAndRepairOfMotorcycles,

        /// <remarks/>
        RetailSaleOfFuels,

        /// <remarks/>
        WholesaleTradeIntermediaries,

        /// <remarks/>
        WholesaleOfAgriculturalRawMaterials,

        /// <remarks/>
        WholesaleOfFoodProducts,

        /// <remarks/>
        WholesaleOfNonfoodConsumerGoods,

        /// <remarks/>
        WholesaleOfNonAgriculturalIntermediateProducts,

        /// <remarks/>
        WholesaleOfIndustrialEquipment,

        /// <remarks/>
        OtherWholesale,

        /// <remarks/>
        RetailSaleInNonSpecializedStores,

        /// <remarks/>
        RetailSaleOfFoodInSpecializedStores,

        /// <remarks/>
        RetailSaleOfPersonalProperty,

        /// <remarks/>
        RetailSaleOfHouseholdGoods,

        /// <remarks/>
        RetailSaleOfSecondHandGoods,

        /// <remarks/>
        RetailTradeNotInStores,

        /// <remarks/>
        RepairOfPersonalAndHouseholdGoods,

        /// <remarks/>
        Hotels,

        /// <remarks/>
        OtherProvisionOfShortTermAccommodation,

        /// <remarks/>
        Restaurants,

        /// <remarks/>
        Taverns,

        /// <remarks/>
        RailTransport,

        /// <remarks/>
        UrbanRoadTransport,

        /// <remarks/>
        LongDistanceRoadTransport,

        /// <remarks/>
        TouristTrains,

        /// <remarks/>
        CommunalRoadTransport,

        /// <remarks/>
        InternationalRoadTransport,

        /// <remarks/>
        TransportViaPipelines,

        /// <remarks/>
        MaritimeTransport,

        /// <remarks/>
        CoastalTransport,

        /// <remarks/>
        ScheduledAirTransport,

        /// <remarks/>
        NonScheduledAirTransport,

        /// <remarks/>
        HandlingAndStorage,

        /// <remarks/>
        OtherSupportingTransport,

        /// <remarks/>
        TravelAgents,

        /// <remarks/>
        FreightTransportOrganization,

        /// <remarks/>
        PostAndCourierActivities,

        /// <remarks/>
        Telecommunications,

        /// <remarks/>
        MonetaryIntermediation,

        /// <remarks/>
        OtherFinancialIntermediation,

        /// <remarks/>
        Insurance,

        /// <remarks/>
        FinancialAuxiliaries,

        /// <remarks/>
        InsuranceAuxiliaries,

        /// <remarks/>
        RealEstateActivitiesForOwnAccount,

        /// <remarks/>
        RentalOfRealEstate,

        /// <remarks/>
        RealEstateActivitiesForThirdParties,

        /// <remarks/>
        RentingOfAutomobiles,

        /// <remarks/>
        RentalOfOtherTransportEquipment,

        /// <remarks/>
        RentalOfMachineryAndEquipment,

        /// <remarks/>
        RentalOfPersonalAndHouseholdGoods,

        /// <remarks/>
        ITSystemConsultancy,

        /// <remarks/>
        SoftwareImplementation,

        /// <remarks/>
        DataProcess,

        /// <remarks/>
        DataBankActivities,

        /// <remarks/>
        MaintenanceAndRepairOfOfficeAndComputingMachinery,

        /// <remarks/>
        OtherActivitiesRelatedToComputerScience,

        /// <remarks/>
        DevelopmentResearchNaturalSciences,

        /// <remarks/>
        ResearchAndDevelopmentInSocialSciencesAndHumanities,

        /// <remarks/>
        LegalAccountingAndManagementBoard,

        /// <remarks/>
        ArchitecturalAndEngineeringActivities,

        /// <remarks/>
        TechnicalTestingAndAnalysis,

        /// <remarks/>
        Publicity,

        /// <remarks/>
        SelectionAndProvisionOfPersonnel,

        /// <remarks/>
        Security,

        /// <remarks/>
        CleaningActivities,

        /// <remarks/>
        VariousServicesProvidedMainlyToBusinesses,

        /// <remarks/>
        GeneralAdministrationEconomicAndSocial,

        /// <remarks/>
        SovereigntyServices,

        /// <remarks/>
        CompulsorySocialSecurity,

        /// <remarks/>
        PreschoolEducation,

        /// <remarks/>
        BasicEducation,

        /// <remarks/>
        SecondaryEducation,

        /// <remarks/>
        HighEducation,

        /// <remarks/>
        ProfessionalTraining,

        /// <remarks/>
        AdultAndOtherEducation,

        /// <remarks/>
        ActivitiesToHumanHealth,

        /// <remarks/>
        VeterinaryActivities,

        /// <remarks/>
        SocialAction,

        /// <remarks/>
        SanitationRoadsAndWasteManagement,

        /// <remarks/>
        EconomicOrganizations,

        /// <remarks/>
        UnionsOfEmployees,

        /// <remarks/>
        OtherMembershipOrganizations,

        /// <remarks/>
        MotionPictureAndVideo,

        /// <remarks/>
        RadioAndTelevisionActivities,

        /// <remarks/>
        OtherEntertainmentActivities,

        /// <remarks/>
        NewsAgencies,

        /// <remarks/>
        OtherCulturalActivities,

        /// <remarks/>
        SportsActivities,

        /// <remarks/>
        RecreationalActivities,

        /// <remarks/>
        PersonalServices,

        /// <remarks/>
        DomesticServices,

        /// <remarks/>
        ExtraterritorialActivities,

        /// <remarks/>
        Financing,

        /// <remarks/>
        FinancialServices,

        /// <remarks/>
        EnergyAndWaterDistribution,

        /// <remarks/>
        ConstructionAndPropertyDevelopment,

        /// <remarks/>
        TourismAndDistribution,

        /// <remarks/>
        DistributionAndOtherCommercialServices,

        /// <remarks/>
        IndividualsAndHouseholds,

        /// <remarks/>
        Mortgage,

        /// <remarks/>
        InternationalOrganisations,

        /// <remarks/>
        HirePurchase,

        /// <remarks/>
        StateAndStateEnterprises,

        /// <remarks/>
        Other,

        /// <remarks/>
        TradeAndDistribution,

        /// <remarks/>
        Transport,

        /// <remarks/>
        CommunicationServices,

        /// <remarks/>
        CreditCards,

        /// <remarks/>
        MedicalServices,

        /// <remarks/>
        InformationTechnologies,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum LegalForm
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        JointLiabilityCompany,

        /// <remarks/>
        SpecialPartnershipCompany,

        /// <remarks/>
        LimitedLiabilityCompanyPublic,

        /// <remarks/>
        LimitedLiabilityCompanyPrivate,

        /// <remarks/>
        JointStockCompany,

        /// <remarks/>
        Cooperative,

        /// <remarks/>
        Foundations,

        /// <remarks/>
        Association,

        /// <remarks/>
        Audit,

        /// <remarks/>
        Notary,

        /// <remarks/>
        CoPartnership,

        /// <remarks/>
        NonRegisteredAssociation,

        /// <remarks/>
        ReligiousOrganization,

        /// <remarks/>
        GovernmentalInstitution,

        /// <remarks/>
        Political,

        /// <remarks/>
        PublicInstitution,

        /// <remarks/>
        Entrepreneur,

        /// <remarks/>
        LegalPersonUnderPublicLaw,

        /// <remarks/>
        SoleProprietor,

        /// <remarks/>
        Society,

        /// <remarks/>
        InvestmentGroup,

        /// <remarks/>
        NongovernmentalOrganization,

        /// <remarks/>
        School,

        /// <remarks/>
        IndividualCompany,

        /// <remarks/>
        Farm,

        /// <remarks/>
        PublicEnterprise,

        /// <remarks/>
        MunicipalEnterprise,

        /// <remarks/>
        ReligiousOrganizationsCompany,

        /// <remarks/>
        PublicOrganizationsCompany,

        /// <remarks/>
        PartnershipWithFullLiability,

        /// <remarks/>
        LimitedLiabilityCompany,

        /// <remarks/>
        CompanyWithAdditionalLiability,

        /// <remarks/>
        Branch,

        /// <remarks/>
        Representation,

        /// <remarks/>
        CooperativeSociety,

        /// <remarks/>
        CooperativeSocietiesUnionCompany,

        /// <remarks/>
        CooperativeSocietiesCompany,

        /// <remarks/>
        ShareEnterprise,

        /// <remarks/>
        CooperativeSocietiesUnion,

        /// <remarks/>
        FamilyBusiness,

        /// <remarks/>
        CompanyUnionCompany,

        /// <remarks/>
        PublicFoundation,

        /// <remarks/>
        TheCorporationProfAssociation,

        /// <remarks/>
        ProfessionalCreativeOrganization,

        /// <remarks/>
        PublicOrganizationsUnion,

        /// <remarks/>
        SportingAssociation,

        /// <remarks/>
        SportsPublicOrganization,

        /// <remarks/>
        FishermenFarm,

        /// <remarks/>
        SoleTrader,

        /// <remarks/>
        ForeignMerchantBranch,

        /// <remarks/>
        RepresentationOfForeignMerchantK,

        /// <remarks/>
        EuropeanEconomicInterestGrouping,

        /// <remarks/>
        EuEconomicInterestGroupingBranch,

        /// <remarks/>
        ArbitrationCourt,

        /// <remarks/>
        EuropeanCompany,

        /// <remarks/>
        EuropeanCooperativeAssociation,

        /// <remarks/>
        PoliticalParty,

        /// <remarks/>
        AllianceOfPoliticalParties,

        /// <remarks/>
        RepresentOfForeignOrganizations,

        /// <remarks/>
        Mission,

        /// <remarks/>
        Monastery,

        /// <remarks/>
        Office,

        /// <remarks/>
        Congregation,

        /// <remarks/>
        Diocese,

        /// <remarks/>
        Center,

        /// <remarks/>
        Church,

        /// <remarks/>
        GeneralPartnership,

        /// <remarks/>
        LimitedPartnership,

        /// <remarks/>
        PublicOrganization,

        /// <remarks/>
        DiaconalOffice,

        /// <remarks/>
        MentalTrainingAuthority,

        /// <remarks/>
        NewChurch,

        /// <remarks/>
        PoliticalOrganization,

        /// <remarks/>
        Union,

        /// <remarks/>
        RepresentationOfForeignMerchantU,

        /// <remarks/>
        TradeUnion,

        /// <remarks/>
        Representative,

        /// <remarks/>
        CatholicPublicPerson,

        /// <remarks/>
        TradeUnionIndependentUnit,

        /// <remarks/>
        TradeUnionAssociation,

        /// <remarks/>
        SocietyRel,

        /// <remarks/>
        EconomicInterestGrouping,

        /// <remarks/>
        RepresentationOfForeignMerchant,

        /// <remarks/>
        SoleOwnershipLimitedLiabilityCo,

        /// <remarks/>
        SimplifiedJointStockCompany,

        /// <remarks/>
        RuralBusinessEntity,

        /// <remarks/>
        CV,

        /// <remarks/>
        GroupDebtor,

        /// <remarks/>
        SeaTransport,

        /// <remarks/>
        Firm,

        /// <remarks/>
        CooperativeAssociation,

        /// <remarks/>
        ParentCooperative,

        /// <remarks/>
        VillageCooperative,

        /// <remarks/>
        Limited,

        /// <remarks/>
        MaskapaiAndilIndonesia,

        /// <remarks/>
        NV,

        /// <remarks/>
        RegionalCompany,

        /// <remarks/>
        StateOwnedCompany,

        /// <remarks/>
        CivilFellowship,

        /// <remarks/>
        CivicCompany,

        /// <remarks/>
        PrimaryCooperative,

        /// <remarks/>
        CooperativeCenter,

        /// <remarks/>
        VillageCooperativeCenter,

        /// <remarks/>
        TradeEnterprise,

        /// <remarks/>
        RuralLoanTradeUnit,

        /// <remarks/>
        GovernmentOrStateOrganization,

        /// <remarks/>
        JointVenture,

        /// <remarks/>
        SACorporation,

        /// <remarks/>
        StatutoryCorporation,

        /// <remarks/>
        PartnershipByEstoppel,

        /// <remarks/>
        MultimediaRecord,

        /// <remarks/>
        Newspaper,

        /// <remarks/>
        Brochure,

        /// <remarks/>
        ElectronicMassMedia,

        /// <remarks/>
        Yearbook,

        /// <remarks/>
        InformationAgencyAnnouncement,

        /// <remarks/>
        InternetMedia,

        /// <remarks/>
        Newsletter,

        /// <remarks/>
        InformativeMaterial,

        /// <remarks/>
        InternetPortal,

        /// <remarks/>
        Calendar,

        /// <remarks/>
        Catalogue,

        /// <remarks/>
        NewsReel,

        /// <remarks/>
        MonthlyNewsletter,

        /// <remarks/>
        NonperiodicPublication,

        /// <remarks/>
        PeriodicPublication,

        /// <remarks/>
        Program,

        /// <remarks/>
        RadioBroadcast,

        /// <remarks/>
        Handbook,

        /// <remarks/>
        TouristGuide,

        /// <remarks/>
        TvBroadcast,

        /// <remarks/>
        OneTimePublication,

        /// <remarks/>
        Magazine,

        /// <remarks/>
        ProffesionalAssociations,

        /// <remarks/>
        OpenJointStockCompany,

        /// <remarks/>
        GovernmentCorporation,

        /// <remarks/>
        CommunalServices,

        /// <remarks/>
        CreditUnion,

        /// <remarks/>
        ClosedJointStockCompany,

        /// <remarks/>
        Establishment,

        /// <remarks/>
        CommercialUndertaking,

        /// <remarks/>
        AssociationOfLegalEntities,

        /// <remarks/>
        HomeownersAssociation,

        /// <remarks/>
        FinancialInstitution,

        /// <remarks/>
        NonProfitOrganization,

        /// <remarks/>
        PrivateCompanyLimitedByShares,

        /// <remarks/>
        PublicCompanyimitedByShares,

        /// <remarks/>
        CompanyLimitedByGuarantee,

        /// <remarks/>
        UnlimitedLiabilityCompany,

        /// <remarks/>
        Partnership,

        /// <remarks/>
        RegisteredAssociation,

        /// <remarks/>
        VillageBusinessUnit,

        /// <remarks/>
        ShippingExpedition,

        /// <remarks/>
        Persero,

        /// <remarks/>
        TheCivilGuild,

        /// <remarks/>
        PublicCompany,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum MaritalStatus
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Single,

        /// <remarks/>
        Married,

        /// <remarks/>
        Divorced,

        /// <remarks/>
        Spouse,

        /// <remarks/>
        Widowed,

        /// <remarks/>
        Engaged,

        /// <remarks/>
        Separated,

        /// <remarks/>
        MonogamousMarriage,

        /// <remarks/>
        PolygamousMarriage,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum MethodOfPayment
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        CurrentAccount,

        /// <remarks/>
        BillOfExchange,

        /// <remarks/>
        BankingReceipt,

        /// <remarks/>
        DirectRemittance,

        /// <remarks/>
        AuthorizationToDirectCurrentAccountDebit,

        /// <remarks/>
        CashPayment,

        /// <remarks/>
        PaidByEmployer,

        /// <remarks/>
        BankCard,

        /// <remarks/>
        Other,

        /// <remarks/>
        MobileMoney,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum OwnershipType
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Individual,

        /// <remarks/>
        CoOwnerAccount,

        /// <remarks/>
        ConsortiumOfCompanies,

        /// <remarks/>
        IndividualWithConsortiumOfBanks,

        /// <remarks/>
        CoOwnerWithConsortiumOfBanks,

        /// <remarks/>
        ConsortiumOfBanksAndCompanies,

        /// <remarks/>
        Joint,

        /// <remarks/>
        Single,

        /// <remarks/>
        GroupLoan,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/CI.CBS.Contracts.Public.Structures.Enums." +
        "Common")]
    public enum Resident
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Yes,

        /// <remarks/>
        No,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public enum SocialStatus
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        Student,

        /// <remarks/>
        Employed,

        /// <remarks/>
        Unemployed,

        /// <remarks/>
        Retired,

        /// <remarks/>
        HomeMaker,

        /// <remarks/>
        Housewife,

        /// <remarks/>
        SelfEmployed,

        /// <remarks/>
        MaternityLeave,

        /// <remarks/>
        EmployedWithIndefiniteContract,

        /// <remarks/>
        EmployedWithFixedTermContract,

        /// <remarks/>
        InformalEmployment,

        /// <remarks/>
        Employee,

        /// <remarks/>
        Worker,

        /// <remarks/>
        Casual,

        /// <remarks/>
        Contract,

        /// <remarks/>
        Permanent,

        /// <remarks/>
        Pensioner,

        /// <remarks/>
        DisabilityPension,

        /// <remarks/>
        Parttimejob,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/CI.CBS.Contracts.Public.Structures.Enums." +
        "Common")]
    public enum SubjectSearchStatus
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        SubjectFound,

        /// <remarks/>
        SubjectNotFound,

        /// <remarks/>
        IndividualMatchesConfirmDateOfBirth,

        /// <remarks/>
        ConsentRequired,

        /// <remarks/>
        InquiryReasonRequired,

        /// <remarks/>
        SubjectIdentificationInvalid,

        /// <remarks/>
        SubjectName3CharsRequired,

        /// <remarks/>
        InvalidDateOfBirth,

        /// <remarks/>
        IDNumberIsConnectedWithIndividual,

        /// <remarks/>
        IDNumberIsConnectedWithCompany,

        /// <remarks/>
        MatchingLimitExceeded,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class SmartSearchCompanyResults : SearchResults
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class SmartSearchIndividualResults : SearchResults
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SmartSearchCompanyQuery))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SmartSearchIndividualQuery))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class SmartSearchQuery
    {

        private bool avoidUsageLogField;

        private bool avoidUsageLogFieldSpecified;

        private int inquiryReasonField;

        private bool inquiryReasonFieldSpecified;

        private string inquiryReasonTextField;

        private SmartSearchParameters parametersField;

        /// <remarks/>
        public bool AvoidUsageLog
        {
            get
            {
                return this.avoidUsageLogField;
            }
            set
            {
                this.avoidUsageLogField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AvoidUsageLogSpecified
        {
            get
            {
                return this.avoidUsageLogFieldSpecified;
            }
            set
            {
                this.avoidUsageLogFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int InquiryReason
        {
            get
            {
                return this.inquiryReasonField;
            }
            set
            {
                this.inquiryReasonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InquiryReasonSpecified
        {
            get
            {
                return this.inquiryReasonFieldSpecified;
            }
            set
            {
                this.inquiryReasonFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string InquiryReasonText
        {
            get
            {
                return this.inquiryReasonTextField;
            }
            set
            {
                this.inquiryReasonTextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SmartSearchParameters Parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class SmartSearchCompanyQuery : SmartSearchQuery
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class SmartSearchIndividualQuery : SmartSearchQuery
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public partial class PublicSearchCompanyRecord
    {

        private string addressField;

        private long creditinfoIdField;

        private bool creditinfoIdFieldSpecified;

        private string registeredNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <remarks/>
        public long CreditinfoId
        {
            get
            {
                return this.creditinfoIdField;
            }
            set
            {
                this.creditinfoIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreditinfoIdSpecified
        {
            get
            {
                return this.creditinfoIdFieldSpecified;
            }
            set
            {
                this.creditinfoIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string RegisteredName
        {
            get
            {
                return this.registeredNameField;
            }
            set
            {
                this.registeredNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public partial class PublicSearchCompanyResults
    {

        private PublicSearchCompanyRecord[] companyRecordsField;

        private System.Nullable<long> creditinfoIdField;

        private bool creditinfoIdFieldSpecified;

        private NilReport nilReportField;

        private PublicSearchCompanyParameters parametersField;

        private SubjectSearchStatus statusField;

        private bool statusFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public PublicSearchCompanyRecord[] CompanyRecords
        {
            get
            {
                return this.companyRecordsField;
            }
            set
            {
                this.companyRecordsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<long> CreditinfoId
        {
            get
            {
                return this.creditinfoIdField;
            }
            set
            {
                this.creditinfoIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreditinfoIdSpecified
        {
            get
            {
                return this.creditinfoIdFieldSpecified;
            }
            set
            {
                this.creditinfoIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public NilReport NilReport
        {
            get
            {
                return this.nilReportField;
            }
            set
            {
                this.nilReportField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public PublicSearchCompanyParameters Parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }

        /// <remarks/>
        public SubjectSearchStatus Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatusSpecified
        {
            get
            {
                return this.statusFieldSpecified;
            }
            set
            {
                this.statusFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5")]
    public partial class NilReport
    {

        private NilReportRecord[] recordsField;

        private NilReportSum summaryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public NilReportRecord[] Records
        {
            get
            {
                return this.recordsField;
            }
            set
            {
                this.recordsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public NilReportSum Summary
        {
            get
            {
                return this.summaryField;
            }
            set
            {
                this.summaryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public partial class PublicSearchCompanyParameters
    {

        private string idNumberField;

        private IDNumberTypePublicCompany idNumberTypeField;

        private bool idNumberTypeFieldSpecified;

        private string registeredNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string IdNumber
        {
            get
            {
                return this.idNumberField;
            }
            set
            {
                this.idNumberField = value;
            }
        }

        /// <remarks/>
        public IDNumberTypePublicCompany IdNumberType
        {
            get
            {
                return this.idNumberTypeField;
            }
            set
            {
                this.idNumberTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdNumberTypeSpecified
        {
            get
            {
                return this.idNumberTypeFieldSpecified;
            }
            set
            {
                this.idNumberTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string RegisteredName
        {
            get
            {
                return this.registeredNameField;
            }
            set
            {
                this.registeredNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public enum IDNumberTypePublicCompany
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        PinNumber,

        /// <remarks/>
        RegistrationNumber,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public partial class PublicSearchCompanyQuery
    {

        private PublicSearchCompanyParameters parametersField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public PublicSearchCompanyParameters Parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public partial class PublicSearchIndividualRecord
    {

        private string addressField;

        private long creditinfoIdField;

        private bool creditinfoIdFieldSpecified;

        private System.Nullable<System.DateTime> dateOfBirthField;

        private bool dateOfBirthFieldSpecified;

        private string fullNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <remarks/>
        public long CreditinfoId
        {
            get
            {
                return this.creditinfoIdField;
            }
            set
            {
                this.creditinfoIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreditinfoIdSpecified
        {
            get
            {
                return this.creditinfoIdFieldSpecified;
            }
            set
            {
                this.creditinfoIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                return this.dateOfBirthField;
            }
            set
            {
                this.dateOfBirthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOfBirthSpecified
        {
            get
            {
                return this.dateOfBirthFieldSpecified;
            }
            set
            {
                this.dateOfBirthFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FullName
        {
            get
            {
                return this.fullNameField;
            }
            set
            {
                this.fullNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public partial class PublicSearchIndividualResults
    {

        private System.Nullable<long> creditinfoIdField;

        private bool creditinfoIdFieldSpecified;

        private PublicSearchIndividualRecord[] individualRecordsField;

        private NilReport nilReportField;

        private PublicSearchIndividualParameters parametersField;

        private SubjectSearchStatus statusField;

        private bool statusFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<long> CreditinfoId
        {
            get
            {
                return this.creditinfoIdField;
            }
            set
            {
                this.creditinfoIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreditinfoIdSpecified
        {
            get
            {
                return this.creditinfoIdFieldSpecified;
            }
            set
            {
                this.creditinfoIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public PublicSearchIndividualRecord[] IndividualRecords
        {
            get
            {
                return this.individualRecordsField;
            }
            set
            {
                this.individualRecordsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public NilReport NilReport
        {
            get
            {
                return this.nilReportField;
            }
            set
            {
                this.nilReportField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public PublicSearchIndividualParameters Parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }

        /// <remarks/>
        public SubjectSearchStatus Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatusSpecified
        {
            get
            {
                return this.statusFieldSpecified;
            }
            set
            {
                this.statusFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public partial class PublicSearchIndividualParameters
    {

        private string forename1Field;

        private string idNumberField;

        private IDNumberTypePublicIndividual idNumberTypeField;

        private bool idNumberTypeFieldSpecified;

        private string surnameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Forename1
        {
            get
            {
                return this.forename1Field;
            }
            set
            {
                this.forename1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string IdNumber
        {
            get
            {
                return this.idNumberField;
            }
            set
            {
                this.idNumberField = value;
            }
        }

        /// <remarks/>
        public IDNumberTypePublicIndividual IdNumberType
        {
            get
            {
                return this.idNumberTypeField;
            }
            set
            {
                this.idNumberTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdNumberTypeSpecified
        {
            get
            {
                return this.idNumberTypeFieldSpecified;
            }
            set
            {
                this.idNumberTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Surname
        {
            get
            {
                return this.surnameField;
            }
            set
            {
                this.surnameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public enum IDNumberTypePublicIndividual
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        PinNumber,

        /// <remarks/>
        NationalID,

        /// <remarks/>
        PassportNumber,

        /// <remarks/>
        AlienRegistration,

        /// <remarks/>
        ServiceId,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public partial class PublicSearchIndividualQuery
    {

        private PublicSearchIndividualParameters parametersField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public PublicSearchIndividualParameters Parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public partial class SearchCompanyRecord
    {

        private string addressField;

        private long creditinfoIdField;

        private bool creditinfoIdFieldSpecified;

        private string registeredNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <remarks/>
        public long CreditinfoId
        {
            get
            {
                return this.creditinfoIdField;
            }
            set
            {
                this.creditinfoIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreditinfoIdSpecified
        {
            get
            {
                return this.creditinfoIdFieldSpecified;
            }
            set
            {
                this.creditinfoIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string RegisteredName
        {
            get
            {
                return this.registeredNameField;
            }
            set
            {
                this.registeredNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public partial class SearchCompanyResults
    {

        private SearchCompanyRecord[] companyRecordsField;

        private System.Nullable<long> creditinfoIdField;

        private bool creditinfoIdFieldSpecified;

        private NilReport nilReportField;

        private SearchCompanyParameters parametersField;

        private SubjectSearchStatus statusField;

        private bool statusFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public SearchCompanyRecord[] CompanyRecords
        {
            get
            {
                return this.companyRecordsField;
            }
            set
            {
                this.companyRecordsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<long> CreditinfoId
        {
            get
            {
                return this.creditinfoIdField;
            }
            set
            {
                this.creditinfoIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreditinfoIdSpecified
        {
            get
            {
                return this.creditinfoIdFieldSpecified;
            }
            set
            {
                this.creditinfoIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public NilReport NilReport
        {
            get
            {
                return this.nilReportField;
            }
            set
            {
                this.nilReportField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SearchCompanyParameters Parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }

        /// <remarks/>
        public SubjectSearchStatus Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatusSpecified
        {
            get
            {
                return this.statusFieldSpecified;
            }
            set
            {
                this.statusFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public partial class SearchCompanyParameters
    {

        private string idNumberField;

        private IDNumberTypeCompany idNumberTypeField;

        private bool idNumberTypeFieldSpecified;

        private string registeredNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string IdNumber
        {
            get
            {
                return this.idNumberField;
            }
            set
            {
                this.idNumberField = value;
            }
        }

        /// <remarks/>
        public IDNumberTypeCompany IdNumberType
        {
            get
            {
                return this.idNumberTypeField;
            }
            set
            {
                this.idNumberTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdNumberTypeSpecified
        {
            get
            {
                return this.idNumberTypeFieldSpecified;
            }
            set
            {
                this.idNumberTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string RegisteredName
        {
            get
            {
                return this.registeredNameField;
            }
            set
            {
                this.registeredNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public enum IDNumberTypeCompany
    {

        /// <remarks/>
        NotSpecified,

        /// <remarks/>
        PinNumber,

        /// <remarks/>
        RegistrationNumber,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public partial class SearchCompanyQuery
    {

        private SearchCompanyParameters parametersField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SearchCompanyParameters Parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public partial class SearchIndividualRecord
    {

        private string addressField;

        private long creditinfoIdField;

        private bool creditinfoIdFieldSpecified;

        private System.Nullable<System.DateTime> dateOfBirthField;

        private bool dateOfBirthFieldSpecified;

        private string fullNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <remarks/>
        public long CreditinfoId
        {
            get
            {
                return this.creditinfoIdField;
            }
            set
            {
                this.creditinfoIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreditinfoIdSpecified
        {
            get
            {
                return this.creditinfoIdFieldSpecified;
            }
            set
            {
                this.creditinfoIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                return this.dateOfBirthField;
            }
            set
            {
                this.dateOfBirthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOfBirthSpecified
        {
            get
            {
                return this.dateOfBirthFieldSpecified;
            }
            set
            {
                this.dateOfBirthFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FullName
        {
            get
            {
                return this.fullNameField;
            }
            set
            {
                this.fullNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://creditinfo.com/CB5/v5.21/Search")]
    public partial class SearchIndividualResults
    {

        private System.Nullable<long> creditinfoIdField;

        private bool creditinfoIdFieldSpecified;

        private SearchIndividualRecord[] individualRecordsField;

        private NilReport nilReportField;

        private SearchIndividualParameters parametersField;

        private SubjectSearchStatus statusField;

        private bool statusFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<long> CreditinfoId
        {
            get
            {
                return this.creditinfoIdField;
            }
            set
            {
                this.creditinfoIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreditinfoIdSpecified
        {
            get
            {
                return this.creditinfoIdFieldSpecified;
            }
            set
            {
                this.creditinfoIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        public SearchIndividualRecord[] IndividualRecords
        {
            get
            {
                return this.individualRecordsField;
            }
            set
            {
                this.individualRecordsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public NilReport NilReport
        {
            get
            {
                return this.nilReportField;
            }
            set
            {
                this.nilReportField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public SearchIndividualParameters Parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }

        /// <remarks/>
        public SubjectSearchStatus Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatusSpecified
        {
            get
            {
                return this.statusFieldSpecified;
            }
            set
            {
                this.statusFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void SearchIndividualCompletedEventHandler(object sender, SearchIndividualCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SearchIndividualCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal SearchIndividualCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public SearchIndividualResults Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((SearchIndividualResults)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void SearchCompanyCompletedEventHandler(object sender, SearchCompanyCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SearchCompanyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal SearchCompanyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public SearchCompanyResults Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((SearchCompanyResults)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void PublicSearchIndividualCompletedEventHandler(object sender, PublicSearchIndividualCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PublicSearchIndividualCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal PublicSearchIndividualCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public PublicSearchIndividualResults Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((PublicSearchIndividualResults)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void PublicSearchCompanyCompletedEventHandler(object sender, PublicSearchCompanyCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PublicSearchCompanyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal PublicSearchCompanyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public PublicSearchCompanyResults Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((PublicSearchCompanyResults)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void SmartSearchIndividualCompletedEventHandler(object sender, SmartSearchIndividualCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SmartSearchIndividualCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal SmartSearchIndividualCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public SmartSearchIndividualResults Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((SmartSearchIndividualResults)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void SmartSearchCompanyCompletedEventHandler(object sender, SmartSearchCompanyCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SmartSearchCompanyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal SmartSearchCompanyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public SmartSearchCompanyResults Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((SmartSearchCompanyResults)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void GetCustomReportSectionsCompletedEventHandler(object sender, GetCustomReportSectionsCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCustomReportSectionsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetCustomReportSectionsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void GetCustomReportCompletedEventHandler(object sender, GetCustomReportCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCustomReportCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetCustomReportCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public CustomReport Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((CustomReport)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void GetExternalReportCompletedEventHandler(object sender, GetExternalReportCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetExternalReportCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetExternalReportCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public System.Xml.XmlElement Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlElement)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void GetExternalReportListCompletedEventHandler(object sender, GetExternalReportListCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetExternalReportListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetExternalReportListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void GetExternalReportSchemaCompletedEventHandler(object sender, GetExternalReportSchemaCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetExternalReportSchemaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetExternalReportSchemaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public Schemas Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((Schemas)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void GetPdfReportCompletedEventHandler(object sender, GetPdfReportCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetPdfReportCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetPdfReportCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public byte[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void GetSupportedLanguagesCompletedEventHandler(object sender, GetSupportedLanguagesCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSupportedLanguagesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetSupportedLanguagesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public LanguageDTO[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((LanguageDTO[])(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void GetSupportedReportsCompletedEventHandler(object sender, GetSupportedReportsCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSupportedReportsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetSupportedReportsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }

    }
}
