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
using Vending.Utils;

namespace Vending.ViewModel
{
    class DrinksController
    {
        
        DrinksRepository drinksRepository = new DrinksRepository();
        MonetRepository monetRepository = new MonetRepository();

        Bucket bucket = new Bucket();
        
        public List<DrinkBlank> Drinks { get; set; }
        public List<String> output = new List<string>();

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
                IsCanBuy = false,
                Count = item.Count.Value,
                ImageBitmap = ImageUtils.ConvertByteArrayToBitmapImage(item.Image)
            };
        }

        public void OnSelectButtonClick(int idDrink)
        {
            var selectedDrink = Drinks.Find(x => x.Id == idDrink);

            if (selectedDrink.Count >= 1)
            {
                bucket.AddDrink(selectedDrink.Id, selectedDrink.Cost);
                Drinks.Find(x => x.Id == idDrink).Count -= 1;
                UpdateOutputForUser(selectedDrink);
            }

            CheckIsCanBuyMore();
        }

        public decimal OnAddNominalClick(int nominal) {

            bucket.AddNominal(nominal);

            CheckIsCanBuyMore();

            return bucket.DepositedMoney;
        }

        private void CheckIsCanBuyMore()
        {
            foreach (var item in Drinks)
            {
                if (item.Cost <= bucket.Change && item.Count != 0)
                {
                    item.IsCanBuy = true;
                }
                else
                {
                    item.IsCanBuy = false;
                }
            }
        }

        private void UpdateOutputForUser(DrinkBlank selectedDrink)
        {
            if (output.Count != 0)
            {
                output.Remove(output.Last());
            }

            output.Add($"{selectedDrink.Name} 1 шт.");
            output.Add($"Сдача: {bucket.Change} руб.");
        }

        public void OnGetChange()
        {
            var coin1 = bucket.addingMonets.Where(x=>x == 1).Sum();
            var coin2 = bucket.addingMonets.Where(x => x == 2).Sum();
            var coin5 = bucket.addingMonets.Where(x => x == 5).Sum();
            var coin10 = bucket.addingMonets.Where(x => x == 10).Sum();

            var coins = monetRepository.GetCoins();

            coins.Find(x => x.Nominal == 1).Count += coin1;
            coins.Find(x => x.Nominal == 2).Count += coin2;
            coins.Find(x => x.Nominal == 5).Count += coin5;
            coins.Find(x => x.Nominal == 10).Count += coin10;

            monetRepository.EditCoins(coins);

            foreach (var item in Drinks)
            {
                drinksRepository.EditDrinkCount(item.Id, item.Count);
            }
        }

        public void OnClear()
        {
            output.Clear();
            bucket = new Bucket();
            Drinks.ForEach(x => x.IsCanBuy = false);
        }
    }
}
