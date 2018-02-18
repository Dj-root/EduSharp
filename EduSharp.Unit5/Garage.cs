namespace EduSharp.Troelsen.Unit5
{
    public class Garage
    {
        public int NumberOfCars { get; set; } = 1;
        public Car MyAuto { get; set; }=new Car();


        public Garage()
        {
//            MyAuto = new Car();
//            NumberOfCars = 1;
        }

        public Garage(Car car, int number)
        {
            MyAuto = car;
            NumberOfCars = number;
        }
    }
}