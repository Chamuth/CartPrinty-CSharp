using System.Windows.Documents;
using System.Windows.Media;

namespace csharp_cartprinty_sdk
{
    public class DefaultBillTheme : IBillTheme
    {
        public FlowDocument Apply(FlowDocument input)
        {
            input.FontFamily = new FontFamily("Courier New"); // Change the font family
            return input;
        }
    }
}
