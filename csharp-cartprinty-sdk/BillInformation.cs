using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_cartprinty_sdk
{
    /// <summary>
    /// Contains all the information the bill is going to consist
    /// </summary>
    public class BillInformation
    {
        public BillInformation(Header _headerInformation, List<Product> _products, Footer _footerInformation, float cash, float balance, int orderNumber)
        {
            HeaderInformation = _headerInformation;
            Products = _products;
            FooterInformation = _footerInformation;

            //Gets information for calculations, SUB TOTAL is calculated automatically
            Cash = cash;
            Balance = balance;
            OrderNumber = orderNumber;
        }

        public Header HeaderInformation { get; set; }
        public List<Product> Products { get; set; }
        public Footer FooterInformation { get; set; }

        public float Cash { get; set; }
        public float Balance { get; set;}
        public int OrderNumber { get; set; }
        
    }
}
