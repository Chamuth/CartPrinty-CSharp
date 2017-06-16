using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_cartprinty_sdk
{
    /// <summary>
    /// An object containing information about the footer of the bill
    /// </summary>
    public class Footer
    {
        /// <summary>
        /// Creates a new Footer object that contains the information about the footer of the bill
        /// </summary>
        /// <param name="footerMessage">The message of the footer of the bill</param>
        public Footer(string footerMessage = "Thank you come again")
        {
            Message = footerMessage;
        }

        public string Message { get; set; }
    }
}
