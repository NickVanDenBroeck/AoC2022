namespace AoC2022.Days
{
    internal static class Day3
    {
        private static readonly string path = $@"{System.AppDomain.CurrentDomain.BaseDirectory}\Days\Day3.txt";
        private static readonly string[] input = Common.GetInput(path);

        public static int Day3Part1Result()
        {
            var commonCharacters = CommonRucksackCompartmentItems();

            int result = GetScore(commonCharacters);

            return result;
        }

        public static int Day3Part2Result()
        {
            var badges = GetBadges();
            int result = GetScore(badges);

            return result;
        }

        private static List<char> CommonRucksackCompartmentItems()
        {
            var chars = new List<char>();

            foreach (var rucksackItems in input)
            {
                var firstCompartement = rucksackItems[..(rucksackItems.Length / 2)];
                var secondCompartement = rucksackItems[(rucksackItems.Length / 2)..];
                chars.Add(GetMatchingCharacter(firstCompartement, secondCompartement));
            }

            return chars;
        }

        private static char GetMatchingCharacter(string firstCompartement, string secondCompartement)
        {          
            for (int i = 0; i < firstCompartement.Length; i++)
            {
                for (int y = 0; y < secondCompartement.Length; y++)
                {
                    if (firstCompartement[i].Equals(secondCompartement[y]))
                    {
                        return firstCompartement[i];
                    }
                }
            }
            
            return new char();
        }

        private static Dictionary<int, char> AlphabetPoints()
        {
            char[] alphabet = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
            Dictionary<int, char> values = new Dictionary<int, char>();

            var counter = alphabet.Length;

            for (int i = 0; i < alphabet.Length; i++)
            {
                counter += 1;
                values.Add(i+1, char.ToLower(alphabet[i]));
                values.Add(counter, alphabet[i]);
            }

            return values;
        }

        private static int GetScore(List<Char> commonCharacters)
        {
            var alphabetPoints=AlphabetPoints();
            var score = 0;

            foreach (var character in commonCharacters)
            {
                var points = alphabetPoints.First(x => x.Value.Equals(character)).Key;
                score += points;
            }

            return score;
        }

        private static List<Char> GetBadges()
        {
            var characters = new List<Char>();

            for (int i = 0; i < input.Length; i+=3)
            {
                var group = input[i..(i+3)];

                var sortedGroup = new List<string>();

                foreach (var item in group)
                {
                    var distinct = new string(item.ToCharArray().Distinct().ToArray());
                    var sorted = string.Concat(distinct.OrderBy(x => x));

                    sortedGroup.Add(sorted);
                }
                characters.Add(MatchingCharacter(sortedGroup));
            }

            return characters; 
        }

        private static char MatchingCharacter(List<string> sortedGroup)
        {
            int count = 0;

            for (int y = 0; y < sortedGroup[0].Length; y++)
            {
                var character = sortedGroup[0][y];

                var groupHasSameCharacter = sortedGroup[1].Contains(character) && sortedGroup[2].Contains(character);

                if (groupHasSameCharacter)
                {
                    count++;
                    return character;
                }
            }

            return new char();
        }
    }
}
