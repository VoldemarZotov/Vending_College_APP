using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Model.DB;

namespace Vending.Repository
{
    internal class MonetRepository
    {
        VendingEntities db = new VendingEntities();

        public List<Coins> GetCoins()
        {

            return db.Coins.ToList();
        }

        public void EditCoins(List<Coins> coins)
        {
            foreach (var item in coins)
            {
                db.Coins.Find(item.Id).Count = item.Count;
            }

            db.SaveChanges();
        }

    }
}
