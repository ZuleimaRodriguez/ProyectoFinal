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
    /// Interaction logic for Producto.xaml
    /// </summary>
    public partial class Producto : Window
    {
        public Producto()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            //guarda nuevo registro
            //Instanciar base de datos
            if ((Regex.IsMatch(txtPersonaje.Text, @"^[a-zA-Z]+$")) && (Regex.IsMatch(txtPrecio.Text,@"^\d+$")))
            {

                bit db = new bit();
                BaseDatosBITland.MiBd.Producto emp = new BaseDatosBITland.MiBd.Producto();
                emp.Personaje = txtPersonaje.Text;
                emp.Precio = int.Parse(txtPrecio.Text);
                emp.CategoriaCategoria = (string)cbxCategoria.SelectedValue;
                emp.TipoProductoTipo = (string)cbxTipo.SelectedValue;
                db.Productos.Add(emp);
                db.SaveChanges();

            }
            else
            { MessageBox.Show("solo caracteres en Personaje y numeros en precio"); }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if ((Regex.IsMatch(txtPrecio.Text, @"^\d+$")) && (Regex.IsMatch(txtPersonaje.Text, @"^[a-zA-Z]+$")))
            {

                //actualiza
                bit db = new bit();

                int id = int.Parse(txtIdProducto.Text);
                var em = db.Productos.SingleOrDefault(x => x.idProducto == id);

                if (em != null)
                {
                    em.Personaje = txtPersonaje.Text;
                    em.Precio = int.Parse(txtPrecio.Text);
                    em.CategoriaCategoria = (string)cbxCategoria.SelectedValue;
                    em.TipoProductoTipo = (string)cbxTipo.SelectedValue;
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("solo caracteres en Personaje y numeros en precio"); }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtIdProducto.Text, @"^\d+$"))//se esta verificando que se agregue 
            {
                //elimina registro
                bit db = new bit();

                int id = int.Parse(txtIdProducto.Text);
                var em = db.Productos.SingleOrDefault(x => x.idProducto == id);
                if (em != null)
                {
                    db.Productos.Remove(em);
                    db.SaveChanges();
                }

            }
            else { MessageBox.Show("solo Numeros idProducto"); }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            //consulta por id
            if (Regex.IsMatch(txtPersonaje.Text, @"^[a-zA-Z]+$"))
            {
                bit db = new bit();

                string personaje = txtPersonaje.Text;

                var reg = from s in db.Productos
                          where s.Personaje == personaje
                          select new
                          {
                              s.idProducto,
                              s.Personaje,
                              s.Precio,
                              s.CategoriaCategoria
                          };
                btGrid.ItemsSource = reg.ToList();
            }
            else { MessageBox.Show("solo caracteres en Personaje"); }
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            bit db = new bit();
            cbxCategoria.ItemsSource = db.Niveles.ToList();
            cbxCategoria.DisplayMemberPath = "Categoria";
            cbxCategoria.SelectedValuePath = "Categoria";
            bit d = new bit();
            cbxTipo.ItemsSource = d.Tipo.ToList();
            cbxTipo.DisplayMemberPath = "Tipo";
            cbxTipo.SelectedValuePath = "Tipo";

        }
    }
}
