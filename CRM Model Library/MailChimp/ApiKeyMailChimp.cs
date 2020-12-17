using System;
using System.Collections.Generic;
using System.Text;
using MailChimp.Net;
using System.Threading.Tasks;
using MailChimp.Net.Core;

namespace CRM_Model_Library
{
    public static class ApiKeyMailChimp
    {
        private const string ApiKey = "474d98b60a1b310691196071ea85bf44-us7";
        public static readonly MailChimpManager Manager = new MailChimpManager(ApiKey);
    }
}
