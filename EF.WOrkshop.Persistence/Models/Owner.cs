namespace EF.Workshop.Persistence.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
