using Canvas.Models;

namespace  Library.Canvas
{

    public class StudentService
    {
        public List<Person> studentList= new List<Person>();
        public CourseService CourseService;

        public StudentService(CourseService courseService){
            this.CourseService = courseService;
        }
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

        public void Group(){
            if(studentList.Count()==0){
                Console.WriteLine("No students to group");
            }
            else{
                int numGroups = studentList.Count / 3;  //determine number of groups, int division
                int temp = numGroups;   //used to start mod math
                int num=0;
                List<Person>[] groupArr = new List<Person>[numGroups];  //create arr of lists represent groups
                for(int i=0; i<studentList.Count; i++){ //loop thru students
                    num=numGroups%temp; //ind of arr based off numGroups mod temp
                    groupArr[num].Add(studentList[i]);  //add to list in each arr
                    temp++;
                }
            }
        }

        public void EnrollStudentInCourse(int studentId, string courseName)
        {
            var student = studentList.FirstOrDefault(s => s.Id.ToString() == studentId.ToString());
            var newCourse = new Course{
                Name = courseName,
                Roster = new List<Person>()
            };
            
            newCourse.Roster.Add(student);

            if (student.Courses == null)
            {
                student.Courses = new List<Course>();
            }

            student.Courses.Add(newCourse);

            CourseService.Add(newCourse);
            Update(student);
                
        }
    }
}