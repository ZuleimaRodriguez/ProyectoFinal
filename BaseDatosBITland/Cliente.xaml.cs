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
    /// Interaction logic for Cliente.xaml
    /// </summary>
    public partial class Cliente : Window
    {
        public Cliente()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            //guarda nuevo registro
            //Instanciar base de datos
            if ((Regex.IsMatch(txtTienda.Text, @"^[a-zA-Z]+$")) && (Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z]+$")) && (Regex.IsMatch(txtDireccion.Text, @"^[a-zA-Z]+$")))
            {

                BITland1 db = new BITland1();
                Cliente emp = new Cliente();
               /* emp.= txtNombre.Text;
                emp.DepartamentoId = (int)cbDeps.SelectedValue;
                db.Cliente.Add(emp);
                db.SaveChanges();*/

            }
            else
            { MessageBox.Show("solo caracteres en nombre y/o numeros en sueldo"); }
            
        }
    }
}
