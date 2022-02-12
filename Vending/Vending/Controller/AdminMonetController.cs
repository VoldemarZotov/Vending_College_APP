using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Model.DB;
using Vending.Repository;

namespace Vending.Controller
{
    internal class AdminMonetController
    {   
        MonetRepository repository = new MonetRepository();

        public List<Coins> Monets { get; set; }

        public AdminMonetController()
        {
            Monets = repository.GetCoins().ToList();
        }

        public void EditCoins()
        {
            repository.EditCoins(Monets);
        }
    }
}
