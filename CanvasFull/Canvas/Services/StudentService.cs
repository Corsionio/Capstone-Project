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

        public void Group(){
            if(studentList.Count == 0){
                Console.WriteLine("No students to group");
            }
            else{
                int numGroups = (Students.Count + 3-1) / 3;  //determine number of groups, int division, ceil                
                int temp=0;   //used to start mod math
                
                List<Person>[] groupArr = new List<Person>[numGroups];  //create arr of lists represent groups
                
                for(int i=0; i<groupArr.Length;i++){
                    groupArr[i] = new List<Person>();   //initialize list
                }

                for(int i=0; i<Students.Count; i++){ //loop thru students
                        
                    groupArr[temp].Add(Students[i]);  //add to list in each arr
                    temp++;
                    if(temp==(numGroups)){
                        temp=0;
                    }
                }

                //print groups
                for(int i=0;i<groupArr.Length; i++){
                Console.WriteLine("Group " + (i+1) +": ");
                
                groupArr[i].ForEach(Console.WriteLine);
               
                }
                Console.WriteLine("Groups have been created");
            }
        }
    }
}