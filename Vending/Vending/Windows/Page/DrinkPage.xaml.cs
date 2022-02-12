using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vending.Controller;
using Vending.Model.Blank;
using Vending.Repository;

namespace Vending.Window.Page
{
    /// <summary>
    /// Логика взаимодействия для DrinkPage.xaml
    /// </summary>
    public partial class DrinkPage : System.Windows.Controls.Page
    {

        AdminDrinkController controller = new AdminDrinkController();

        public DrinkPage()
        {
            InitializeComponent();
            UpdateLists();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var currentId = Convert.ToInt32((sender as Button).Tag);
            var currentItem = controller.Drinks.Find(x => x.Id == currentId);

            EditDrink window = new EditDrink(currentItem);
            window.ShowDialog();
            UpdateLists();
        }

        private void UpdateLists()
        {
            drinkList.ItemsSource = null;
            drinkList.ItemsSource = controller.Drinks;
        }
    }
}
