namespace LectureAbstractionAndEncapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new RationalNumber[]
            {
               new RationalNumber(1, 3),
               new RationalNumber(1, 4),
               new RationalNumber(1, 2),
               new RationalNumber(5, 2),
            };

            Console.WriteLine(Average(arr));
            var firstNumber = new RationalNumber(1, 3);
            var secondNumber = new RationalNumber(1, 4);

            var thirdNumber = firstNumber + secondNumber;

            var fourthNumber = new RationalNumber(4, -6);

            if (thirdNumber.Equals(fourthNumber)) Console.WriteLine($"{thirdNumber} equals to {fourthNumber}");
            else Console.WriteLine($"{thirdNumber} does not equal to {fourthNumber}");

            Console.WriteLine(firstNumber / secondNumber);
            Console.WriteLine(thirdNumber);
            Console.WriteLine(firstNumber);
            Console.WriteLine((decimal)firstNumber);
        }

        static RationalNumber Average(RationalNumber[] numbers)
        {
            var result = new RationalNumber();
            foreach (var num in numbers)
                result += num;

            result /= numbers.Length;

            return result;
        }
    }
}
