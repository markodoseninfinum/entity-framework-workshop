using EF.Workshop.Persistence.Models;

namespace EF.Workshop.Persistence.DataSeed
{
    public static class MockData
    {
        public static Dog GetDog()
        {
            return new Dog
            {
                Id = 3,
                Name = "Dogo",
                BirthDate = new DateTime(2022, 08, 01, 0, 0, 0, DateTimeKind.Utc),
                Gender = Gender.Female,
                IsFriendly = true,
                OwnerId = 1,
                NumberOfGoodBoyPoints = 3,
            };
        }

        public static Cat GetCat()
        {
            return new Cat
            {
                Id = 4,
                Name = "Mjau mjau",
                BirthDate = new DateTime(2022, 08, 01, 0, 0, 0, DateTimeKind.Utc),
                Gender = Gender.Male,
                IsFriendly = true,
                OwnerId = 1,
                NumberOfLifesUsed = 1,
            };
        }

        public static Medicine GetMedicine()
        {
            return new Medicine
            {
                Id = 1,
                Name = "Lijek 1",
            };
        }

        public static object GetOwner()
        {
            return new
            {
                Id = 1,
                Name = "Marko Dosen",
                Address_City = "Zagreb",
                Address_Street = "Strojarska cesta 22",
            };
        }

        public static object GetAddress()
        {
            return new
            {
                OwnerId = 1,
                City = "Zagreb",
                Street = "Strojarska cesta 22",
            };
        }

        public static PetMedicine GetPetMedicine()
        {
            return new PetMedicine
            {
                MedicineId = 1,
                StartDate = new DateTime(2022, 08, 10, 0, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(2022, 09, 01, 0, 0, 0, DateTimeKind.Utc),
                PetId = 1
            };
        }
    }
}
