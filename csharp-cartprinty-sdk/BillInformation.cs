using System.Collections.Generic;

namespace csharp_cartprinty_sdk
{
    /// <summary>
    /// Contains all the information the bill is going to consist
    /// </summary>
    public class BillInformation
    {
        public BillInformation(Header _headerInformation, List<Product> _products, Footer _footerInformation, float cash, float balance, int orderNumber, string _currencySymbol = "")
        {
            HeaderInformation = _headerInformation;
            Products = _products;
            FooterInformation = _footerInformation;

            //Gets information for calculations, SUB TOTAL is calculated automatically
            Cash = cash;
            Balance = balance;
            OrderNumber = orderNumber;

            // Set the currency symbols
            CurrencySymbol = _currencySymbol;
        }

        public string CurrencySymbol { get; set; }

        public Header HeaderInformation { get; set; }
        public List<Product> Products { get; set; }
        public Footer FooterInformation { get; set; }

        public float Cash { get; set; }
        public float Balance { get; set;}
        public int OrderNumber { get; set; }
        
    }
}
