using System;
using System.Windows;
using System.Windows.Controls;
using Vending.ViewModel;
using Vending.Window;

namespace Vending
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        DrinksController controller = new DrinksController();
        
        public MainWindow()
        {
            InitializeComponent();

            drinksList.ItemsSource = controller.Drinks;
            outputList.ItemsSource = controller.output;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var buttonTag = Convert.ToInt32((sender as Button).Tag);
            controller.OnSelectButtonClick(buttonTag);
            buttonNominal1.IsEnabled = false;
            buttonNominal2.IsEnabled = false;
            buttonNominal5.IsEnabled = false;
            buttonNominal10.IsEnabled = false;
            buttonChange.IsEnabled = true;
            UpdateLists();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var buttonTag = Convert.ToInt32((sender as Button).Tag);
            var allMoney = controller.OnAddNominalClick(buttonTag);
            depositedMoney.Text = $"{allMoney} руб.";
            UpdateLists();
        }

        private void UpdateLists()
        {
            drinksList.ItemsSource = null;
            drinksList.ItemsSource = controller.Drinks;

            outputList.ItemsSource = null;
            outputList.ItemsSource = controller.output;
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            controller.OnGetChange();
            Clear();
        }

        private void Clear()
        {
            buttonNominal1.IsEnabled = true;
            buttonNominal2.IsEnabled = true;
            buttonNominal5.IsEnabled = true;
            buttonNominal10.IsEnabled = true;
            buttonChange.IsEnabled = false;
            controller.OnClear();
            UpdateLists();
            depositedMoney.Text = $"0 руб.";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PasswordWindow window = new PasswordWindow();
            window.ShowDialog();
        }
    }
}
