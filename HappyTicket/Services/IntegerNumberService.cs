using System;

namespace LuckyTicket.Services
{
   public static class IntegerNumberService
    {
        public static uint Length(uint number)
        {
            var countOfDigits = (uint)number.ToString().Length;
            return countOfDigits;
        }

        public static (uint, uint) SplitIntoParts(uint number, uint amountOfDigitsInPart)
        {
            var (rightPart, leftPart) = (0u, 0u);
            if (Length(number) > 2 * amountOfDigitsInPart)
            {
                return (0, 0);
            }
            leftPart += (uint)(number / Math.Pow(10, amountOfDigitsInPart / 2));
            rightPart += (uint)(number % Math.Pow(10, amountOfDigitsInPart / 2));
            return (leftPart, rightPart);
        }

        public static uint GetDigitsSum(uint number)
        {
            uint sumOfDigits = 0;
            while (number != 0)
            {
                sumOfDigits += number % 10;
                number /= 10;
            }
            return sumOfDigits;
        }

        public static bool HasEvenAmountOfDigits(uint number)
        {
            var numberLength = Length(number);
            if (numberLength % 2 == 0)
            {
                return true;
            }
            return false;
        }
    }
}
