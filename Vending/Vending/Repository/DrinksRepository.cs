using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Model.DB;

namespace Vending.Repository
{
    class DrinksRepository
    {
        VendingEntities db = new VendingEntities();

        public List<Drinks> GetDrinks() {

            return db.Drinks.ToList();
        }

        public void AddDrink(Drinks drink)
        {
            db.Drinks.Add(drink);
            db.SaveChanges();
        }

        public void EditDrink(Drinks drink)
        {
            var drinkDb = db.Drinks.Find(drink.Id);

            drinkDb.Name = drink.Name;
            drinkDb.Cost = drink.Cost;
            drinkDb.Image = drink.Image;
            drinkDb.Count = drink.Count;

            db.SaveChanges();
        }

        public void EditDrinkCount(int id, int count)
        {
            var drinkDb = db.Drinks.Find(id);

            drinkDb.Count = count;

            db.SaveChanges();
        }

    }
}
