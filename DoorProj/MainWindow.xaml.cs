using Microsoft.Win32;
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
using Entities;
using ExcelParserLibrary;
using System.Threading;

namespace DoorProj
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TechnologicalCard technologicalCard = null;

        public MainWindow()
        {
            InitializeComponent();
            LoadingAnimation.Visibility = Visibility.Collapsed;
        }

        private void MenuItem_LoadTechnoCard(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Excel file (*.xls; *.xlsx)|*.xls; *.xlsx";
            if (open.ShowDialog() == true)
            {
                Table.ItemsSource = null;
                LoadingAnimation.Visibility = Visibility.Visible;
                new Thread(new ThreadStart(() =>
                {
                    technologicalCard = new ExcelParser(open.FileName).ParseTechnoCard();
                    if (technologicalCard != null)
                    {
                        Table.Dispatcher.Invoke(() => { Table.ItemsSource = technologicalCard.Blocks; });
                    }
                    else
                    {
                        MessageBox.Show("Не вдалось завантажити технологічну карту", "Помилка");
                    }
                    LoadingAnimation.Dispatcher.Invoke(() => { LoadingAnimation.Visibility = Visibility.Collapsed; });
                })).Start();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            ExcelParser.KillProccess();
        }
    }
}
