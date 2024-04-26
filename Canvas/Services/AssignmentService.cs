using Canvas.Models;

namespace Canvas.Services{
    public class AssignmentService{
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
    }
}