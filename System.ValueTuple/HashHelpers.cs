namespace System.Numerics.Hashing
{
    internal static class HashHelpers
    {
        public static readonly int RandomSeed = new Random().Next(-2147483648, 2147483647);

        public static int Combine(int h1, int h2)
        {
            uint num = (uint)((h1 << 5) | (int)((uint)h1 >> 27));
            return ((int)num + h1) ^ h2;
        }
    }
}
