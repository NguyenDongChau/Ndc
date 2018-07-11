using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ndc.Library.RequestResponse
{
    public class Request
    {
        public string RequestName { get; set; }
        public string RequestParam { get; set; }

        public static Request GetRequest(string encrypted, string strKey)
        {
            var request = new Request();
            try
            {
                //Decrypt request string 
                var strRequest = EncryptDecrypt.Decryption.Decrypt(strKey);
                //Deserialize request string to request object
                request = JsonConvert.DeserializeObject<Request>(strRequest);
            }
            catch(Exception ex)
            {
                //Write error log
                ex.StackTrace.ToString();
            }
            return request;
        }
    }
}
