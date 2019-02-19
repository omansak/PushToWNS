using System;
using System.IO;
using System.Net;
using System.Text;

namespace PushToWNS
{
    public class PushNotification
    {
        public HttpStatusCode Push(Configuration configuration)
        {
            try
            {
                OAuthToken accessToken = new WNSOAuth().GetAccess(configuration);
                byte[] contentInBytes = Encoding.UTF8.GetBytes(configuration.XML);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(configuration.ChannelUri);
                request.Method = "POST";
                request.Headers.Add("X-WNS-Type", configuration.NotificationType);
                request.ContentType = configuration.ContentType;
                request.Headers.Add("Authorization", $"Bearer {accessToken.AccessToken}");

                using (Stream requestStream = request.GetRequestStream())
                    requestStream.Write(contentInBytes, 0, contentInBytes.Length);

                using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
                    return webResponse.StatusCode;
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                switch (code)
                {
                    case HttpStatusCode.Unauthorized:
                        {
                            new WNSOAuth().GetAccess(configuration);
                            return Push(configuration);
                        }
                    case HttpStatusCode.Gone:
                    case HttpStatusCode.NotFound:
                        throw new Exception("The channel URI is no longer valid");
                    case HttpStatusCode.NotAcceptable:
                        throw new Exception("This channel is being throttled by WNS");
                    default:
                        {
                            // http://msdn.microsoft.com/en-us/library/windows/apps/hh868245.aspx#wnsresponsecodes
                            return code;
                        }
                }
            }

        }
    }
}
