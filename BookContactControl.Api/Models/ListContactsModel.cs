using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookContactControl.Api.Models
{
    public class ListContactsModel
    {
        public int Skip { get; set; }
        public int Take { get; set; }

        public String Order { get; set; }
    }
}