using System.Collections.Generic;

namespace Canvas.Models{
    public class Person {

        public int Id {get; set;}
        public string? Name {get;set;}

        public Dictionary<int, double> Grades {get; set;}

        public PersonClassification Classification  {get; set;}

        public List<Course> Courses {get; set;} = new List<Course>();

        public Person(){
            Name  = string.Empty;
            Grades = new Dictionary<int, double>();
            Courses = new List<Course>();
        }

            public override string ToString()
            {
                string v = $"[{Id}] {Name} - {Classification.ToString()}";
                return v;
            }

            public enum PersonClassification
            {
                Freshman, Sophmore, Junior, Senior
            }
        }
    }