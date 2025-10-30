// Database context file - the database context allows us to connect to 
// the database and build the database tables based on our data model.
using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.Models;

namespace VirtualPetAdoption.Data
{
    public class PetAdoptionContext : DbContext {
        // Constructor for the PetAdoptionContext
        // Special method that when it's called, creates a new
        // instance of an object
        public PetAdoptionContext(DbContextOptions<PetAdoptionContext> options) : base(options)
        {

        }

        //Attributes for the PetAdoptionContext
        public DbSet<Pet> Pets { get; set; }  //holds a list of pets from the database table

        // Method for building a new data model for each pet and poplulating with data
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //Use the model builder to create a group of new pets 
            //Entity = a table in the database 
            modelBuilder.Entity<Pet>().HasData(
                new Pet {
                    Id = 1,
                    Name = "Fluffy",
                    Species = "Cat",
                    Description = "A calm and relaxed cat who enjoys naps.",
                    ImageUrl = "/images/cat.png",
                    EnergyLevel = 2
                },
                new Pet {
                    Id = 2,
                    Name = "Rex",
                    Species = "Dog",
                    Description = "A high-energy dog who loves to play fetch.",
                    ImageUrl = "/images/dog.png",
                    EnergyLevel = 5
                },
                new Pet {
                    Id = 3,
                    Name = "Nibbles",
                    Species = "Rabbit",
                    Description = "A friendly rabbit with moderate energy.",
                    ImageUrl = "/images/rabbit.png",
                    EnergyLevel = 3
                }
            );
        }
    }
}