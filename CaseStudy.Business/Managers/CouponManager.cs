using CaseStudy.Exception.Handlers;
using CaseStudy.Exception.Models;
using CaseStudy.Model.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CaseStudy.Business.Managers
{
    public class CouponManager
    {
        public static List<string> GenerateCoupon()
        {
            try
            {
                var keys = AppConstants.CouponCharacterSets;
                var couponCount = AppConstants.CouponCount;
                var lengthOfCoupon = AppConstants.LengthOfCoupon;
                var generatedCoupons = new List<string>();

                while (generatedCoupons.Count < couponCount)
                {
                    var coupon = SetUnique(keys, lengthOfCoupon);

                    if (generatedCoupons.Contains(coupon)) continue;

                    generatedCoupons.Add(coupon);
                }

                return generatedCoupons.ToList();
            }
            catch (System.Exception exception)
            {
                var methodBase = MethodBase.GetCurrentMethod();

                var businessOperationException = new BusinessOperationException(new BusinessExceptionModel()
                {
                    NameSpace = methodBase?.DeclaringType?.Namespace,
                    ClassName = methodBase?.Name,
                    MethodName = methodBase?.Name,
                }, exception.Message, exception.InnerException);

                throw businessOperationException;
            }
        }
        private static string SetUnique(IReadOnlyList<char> keys, int lengthOfCoupon)
        {
            return Enumerable
                .Range(1, lengthOfCoupon)
                .Select(_ => keys[new Random().Next(0, keys.Count - 1)])
                .Aggregate("", (e, c) => e + c);
        }

        public static bool CheckCoupon(string coupon)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(coupon) || string.IsNullOrEmpty(coupon)) return false;
                if (coupon.Length < AppConstants.LengthOfCoupon) return false;
                if (coupon.Length > AppConstants.LengthOfCoupon) return false;

                var couponCharSet = coupon.ToCharArray();

                foreach (var item in couponCharSet)
                {
                    if (AppConstants.CouponCharacterSets.Any(x => !AppConstants.CouponCharacterSets.Contains(item))) return false;
                }

                return true;
            }
            catch (System.Exception exception)
            {
                var methodBase = MethodBase.GetCurrentMethod();

                var businessOperationException = new BusinessOperationException(new BusinessExceptionModel()
                {
                    NameSpace = methodBase?.DeclaringType?.Namespace,
                    ClassName = methodBase?.Name,
                    MethodName = methodBase?.Name,
                }, exception.Message, exception.InnerException);

                throw businessOperationException;
            }
        }
    }
}
