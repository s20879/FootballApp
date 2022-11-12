namespace FootballApp.Models
{
    public class Footballer
    {
        public int IdFootballer { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int IdCoutry { get; set; }
        public virtual Country Country { get; set; }


    }
}
