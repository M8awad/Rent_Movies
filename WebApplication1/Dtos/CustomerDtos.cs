using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Dtos
{
    public class CustomerDtos
    {
        public int Id { get; set; }

        
        [StringLength(225)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Required]
        public byte MembershipId { get; set; }

        public MembershipTypeDto MembershipType{ get; set; }


        //[Min18yearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}