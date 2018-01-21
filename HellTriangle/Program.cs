using System;
namespace HellTriangle
{
    public class Program
    {
        static void Main(string[] args)
        {
            //example = [[6],[3,5],[9,7,1],[4,6,8,4]]
            var elementsValues = new[] { 
                new []{ 6 },
                new []{ 3, 5 }, //One more element
                new []{ 9, 7, 1 },
                new []{ 4, 6, 8, 4 },
            };

            var max = HellTriangleCalculator.TryGetMaxSumTopToBottom(0, 0, elementsValues);
            Console.WriteLine(max);

            Console.ReadKey();
        }
    }
}
