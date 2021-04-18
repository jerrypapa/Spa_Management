using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

  namespace Spa_Management.Operations
{
  
    public class IPRSDetails
    {

        private readonly DbOperations _dbOpers;
        // Get IPRS Response details functions 

        public class message_validation
        {
            public string api_user { get; set; }
            public string api_password { get; set; }
            public string token { get; set; }

        }

        public class message_route
        {
            public string @interface { get; set; }

            public string request_type { get; set; }

            public string external_ref_number { get; set; }
        }

        public class message_body
        {
            public string query_by { get; set; }

            public string id_number { get; set; }

            public string serial_number { get; set; }
        }

        public class IPRSSendResponse
        {
            public message_validation message_validation { get; set; }
            public message_route message_route { get; set; }
            public message_body message_body { get; set; }
        }

        // Json Format 
        //  {  
        //   "message_validation":{  
        //      "api_user":"dit",
        //      "api_password":"123456",
        //      "token": "gTNR4LL5EMrR25DvhhZGsg"
        //   },
        //   "message_route": {
        //       "interface": "IPRS",
        //       "request_type": "iprs",
        //       "external_ref_number":"1547457640686"
        //   },
        //   "message_body":{
        //       "query_by": "by_id",
        //   "id_number": "30618657",
        //   "serial_number": ""
        //   }
        //}

        public class error_description
        {
            public string citizenship { get; set; }
            public object clan { get; set; }
            public string date_of_birth { get; set; }
            public object date_of_death { get; set; }
            public string date_of_issue { get; set; }
            public string error_code { get; set; }
            public string error_desc { get; set; }
            public object ethnic_group { get; set; }
            public object family { get; set; }
            public object finger_print { get; set; }
            public string first_name { get; set; }
            public string gender { get; set; }
            public string id_number { get; set; }
            public object occupation { get; set; }
            public string other_name { get; set; }
            public object photo { get; set; }
            public object pin { get; set; }
            public string place_of_birth { get; set; }
            public object place_of_death { get; set; }
            public string place_of_live { get; set; }
            public object reg_office { get; set; }
            public string serial_number { get; set; }
            public object signature { get; set; }
            public string surname { get; set; }

            //public string citizenship { get; set; }

            //public string clan { get; set; }

            //public DateTime date_of_birth { get; set; }

            //public DateTime date_of_death { get; set; }

            //public DateTime date_of_issue { get; set; }
            //public string error_code { get; set; }

            //public string error_desc { get; set; }

            //public string ethnic_group { get; set; }
            //public string family { get; set; }

            //public byte finger_print { get; set; }

            //public string first_name { get; set; }

            //public string gender { get; set; }

            //public string id_number { get; set; }

            //public string occupation { get; set; }

            //public string other_name { get; set; }

            //public byte photo { get; set; }

            //public string pin { get; set; }

            //public string place_of_birth { get; set; }

            //public string place_of_death { get; set; }

            //public string place_of_live { get; set; }

            //public string reg_office { get; set; }

            //public string serial_number { get; set; }

            //public byte signature { get; set; }

            //public string surname { get; set; }
        }

        public class IPRSGetResponseDetails
        {
            public string error_code { get; set; }

            public error_description error_desc { get; set; }
            
        }


        public string IPRSResponseDetails(object _obj)
        {
            try
            {
                //string url = object.ReferenceEquals(_dbOpers.GetSysParameter("IPRS Token URL"), null) ? "http://apps.kenswitch.com:9090/RAPI/api/Solid/SubmitRequest" : _dbOpers.GetSysParameter("IPRS Token URL").Value.Trim();
                string url = "http://apps.kenswitch.com:9090/RAPI/api/Solid/SubmitRequest";
                WebRequest tRequest = WebRequest.Create(url);

                tRequest.Method = "POST";
                tRequest.ContentType = "application/json";
                string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(_obj);

                Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);

                tRequest.ContentLength = byteArray.Length;
                tRequest.ContentType = "application/json";
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse request = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = request.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                string res = tReader.ReadToEnd();
                                return res;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _dbOpers.LogError("IPRS Details Response", "Log IPRS Details Response to " + _obj, "", ex.Message.ToString(), object.ReferenceEquals(ex.InnerException, null) ? "N/A" : ex.InnerException.ToString());
            }
            return null;
        }
    }

}

