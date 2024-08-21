using SimpleRestaurant1.Models;
using System;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleRestaurant1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Employee employee = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            int quantity;

            try
            {
                if (quantityInput.Text is not null)
                {
                    if (Int32.TryParse(quantityInput.Text, out quantity))
                    {
                        if (chickenRadioButton.IsChecked == true)
                        {
                            object order = employee.NewRequest(quantity, "Chicken");
                            // in case employee forgets the order, I would use DI with interfaces here if I wasn't restricted with 'Design Restrictions' of the project
                            if (order is EggOrder) 
                            {
                                EggOrder wrongOrder = (EggOrder)order;

                                resultsTextBlock.Text += "\nOrder for " + wrongOrder.GetQuantity().ToString() + " eggs has been accepted";
                                eggQualityLabel.Content = employee.Inspect(wrongOrder);
                            }
                            else
                            {
                                ChickenOrder chickenOrder = (ChickenOrder)order;

                                resultsTextBlock.Text += "\nOrder for " + chickenOrder.GetQuantity().ToString() + " chickens has been accepted\n";
                                resultsTextBlock.Text += employee.Inspect(chickenOrder);
                            }
                            
                            
                        }
                        else if (eggRadioButton.IsChecked == true)
                        {
                            object order = employee.NewRequest(quantity, "Egg");

                            if (order is ChickenOrder)  // in case employee forgets the order
                            {
                                ChickenOrder wrongOrder = (ChickenOrder)order;

                                resultsTextBlock.Text += "\nOrder for " + wrongOrder.GetQuantity().ToString() + " chickens has been accepted";
                                resultsTextBlock.Text += employee.Inspect(wrongOrder);
                            }
                            else
                            {
                                EggOrder eggOrder = (EggOrder)order;

                                resultsTextBlock.Text += "\nOrder for " + eggOrder.GetQuantity().ToString() + " eggs has been accepted";
                                eggQualityLabel.Content = employee.Inspect(eggOrder);
                            }
                        }
                    }
                    else
                    {
                        resultsTextBlock.Text += "\nWarning: enter an numeric value";
                    }
                }
                else 
                {
                    MessageBox.Show("Enter order quantity before submitting", "Info", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            catch (Exception exeption)
            {
                resultsTextBlock.Text += "\nException: " + exeption.Message;
            }
            
        }

        private void copytButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object order = employee.CopyRequest();
                if (order is EggOrder)
                {
                    EggOrder eggOrder = (EggOrder)order;

                    resultsTextBlock.Text += "\nOrder for " + eggOrder.GetQuantity().ToString() + " eggs has been accepted";
                    eggQualityLabel.Content = employee.Inspect(eggOrder);
                }
                else if (order is ChickenOrder)
                {
                    ChickenOrder chickenOrder = (ChickenOrder)order;

                    resultsTextBlock.Text += "\nOrder for " + chickenOrder.GetQuantity().ToString() + " chickens has been accepted\n";
                    resultsTextBlock.Text += employee.Inspect(chickenOrder);
                }
            }
            catch (Exception exeption)
            {
                resultsTextBlock.Text += "\nException: " + exeption.Message;
            }
        }

        private void prepareButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resultsTextBlock.Text += "\n" + employee.PrepareFood();
            }
            catch (Exception exeption)
            {
                resultsTextBlock.Text += "\nException: " + exeption.Message;
            }
        }
    }
}