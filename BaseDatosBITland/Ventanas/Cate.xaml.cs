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
    /// Interaction logic for Cate.xaml
    /// </summary>
    public partial class Cate : Window
    {
        public Cate()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txbCategoria.Text, @"^[a-zA-Z]+$"))
            {

                BITland db = new BITland();
                Categoria emp = new Categoria();
                emp.Cate = txbCategoria.Text;
                db.Categorias.Add(emp);
                db.SaveChanges();
                MessageBox.Show("Se agrego correctamente");

            }
            else
            { MessageBox.Show("Solo caracteres en Categoria"); }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if ((Regex.IsMatch(txbIdCategoria.Text, @"^\d+$")) && (Regex.IsMatch(txbCategoria.Text, @"^[a-zA-Z]+$")))
            {

                //actualiza
                BITland db = new BITland();

                int id = int.Parse(txbIdCategoria.Text);
                var em = db.Categorias.SingleOrDefault(x => x.idCategoria == id);
                //  var em = from x in db.Empleados
                //         where x.id == id
                //       select x;
                if (em != null)
                {
                    em.Cate = txbCategoria.Text;
                    em.idCategoria = int.Parse(txbIdCategoria.Text);
                    db.SaveChanges();
                    MessageBox.Show("Se actualizo correctamente");
                }
            }
            else { MessageBox.Show("Solo Numeros en Id Categoria y/o caracteres en Categoria"); }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txbIdCategoria.Text, @"^\d+$"))//se esta verificando que se agregue 
            {
                //elimina registro
                BITland db = new BITland();

                int id = int.Parse(txbIdCategoria.Text);
                var em = db.Categorias.SingleOrDefault(x => x.idCategoria == id);
                
                if (em != null)
                {
                    db.Categorias.Remove(em);
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


            var reg = from s in db.Categorias

                      select s;
            dgCategoria.ItemsSource = reg.ToList();
        }
    }
}
