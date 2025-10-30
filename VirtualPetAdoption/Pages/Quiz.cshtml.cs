using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.Data;
using VirtualPetAdoption.Models;

namespace VirtualPetAdoption.Pages
{
    public class QuizModel : PageModel
    {
        private readonly PetAdoptionContext _context;

        public QuizModel(PetAdoptionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public int EnergyPreference { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var pets = await _context.Pets.ToListAsync();
            
            Pet bestMatch = null;
            int smallestDifference = int.MaxValue;

            foreach (var pet in pets)
            {
                int difference = Math.Abs(pet.EnergyLevel - EnergyPreference);
                if (difference < smallestDifference)
                {
                    smallestDifference = difference;
                    bestMatch = pet;
                }
            }

            return RedirectToPage("./Results", new { petId = bestMatch.Id, userName = Name });
        }
    }
}

