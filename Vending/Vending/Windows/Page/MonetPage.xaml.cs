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

namespace Vending.Window.Page
{
    /// <summary>
    /// Логика взаимодействия для MonetPage.xaml
    /// </summary>
    public partial class MonetPage : System.Windows.Controls.Page
    {
        AdminMonetController controller = new AdminMonetController();   

        public MonetPage()
        {
            InitializeComponent();

            UpdateCounts();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            controller.Monets.Find(x => x.Nominal == 10).Count = Convert.ToInt32(monet10Count.Text);
            controller.Monets.Find(x => x.Nominal == 1).Count = Convert.ToInt32(monet1Count.Text);
            controller.Monets.Find(x => x.Nominal == 2).Count = Convert.ToInt32(monet2Count.Text);
            controller.Monets.Find(x => x.Nominal == 5).Count = Convert.ToInt32(monet5Count.Text);

            controller.EditCoins();
            MessageBox.Show("Сохранено");

            UpdateCounts();
        }

        private void UpdateCounts()
        {
            monet10Count.Text = controller.Monets.Find(x => x.Nominal == 10).Count.ToString();
            monet5Count.Text = controller.Monets.Find(x => x.Nominal == 5).Count.ToString();
            monet1Count.Text = controller.Monets.Find(x => x.Nominal == 1).Count.ToString();
            monet2Count.Text = controller.Monets.Find(x => x.Nominal == 2).Count.ToString();
        }
    }
}
