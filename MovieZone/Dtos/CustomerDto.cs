using MovieZone.Helper;
using MovieZone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieZone.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        //[Min18YearsForMember]
        public DateTime? Birthdate { get; set; }
    }
}