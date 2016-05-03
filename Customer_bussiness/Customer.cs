using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_bussiness
{
    public class Customer
    {
        private string email;

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        private string companyName { get; set; }
        private string CustomeID { get; set; }
        private string YTDOrders { get; set; }
        private string YTDSAles { get; set; }



    }
}
