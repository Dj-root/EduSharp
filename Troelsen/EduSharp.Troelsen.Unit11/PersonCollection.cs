using System.Collections;

namespace EduSharp.Troelsen.Unit11
{
    public class PersonCollection : IEnumerable
    {
        ArrayList arPeople = new ArrayList();

        public Person this[int index]
        {
            get { return (Person) arPeople[index]; }
            set { arPeople.Insert(index, value);}
        }

        public Person GePerson(int pos)
        {
            return (Person)arPeople[pos];
        }

        public void AddPerson(Person p)
        {
            arPeople.Add(p);
        }

        public void ClearPeople()
        {
            arPeople.Clear();
        }

        public int Count
        {
            get
            {
                return arPeople.Count;
            }

        }

        public IEnumerator GetEnumerator()
        {
            {
                return arPeople.GetEnumerator();
            }
        }
    }
}