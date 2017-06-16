using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using csharp_cartprinty_sdk;

namespace csharp_cartprinty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var properties = new Dictionary<string, string>();
            properties.Add("Date", "06/6/2017");
            properties.Add("Operator", "NIGGA");
            properties.Add("Bill No", "000000445");
            properties.Add("Unit", "000000445");

            //Print that shit
            var doc = CartPrinty.CreateBill(new BillInformation(
                   new Header(@"C:\Users\Chamuth\Pictures\16473153_1828897797324662_6195901836518424407_n.jpg", new List<string>(new string[]
                   {
                       "ATUKORALA"
                   }), new List<string>(new string[]
                   {
                       "BAKERY & RESTAURENT"
                   }), new List<string>(new string[]
                   {
                       "NO:69, MAIN STREET,",
                       "KEGALLE."
                   }), properties),
                   new List<Product>(new Product[]
                   {
                       new Product("GRAND TEA", 200.00f, 2)
                   }),
                   new Footer(),
                   500.00f, 100.00f, 100023
                ));

            Document.Document = doc;
        }
    }
}
