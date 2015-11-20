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
    /// Interaction logic for Nivel.xaml
    /// </summary>
    public partial class Nivel : Window
    {
        public Nivel()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if ((Regex.IsMatch(txtNivel.Text, @"^[a-zA-Z]+$")))
            {

                bit db = new bit();
                BaseDatosBITland.MiBd.Nivel emp = new BaseDatosBITland.MiBd.Nivel();
                emp.Niveles = txtNivel.Text;
                db.Niveles.Add(emp);
                db.SaveChanges();

            }
            else
            { MessageBox.Show("solo caracteres en Nivel"); }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if ((Regex.IsMatch(txtNivel.Text, @"^\d+$")))
            {

                //actualiza
                bit db = new bit();

                int id = int.Parse(txtIdNivel.Text);
                var em = db.Niveles.SingleOrDefault(x => x.idNivel == id);

                if (em != null)
                {
                    em.Niveles = txtNivel.Text;
                    
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("solo Numeros #id y caracteres en Nivel"); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtIdNivel.Text, @"^\d+$"))//se esta verificando que se agregue 
            {
                //elimina registro
                bit db = new bit();

                int id = int.Parse(txtIdNivel.Text);
                var em = db.Niveles.SingleOrDefault(x => x.idNivel == id);
                if (em != null)
                {
                    db.Niveles.Remove(em);
                    db.SaveChanges();
                }

            }
            else { MessageBox.Show("solo Numeros #id"); }
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            bit db = new bit();


            var reg = from s in db.Niveles

                      select s;
            dtGrib.ItemsSource = reg.ToList();
        }
    }
}
