using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace CS3280_GroupProject
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        #region Private Class Variables
        private SearchManager searchQueryManager;
        public event Action<string> SendInvoice;
        #endregion

        /// <summary>
        /// SearchManager object for sql statements
        /// </summary>
        SearchManager Search;

        /// <summary>
        /// Creates a new search window.
        /// </summary>
        public SearchWindow()
        {
            InitializeComponent();

            #region Init. Class Variables
            //Setup Search Query Manager
            searchQueryManager = new SearchManager();
            #endregion  
        }

        /// <summary>
        /// Clears the invoice data list (DataGrid) when the clear button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Reset datagrid
                Invoice_Data.ItemsSource = null;

                //Reset all drop down boxes
                if (Filter_Number.SelectedItem != null)
                {
                    Filter_Number.SelectedItem = null;
                }
                else if (Filter_Date.SelectedItem != null)
                {
                    Filter_Date.SelectedItem = null;
                }
                else if (Filter_Total.SelectedItem != null)
                {
                    Filter_Total.SelectedItem = null;
                }

                //Disable other drop down menus
                Filter_Number.IsEnabled = true;
                Filter_Date.IsEnabled = true;
                Filter_Total.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Pulls up the selected invoice when the select button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Select_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Invoice_Data.SelectedItem == null)
                    return;
                string[] data = Invoice_Data.SelectedItem.ToString().Split('=');
                SendInvoice(data[1].Substring(1, 4));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Method to fill the invoice number drop down menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filter_Number_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                //Init object
                Search = new SearchManager();

                //Fill drop down menu
                Filter_Number.ItemsSource = Search.GetAllInvoicesView();

                //Disable other drop down menus
                Filter_Date.IsEnabled = false;
                Filter_Total.IsEnabled = false;

                //Enable select button
                Btn_Select.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Method to fill the invoice date drop down number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filter_Date_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                //Init object
                Search = new SearchManager();

                //Fill drop down menu
                Filter_Date.ItemsSource = Search.filterDateOptions();

                //Disable other drop down menus
                Filter_Number.IsEnabled = false;
                Filter_Total.IsEnabled = false;

                //Enable select button
                Btn_Select.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Method that fills the invoice total drop down menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filter_Total_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                //Init object
                Search = new SearchManager();

                //Fill drop down menu
                Filter_Total.ItemsSource = Search.filterTotalOptions();

                //Disable other drop down menus
                Filter_Number.IsEnabled = false;
                Filter_Date.IsEnabled = false;

                //Enable select button
                Btn_Select.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// This method selects and displays the Invoice number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filter_Number_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Filter_Number.SelectedItem != null)
                {
                    List<string> steve = Search.GetInvoicesByInvoiceNumber(Filter_Number.SelectedItem.ToString());
                    Invoice_Data.ItemsSource = steve.Select(item => new { item });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// This method selects and displays the Invoice Date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filter_Date_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Filter_Date.SelectedItem != null)
                {
                    List<string> joe = Search.GetInvoicesByInvoiceDate(Filter_Date.SelectedItem.ToString());
                    Invoice_Data.ItemsSource = joe.Select(item => new { item });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// This method selects and displays the Invoice Total
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filter_Total_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Filter_Total.SelectedItem != null)
                {
                    List<string> george = Search.GetInvoicesByInvoiceTotal(Filter_Total.SelectedItem.ToString());
                    Invoice_Data.ItemsSource = george.Select(item => new { item });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Filter(object sender, EventArgs e)
        {

        }
    }
}
