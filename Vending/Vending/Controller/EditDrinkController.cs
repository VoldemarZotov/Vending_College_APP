using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Model.Blank;
using Vending.Model.DB;
using Vending.Repository;

namespace Vending.Controller
{
    internal class EditDrinkController
    {
        DrinksRepository drinksRepository = new DrinksRepository();

        public void AddDrink(DrinkBlank drink)
        {
            drinksRepository.AddDrink(new Drinks()
            {
                Name = drink.Name,
                Cost = drink.Cost,
                Count = drink.Count,
                Image = drink.Image
            });
        }

        public void EditDrink(DrinkBlank drink)
        {
            drinksRepository.EditDrink(new Drinks()
            {
                Id = drink.Id,
                Name = drink.Name,
                Cost = drink.Cost,
                Count = drink.Count,
                Image = drink.Image
            });
        }
    }
}
