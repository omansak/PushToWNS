# PushToWNS
Send push notifications to WNS for Windows 8/10 applications UWP [Windows Notification Services](https://docs.microsoft.com/en-us/windows/uwp/design/shell/tiles-and-notifications/windows-push-notification-services--wns--overview). 
# WNS (Windows Notification Service)
Send push notifications from a .NET Core application to a Windows 8/10 (UWP) device using Windows Notification Services.
# Pre-Requirements
## Secret & SId
Get SId and Secret from LiveServices (Dashboard -> Your App -> App Managament -> WNS/MPNS -> Live Services site)
```https://partner.microsoft.com/en-us/dashboard/products/<-YourProductId->/liveservices```
## Channel URI
Run in your client UWP application and get your channel URI
```c#
var channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
```
# Usage
```c#
PushToWNS.Configuration configuration = new Configuration();
configuration.ChannelUri = "https://db5p.notify.windows.com/?token=AwYAAADKCTA6i4....";
configuration.SId ="ms-app://s-1-15-2-1407194542-....";
configuration.Secret = "fgOErrASmDC7X/jwQhbg9hjVKS9....";
configuration.XML= @"<?xml version=""1.0"" encoding=""utf-8""?> <toast launch=""<-Your Data->""> <visual baseUri=""""> <binding template=""ToastGeneric""> <text>🔥 Hello World</text> <image src=""https://d1q6f0aelx0por.cloudfront.net/product-logos/5431a80b-9ab9-486c-906a-e3d4b5ccaa96-hello-world.png"" /> </binding> </visual> <audio src=""ms-winsoundevent:Notification.Looping.Alarm9"" /> <actions /> </toast>";
new PushToWNS.PushNotification().Push(configuration);
```
