namespace EduSharp.Troelsen.Unit10
{

    public delegate int BinaryOp(int x, int y);
    public class SimpleMath
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Subtract(int x, int y)
        {
            return x - y;
        }

        public static int SquareNumber(int a)
        {
            return a * a;
        }

        public static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }
    }
}