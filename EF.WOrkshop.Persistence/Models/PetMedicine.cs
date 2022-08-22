namespace EF.Workshop.Persistence.Models
{
    public class PetMedicine
    {
        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
