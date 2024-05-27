using System.ComponentModel;

namespace C_Utilities
{
    public class Enumes
    {
        public enum CustomerType
        {
            [Description("None")]
            None,

            [Description("Patient")]
            Patient,

            [Description("Doctor")]
            Doctor,

            [Description("Worker")]
            Worker,

            [Description("Other People")]
            OtherPeople
        }


        public enum Gender
        {
            Male,
            Female,
        }

        public enum FinancialAdvanceType
        {
            BuyProduct,
            GetMoney
        }

        public enum PaymentStatus
        {
            Paid,
            NotPaid
        }
        public enum Status
        {
            New,
            InProgress,
            Completed,
            Failed
        }

    }
    }



    public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
        return attribute == null ? value.ToString() : attribute.Description;
    }
}
