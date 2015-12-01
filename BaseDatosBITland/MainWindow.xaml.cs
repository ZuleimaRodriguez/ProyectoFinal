using System;
using BaseDatosBITland.ProyectoFinal;
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
using System.Text.RegularExpressions;

namespace BaseDatosBITland
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Ventanas.Factu ob = new Ventanas.Factu();
            ob.Show();
            

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Ventanas.Tiendas ob = new Ventanas.Tiendas();
            ob.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Ventanas.Cate ob = new Ventanas.Cate();
            ob.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Ventanas.Produ ob = new Ventanas.Produ();
            ob.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Ventanas.Tipo ob = new Ventanas.Tipo();
            ob.Show();
        }
    }
}
