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

namespace Kassa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Ostukorv> List { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            List = new List<Ostukorv>();
        }


        public class Ostukorv
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
        }

        private void Lisa_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDouble(ProductPrice.Text) > 0)
            {
                Ostukorv_List.Items.Add(new Ostukorv { Name = ProductName.Text, Price = int.Parse(ProductPrice.Text), Quantity = int.Parse(ProductQuantity.Text) });
                List.Add(new Ostukorv { Name = ProductName.Text, Price = int.Parse(ProductPrice.Text), Quantity = int.Parse(ProductQuantity.Text) });
            }
        }

        private void Eemalda_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Osta_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
