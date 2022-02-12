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
using Vending.Window;

namespace Vending
{
    /// <summary>
    /// Логика взаимодействия для PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : System.Windows.Window
    {
        public PasswordWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (password.Password == "121Qwe!")
            {
                AdminWindow window = new AdminWindow();
                window.ShowDialog();
            }
        }
    }
}
