using System.Windows.Documents;

namespace csharp_cartprinty_sdk
{
    public interface IBillTheme
    {
        FlowDocument Apply(FlowDocument input);
    }
}
