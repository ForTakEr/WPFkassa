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
        public List<Ostukorv> PoeList { get; private set; }
        public List<Ostukorv> OstuList { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            OstuList = new List<Ostukorv>();
            PoeList = new List<Ostukorv>();
        }


        public class Ostukorv
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
        }

        private void Lisa_Click(object sender, RoutedEventArgs e)
        {
            var samad = PoeList.FirstOrDefault(x => x.Name.Contains(ProductName.Text));
            if (Convert.ToDouble(ProductPrice.Text) > 0 && samad == null)
            {
               PoeList.Add(new Ostukorv { Name = ProductName.Text, Price = int.Parse(ProductPrice.Text)});

                Pood_List.ItemsSource = null;
                Pood_List.ItemsSource = PoeList;
            }
            else
            {
                MessageBox.Show("Sellise nimega toode on juba olemas");
            }
            ProductName.Text = "";
            ProductPrice.Text = "";
        }

        private void Eemalda_Click(object sender, RoutedEventArgs e)
        {
            int EemaldusKoht = Korv_List.SelectedIndex;

            if (EemaldusKoht > -1)
            {
                OstuList.RemoveAt(EemaldusKoht);

                Korv_List.ItemsSource = null;
                Korv_List.ItemsSource = OstuList;
            }
        }

        private void Osta_Click(object sender, RoutedEventArgs e)
        {
            var buy = new Buy();
            buy.Price(OstuList);
        }

        private void pKorv_Click(object sender, RoutedEventArgs e)
        {
            var matches = OstuList.Where(p => String.Equals(p.Name, PoeList[Pood_List.SelectedIndex].Name, StringComparison.CurrentCulture));

            if (matches.Any())
            {
                foreach (var item in matches)
                {
                    item.Quantity += int.Parse(ProductQuantity.Text);
                }
                Korv_List.ItemsSource = null;
                Korv_List.ItemsSource = OstuList;
            }
            else
            {
                OstuList.Add(PoeList[Pood_List.SelectedIndex]);

                OstuList[OstuList.Count - 1].Quantity = int.Parse(ProductQuantity.Text);
            }
        }
    }
}
