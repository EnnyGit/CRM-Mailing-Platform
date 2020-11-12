using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Project.Pages
{
    public class EmailListBase : ComponentBase
    {
        public IEnumerable<Email> Emails { get; set; }
        
    }
}
