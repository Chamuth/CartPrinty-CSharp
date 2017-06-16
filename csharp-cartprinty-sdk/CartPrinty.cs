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

namespace csharp_cartprinty_sdk
{
    public class CartPrinty
    {
        
        public static FlowDocument CreateBill(BillInformation billInformation)
        {
            var document = new FlowDocument();
            document.FlowDirection = FlowDirection.LeftToRight;

            #region CREATE HEADER

            #region ADD HEADER IMAGE
            var imagePar = new Paragraph();
            imagePar.TextAlignment = TextAlignment.Center;
            imagePar.Margin = new Thickness(0, 0, 0, 10);

            var image = new Image();
            image.HorizontalAlignment = HorizontalAlignment.Center;
            image.Source = new BitmapImage(new Uri(billInformation.HeaderInformation.ImageURL));
            image.Height = 75;
            imagePar.Inlines.Add(image);

            document.Blocks.Add(imagePar);
            #endregion

            #region ADD HEADING TYPE 1 ELEMENTS
            foreach (var header in billInformation.HeaderInformation.Header1)
            {
                var header_par = new Paragraph();
                header_par.Margin = new Thickness(0);
                header_par.FontWeight = FontWeights.Bold;
                header_par.FontSize = 20;
                header_par.TextAlignment = TextAlignment.Center;
                
                header_par.Inlines.Add(header);

                document.Blocks.Add(header_par);
            }
            #endregion

            #region ADD HEADING TYPE 2 ELEMENTS
            foreach (var header in billInformation.HeaderInformation.Header2)
            {
                var header_par = new Paragraph();
                header_par.Margin = new Thickness(0,5,0,0);
                header_par.FontWeight = FontWeights.Bold;
                header_par.FontSize = 15;
                header_par.TextAlignment = TextAlignment.Center;

                header_par.Inlines.Add(header);

                document.Blocks.Add(header_par);
            }
            #endregion

            #region ADD CHILD HEADERS
            foreach (var header in billInformation.HeaderInformation.ChildHeaders)
            {
                var header_par = new Paragraph();
                header_par.Margin = new Thickness(0, 10, 0, 0);
                header_par.FontSize = 12;
                header_par.TextAlignment = TextAlignment.Center;

                header_par.Inlines.Add(header);

                document.Blocks.Add(header_par);
            }
            #endregion

            #region ADD PROPERTIES
            var propTable = new Table();
            var propTableRows = new TableRowGroup();
            propTableRows.FontSize = 12;

            var rowCounter = 0;
            var currentTableRow = new TableRow();

            for (int i = 0; i < billInformation.HeaderInformation.Properties.Count; i++)
            {
                rowCounter++;

                var currentElement = billInformation.HeaderInformation.Properties.ElementAt(i);

                var par = new Paragraph();
                par.Inlines.Add((currentElement.Key.ToString() + " : " + currentElement.Value.ToString()));

                var tableCell = new TableCell();
                tableCell.Blocks.Add(par);

                currentTableRow.Cells.Add(tableCell);

                if (billInformation.HeaderInformation.Properties.Count == i - 1)
                {
                    // Last of elements
                    propTableRows.Rows.Add(currentTableRow);
                    break;
                }


                if (rowCounter == 2)
                {
                    //Reset the rowCounter
                    rowCounter = 0;
                    //Add the current Table row to the collection
                    propTableRows.Rows.Add(currentTableRow);
                    //Reset the table row collection
                    currentTableRow = new TableRow();
                }
            }

            //Add the properties table to the document 
            propTable.RowGroups.Add(propTableRows);
            document.Blocks.Add(propTable);
            #endregion

            #endregion

            #region ADD THE PRODUCTS
            var productTable = new Table();

            var productTableRows = new TableRowGroup();
            productTableRows.FontSize = 13;

            var productTableHeaders = new TableRow();
            productTableHeaders.FontWeight = FontWeights.Bold;

            //ADD THE TABLE HEADINGS
            var tableHeader1 = new TableCell();
            var tableHeader1Content = new Paragraph(); tableHeader1Content.Inlines.Add("Product");
            tableHeader1.Blocks.Add(tableHeader1Content);

            var tableHeader2 = new TableCell();
            var tableHeader2Content = new Paragraph(); tableHeader2Content.Inlines.Add("Price");
            tableHeader2.Blocks.Add(tableHeader2Content);

            var tableHeader3 = new TableCell();
            var tableHeader3Content = new Paragraph(); tableHeader3Content.Inlines.Add("Qty");
            tableHeader3.Blocks.Add(tableHeader3Content);

            var tableHeader4 = new TableCell();
            var tableHeader4Content = new Paragraph(); tableHeader4Content.Inlines.Add("Amount");
            tableHeader4.Blocks.Add(tableHeader4Content);

            productTableHeaders.Cells.Add(tableHeader1);
            productTableHeaders.Cells.Add(tableHeader2);
            productTableHeaders.Cells.Add(tableHeader3);
            productTableHeaders.Cells.Add(tableHeader4);

            productTableRows.Rows.Add(productTableHeaders);


            //ADD THE PRODUCTS
            foreach (var product in billInformation.Products)
            {
                var productRow = new TableRow();

                var productCell = new TableCell();
                var productName = new Paragraph(); productName.Inlines.Add(product.PRODUCT_NAME);
                productCell.Blocks.Add(productName);

                var priceCell = new TableCell();
                var priceName = new Paragraph(); priceName.Inlines.Add(product.PRODUCT_PRICE.ToString());
                priceCell.Blocks.Add(productName);

                var qtyCell = new TableCell();
                var qtyName = new Paragraph(); qtyName.Inlines.Add(product.QUANTITY.ToString());
                qtyCell.Blocks.Add(productName);

                var amountCell = new TableCell();
                var amountName = new Paragraph(); amountName.Inlines.Add(product.AMOUNT.ToString());
                amountCell.Blocks.Add(productName);

                //Add the cells to the product row
                productRow.Cells.Add(productCell);
                productRow.Cells.Add(priceCell);
                productRow.Cells.Add(qtyCell);
                productRow.Cells.Add(amountCell);

                //Add the product row to the ProductTableRows
                productTableRows.Rows.Add(productRow);
            }

            //Add the ProductTableRows to the product table
            productTable.RowGroups.Add(productTableRows);

            //Add the product table to the flow document
            document.Blocks.Add(productTable);
            #endregion

            #region CALCULATIONS
            //Calculate the subtotal
            var total_price = 0.0f;

            foreach (var product in billInformation.Products)
                total_price += product.AMOUNT;

            var calculationTable = new Table();
            var calculationRowGroup = new TableRowGroup();

            var subtotal = new TableRow();
            subtotal.FontSize = 15;

            var subtotal_text = new TableCell();
            var subtotal_text_val = new Paragraph();
            subtotal_text_val.FontWeight = FontWeights.Bold;
            subtotal_text_val.Inlines.Add("SUB TOTAL");
            subtotal_text.Blocks.Add(subtotal_text_val);

            var subtotal_value = new TableCell();
            subtotal_value.TextAlignment = TextAlignment.Right;
            var subtotal_value_val = new Paragraph();
            subtotal_value_val.Inlines.Add(total_price.ToString());
            subtotal_value.Blocks.Add(subtotal_value_val);

            //Add the subtotals to their parent rows
            subtotal.Cells.Add(subtotal_text);
            subtotal.Cells.Add(subtotal_value);

            //Add the subtotal row in to the tablerowgroup
            calculationRowGroup.Rows.Add(subtotal);

            //ADD THE SPACERS
            var spacerRow = new TableRow();
            spacerRow.FontSize = 15;
            var emptyCell = new TableCell();
            spacerRow.Cells.Add(emptyCell);

            calculationRowGroup.Rows.Add(spacerRow);


            //CASH
            var cashRow = new TableRow();
            cashRow.FontSize = 11;

            var cash_title = new TableCell();
            var cash_title_text = new Paragraph();
            cash_title_text.Inlines.Add("CASH");
            cash_title.Blocks.Add(cash_title_text);
            cashRow.Cells.Add(cash_title);

            var cash_value = new TableCell();
            cash_value.TextAlignment = TextAlignment.Right;
            var cash_value_text = new Paragraph();
            cash_value_text.Inlines.Add(billInformation.Cash.ToString());
            cash_value.Blocks.Add(cash_value_text);
            cashRow.Cells.Add(cash_value);

            calculationRowGroup.Rows.Add(cashRow);

            //BALANCE
            var balanceRow = new TableRow();
            balanceRow.FontSize = 11;

            var balance_title = new TableCell();
            var balance_title_text = new Paragraph();
            balance_title_text.Inlines.Add("BALANCE");
            balance_title.Blocks.Add(balance_title_text);
            balanceRow.Cells.Add(balance_title);

            var balance_value = new TableCell();
            balance_value.TextAlignment = TextAlignment.Right;
            var balance_value_text = new Paragraph();
            balance_value_text.Inlines.Add(billInformation.Balance.ToString());
            balance_value.Blocks.Add(balance_value_text);
            balanceRow.Cells.Add(balance_value);

            calculationRowGroup.Rows.Add(balanceRow);


            //ORDER NUMBER
            var orderNumberRow = new TableRow();
            orderNumberRow.FontSize = 11;

            var orderNumberTitle = new TableCell();
            var orderNumberTitle_value = new Paragraph();
            orderNumberTitle_value.Inlines.Add("ORDER NO");
            orderNumberTitle.Blocks.Add(orderNumberTitle_value);
            orderNumberRow.Cells.Add(orderNumberTitle);

            var orderNumberValue = new TableCell();
            var orderNumberValue_value = new Paragraph();
            orderNumberValue_value.Inlines.Add(billInformation.OrderNumber.ToString());
            orderNumberValue.Blocks.Add(orderNumberValue_value);
            orderNumberRow.Cells.Add(orderNumberValue);

            calculationRowGroup.Rows.Add(orderNumberRow);

            //ADD THE ROW GROUP TO THE TABLE
            calculationTable.RowGroups.Add(calculationRowGroup);
            #endregion

            #region ADD THE FOOTER
            var footerMessage = new Paragraph();
            footerMessage.TextAlignment = TextAlignment.Center;
            footerMessage.Inlines.Add(billInformation.FooterInformation.Message);

            var attribution = new Paragraph();
            attribution.TextAlignment = TextAlignment.Center;
            attribution.Inlines.Add("CartPrinty (ninponix.com/cartprinty)");

            //Add the footerMessage and attribution
            document.Blocks.Add(footerMessage);
            document.Blocks.Add(attribution);
            #endregion
            


            return document;
        }
    }
}
