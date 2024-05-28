using System.ComponentModel;
using System.Reflection;

namespace C_Utilities
{
    public class Enumes
    {
    

public enum CustomerType
    {
        [Description("Nursing")]
        Nursing = 1,

        [Description("Hospital Management")]
        HospitalManagement = 2,

        [Description("Doctor")]
        Doctor = 3,

        [Description("Worker")]
        Worker = 4,

        [Description("Other People")]
        OtherPeople = 5
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
