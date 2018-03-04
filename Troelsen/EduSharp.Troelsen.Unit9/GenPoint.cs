namespace EduSharp.Troelsen.Unit9
{
    public struct GenPoint<T>
    {
        private T xPos;
        private T yPos;

        public GenPoint(T xPos, T yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public T X
        {
            get => xPos;
            set => xPos = value;
        }

        public T Y
        {
            get => yPos;
            set => yPos = value;
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", xPos, yPos);
        }

        public void ResetPoint()
        {
            xPos = default(T);
            yPos = default(T);
        }
    }
}