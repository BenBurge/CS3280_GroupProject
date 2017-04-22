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

            //Test Setup
            Invoice_Data.ItemsSource = searchQueryManager.GetAllInvoicesView();
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
                Invoice_Data.ItemsSource = searchQueryManager.GetAllInvoicesView();

                //Reset all drop down boxes
                Filter_Number.SelectedItem = null;
                Filter_Date.SelectedItem = null;
                Filter_Total.SelectedItem = null;
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
                if (SendInvoice != null)
                {
                    Console.WriteLine("sending invoice");
                    SendInvoice("5000");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Filter_Number_DropDownOpened_1(object sender, EventArgs e)
        {
            //Init object
            Search = new SearchManager();

            //Fill drop down menu
            Filter_Number.ItemsSource = Search.GetAllInvoicesView();

            //Enable select button
            Btn_Select.IsEnabled = true;
        }

        private void Filter_Date_DropDownOpened_1(object sender, EventArgs e)
        {
            {
                //Init object
                Search = new SearchManager();

                //Fill drop down menu
                Filter_Date.ItemsSource = Search.filterDateOptions();

                //Enable select button
                Btn_Select.IsEnabled = true;
            }
        }
        private void Filter_Total_DropDownOpened(object sender, EventArgs e)
        {
            //Init object
            Search = new SearchManager();

            //Fill drop down menu
            Filter_Total.ItemsSource = Search.filterTotalOptions();

            //Enable select button
            Btn_Select.IsEnabled = true;
        }
    }
}
