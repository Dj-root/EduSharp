using System.Collections;
using System.Collections.Generic;

namespace EduSharp.Troelsen.Unit11
{
    public class PersonCollection : IEnumerable
    {
        private Dictionary<string, Person> listPeople = new Dictionary<string, Person>();

        ArrayList arPeople = new ArrayList();

        public Person this[int index]
        {
            get { return (Person) arPeople[index]; }
            set { arPeople.Insert(index, value);}
        }

        public Person this[string name]
        {
            get { return (Person) listPeople[name]; }
            set { listPeople[name] = value; }
        }

        public void TextClearPeople()
        {
            listPeople.Clear();
        }

        public int TextCount
        {
            get { return listPeople.Count; }
        }

        public IEnumerator TextGetEnumerator()
        {
            {
                return listPeople.GetEnumerator();
            }
        }

        public Person GetPerson(int pos)
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