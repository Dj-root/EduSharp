using System.Collections;

namespace EduSharp.Troelsen.Unit9
{
    public class CarCollection : IEnumerable
    {
        private ArrayList arCars = new ArrayList();

        public Car GetCar(int pos)
        {
            return (Car)arCars[pos];
        }

        public void AddCar(Car c)
        {
            arCars.Add(c);
        }

        public void Clear()
        {
            arCars.Clear();
        }

        public int Count
        {
            get { return arCars.Count; }
        }



        public IEnumerator GetEnumerator()
        {
            return arCars.GetEnumerator();
        }
    }
}