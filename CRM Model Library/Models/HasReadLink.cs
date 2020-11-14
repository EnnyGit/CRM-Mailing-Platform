using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_Model_Library.Models
{
    public class HasReadLink
    {
        public int ContactId { get; set; }
        public int EmailId { get; set; }
        public bool Read { get; set; }
    }
}
