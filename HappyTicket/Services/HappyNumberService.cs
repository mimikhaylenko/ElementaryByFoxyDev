namespace LuckyTicket.Services
{
    class HappyNumberService
    {
        /// <summary>
        /// Returns true if sum of the first happyNumberLength/2 digits is equal to a sum of the last happyNumberLength/2 digits 
        /// </summary>  
        public static bool IsNumberHappyInSimpleWay(uint number, uint happyNumberLength)
        {
            var numberLength = IntegerNumberService.Length(number);
            bool isNumberHappy;
            if (numberLength > happyNumberLength)
            {
                return false;
            }
            var parts = IntegerNumberService.SplitIntoParts(number, happyNumberLength);
            isNumberHappy = IntegerNumberService.GetDigitsSum(parts.Item1) == IntegerNumberService.GetDigitsSum(parts.Item2);
            return isNumberHappy;
        }

        /// <summary>
        /// Returns true if sum of odd digits is equal to a sum of even digits 
        /// </summary> 
        public static bool IsNumberHappyInСomplicatedWay(uint number, uint happyNumberLength)
        {
            uint evenDigitsSum = 0;
            uint oddDigitsSum = 0;
            uint numberLength = IntegerNumberService.Length(number);
            bool isNumberHappy;
            if (numberLength > happyNumberLength)
            {
                return false;
            }
            for (int i = 0; i < numberLength; i++)
            {
                var currentDigit = number % 10;
                if (currentDigit % 2 == 0)
                {
                    evenDigitsSum += currentDigit;
                }
                else
                {
                    oddDigitsSum += currentDigit;
                }
                number /= 10;
            }
            isNumberHappy = evenDigitsSum == oddDigitsSum;
            return isNumberHappy;
        }
    }
}
