using Canvas.Models;

namespace Canvas.Services{

    public class StudentService
    {
        public List<Person> studentList= new List<Person>();

        public void Add(Person student)
        {
            studentList.Add(student);
        }
        
        public List <Person> Students
        {
            get
            {
                return studentList;
            }
        }

        public IEnumerable<Person> Search(string query)
        {
            return studentList.Where(s=> s.Name.ToUpper().Contains(query.ToUpper()));
        }

        public void Update(Person studentUpdate){
            var i = Students.FindIndex(s => s.Id == studentUpdate.Id);
            if(i != -1){
                Students[i] = studentUpdate;
            }
        }
    }
}