namespace Library.Canvas;

public class CourseService
{
    
        public List<Course> courseList = new List<Course>();

        private string? query;
        private static readonly object _lock = new object();
        private static CourseService instance;
        public static CourseService Current {
            get {
                // Program does not work if lock is used
                // ask abt this in office hours
                if(instance == null){
                    lock(_lock){
                        if(instance == null){
                            instance = new CourseService();
                        }
                    }
                }
                return instance;
            }
        }

        public IEnumerable<Course> Courses {
            get{
                return courseList.Where(
                    c => 
                        c.Name.ToUpper().Contains(query ?? string.Empty)
                        || c.Code.ToUpper().Contains(query ?? string.Empty));
            }
        }

        public IEnumerable<Course> Search(string query){
            this.query = query;
            return Courses;
        }
        public CourseService(){
            courseList = new List<Course>();
        }

        public void Add(Course course){
            
            courseList.Add(course);
        }

        public IEnumerable<Course> GetByCourse(Guid assignmentId) {
            return courseList.Where(a => a.AssignmentId == assignmentId);
        }

        public IEnumerable<Course> CourseSearch(string query)
        {
            return courseList.Where(c=> c.Name.ToUpper().Contains(query.ToUpper())
                                || c.Description.ToUpper().Contains(query.ToUpper()));
        }

        public Course CourseById(string code) // code is name not id
        {
            return courseList.FirstOrDefault(c => c.Name == code);
        }
}
