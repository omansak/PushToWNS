using PushToWNS;
using System;

namespace PushToWNS_debugger
{
    class Program
    {
        static void Main(string[] args)
        {
            PushToWNS.Configuration configuration = new Configuration();
            /*
             * Run in your client UWP application and get your channel URI
             * var channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
             */
            configuration.ChannelUri = "https://db5p.notify.windows.com/?token=AwYAAADKCTA6i4....";
            /*
             *Get SId and Secret from LiveServices (Dashboard -> Your App -> App Managament -> WNS/MPNS -> Live Services site)
             *https://partner.microsoft.com/en-us/dashboard/products/<-YourProductId->/liveservices
             */
            configuration.SId =
                "ms-app://s-1-15-2-1407194542-....";
            configuration.Secret = "fgOErrASmDC7X/jwQhbg9hjVKS9....";
            configuration.XML= @"<?xml version=""1.0"" encoding=""utf-8""?> <toast launch=""<-Your Data->""> <visual baseUri=""""> <binding template=""ToastGeneric""> <text>🔥 Hello World</text> <image src=""https://d1q6f0aelx0por.cloudfront.net/product-logos/5431a80b-9ab9-486c-906a-e3d4b5ccaa96-hello-world.png"" /> </binding> </visual> <audio src=""ms-winsoundevent:Notification.Looping.Alarm9"" /> <actions /> </toast>";
            Console.WriteLine(new PushToWNS.PushNotification().Push(configuration));
            Console.ReadLine();
        }
    }
}
