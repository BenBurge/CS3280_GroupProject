using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_GroupProject
{
    class SearchManager
    {
        #region Private Class Variables
        #endregion

        /// <summary>
        /// Creates a new search query manager that controls all the searching needed for the search
        /// window class.
        /// </summary>
        public SearchManager()
        {
        }

        /// <summary>
        /// Queries the invoice database and pulls all of the invoices
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllInvoicesView()
        {
            try
            {
                //Create DataSet to hold query data
                List<string> InvoiceNum = new List<string>();
                int iRet = 0;

                DataSet ds = ExecuteSQLStatement(ClsQuery.getInvoiceOptions(), ref iRet);

                //Get query results
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    InvoiceNum.Add(dr[0].ToString());
                }

                //return query results
                return InvoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrives a list of options for date filter
        /// </summary>
        /// <returns></returns>
        public List<string> filterDateOptions()
        {
            try
            {
                //Create DataSet to hold query data
                List<string> InvoiceDate = new List<string>();
                int iRet = 0;

                DataSet ds = ExecuteSQLStatement(ClsQuery.getDateOptions(), ref iRet);

                //Get query results
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    InvoiceDate.Add(dr[0].ToString());
                }

                //return query results
                return InvoiceDate;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a list of Total Filters
        /// </summary>
        /// <returns></returns>
        public List<string> filterTotalOptions()
        {
            try
            {
                //Create DataSet to hold query data
                List<string> InvoiceTotal = new List<string>();
                int iRet = 0;

                DataSet ds = ExecuteSQLStatement(ClsQuery.getTotalOptions(), ref iRet);

                //Get query results
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    InvoiceTotal.Add(dr[0].ToString());
                }

                //return query results
                return InvoiceTotal;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// SQL Executer with return values
        /// </summary>
        /// <param name="sSQL"></param>
        /// <param name="iRetVal"></param>
        /// <returns></returns>
        private DataSet ExecuteSQLStatement(string sSQL, ref int iRetVal)
        {
            try
            {
                DataSet ds = new DataSet();

                using (OleDbConnection conn = new OleDbConnection(ClsQuery.getConnString()))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        //Open Connection
                        conn.Open();

                        adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        //Fill dataset
                        adapter.Fill(ds);
                    }
                }

                iRetVal = ds.Tables[0].Rows.Count;

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// SQL executer with no expected return values
        /// </summary>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        private int ExecuteNonQuery(string sSQL)
        {
            try
            {
                int iNumRows;

                using (OleDbConnection conn = new OleDbConnection(ClsQuery.getConnString()))
                {
                    conn.Open();

                    OleDbCommand cmd = new OleDbCommand(sSQL, conn);
                    cmd.CommandTimeout = 0;

                    iNumRows = cmd.ExecuteNonQuery();
                }

                return iNumRows;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
