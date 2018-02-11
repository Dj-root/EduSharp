namespace EduSharp.Unit8
{
    public interface IShape:IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }
}