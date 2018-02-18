namespace EduSharp.Troelsen.Unit9
{
    public class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }

        //        public string SSN { get; set; } = "";

        public Person(string fname, string lname, int personAge)
        {
            FirstName = fname;
            LastName = lname;
            Age = personAge;
        }
        public Person() { }

        public override string ToString()
        {
            string myState;
            myState = string.Format("Name: {0} {1}; Age: {2}", FirstName, LastName, Age);
            return myState;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person && obj != null)
            {
                Person temp;
                temp = (Person)obj;
                if (temp.FirstName == this.FirstName
                    && temp.LastName == this.LastName
                    && temp.Age == this.Age)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        //        public override int GetHashCode()
        //        {
        //            return SSN.GetHashCode();
        //        }
    }
}