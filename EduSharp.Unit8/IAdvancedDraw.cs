namespace EduSharp.Unit8
{
    public interface IAdvancedDraw:IDrawable
    {
        void DrawInBoundingBox(int top, int left, int bottom, int right);
        void DrawUpsideDown();
    }
}