using System.Reflection;
using Casino.Attributes;

namespace Casino.Enums
{
    public enum Actions
    {
        [StringValue("Test1")]
        DepositMoney = 1,
        [StringValue("Test2")]
        WithdrawMoney = 2,
        [StringValue("Test3")]
        ChangeBetAmount = 3,
        Spin = 4,
        CheckBalance = 5,
        Quit = 6,
    }

    public static class EnumExtensions
    {
        public static string GetStringValue(this Enum value)
        {
            if (value == null)
            {
                return String.Empty;
            }

            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];
            return attribs.Length > 0 ? attribs[0].Value : String.Empty;
        }
    }
}
