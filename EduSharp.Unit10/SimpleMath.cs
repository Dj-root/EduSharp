﻿namespace EduSharp.Unit10
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
    }
}