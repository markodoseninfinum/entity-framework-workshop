namespace EF.Workshop.Persistence.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PetMedicine> Pets { get; set; }
    }
}
