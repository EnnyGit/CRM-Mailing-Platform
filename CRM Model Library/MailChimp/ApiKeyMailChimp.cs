using MailChimp.Net;

namespace CRM_Model_Library
{
    public static class ApiKeyMailChimp
    {
        private const string ApiKey = "474d98b60a1b310691196071ea85bf44-us7";
        public static readonly MailChimpManager Manager = new MailChimpManager(ApiKey);
    }
}