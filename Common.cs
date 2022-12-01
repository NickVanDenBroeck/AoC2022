namespace AoC2022
{
    internal static class Common
    {
        public static string[] GetInput(string path)
        {
            string[] result = File.ReadAllLines($@"{path}");

            return result;
        }
    }
}
