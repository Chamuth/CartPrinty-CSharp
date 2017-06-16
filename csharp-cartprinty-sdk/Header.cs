using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_cartprinty_sdk
{
    /// <summary>
    /// An object containing information about the header of the generating bill
    /// </summary>
    public class Header
    {
        /// <summary>
        /// Creates a new object of Header containing information about the header of the bill going to be created
        /// </summary>
        /// <param name="_imageURL">URIs for the Images. This is placed in the center, top of the bill</param>
        /// <param name="_header1">After the Images the header type 1 Elements are placed</param>
        /// <param name="_header2">After the header type 1 elements, Header type 2 elements are placed</param>
        /// <param name="_childHeaders">After the header type 2 elements, child headers are placed</param>
        /// <param name="_properties">After all of the header types and the images, the properties (key-value pair) is going to be placed in the bottom of the header of the bill</param>
        public Header(string _imageURL, List<string> _header1, List<string> _header2, List<string> _childHeaders, Dictionary<string, string> _properties)
        {
            ImageURL = _imageURL;
            Header1 = _header1;
            Header2 = _header2;
            ChildHeaders = _childHeaders;
            Properties = _properties;
        }

        public string ImageURL { get; set; }
        public List<string> Header1 { get; set; }
        public List<string> Header2 { get; set; }
        public List<string> ChildHeaders { get; set; }
        public Dictionary<string,string> Properties { get; set; }
    }
}
