using System.ComponentModel.DataAnnotations;
namespace Commander.Dtos
{
    public class CommandReadDto
    {
        public int Id { get; set; }
        // public string HowTo { get; set; }

        private string _howTo;
        
        public string HowTo 
        {
            get { return _howTo.ToUpper(); }
            set { _howTo = value; }
        }

        public string Line { get; set; }
        // public string Platform { get; set; } we won't show that in our response
    }
}