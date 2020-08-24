using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class CustomerFormViewModel
    {
        internal Customer Customer;

        //public CustomerFormViewModel(Customer customer)
        //{
        //    Customer = customer;
        //}

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        //public Customer Customer { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18yearsIfAMember]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Membership Type")]
        [Required]
        public byte? MembershipId { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }



        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Customer " : "New Customer";
            }

        }

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Birthdate = customer.Birthdate;
            MembershipId = customer.MembershipId;
        }





    }
}