using System;
using BaseDatosBITland.MiBd;
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
using System.Data.SqlClient;

namespace BaseDatosBITland
{
    /// <summary>
    /// Interaction logic for Factura.xaml
    /// </summary>
    public partial class Factura : Window
    {
        public Factura()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            bit db = new bit();
            cbxTipoPro.ItemsSource = db.Tipo.ToList();
            cbxTipoPro.DisplayMemberPath = "Tipo";
            cbxTipoPro.SelectedValuePath = "idTipo";
            bit db1 = new bit();
            cbxCategoria.ItemsSource = db1.Categorias.ToList();
            cbxCategoria.DisplayMemberPath = "Categorias";
            cbxCategoria.SelectedValuePath = "idCategoria";
            bit db2 = new bit();
            cbxClienteFac.ItemsSource = db2.Clientes.ToList();
            cbxClienteFac.DisplayMemberPath = "Tienda";
            cbxCategoria.SelectedValuePath = "idTienda";
        }
    }
}
