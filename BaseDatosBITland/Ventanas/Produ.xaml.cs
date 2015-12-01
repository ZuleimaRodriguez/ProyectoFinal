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
    /// Interaction logic for Produ.xaml
    /// </summary>
    public partial class Produ : Window
    {
        public Produ()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            //guarda nuevo registro
            //Instanciar base de datos

            if ((Regex.IsMatch(txbPersonaje.Text, @"^[a-zA-Z]+$")) && (Regex.IsMatch(txbPrecio.Text, @"^\d+$")) && (Regex.IsMatch(txbCantidad.Text, @"^\d+$")) && (cbxCategoria.SelectedIndex > -1)&&(cbxTipo.SelectedIndex > -1))
            {

                BITland db = new BITland();
                Producto emp = new Producto();
                emp.Personaje = txbPersonaje.Text;
                emp.Cantidad = int.Parse(txbCantidad.Text);
                emp.Precio = int.Parse(txbPrecio.Text);
                emp.CategoriaidCategoria = (int)cbxCategoria.SelectedValue;
                emp.TipoProductoidTipo = (int)cbxTipo.SelectedValue;
                db.Productos.Add(emp);
                db.SaveChanges();
                MessageBox.Show("Se agrego correctamente");

            }
            else
            { MessageBox.Show("Solo caracteres en Personaje y/o numeros en Precio y Cantidad"); }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if ((Regex.IsMatch(txbPersonaje.Text, @"^[ a-zA-Z]+$")) && (Regex.IsMatch(txbPrecio.Text, @"^\d+$")) && (Regex.IsMatch(txbCantidad.Text, @"^\d+$"))&&(Regex.IsMatch(txbIdProducto.Text,  @"^\d+$")))
            {

                //actualiza
                BITland db = new BITland();

                int id = int.Parse(txbIdProducto.Text);
                var em = db.Productos.SingleOrDefault(x => x.idProducto == id);
                if (em != null)
                {
                    em.Personaje = txbPersonaje.Text;
                    em.Cantidad = int.Parse(txbCantidad.Text);
                    em.Precio = int.Parse(txbPrecio.Text);
                    em.CategoriaidCategoria = (int)cbxCategoria.SelectedValue;
                    em.TipoProductoidTipo = (int)cbxTipo.SelectedValue;
                    db.SaveChanges();
                    MessageBox.Show("Se actualizo correctamente");
                }
            }
            else { MessageBox.Show("Solo caracteres en Personaje y/o numeros en Id Producto, Precio y Cantidad"); }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txbIdProducto.Text, @"^\d+$"))
            {
                //elimina registro
                BITland db = new BITland();

                int id = int.Parse(txbIdProducto.Text);
                var em = db.Productos.SingleOrDefault(x => x.idProducto == id);
                if (em != null)
                {
                    db.Productos.Remove(em);
                    db.SaveChanges();
                    MessageBox.Show("Se elimino correctamente");
                }
            }

            else { MessageBox.Show("Solo ingrese Numeros en id Producto"); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //despliega todos los datos de la base de datos
            BITland db = new BITland();


            var reg = from s in db.Productos

                      select s;
            gbProdu.ItemsSource = reg.ToList();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            BITland db = new BITland();
            cbxCategoria.ItemsSource = db.Categorias.ToList();
            cbxCategoria.DisplayMemberPath = "Cate";
            cbxCategoria.SelectedValuePath = "idCategoria";
            cbxCategoria.SelectedIndex = 0;

            BITland db1 = new BITland();
            cbxTipo.ItemsSource = db1.Tipos.ToList();
            cbxTipo.DisplayMemberPath = "Tipo";
            cbxTipo.SelectedValuePath = "idTipo";
            cbxCategoria.SelectedIndex = 0;
        }
    }
}
