using System.Runtime.Serialization;

namespace PortfolioTracker.Database.DataModels
{
    public enum Portfolios
    {
        [EnumMember(Value = "RobinHood")]
        RobinHood = 0,
        [EnumMember(Value = "Fidelity")]
        Fidelity = 1,
        [EnumMember(Value = "Webull")]
        Webull = 2
    }
}
