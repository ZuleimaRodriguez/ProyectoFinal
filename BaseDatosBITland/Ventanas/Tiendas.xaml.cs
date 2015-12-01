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

namespace BaseDatosBITland.Ventanas
{
    /// <summary>
    /// Interaction logic for Tiendas.xaml
    /// </summary>
    public partial class Tiendas : Window
    {
        public Tiendas()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if ((Regex.IsMatch(txbTienda.Text, @"^[a-zA-Z\s]+$")) && (Regex.IsMatch(txbNombre.Text, @"^[a-zA-Z\s]+$")) && (Regex.IsMatch(txbDireccion.Text, @"^[a-zA-Z\s]+$")))
            {

                BITland db = new BITland();
                Cliente emp = new Cliente();
                emp.Nombre = txbNombre.Text;
                emp.Tienda = txbTienda.Text;
                emp.Direccion = txbDireccion.Text;
                db.Clientes.Add(emp);
                db.SaveChanges();
                MessageBox.Show("Se agrego correctamente");
            }
            else
            { MessageBox.Show("Solo caracteres en Tienda, Nombre y Direccion"); }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if ((Regex.IsMatch(txbIdTienda.Text, @"^\d+$")) && (Regex.IsMatch(txbTienda.Text, @"^[a-zA-Z\s]+$")) && (Regex.IsMatch(txbNombre.Text, @"^[ a-zA-Z\s]+$")) && (Regex.IsMatch(txbDireccion.Text, @"^[a-zA-Z\s]\d+$")))
            {
                //actualiza
                BITland db = new BITland();

                int id = int.Parse(txbIdTienda.Text);
                var em = db.Clientes.SingleOrDefault(x => x.idCliente == id);
               
                if (em != null)
                {
                    em.Nombre = txbNombre.Text;
                    em.Direccion = txbDireccion.Text;
                    em.Tienda = txbTienda.Text;
                    db.SaveChanges();
                    MessageBox.Show("Se actualizo correctamente");
                }
            }
            else { MessageBox.Show("Solo Numeros en Id Tienda y/o caracteres en Nombre, Direccion y Tienda"); }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txbIdTienda.Text, @"^\d+$"))//se esta verificando que se agregue 
            {
                //elimina registro
                BITland db = new BITland();

                int id = int.Parse(txbIdTienda.Text);
                var em = db.Clientes.SingleOrDefault(x => x.idCliente == id);

                if (em != null)
                {
                    db.Clientes.Remove(em);
                    db.SaveChanges();
                    MessageBox.Show("Se elimino correctamente");
                }

            }
            else { MessageBox.Show("solo Numeros #id"); }
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            //despliega todos los datos de la base de datos
            BITland db = new BITland();


            var reg = from s in db.Clientes

                      select s;
            dgTienda.ItemsSource = reg.ToList();
        }
    }
}
