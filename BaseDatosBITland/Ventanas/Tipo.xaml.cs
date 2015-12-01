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
    /// Interaction logic for Tipo.xaml
    /// </summary>
    public partial class Tipo : Window
    {
        public Tipo()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            //guarda nuevo registro
            //Instanciar base de datos
            if ((Regex.IsMatch(txbTipo.Text, @"^[a-zA-Z\s]+$")))
            {

                BITland db = new BITland();
                TipoProducto emp = new TipoProducto();
                emp.Tipo = txbTipo.Text;
                db.Tipos.Add(emp);
                db.SaveChanges();
                MessageBox.Show("Se agrego Correctamente");

            }
            else
            { MessageBox.Show("Solo caracteres en Tipo de producto"); }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if ((Regex.IsMatch(txbIdTipo.Text, @"^\d+$")) && (Regex.IsMatch(txbTipo.Text, @"^[a-zA-Z\s]+$")))
            {

                //actualiza
                BITland db = new BITland();

                int id = int.Parse(txbIdTipo.Text);
                var em = db.Tipos.SingleOrDefault(x => x.idTipo == id);
                {
                    em.Tipo = txbTipo.Text;
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo Numeros en Id Tipo y/o caracteres en Tipo de producto"); }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txbIdTipo.Text, @"^\d+$"))//se esta verificando que se agregue 
            {
                //elimina registro
                BITland db = new BITland();

                int id = int.Parse(txbIdTipo.Text);
                var em = db.Tipos.SingleOrDefault(x => x.idTipo == id);
                if (em != null)
                {
                    db.Tipos.Remove(em);
                    db.SaveChanges();
                }

            }
            else { MessageBox.Show("Solo Numeros en Id Tipo de producto"); }
        }

        private void btnMostar_Click(object sender, RoutedEventArgs e)
        {
            //despliega todos los datos de la base de datos
            BITland db = new BITland();


            var reg = from s in db.Tipos

                      select s;
            dgTipo.ItemsSource = reg.ToList();
        }
    }
}
