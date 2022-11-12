namespace FootballApp.Models
{
    public class Country
    {
        public Country() {
        Footballers = new HashSet<Footballer>();
        }
        public int IdCountry { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Footballer> Footballers { get; set;}
    }
}
