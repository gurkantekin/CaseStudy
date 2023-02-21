using CaseStudy.Business.Managers;
using System;

namespace Case1.ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            var coupons = CouponManager.GenerateCoupon();

            var invalidCoupon = CouponManager.CheckCoupon("0PMGYFGT");

            Console.WriteLine($"Invalid Coupon: 0PMGYFGT  Is this coupon valid?: {invalidCoupon}\n");

            foreach (var _ in coupons)
            {
                var validCoupon = CouponManager.CheckCoupon(_);

                Console.WriteLine($"Coupon: {_}  Is this coupon valid?: {validCoupon}");
            }

            Console.ReadKey();
        }
    }
}
