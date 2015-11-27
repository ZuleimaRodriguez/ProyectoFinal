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

                bit db = new bit();
                BaseDatosBITland.MiBd.Cliente emp = new BaseDatosBITland.MiBd.Cliente();
                emp.Nombre= txtNombre.Text;
                emp.Tienda = txtTienda.Text;
                emp.Direccion = txtDireccion.Text;
                emp.NivelNivel = (string)cbxNivel.SelectedValue;
                db.Clientes.Add(emp);
                db.SaveChanges();

            }
            else
            { MessageBox.Show("solo caracteres en nombre, tienda y direccion"); }
            
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtIdCliente.Text, @"^\d+$"))//se esta verificando que se agregue 
            {
                //elimina registro
                bit db = new bit();

                int id = int.Parse(txtIdCliente.Text);
                var em = db.Clientes.SingleOrDefault(x => x.idCliente == id);
                if (em != null)
                {
                    db.Clientes.Remove(em);
                    db.SaveChanges();
                }

            }
            else { MessageBox.Show("solo Numeros #id"); }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if ((Regex.IsMatch(txtIdCliente.Text, @"^\d+$")) && (Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z]+$")) && (Regex.IsMatch(txtTienda.Text, @"^[a-zA-Z]+$"))&&
                (Regex.IsMatch(txtDireccion.Text, @"^[a-zA-Z]+$")))
            {

                //actualiza
                bit db = new bit();

                int id = int.Parse(txtIdCliente.Text);
                var em = db.Clientes.SingleOrDefault(x => x.idCliente == id);

                if (em != null)
                {
                    em.Nombre = txtNombre.Text;
                    em.Tienda = txtTienda.Text;
                    em.Direccion = txtDireccion.Text;
                    em.NivelNivel = (string)cbxNivel.SelectedValue;
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("solo Numeros #id y caracteres en Nombre"); }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bit db = new bit();


            var reg = from s in db.Clientes

                      select s;
            dtGrid.ItemsSource = reg.ToList();
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            bit db = new bit();
            cbxNivel.ItemsSource = db.Niveles.ToList();
            cbxNivel.DisplayMemberPath = "Niveles";
            cbxNivel.SelectedValuePath = "Niveles";
        }
    }
}
