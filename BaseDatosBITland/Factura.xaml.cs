using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using BaseDatosBITland.MiBd;

namespace BaseDatosBITland
{
    /// <summary>
    /// Interaction logic for Factura.xaml
    /// </summary>
    public partial class Factura : Window
    {
        public Factura()
        {
            InitializeComponent();
            ShoppingCart = new List<BaseDatosBITland.MiBd.Producto>();
        }
        private BaseDatosBITland.MiBd.Producto tmpProduct = null;
        private List<BaseDatosBITland.MiBd.Producto> ShoppingCart;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //we make sure there is at least one item in the cart and a sales person has been selected
            if (ShoppingCart.Count > 0 && cbxClienteFac.SelectedIndex > -1)
            {
                //auto dispose after no longer in scope
                using (bit db = new bit())
                {
                    //All database transactions are considered 1 unit of work
                    using (var dbTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            //we create the invoice object
                            BaseDatosBITland.MiBd.Factura inv = new BaseDatosBITland.MiBd.Factura();
                            inv.Fecha = DateTime.Now;
                            //assign sales person by querying the database using the Combobox selection
                            inv.ClienteidCliente =
                                db.Clientes.SingleOrDefault(s => s.idCliente == (int)cbxClienteFac.SelectedValue);

                            //for each product in the shopping cart we query the database
                            foreach (var prod in ShoppingCart)
                            {
                                //get product record with id
                                BaseDatosBITland.MiBd.Producto p = db.Productos.SingleOrDefault(i => i.idProducto == prod.idProducto);

                            }
                          //  p.Qty = RemainingItems;
                            //inv.listVenta.Add(p);

                            //we add the generated invoice to the Invoice Entity (Table)
                            db.Facturas.Add(inv);
                            //Save Changed to the database
                            db.SaveChanges();
                            //Make the changes permanent 
                            dbTransaction.Commit();
                            //We restore the form with defaults
                            CleanUp();
                            //Show confirmation message to the user
                            MessageBox.Show(string.Format("Compra Realizada #{0}  guardada", inv.idFactura), "Success", MessageBoxButton.OK,
                                MessageBoxImage.Information);
                        }
                        catch
                        {
                            //if an error is produced, we rollback everything
                            dbTransaction.Rollback();
                            //We notify the user of the error
                            MessageBox.Show("Hubo un error en la compra, no se puede realizar captura", "Error Fatal", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select at least one product and a Sales Person", "Data Error",
                    MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
        private void CleanUp()
        {
            //shopping cart = a new empty list
            ShoppingCart = new List<BaseDatosBITland.MiBd.Producto>();
            //Textboxes and labels are set to defaults
            txtId.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            lblTotal.Content = "Total: $0.00";
            //DataGrid items are set to null
            dtGridCompra.ItemsSource = null;
            dtGridCompra.Items.Refresh();
            //Tmp variable is erased using null
            tmpProduct = null;

        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            bit db = new bit();
            cbxTipoPro.ItemsSource = db.Tipo.ToList();
            cbxTipoPro.DisplayMemberPath = "Tipo";
            cbxTipoPro.SelectedValuePath = "idTipo";
            bit db1 = new bit();
            cbxCategoria.ItemsSource = db1.Categorias.ToList();
            cbxCategoria.DisplayMemberPath = "Categorias";
            cbxCategoria.SelectedValuePath = "idCategoria";
            bit db2 = new bit();
            cbxClienteFac.ItemsSource = db2.Clientes.ToList();
            cbxClienteFac.DisplayMemberPath = "Tienda";
            cbxCategoria.SelectedValuePath = "Tienda";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            bit db = new bit();
            
            var reg = from s in db.Productos
                      where s.TipoidTipo == cbxTipoPro.SelectedValuePath && 
                      s.CategoriaidCategoria == cbxCategoria.SelectedValuePath
                      select new
                      {
                          s.idProducto,
                          s.Personaje,
                          s.Precio
                      };
                   
            dtGridProducto.ItemsSource = reg.ToList();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //we first check if a product has been selected
            if (tmpProduct == null)
            {
                //if not we call the search button method
                Button_Click_2(null, null);
                //we check again if the product was found
                if (tmpProduct == null)
                {
                    //if tmpProduct is empty (Product not found) we exit the procedure
                    MessageBox.Show("No product was selected", "No product", MessageBoxButton.OK,
                        MessageBoxImage.Exclamation);
                    //exit procedure
                    return;
                }
            }

            int qty;

            // we try to parse the number of the textbox if the number is invalid 
            int.TryParse(txtCantidad.Text, out qty);
            //if qty is 0 we assign 0 otherwise we assign the actual parsed value
            qty = qty == 0 ? 1 : qty;
            //we add the product to the Cart
            ShoppingCart.Add(new BaseDatosBITland.MiBd.Producto()
            {
                idProducto = tmpProduct.idProducto,
                Personaje = tmpProduct.Personaje,
                Precio = tmpProduct.Precio
            });

            
       
                
                
                //perform  query on Shopping Cart to select certain fields and perform subtotal operation 
                BindDataGrid();
                //<----------------------
                //cleanup variables
                tmpProduct = null;
                //once the products had been added we clear the textbox of code and quantity.
                txtId.Text = string.Empty;
                txtCantidad.Text = string.Empty;
                //clean up current product label
                lblcantidad.Content = "Current product N/A";
            
        }
        private void BindDataGrid()
        {
            int x = int.Parse(txtCantidad.Text);
            //we query the array cart and add a new calculated field Subtotal
            var cartItems = from s in ShoppingCart
                            select new
                            {
                                
                                s.idProducto,
                                s.Personaje,
                                s.Precio,
                                SubTotal = x * s.Precio
                            };

            //refresh dataGridview-----------
            dtGridCompra.ItemsSource = null;
            dtGridCompra.ItemsSource = cartItems;

            //we add the total with sum(price) and apply a currency formating.
            lblTotal.Content = string.Format("Total: {0}", ShoppingCart.Sum(w => w.Precio * x ).ToString("C"));

        }
    }
}
