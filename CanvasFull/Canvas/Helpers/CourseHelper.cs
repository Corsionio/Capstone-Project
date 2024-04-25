using Canvas.Services;
using Library.Canvas;



namespace Canvas.Helpers
{

    public class CourseHelper
    {
        private CourseService courseService = new CourseService();
        
        public void AddCourse(){
            Console.WriteLine("Course Name:");
            var courseName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Course Code:");
            var courseCode = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Course Description:");
            var courseDescription = Console.ReadLine() ?? string.Empty;

            Course myCourse;

            myCourse = new Course{Name = courseName, Code = courseCode, Description = courseDescription};

            Console.WriteLine(myCourse);

            CourseService.Current.Add(myCourse);
        }

        public void SearchCourse(){
            Console.WriteLine("Please search for a course by typing either the name or description");
            var choice = Console.ReadLine() ?? string.Empty;

            var found = CourseService.Current.CourseSearch(choice);
            if(found.Any()){
                foreach(var c in found){
                Console.WriteLine($"{c}");
                }
            }else{
                Console.WriteLine("none found");
            }
        }

        public void UpdateCourse(){
            int count = -1;
            foreach(var course in CourseService.Current.Courses()){
                Console.WriteLine($"{++count}. {course.Name}, {course.Code}");
            }

            Console.WriteLine("Please pick a course by typing the assigned integer");
            var choice = Console.ReadLine() ?? string.Empty;
            
            if(int.TryParse(choice, out int intChoice)){
                var courseToUpdate = CourseService.Current.Courses().ElementAt(intChoice);
                Console.WriteLine($"{courseToUpdate}");


                Console.WriteLine("New Course Name");
                courseToUpdate.Name = Console.ReadLine();

            }
        }

        public void ListCourses(){
            foreach(var course in CourseService.Current.Courses()){
                Console.WriteLine($"{course.Name}, {course.Code}");
            }
        }
    }
}