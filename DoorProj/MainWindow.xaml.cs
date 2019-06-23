﻿using Microsoft.Win32;
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
using DBDataProvider;
using EntitiesDB;
using DbDataProvider;

namespace DoorProj
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities.TechnologicalCard technologicalCard = null;
        public MainWindow()
        {
            InitializeComponent();
            LoadingAnimation.Visibility = Visibility.Collapsed;
            try
            {
                //new DoorProvider().AddDoor(new Door() { Name = "New Test Door" });
                /*new DoorBoxProvider().AddDoorBox(new DoorBox() { Name = "New Test DoorBox" });
                new DoorStepProvider().AddDoorStep(new DoorStep() { Name = "New Test DoorStep" });
                new HingeProvider().AddHinge(new Hinge() { Name = "New Test Hinge" });
                new LockProvider().AddLock(new Lock() { Name = "New Test Lock" });*/
                 new TechnologicalCardProvider().AddTC(new EntitiesDB.TechnologicalCard() { TechCardNumber = "TEst",
                     Responsible = "Test Person", ResponsibleForPrint = "Test Person" });
                //MessageBox.Show(new TechnologicalCardProvider().GetTcByID(1)?.Blocks.Count.ToString()??"NoCard");
                //MessageBox.Show("Everything good");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show(e.StackTrace);
            }
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
                    ExcelParser.KillProccess();
                })).Start();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            ExcelParser.KillProccess();
        }
    }
}
