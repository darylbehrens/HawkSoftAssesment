using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HawkSoftAssesment.Models
{

    public class Contact : DbModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}
