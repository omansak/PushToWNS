namespace PushToWNS
{
    public class Configuration
    {
        public string Secret { get; set; }
        public string SId { get; set; }
        public string ChannelUri { get; set; }
        public string NotificationType { get; set; }
        public string ContentType { get; set; }
        public string XML { get; set; }

        public Configuration()
        {
            NotificationType = "wns/toast";
            ContentType = "text/xml";
        }

    }
}
