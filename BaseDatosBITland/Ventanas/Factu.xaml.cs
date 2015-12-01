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
    /// Interaction logic for Factu.xaml
    /// </summary>
    public partial class Factu : Window
    {
        //Temp varible to hold the last found item
        private Producto tmpProduct = null;
        //Array of Cart items 
        private List<Producto> ShoppingCart;
        public Factu()
        {
            InitializeComponent();
            ShoppingCart = new List<Producto>();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //If a product code is not empty we search the database
            if (Regex.IsMatch(txbCodigoPro.Text.Trim(), @"^\d+$"))
            {
                BITland db = new BITland();
                //parse the product code as int from the TextBox
                int id = int.Parse(txbCodigoPro.Text);
                //We query the database for the product
                Producto p = db.Productos.SingleOrDefault(x => x.idProducto == id);
                if (p != null) //if product was found
                {
                    //store in a temp variable (if user clicks on add we will need this for the Array)
                    tmpProduct = p;
                    //We display the product information on a label 
                    lblTotalProducto.Content = string.Format("ID: {0}, Personaje: {1}, Precio: {2}, EnStock (Qty): {3}", p.idProducto, p.Personaje, p.Precio, p.Cantidad);
                }
                else
                {
                    //if product was not found we display a user notification window
                    MessageBox.Show("Producto no encontrado", "Error en el Id Producto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            //we first check if a product has been selected
            if (tmpProduct == null)
            {
                //if not we call the search button method
                Button_Click_1(null, null);
                //we check again if the product was found
                if (tmpProduct == null)
                {
                    //if tmpProduct is empty (Product not found) we exit the procedure
                    MessageBox.Show("No hay producto seleccionado", "No hay producto", MessageBoxButton.OK,
                        MessageBoxImage.Exclamation);
                    //exit procedure
                    return;
                }
            }
        }
        //this method will clear/reset form values
        private void CleanUp()
        {
            //shopping cart = a new empty list
            ShoppingCart = new List<Producto>();
            //Textboxes and labels are set to defaults
            txbCodigoPro.Text = string.Empty;
            txbCantidad.Text = string.Empty;
            lblTotal.Content = "Total: $0.00";
            //DataGrid items are set to null
            gbCarrito.ItemsSource = null;
            gbCarrito.Items.Refresh();
            //Tmp variable is erased using null
            tmpProduct = null;

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            CleanUp();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //We ask the user if really wants to delete the item
            if (
                MessageBox.Show("Esta seguro de borrar este producto del carrito?", "Confirmado",
                    MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                //if Result is OK we get the Button that was click
                Button deleteButton = (Button)sender;
                //We get the record id binded using the commandParameter attribute {Binding Id}
                int id = (int)deleteButton.CommandParameter;
                //Remove the product from the Array
                ShoppingCart.RemoveAll(s => s.idProducto == id);
                //Update the DataGrid
                BindDataGrid();
            }
        }
        private void BindDataGrid()
        {
            //we query the array cart and add a new calculated field Subtotal
            var cartItems = from s in ShoppingCart
                            select new
                            {
                                s.idProducto,
                                s.Personaje,
                                s.Cantidad,
                                s.Precio,
                                SubTotal = s.Cantidad * s.Precio
                            };

            //refresh dataGridview-----------
            gbCarrito.ItemsSource = null;
            gbCarrito.ItemsSource = cartItems;

            //we add the total with sum(price) and apply a currency formating.
            lblTotal.Content = string.Format("Total: {0}", ShoppingCart.Sum(x => x.Precio* x.Cantidad).ToString("C"));
        }

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            //we make sure there is at least one item in the cart and a sales person has been selected
            if (ShoppingCart.Count > 0 && cbxTienda.SelectedIndex > -1)
            {
                //auto dispose after no longer in scope
                using (BITland db = new BITland())
                {
                    //All database transactions are considered 1 unit of work
                    using (var dbTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            //we create the invoice object
                            Factura inv = new Factura();
                            inv.Fecha = DateTime.Now;
                            //assign sales person by querying the database using the Combobox selection
                            inv.Tienda =
                                db.Clientes.SingleOrDefault(s => s.idCliente == (int)cbxTienda.SelectedValue);

                            //for each product in the shopping cart we query the database
                            foreach (var prod in ShoppingCart)
                            {
                                //get product record with id
                                Producto p = db.Productos.SingleOrDefault(i => i.idProducto == prod.idProducto);
                                //reduce inventory
                                int RemainingItems = p.Cantidad - prod.Cantidad >= 0 ? (p.Cantidad - prod.Cantidad) : p.Cantidad;
                                if (p.Cantidad == RemainingItems)
                                {
                                    MessageBox.Show(
                                        string.Format(
                                            "No disponible para venta #{0} No hay existencia, Desea Continuar?",
                                            p.idProducto),
                                        "No hay existencia", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                                    //end transaction
                                    dbTransaction.Rollback();
                                    //exit procedure
                                    return;
                                }
                                else
                                {
                                    //If Qty is ok we sell the product
                                    p.Cantidad = RemainingItems;
                                    inv.ListaVenta.Add(p);
                                }

                            }

                            //we add the generated invoice to the Invoice Entity (Table)
                            db.Facturas.Add(inv);
                            //Save Changed to the database
                            db.SaveChanges();
                            //Make the changes permanent 
                            dbTransaction.Commit();
                            //We restore the form with defaults
                            CleanUp();
                            //Show confirmation message to the user
                            MessageBox.Show(string.Format("Compra #{0}  guardada", inv.idFactura), "Listo", MessageBoxButton.OK,
                                MessageBoxImage.Information);
                        }
                        catch
                        {
                            //if an error is produced, we rollback everything
                            dbTransaction.Rollback();
                            //We notify the user of the error
                            MessageBox.Show("Error en la compra, no disponible para realizar compra", "Error fatal", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione producto y Tienda", "Error en los datos",
                    MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void gbCarrito_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
