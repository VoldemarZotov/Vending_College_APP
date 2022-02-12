using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Model.Blank;
using Vending.Model.Bucket;
using Vending.Model.DB;
using Vending.Repository;

namespace Vending.ViewModel
{
    class DrinksController
    {
        Bucket bucket = new Bucket();
        DrinksRepository drinksRepository = new DrinksRepository();

        public List<DrinkBlank> Drinks { get; set; }

        public DrinksController()
        {
            Drinks = drinksRepository.GetDrinks().ConvertAll(
                new Converter<Drinks, DrinkBlank>(DrinkToBlankConverter)
            );
        }

        public static DrinkBlank DrinkToBlankConverter(Drinks item)
        {
            return new DrinkBlank()
            {
              Id = item.Id,
              Cost = item.Cost,
              Image = item.Image,
              Name = item.Name,
              IsCanBuy = false
            };
        }

        public void OnSelectButtonClick(int idDrink)
        {
            var drinkCost = Drinks.Where(x => x.Id == idDrink).FirstOrDefault().Cost;
        }

        public decimal OnAddNominalClick(int nominal) {

            bucket.AddNominal(nominal);

            //Drinks.Where(x => x.Cost <= bucket.DepositedMoney).ForEach(x => x.IsCanBuy = true);

            foreach (var item in Drinks) {
                if (item.Cost <= bucket.DepositedMoney) {
                    item.IsCanBuy = true;
                }
            }

            return bucket.DepositedMoney;
        }
    }
}
