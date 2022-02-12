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
using System.Windows.Shapes;
using Vending.Window.Page;

namespace Vending.Window
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : System.Windows.Window
    {
        DrinkPage page1 = new DrinkPage();
        MonetPage page2 = new MonetPage();

        public AdminWindow()
        {

            InitializeComponent();
            FrameContent.Navigate(page1);
        }

        private void buttonMonet_Click(object sender, RoutedEventArgs e)
        {
            FrameContent.Navigate(page2);
        }

        private void buttonDrink_Click(object sender, RoutedEventArgs e)
        {
            FrameContent.Navigate(page1);
        }
    }
}
