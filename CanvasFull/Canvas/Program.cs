
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Canvas.Models;
using Canvas.Helpers;
using Canvas.Services;
using Microsoft.VisualBasic;

namespace Canvas // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentHelper = new StudentHelper();
            var courseHelper = new CourseHelper();
            var assignmentHelper = new AssignmentHelper();

            
           bool cont = true;

            while(cont){
                Console.WriteLine("Choose an action");
                    Console.WriteLine("1. Add a student enrollment");
                    Console.WriteLine("2. Update a studetnt");
                    Console.WriteLine("3. List students");
                    Console.WriteLine("4. Search for student");
                    Console.WriteLine("5. Add course");
                    Console.WriteLine("6. Add Assignment to Course");
                    Console.WriteLine("7. Update Course");
                    Console.WriteLine("8. Search Course");
                    Console.WriteLine("9. List Courses");
                    Console.WriteLine("10. Create Groups");
                    Console.WriteLine("11. List Groups");
                    Console.WriteLine("12. Exit");
                    var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {  
                    if (result == 1){
                        //if they choose 1 we will create a student record
                        studentHelper.AddOrUpdateStudent();
                    }
                    else if(result == 2){
                        studentHelper.UpdateStudentRecord();
                    }
                    else if(result ==3){
                        studentHelper.ListStudents();
                    }
                    else if(result == 4){
                        studentHelper.SearchStudents();
                    }
                    else if (result == 5){
                        courseHelper.AddCourse();
                    }
                    else if(result == 6){
                        assignmentHelper.AddAssignment();
                    }
                    else if(result == 7){
                        courseHelper.UpdateCourse();
                    }
                    else if(result == 8){
                        courseHelper.SearchCourse();
                    }
                    else if(result == 9){
                        courseHelper.ListCourses();
                    }
                    else if(result == 10){
                        studentHelper.CreateGroup();
                    }
                    else if(result == 11){
                        studentHelper.ListGroups();
                    }
                    else if(result == 12){
                        cont = false;
                    }
                }
            }
        }
    }
}