using System.Runtime.Serialization;

namespace PortfolioTracker.Database.DataModels
{
    public enum EquityType
    {
        [EnumMember(Value = "Stock")]
        Stock = 0,
        [EnumMember(Value = "Mutual Fund/ETF")]
        MutualFundsEtf = 1,
        [EnumMember(Value = "Option")]
        Option = 2,
        [EnumMember(Value = "Warrant")]
        Warrant = 3,
        [EnumMember(Value = "Bond")]
        Bond = 4,
        [EnumMember(Value = "Other")]
        Other = 5,
        [EnumMember(Value = "Cash")]
        Cash = 6
    }
}
