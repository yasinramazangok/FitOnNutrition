namespace MultiShop.WebUI.Settings
{
    public class ClientSettings
    {
        public Client MultiShopVisitorClient { get; set; }
        public Client MultiShopSellerClient { get; set; }
        public Client MultiShopAdminClient { get; set; }
    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
