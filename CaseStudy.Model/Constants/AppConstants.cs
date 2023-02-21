using System.IO;

namespace CaseStudy.Model.Constants
{
    public class AppConstants
    {
        public static readonly string FilePath = Directory.GetCurrentDirectory() + @"/Sources/Response.json";
        public static readonly char[] CouponCharacterSets = "ACDEFGHKLMNPRTXYZ234579".ToCharArray();
        public static readonly int CouponCount = 1000;
        public static readonly int LengthOfCoupon = 8;
    }
}