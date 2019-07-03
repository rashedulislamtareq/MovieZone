using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieZone.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DirationInMonth { get; set; }
        public byte DiscountRate { get; set; }


        [NotMapped]
        public static readonly byte Unknown = 0;

        [NotMapped]
        public static readonly byte PayAsYouGo = 1;
    }
} 