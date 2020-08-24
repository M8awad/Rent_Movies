using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.ViewModel;
using System.Web.Mvc;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string MembershipName { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;


    }
}