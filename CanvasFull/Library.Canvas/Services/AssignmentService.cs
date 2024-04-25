
namespace Library.Canvas;


public class AssignmentService
{
    public IList<Assignment> assignments;

        private string? query;

        private static readonly object _lock = new object();
        
        private static AssignmentService instance;

        public static AssignmentService Current {
            get {
                if(instance == null){
                    lock(_lock){
                        if(instance == null){
                            instance = new AssignmentService();
                        }
                    }
                }
                return instance;
            }
        }

        public IEnumerable<Assignment> Assignments {
            get{
                return assignments.Where(
                    c => 
                        c.Name.ToUpper().Contains(query ?? string.Empty)
                        || c.Description.ToUpper().Contains(query ?? string.Empty));
            }
        }

    

        public IEnumerable<Assignment> Search(string query){
            this.query = query;
            return Assignments;
        }
        public AssignmentService(){
            assignments = new List<Assignment>();
        }

        public void AddAssignment(Assignment assignment){
            
            assignments.Add(assignment);
        }

        public IEnumerable<Assignment> GetAssignmentsByCourse(string courseCode) {
    // This method simulates fetching assignments related to a specific course code
    return assignments.Where(a => a.Description.Contains(courseCode) || a.Name.Contains(courseCode));
}
}
