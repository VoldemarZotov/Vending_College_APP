using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending.Model.Bucket
{
    class Bucket
    { 
        
       public List<SelectedDrinks> selectedDrinks { get; set;  }
       public List<int> addingMonets { get; set; }
       public decimal DepositedMoney { get; set; }

        /**
         * Сдача
         */
        public decimal Change { get; set; }

        public Bucket() {

            selectedDrinks = new List<SelectedDrinks>();
            addingMonets = new List<int>();
            DepositedMoney = 0;
            Change = 0;
       }

        public void AddNominal(decimal nominal) {

            DepositedMoney += nominal;
            Change = DepositedMoney;
            addingMonets.Add(Convert.ToInt32(nominal));
        }

       public void AddDrink(int id, decimal cost) {

            var drinkInList = selectedDrinks.FirstOrDefault(x => x.Id == id);

            if (drinkInList != null)
            {
                selectedDrinks.First(x => x.Id == id).Count += 1;
            }
            else
            {
                selectedDrinks.Add(new SelectedDrinks()
                {
                    Id = id,
                    Count = 1,
                    CostForOne = cost
                });
            }

            Change -= cost;
       }

       public void GetChange()
        {

        }
    }
}
