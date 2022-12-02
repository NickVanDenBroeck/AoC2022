namespace AoC2022.Days
{
    internal static class Day2
    {
        private static readonly string path = $@"{System.AppDomain.CurrentDomain.BaseDirectory}\Days\Day2.txt";
        private static string[] input = Common.GetInput(path);
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
            var move = string.Empty;

            if (result.Equals("X")) // Lose
            {
                if (opponent.Equals("A")) // Rock
                {
                    move = "Z";
                }
                else if (opponent.Equals("B")) // Paper
                {
                    move = "X";
                }
                else // Scissor
                {
                    // Win
                    move = "Y";
                }
            }
            else if (result.Equals("Y")) // Draw
            {
                if (opponent.Equals("A")) // Rock
                {
                    move = "X";
                }
                else if (opponent.Equals("B")) // Paper
                {
                    move = "Y";
                }
                else // Scissor
                {
                    // Win
                    move = "Z";
                }
            }
            else // Win
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
            }

            return move;
        }

        private static int Points(string opponent, string me)
        {
            var points = 0;

            if (me.Equals("X")) // Rock
            {
                if (opponent.Equals("A")) // Rock
                {
                    // Draw
                    points = 1 + 3;
                }
                else if (opponent.Equals("B")) // Paper
                {
                    // Loss
                    points = 1;
                }
                else // Scissor
                {
                    // Win
                    points = 1 + 6;
                }
            }
            else if (me.Equals("Y")) // Paper
            {
                if (opponent.Equals("A")) // Rock
                {
                    // Win
                    points = 2 + 6;
                }
                else if (opponent.Equals("B")) // Paper
                {
                    // Draw
                    points = 2 + 3;
                }
                else // Scissor
                {
                    // Loss
                    points = 2;
                }
            }
            else // Scissor
            {
                if (opponent.Equals("A")) // Rock
                {
                    // Loss
                    points = 3;
                }
                else if (opponent.Equals("B")) // Paper
                {
                    // Win
                    points = 3 + 6 ;
                }
                else // Scissor
                {
                    // Draw
                    points = 3 + 3;
                }
            }

            return points;
        }
    }
}
