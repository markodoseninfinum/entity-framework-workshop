namespace EF.Workshop.Persistence.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public bool IsFriendly { get; set; }
        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual ICollection<PetMedicine> Medicines { get; set; }
    }
}
