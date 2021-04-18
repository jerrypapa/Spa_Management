using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spa_Management.Operations
{
    public class SendSMS
    {
        public static bool Send_Sms(string fonNumber, string mess, string userName, string apiKey, string From)
        {
            // Specify your login credentials
            //get credentials from db.
            string username = userName ?? "fintech";//"fintech";
            string recipients = fonNumber;
            // And of course we want our recipients to know what we really do
            string message = mess;// "I'm a Papa Jerry and its ok, I sleep all night and I work all day";
            string from = From ?? "FintechKE";
            // Create a new instance of our awesome gateway class
            AfricasTalkingGateway gateway = new AfricasTalkingGateway(username, apiKey ?? "75beef803c700841fa03177772841ff825379778a1553c1011dba98ab03694b0");
            // Any gateway errors will be captured by our custom Exception class below,
            // so wrap the call in a try-catch block   
            try
            {
                // Thats it, hit send and we'll take care of the rest

                return gateway.sendMessage(recipients, message, from);
            }
            catch (AfricasTalkingGatewayException ex)
            {
                //Console.WriteLine("Encountered an error: " + e.Message);
            }
            return false;
        }
    }
    public class AfricasTalkingGatewayException : Exception
    {
        public AfricasTalkingGatewayException(string message)
                : base(message) { }
    }
    public class AfricasTalkingGateway
    {
        private string _username;
        private string _apiKey;
        private int responseCode;
        //private JavaScriptSerializer serializer;

        private static string SMS_URLString = "https://api.africastalking.com/version1/messaging";
        private static string VOICE_URLString = "https://voice.africastalking.com";
        private static string SUBSCRIPTION_URLString = "https://api.africastalking.com/subscription";
        private static string USERDATA_URLString = "https://api.africastalking.com/version1/user";
        //private static string AIRTIME_URLString = "https://api.africastalking.com/version1/airtime";

        //Change the debug flag to true to view the full response
        private Boolean DEBUG = false;

        public AfricasTalkingGateway(string username_, string apiKey_)
        {
            _username = username_;
            _apiKey = apiKey_;
            //serializer = new JavaScriptSerializer();
        }
        public bool sendMessage(string to_, string message_, string from_ = null, int bulkSMSMode_ = 1, Hashtable options_ = null)
        {
            Hashtable data = new Hashtable();
            data["username"] = _username;
            data["to"] = to_;
            data["message"] = message_;
            if (from_ != null)
            {
                data["from"] = from_;
                data["bulkSMSMode"] = Convert.ToString(bulkSMSMode_);

                if (options_ != null)
                {
                    if (options_.Contains("keyword"))
                    {
                        data["keyword"] = options_["keyword"];
                    }

                    if (options_.Contains("linkId"))
                    {
                        data["linkId"] = options_["linkId"];
                    }

                    if (options_.Contains("enqueue"))
                    {
                        data["enqueue"] = options_["enqueue"];
                    }

                    if (options_.Contains("retryDurationInHours"))
                        data["retryDurationInHours"] = options_["retryDurationInHours"];
                }
            }

            string response = sendPostRequest(data, SMS_URLString);
            if (responseCode == (int)HttpStatusCode.Created)
            {
                var json = JsonConvert.DeserializeObject<dynamic>(response);
                dynamic recipients = json["SMSMessageData"]["Recipients"];
                if (!object.ReferenceEquals(recipients, null))
                {
                    dynamic status = json["SMSMessageData"]["Recipients"][0]["status"];
                    dynamic code = json["SMSMessageData"]["Recipients"][0]["statusCode"];
                    if ((string)status == "Success")
                    {
                        return true;
                    }
                    if ((int)code == 101)
                    {
                        return true;
                    }
                }
                return false;
            }
            throw new AfricasTalkingGatewayException(response);
        }


        public dynamic fetchMessages(int lastReceivedId_)
        {
            string url = SMS_URLString + "?username=" + _username + "&lastReceivedId=" + Convert.ToString(lastReceivedId_);
            string response = sendGetRequest(url);
            if (responseCode == (int)HttpStatusCode.OK)
            {
                dynamic json = JsonConvert.DeserializeObject(response);
                return json["SMSMessageData"]["Messages"];
            }
            throw new AfricasTalkingGatewayException(response);
        }

        public dynamic createSubscription(string phoneNumber_, string shortCode_, string keyword_)
        {
            if (phoneNumber_.Length == 0 || shortCode_.Length == 0 || keyword_.Length == 0)
                throw new AfricasTalkingGatewayException("Please supply phone number, short code and keyword");
            Hashtable data_ = new Hashtable();
            data_["username"] = _username;
            data_["phoneNumber"] = phoneNumber_;
            data_["shortCode"] = shortCode_;
            data_["keyword"] = keyword_;
            string urlString = SUBSCRIPTION_URLString + "/create";
            string response = sendPostRequest(data_, urlString);
            if (responseCode == (int)HttpStatusCode.Created)
            {
                dynamic json = JsonConvert.DeserializeObject<dynamic>(response);
                return json;
            }
            throw new AfricasTalkingGatewayException(response);
        }

        public dynamic deleteSubscription(string phoneNumber_, string shortCode_, string keyword_)
        {
            if (phoneNumber_.Length == 0 || shortCode_.Length == 0 || keyword_.Length == 0)
                throw new AfricasTalkingGatewayException("Please supply phone number, short code and keyword");
            Hashtable data_ = new Hashtable();
            data_["username"] = _username;
            data_["phoneNumber"] = phoneNumber_;
            data_["shortCode"] = shortCode_;
            data_["keyword"] = keyword_;
            string urlString = SUBSCRIPTION_URLString + "/delete";
            string response = sendPostRequest(data_, urlString);
            if (responseCode == (int)HttpStatusCode.Created)
            {
                dynamic json = JsonConvert.DeserializeObject<dynamic>(response);
                return json;
            }
            throw new AfricasTalkingGatewayException(response);
        }

        public dynamic call(string from_, string to_)
        {
            Hashtable data = new Hashtable();
            data["username"] = _username;
            data["from"] = from_;
            data["to"] = to_;

            string urlString = VOICE_URLString + "/call";
            string response = sendPostRequest(data, urlString);

            dynamic json = JsonConvert.DeserializeObject<dynamic>(response);
            if ((string)json["errorMessage"] == "None")
            {
                return json["entries"];
            }
            throw new AfricasTalkingGatewayException(json["errorMessage"]);
        }

        public int getNumQueuedCalls(string phoneNumber_, string queueName_ = null)
        {
            Hashtable data = new Hashtable();
            data["username"] = _username;
            data["phoneNumbers"] = phoneNumber_;
            if (queueName_ != null)
                data["queueName"] = queueName_;

            string urlString = VOICE_URLString + "/queueStatus";
            string response = sendPostRequest(data, urlString);
            dynamic json = JsonConvert.DeserializeObject<dynamic>(response);
            if ((string)json["errorMessage"] == "None")
            {
                return json["entries"];
            }
            throw new AfricasTalkingGatewayException(json["errorMessage"]);
        }

        public void uploadMediaFile(string url_)
        {
            Hashtable data = new Hashtable();
            data["username"] = _username;
            data["url"] = url_;

            string urlString = VOICE_URLString + "/mediaUpload";
            string response = sendPostRequest(data, urlString);
            dynamic json = JsonConvert.DeserializeObject<dynamic>(response);
            if ((string)json["errorMessage"] != "None")
                throw new AfricasTalkingGatewayException(json["errorMessage"]);
        }

        

        public dynamic getUserData()
        {
            string urlString = USERDATA_URLString + "?username=" + _username;
            string response = sendGetRequest(urlString);
            if (responseCode == (int)HttpStatusCode.OK)
            {
                dynamic json = JsonConvert.DeserializeObject<dynamic>(response);
                return json["UserData"];
            }
            throw new AfricasTalkingGatewayException(response);
        }

        private string sendPostRequest(Hashtable dataMap_, string urlString_)
        {
            try
            {
                string dataStr = "";
                foreach (string key in dataMap_.Keys)
                {
                    if (dataStr.Length > 0) dataStr += "&";
                    string value = (string)dataMap_[key];
                    dataStr += HttpUtility.UrlEncode(key, Encoding.UTF8);
                    dataStr += "=" + HttpUtility.UrlEncode(value, Encoding.UTF8);
                }

                byte[] byteArray = Encoding.UTF8.GetBytes(dataStr);

                System.Net.ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCallback;
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(urlString_);

                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.ContentLength = byteArray.Length;
                webRequest.Accept = "application/json";

                webRequest.Headers.Add("apiKey", _apiKey);

                Stream webpageStream = webRequest.GetRequestStream();
                webpageStream.Write(byteArray, 0, byteArray.Length);
                webpageStream.Close();

                HttpWebResponse httpResponse = (HttpWebResponse)webRequest.GetResponse();
                responseCode = (int)httpResponse.StatusCode;
                StreamReader webpageReader = new StreamReader(httpResponse.GetResponseStream());
                string response = webpageReader.ReadToEnd();

                if (DEBUG)
                    Console.WriteLine("Full response: " + response);

                return response;

            }
            catch (WebException ex)
            {
                if (ex.Response == null)
                    throw new AfricasTalkingGatewayException(ex.Message);
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string response = reader.ReadToEnd();

                    if (DEBUG)
                        Console.WriteLine("Full response: " + response);

                    return response;
                }
            }

            catch (AfricasTalkingGatewayException ex)
            {
                throw ex;
            }
        }

        private string sendGetRequest(string urlString_)
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCallback;

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(urlString_);
                webRequest.Method = "GET";
                webRequest.Accept = "application/json";
                webRequest.Headers.Add("apiKey", _apiKey);

                HttpWebResponse httpResponse = (HttpWebResponse)webRequest.GetResponse();
                responseCode = (int)httpResponse.StatusCode;
                StreamReader webpageReader = new StreamReader(httpResponse.GetResponseStream());

                string response = webpageReader.ReadToEnd();

                if (DEBUG)
                    Console.WriteLine("Full response: " + response);

                return response;

            }

            catch (WebException ex)
            {
                if (ex.Response == null)
                    throw new AfricasTalkingGatewayException(ex.Message);

                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string response = reader.ReadToEnd();

                    if (DEBUG)
                        Console.WriteLine("Full response: " + response);

                    return response;
                }
            }

            catch (AfricasTalkingGatewayException ex)
            {
                throw ex;
            }
        }

        private Boolean RemoteCertificateValidationCallback(object sender_, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain_, System.Net.Security.SslPolicyErrors errors_)
        {
            return true;
        }

    }
}
