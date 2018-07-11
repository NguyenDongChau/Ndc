using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ndc.Library.RequestResponse
{
    public class Response
    {
        public long ErrorCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }

        public static string SendResponse(Response response, string strKey)
        {
            var encrypted = string.Empty;
            try
            {
                //Serialize response object
                var strResponse = JsonConvert.SerializeObject(response);
                //Encrypt response string
                encrypted = EncryptDecrypt.Encryption.Encrypt(strResponse, strKey);
            }
            catch (Exception ex)
            {
                //Write error log
                ex.StackTrace.ToString();
            }
            return encrypted;
        }
    }
}
