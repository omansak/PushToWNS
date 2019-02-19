using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace PushToWNS
{
    public class WNSOAuth
    {
        private string _address = "https://login.live.com/accesstoken.srf";
        public OAuthToken GetAccess(Configuration configuration)
        {
            if (string.IsNullOrEmpty(configuration.SId)) throw new ArgumentNullException(nameof(configuration.SId));
            if (string.IsNullOrEmpty(configuration.Secret)) throw new ArgumentNullException(nameof(configuration.SId));

            string response = string.Empty,
                urlEncodedSecret = HttpUtility.UrlEncode(configuration.Secret),
                urlEncodedSid = HttpUtility.UrlEncode(configuration.SId),
                body = "grant_type=client_credentials&" +
                      $"client_id={urlEncodedSid}&" +
                      $"client_secret={urlEncodedSecret}&" +
                      "scope=notify.windows.com";

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                response = client.UploadString(_address, body);
            }
            return GetOAuthTokenFromJson(response);
        }
        private OAuthToken GetOAuthTokenFromJson(string jsonString)
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
            {
                var ser = new DataContractJsonSerializer(typeof(OAuthToken));
                var oAuthToken = (OAuthToken)ser.ReadObject(ms);
                return oAuthToken;
            }
        }
    }
}
