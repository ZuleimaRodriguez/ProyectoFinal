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

namespace BaseDatosBITland
{
    /// <summary>
    /// Interaction logic for BITland.xaml
    /// </summary>
    public partial class BITland : Window
    {
        public BITland()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BaseDatosBITland.Cliente db = new BaseDatosBITland.Cliente();
            db.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BaseDatosBITland.Producto db = new BaseDatosBITland.Producto();
            db.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            BaseDatosBITland.Nivel db = new BaseDatosBITland.Nivel();
            db.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            BaseDatosBITland.Categoria db = new BaseDatosBITland.Categoria();
            db.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            BaseDatosBITland.TipoProducto db = new BaseDatosBITland.TipoProducto();
            db.Show();
        }
    }
}
