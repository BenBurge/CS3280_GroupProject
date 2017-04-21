using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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

namespace CS3280_GroupProject
{
    /// <summary>
    /// Interaction logic for InventoryWindow.xaml
    /// </summary>
    public partial class InventoryWindow : Window
    {
        // Create an instance of the class
        private ClsQuery invQueryManager;
        private InvoiceManager inManager;
        private InvoiceManager inVoManager;
        private int selectedRowIndex;

        /// <summary>
        /// Initialize window and constructor for clsquery
        /// </summary>
        public InventoryWindow()
        {
            InitializeComponent();
            invQueryManager = new ClsQuery();
            inVoManager = new InvoiceManager();
            inManager = new InvoiceManager();
        }

        /// <summary>
        /// Queries the invoice item description and pulls all of the item codes
        /// </summary>
        /// <returns></returns>
        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cm_Item.SelectedItem.Equals("") || cm_Item.SelectedItem == null)
                    return;
                string selectedItemCode = cm_Item.SelectedItem.ToString();
                if (!lb_InvoiceID.Equals("Invoice #0000"))
                {
                    string invoiceNum = lb_InvoiceID.Text.Substring(9);

                    inManager.AddItemToInvoice(invoiceNum,
                        cm_Item.SelectedItem.ToString());

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Selects item to add/delete item in the list using the item code eg. cost and item description
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            // Need to add/change item description and cost
            try
            {
                Console.WriteLine(selectedRowIndex);
                //inManager.DeleteItemFromInvoice(lb_InvoiceID.Text.Substring(9), (selectedRowIndex + 1).ToString());

                //Refresh grid
                //grid.ItemsSource = null;
                //List<String> test = inManager.RetrieveInvoice(lb_InvoiceID.Text.Substring(9), ref invoiceDetails);
                //lb_Total.Text = "Total $" + invoiceDetails[2].ToString();
                //grid.ItemsSource = test.Select(Item => new { Item });
                //btn_Edit.IsEnabled = false;
                //btn_DeleteItem.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }

        }


        /// <summary>
        /// Button to cancel and close the current inventory window
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // close the current window and returns to previous
            this.Close();
        }

        /// <summary>
        /// Adds a new item to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewItem_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Clears the form to default values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCLearForm_Click(object sender, RoutedEventArgs e)
        {
            txtItemDesc.Text = "";
            txtItemCode.Text = "";
            txtItemCost.Text = "";
            cm_Item.Items.Clear();
        }

        /// <summary>
        /// Closes the windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Fills labels and shows data for the item code selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cm_Item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Make a new list
                List<String> items = new List<String>();
                int iRet = 0;
                //Send query
                DataSet ds = inVoManager.ExecuteSQLStatement(ClsQuery.getAllFromItemsDesc(), ref iRet);

                //Populate list
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    items.Add(dr[0].ToString());
                }

                //Return list
                cm_Item.ItemsSource = items;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cm_Item_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                cm_Item.ItemsSource = inManager.populateItemList();

                //Set Selected row
                //btn_Add.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
            //throw new NotImplementedException();
        }
    }
}
