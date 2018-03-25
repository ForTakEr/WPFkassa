using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using static Kassa.MainWindow;

namespace Kassa
{
    class Buy
    {
        public void Price(List<Ostukorv> List)
        {
            List<string> Text = new List<string>();
            double price = 0;
            foreach (var item in List)
            {
                Text.Add(string.Format("{0}x {1} - €{2}", Convert.ToString(item.Quantity), item.Name, item.Price));
                price += item.Price * item.Quantity;
            }

            File.WriteAllLines("Receipt.txt", Text);
            File.AppendAllText("Receipt.txt", "----------------" + Environment.NewLine + "Kokku läks: {0}€" + price);

            Process.Start("Receipt.txt");
        }
    }
}
