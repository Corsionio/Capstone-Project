using Canvas.Models;
using Canvas.Services;
using static Canvas.Models.Person;

namespace Canvas.Helpers{

    public class StudentHelper
    {
        private StudentService studentService = new StudentService();
        public void AddOrUpdateStudent(Person? selectedStudent = null)
        {
            //list for adding students


            Console.WriteLine("What is the name of the student?");
            var name = Console.ReadLine();
            Console.WriteLine("What is the id of the student?");
            var id = Console.ReadLine();
            Console.WriteLine("What is the Classification of the student? (F)reshman, S(O)phmore, (J)unior, (S)enior");
            var classification = Console.ReadLine();
            PersonClassification classEnum = PersonClassification.Freshman;
            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (classification.Equals("O", StringComparison.InvariantCultureIgnoreCase))
            {
                classEnum = PersonClassification.Sophmore;
            }
            else if (classification.Equals("J", StringComparison.InvariantCultureIgnoreCase))
            {
                classEnum = PersonClassification.Junior;
            }
            else if (classification.Equals("S", StringComparison.InvariantCultureIgnoreCase))
            {
                classEnum = PersonClassification.Senior;
            }
            #pragma warning restore CS8602 // Dereference of a possibly null reference.

            bool isCreate = false;
            if(selectedStudent == null)
            {   
                isCreate = true;
                selectedStudent = new Person();

            }

            selectedStudent.Id = int.Parse(id?? "0");
            selectedStudent.Name = name ?? string.Empty;
            selectedStudent.Classification = classEnum;

            if(isCreate){
            studentService.Add(selectedStudent);
            }else{
                studentService.Update(selectedStudent);
            }
        }



        public void UpdateStudentRecord(){
            Console.WriteLine("Select student to update by inputting ID");
            ListStudents();

            var selectionStr = Console.ReadLine();

            if(int.TryParse(selectionStr, out int selectionInt)){
                var selectedStudent = studentService.Students.FirstOrDefault(s => s.Id ==  selectionInt);
                if(selectedStudent != null)
                {
                    AddOrUpdateStudent(selectedStudent);
                }
            }
        }

        public void ListStudents(){
            studentService.Students.ForEach(Console.WriteLine);
        }

        public void SearchStudents()
        {
            Console.WriteLine("Enter a students name to search for");
            var query = Console.ReadLine() ?? string.Empty;

            studentService.Search(query).ToList().ForEach(Console.WriteLine);
        }

        public void CreateGroup()
        {
            studentService.Group();
            Console.WriteLine("Groups have been created");
        }

        public void ListGroups()
        {
            List<Person>[] arrOfGroups = studentService.Group();
            for(int i=0;i<arrOfGroups.Length; i++){
                Console.WriteLine("Group ",i,": ");
                for(int j=0;j<arrOfGroups[i].Count; j++){
                    Console.Write(arrOfGroups[i].Name," ");
                }
                //Console.WriteLine("Group ",i,": ",arrOfGroups[i].Name);
            }
            //studentService.Group.ForEach(Console.WriteLine);
        }

    }
}