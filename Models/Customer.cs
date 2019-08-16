using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace techtshirt.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string type { get; set; }
        public string address { get; set; }

        [DataType(DataType.PhoneNumber)] //view: "  @Html.EditorFor(model => model.PhoneNumber)  "
        public string PhoneNumber { get; set; }
        public string company { get; set; }
    }
}
