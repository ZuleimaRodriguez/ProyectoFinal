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
    /// Interaction logic for TipoProducto.xaml
    /// </summary>
    public partial class TipoProducto : Window
    {
        public TipoProducto()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if ((Regex.IsMatch(txtTipo.Text, @"^[a-zA-Z]+$")))
            {

                bit db = new bit();
                BaseDatosBITland.MiBd.TipoProducto emp = new BaseDatosBITland.MiBd.TipoProducto();
                emp.Tipo = txtTipo.Text;
                db.Tipo.Add(emp);
                db.SaveChanges();

            }
            else
            { MessageBox.Show("solo caracteres en tipo de producto"); }
        }
    }
}
