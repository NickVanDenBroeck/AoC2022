using System.IO;

namespace AoC2022.Days
{
    internal static class Day1
    {
        private static readonly string path = $@"{System.AppDomain.CurrentDomain.BaseDirectory}\Days\Day1.txt";
        private static string[] input = Common.GetInput(path);
        private static List<int> caloriesPerElf = GetCaloriesPerElf(input);

        public static int Day1Part1Result()
        {
            int result = caloriesPerElf.Max();

            return result;
        }

        public static int Day1Part2Result()
        {
            caloriesPerElf.Sort();
            caloriesPerElf.Reverse();

            var result = caloriesPerElf.Take(3).Sum();

            return result;
        }

        private static List<int> GetCaloriesPerElf(string[] input)
        {
            var caloriesPerElf = new List<int>();
            var totalCalories = 0;

            foreach (var calories in input)
            {
                if(string.IsNullOrWhiteSpace(calories))
                {
                    caloriesPerElf.Add(totalCalories);
                    totalCalories = 0;
                    continue;
                }

                totalCalories += int.Parse(calories);
            }

            return caloriesPerElf;
        }
    }
}
