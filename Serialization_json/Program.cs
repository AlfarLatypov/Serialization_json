using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;




namespace Serialization_json
{

  
      

    class Program
    {
        #region SOAP
        // SOAP - протокол 

        static void SoapSerialize(Person person)
        {
            SoapFormatter form = new SoapFormatter();
            using (FileStream fs = new FileStream("person.soap", FileMode.OpenOrCreate))
            {
                form.Serialize(fs, person);
                Console.WriteLine("Object serialization");
            }


        }
        static void SoapSerialize(Person[] person)
        {
            SoapFormatter form = new SoapFormatter();
            using (FileStream fs = new FileStream("person.soap", FileMode.OpenOrCreate))
            {
                form.Serialize(fs, person);
                Console.WriteLine("Object serialization");
            }


        }


        static object SoapDESerialize()
        {
            Person person1 = null;
            SoapFormatter form = new SoapFormatter();
            using (FileStream fs = new FileStream("person.soap", FileMode.OpenOrCreate))
            {
                person1 = (Person)form.Deserialize(fs);
                Console.WriteLine("Deserialize SOAP");
            }

            return person1;
        }

        static Person[] SoapDESerialize(string t)
        {
            Person[] persone = null;
            SoapFormatter form = new SoapFormatter();
            using (FileStream fs = new FileStream("person.soap", FileMode.OpenOrCreate))
            {
                persone = (Person[])form.Deserialize(fs);
                Console.WriteLine("Deserialize SOAP");
            }

            return persone;
        }

        #endregion SOAP



        public static void XMLSerialize (Person pers)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Person));

            using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, pers);
            }
            
        }


        public static void XMLSerialize(Person[] pers)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Person[]));

            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, pers);
            }

        }

        public static void XMLDeSerialize()
        {
            List<Person> persons = new List<Person>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));

            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                formatter.Deserialize(fs);
            }

            foreach (Person item in persons)
            {
                Console.WriteLine(item.Name + " " + item.Age);
            }
        }





        static void Main(string[] args)
        {

             Person person = new Person("Kim", 30);
            Console.WriteLine("Object Create!");


            #region Bibary


            ////Создадим объект BinaryFormatter
            //BinaryFormatter formatter = new BinaryFormatter();

            //using (FileStream fs = new FileStream("person.dat", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, person);
            //    Console.WriteLine("Object serialization");
            //}


            ////Десериализация

            //using (FileStream fs = new FileStream("person.dat", FileMode.OpenOrCreate))
            //{
            //   // var newPerson = formatter.Deserialize(fs);
            //    Person newPerson = (Person)formatter.Deserialize(fs);
            //    Console.WriteLine(newPerson.Name + " " + newPerson.Age);

            //}
            #endregion Bibary

            //SOAP
            // SoapSerialize(person);
            //  person = SoapDESerialize() as Person;
            //SOAP END

            Person[] persons = new Person[3];
            persons[0] = new Person("Kim", 30);
            persons[1] = new Person("Li", 25);
            persons[2] = new Person("Vu", 18);
            //SoapSerialize(persons);

            //foreach (Person item in SoapDESerialize(""))
            //{
            //    Console.WriteLine(item.Name + " " + item.Age);
            //}



            //XMLSerialize(person);

            XMLSerialize(persons);

            XMLDeSerialize();

           

        }
    }
}
