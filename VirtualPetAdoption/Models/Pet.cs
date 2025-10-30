// Data model for the Pets table in the SQLite database
namespace VirtualPetAdoption.Models
{
 public class Pet {
    // Attributes for the Pet class
    // Attributes are variables that hold values which describe the object.
    //Attributes for the pet class describe a pet.
    public int Id {get; set;}
    public string Name { get; set;}
    public string Species {get; set; }
    public string Description {get; set;}
    public string ImageUrl {get; set;}
    public int EnergyLevel {get; set;}
 }   
}