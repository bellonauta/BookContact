using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookContactControl.Api.Models
{
    public class RegisterContactModel
    {
        public String Email { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }
    }
}