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
                MessageBox.Show("Se guardo exitosamente");

            }
            else
            { MessageBox.Show("solo caracteres en tipo de producto"); }
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            //despliega todos los datos de la base de datos
            bit db = new bit();


            var reg = from d in db.Tipo

                      select d;
            dtGrid.ItemsSource = reg.ToList();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if ((Regex.IsMatch(txtId.Text, @"^\d+$")) && (Regex.IsMatch(txtTipo.Text, @"^[a-zA-Z]+$")))
            {

                //actualiza
                bit db = new bit();

                int id = int.Parse(txtId.Text);
                var em = db.Tipo.SingleOrDefault(x => x.idTipo == id);

                if (em != null)
                {
                    em.Tipo = txtTipo.Text;
                    em.idTipo = int.Parse(txtId.Text);
                    db.SaveChanges();
                    MessageBox.Show("Se actualizo exitosamente");
                }
            }
            else { MessageBox.Show("solo caracteres en Personaje y numeros en precio"); }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtId.Text, @"^\d+$"))//se esta verificando que se agregue 
            {
                //elimina registro
                bit db = new bit();

                int id = int.Parse(txtId.Text);
                var em = db.Tipo.SingleOrDefault(x => x.idTipo == id);
                if (em != null)
                {
                    db.Tipo.Remove(em);
                    db.SaveChanges();
                    MessageBox.Show("Se elimino exitosamente");
                }
                else { MessageBox.Show("solo Numeros idProducto"); }
            }

        }
    }
}
