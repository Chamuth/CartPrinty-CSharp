using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_cartprinty_sdk
{
    /// <summary>
    /// Represents a single product type, multiple items can be included
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Create a new product type to add to the cart
        /// </summary>
        /// <param name="_name">Name of the product</param>
        /// <param name="_product_price">Price of a single item of the specified product</param>
        /// <param name="_quantity">Quantity of the product the user has bought</param>
        public Product(string _name, float _product_price, int _quantity)
        {
            PRODUCT_NAME = _name;
            PRODUCT_PRICE = _product_price;
            QUANTITY = _quantity;
            AMOUNT = PRODUCT_PRICE * QUANTITY;
        }

        public string PRODUCT_NAME { get; set; }
        public float PRODUCT_PRICE { get; set; }
        public int QUANTITY { get; set; }
        public float AMOUNT { get; set; }
    }
}
