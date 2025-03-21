

namespace Canvas.Models{

    public class Assignment 
    {
        public string? Name {get; set;}
        
        public string? Description {get; set;}

        public string? TotalAvailablePoints {get; set;}

        public string? DueDate {get; set;}

        //public decimal TotalAvailablePoints {get; set;}

        //public DateTime DueDate {get; set;}

        public Assignment(){
            
        }

        public Assignment(string? name, string? description, string? totalAvailablePoints, string? dueDate){
            Name = name;
            Description = description;
            TotalAvailablePoints = totalAvailablePoints;
            DueDate = dueDate;
        }

        /*public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}, Total Available Points: {TotalAvailablePoints}, Due Date: {DueDate}";
        }*/
    }
}