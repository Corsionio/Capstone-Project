using Canvas.Models;
using Canvas.Services;
using Library.Canvas;
using static Canvas.Models.Assignment;
using AssignmentService = Library.Canvas.AssignmentService;

namespace Canvas.Helpers{
    public class AssignmentHelper{
        private AssignmentService assignmentService = new Library.Canvas.AssignmentService();

        public void AddAssignment(){
            int count = -1;
            foreach(var course in CourseService.Current.Courses){
                Console.WriteLine($"{++count}. {course.Name}, {course.Code}");
            }
            
            Console.WriteLine("Please pick a course by using an integer");
            var choice = Console.ReadLine();

            if(int.TryParse(choice, out int intChoice)){
                var courseToAssignment = CourseService.Current.Courses.ElementAt(intChoice);
                Console.WriteLine($"{courseToAssignment}");

                Console.WriteLine("New Assignment to Add");

                Console.WriteLine("Assignment Name:");
                var assignmentName = Console.ReadLine();

                Console.WriteLine("Assignment Description:");
                var assignmentDescription = Console.ReadLine();

                Console.WriteLine("Assignment max points available:");
                var assignmentTotalAvailablePoints = Console.ReadLine();

                Console.WriteLine("Assignment date Due");
                var assignmentDueDate = Console.ReadLine();

                Models.Assignment myAssignment;

                myAssignment = new Models.Assignment(assignmentName, assignmentDescription, 
                            assignmentTotalAvailablePoints, assignmentDueDate);

                courseToAssignment.Assignments.Add(myAssignment);

                 Console.WriteLine($"Assignment '{assignmentName}' added to {courseToAssignment.Name}");

            }

        }

    }
}