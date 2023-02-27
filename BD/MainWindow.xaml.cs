using Microsoft.EntityFrameworkCore;
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

namespace BD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApplicationContext db = new ApplicationContext();
        }

        /// <summary>
        /// Метод для очистки полей ввода
        /// </summary>
        public void Clear()
        {
            id_user.Clear();
            type_user.Clear();
            cost_user.Clear();           
        }

        /// <summary>
        /// Метод перебирает записи и добавляет их в TextBlock
        /// </summary>
        public void Report_database()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<string> result = new List<string>();
                var product_list = db.Products.ToList();
                foreach (var p in product_list)
                {
                    result.Add($"{p.Id}: {p.Type} - {p.Cost} руб ");
                }

                for (int i = 0; i < result.Count; i++)
                {
                    Report.Text += $"{result[i]}\n";
                }
            }
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            Report.Clear();

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Add_product(type_user.Text, Convert.ToDouble(cost_user.Text));
            }

            Report_database();
            Clear();
        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            Report.Clear();

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Update_product(Convert.ToInt32(id_user.Text), type_user.Text, Convert.ToDouble(cost_user.Text));
            }

            Report_database();
            Clear();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            Report.Clear();

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Delete_product(Convert.ToInt32(id_user.Text));
            }

            Report_database();
            Clear();
        }
    }
}
