using System;
using System.Collections.Generic;
using Vending.Model.Blank;
using Vending.Model.DB;
using Vending.Repository;
using Vending.ViewModel;

namespace Vending.Controller
{
    internal class AdminDrinkController
    {
        DrinksRepository drinksRepository = new DrinksRepository();
        public List<DrinkBlank> Drinks { get; set; }

        public AdminDrinkController()
        {
            Drinks = drinksRepository.GetDrinks().ConvertAll(
                new Converter<Drinks, DrinkBlank>(DrinksController.DrinkToBlankConverter)
            );
        }


    }
}
