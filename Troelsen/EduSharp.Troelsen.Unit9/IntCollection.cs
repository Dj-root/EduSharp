using System.Collections;

namespace EduSharp.Troelsen.Unit9
{
    public class IntCollection:IEnumerable
    {
        private ArrayList arInts = new ArrayList();

        public int GetInt(int pos)
        {
            return (int)arInts[pos];
        }

        public void AddInt(int i)
        {
            arInts.Add(i);
        }

        public void ClearInts()
        {
            arInts.Clear();
        }

        public int Count
        {
            get { return arInts.Count; }
        }


        public IEnumerator GetEnumerator()
        {
            return arInts.GetEnumerator();
        }
    }
}