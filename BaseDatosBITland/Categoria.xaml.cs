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
    /// Interaction logic for Categoria.xaml
    /// </summary>
    public partial class Categoria : Window
    {
        public Categoria()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            //guarda nuevo registro
            //Instanciar base de datos
            if ((Regex.IsMatch(txtCategoria.Text, @"^[a-zA-Z]+$")))
            {

                bit db = new bit();
                BaseDatosBITland.MiBd.Categoria emp = new BaseDatosBITland.MiBd.Categoria();
                emp.Categorias = txtCategoria.Text;
                db.Categorias.Add(emp);
                db.SaveChanges();

            }
            else
            { MessageBox.Show("solo caracteres en Categoria"); }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if ((Regex.IsMatch(txtIdCategoria.Text, @"^\d+$")) && (Regex.IsMatch(txtCategoria.Text, @"^[a-zA-Z]+$")))
            {

                //actualiza
                bit db = new bit();

                int id = int.Parse(txtIdCategoria.Text);
                var em = db.Categorias.SingleOrDefault(x => x.idCategoria == id);

                if (em != null)
                {
                    em.Categorias = txtCategoria.Text;
                    
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("solo Numeros #id y caracteres en Categoria"); }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtIdCategoria.Text, @"^\d+$"))//se esta verificando que se agregue 
            {
                //elimina registro
                bit db = new bit();

                int id = int.Parse(txtIdCategoria.Text);
                var em = db.Categorias.SingleOrDefault(x => x.idCategoria == id);
                if (em != null)
                {
                    db.Categorias.Remove(em);
                    db.SaveChanges();
                }

            }
            else { MessageBox.Show("solo Numeros #id"); }
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            bit db = new bit();


            var reg = from s in db.Categorias

                      select s;
            dtGrid.ItemsSource = reg.ToList();
        }
    }
}
