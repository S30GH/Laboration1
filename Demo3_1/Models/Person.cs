using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo3_1.Models
{
       public class Person
    {
        //top konstruktor
        public Person() { }

        //konstruktor som kan fylla ett objekt
        public Person(int id, string name)
        {
            this.Id = id;
            this.Namn = name;
        }

        //pubilka egenskaper
        public int Id { get; set; }
        public string Namn { get; set; }
    }

    public class ViewModeln
    {
        public IEnumerable<Person> PersonDetaljLista { get; set; }
    }
}
