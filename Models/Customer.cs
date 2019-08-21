using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace techtshirt.Models
{
    public class Customer
    {
        public int id { get; set; }
        [Display(Name = "First Name")]
        public string first_name { get; set; }
        [Display(Name = "Last Name")]
        public string last_name { get; set; }
        [Display(Name = "Type")]
        public string type { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }

       // [DataType(DataType.PhoneNumber)] //view: "  @Html.EditorFor(model => model.PhoneNumber)  "
        [Display(Name = "Phone Number")]
        public string phone { get; set; }
        [Display(Name = "Company")]
        public string company { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
