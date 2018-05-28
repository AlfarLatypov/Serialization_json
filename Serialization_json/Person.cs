using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization_json
{
    [Serializable]
   public class Person
    {
        public Person()
        {

        }

        public string Name { get; set; }
          public int Age { get; set; }

        public Person(string Name,  int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
    }




    public class Human : Person
    {
        public Human(string Name, int Age) : base(Name, Age)
        {
        }
    }




}
