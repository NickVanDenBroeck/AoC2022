namespace AoC2022.Days
{
    internal static class Day2
    {
        private static readonly string path = $@"{System.AppDomain.CurrentDomain.BaseDirectory}\Days\Day2.txt";
        private static readonly string[] input = Common.GetInput(path);

        public static int Day2Part1Result()
        {
            int result = TotalScore(input);

            return result;
        }

        public static int Day2Part2Result()
        {
            int result = TotalScorePart2(input);

            return result;
        }

        public static int TotalScore(string[] input)
        {
            var score = 0;
            foreach (string play in input)
            {
                var split = play.Split(' ');
                var opponent = split[0];
                var me = split[1];

                score += Points(opponent, me);
            }

            return score;
        }

        public static int TotalScorePart2(string[] input)
        {
            var score = 0;

            foreach (string play in input)
            {
                var split = play.Split(' ');
                var opponent = split[0];
                var result = split[1];

                var myMove = MoveToChoose(opponent, result);

                score += Points(opponent, myMove);
            }

            return score;
        }

        private static string MoveToChoose(string opponent, string result)
        {
            string move;

            switch (result)
            {
                // Lose
                case "X":
                    move = opponent switch
                    {
                        // Rock
                        "A" => "Z",
                        // Paper
                        "B" => "X",
                        _ => "Y"
                    };
                    break;
                // Draw
                case "Y":
                    move = opponent switch
                    {
                        // Rock
                        "A" => "X",
                        // Paper
                        "B" => "Y",
                        _ => "Z"
                    };
                    break;
                // Win
                default:
                {
                    if (opponent.Equals("A")) // Rock
                    {
                        move = "Y";
                    }
                    else if (opponent.Equals("B")) // Paper
                    {
                        move = "Z";
                    }
                    else // Scissor
                    {
                        // Win
                        move = "X";
                    }

                    break;
                }
            }

            return move;
        }

        private static int Points(string opponent, string me)
        {
            var points = me switch
            {
                // Rock
                "X" => opponent switch
                {
                    // Rock
                    "A" => 1 + 3,
                    // Paper
                    "B" => 1,
                    _ => 1 + 6
                },
                // Paper
                "Y" => opponent switch
                {
                    // Rock
                    "A" => 2 + 6,
                    // Paper
                    "B" => 2 + 3,
                    _ => 2
                },
                _ => opponent switch
                {
                    // Rock
                    "A" => 3,
                    // Paper
                    "B" => 3 + 6,
                    _ => 3 + 3
                }
            };

            return points;
        }
    }
}
