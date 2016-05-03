using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IHM
{
    public partial class Form3 : Form
    {
        int parsedOrderID;
        public Form3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnFindByOrderID_Click(object sender, EventArgs e)
        {
            if (isOrderID())
            {
                using (SqlConnection myConnection = new SqlConnection(Utility.GetConnectionString()))
                {
                    try
                    {

                        String myQuery = "Select * from Orders where OrderID = @OrderID";

                        using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                        {
                            SqlParameter p = new SqlParameter("@OrderID", System.Data.SqlDbType.Int);
                            p.Value = parsedOrderID;
                            myCommand.Parameters.Add(p);

                            myConnection.Open();
                            SqlDataReader myReader = myCommand.ExecuteReader();

                            DataTable dt = new DataTable();
                            dt.Load(myReader);
                            dtgCustomerOrders.DataSource = dt;

                            myConnection.Close();

                            lblResult.ForeColor = System.Drawing.Color.Green;
                            lblResult.Text = "Bilan de la commande "+parsedOrderID;
                        }

                    }
                    catch (Exception exception)
                    {
                        lblResult.ForeColor = System.Drawing.Color.Red;
                        lblResult.Text = exception.Message;
                    }
                }
            }
        }
        private void btnFillOrder_Click(object sender, EventArgs e)
        {
            if (isOrderID())
            {
                using (SqlConnection myConnection = new SqlConnection(Utility.GetConnectionString()))
                {
                    try
                    {
                        using (SqlCommand myCommand = new SqlCommand("uspFillOrder", myConnection))
                        {
                            myCommand.CommandType = CommandType.StoredProcedure;

                            // @Amount int, @OrderDate 
                            SqlParameter id = new SqlParameter("@OrderID", System.Data.SqlDbType.Int);
                            id.Value = parsedOrderID;
                            myCommand.Parameters.Add(id);

                            SqlParameter date = new SqlParameter("@FilledDate", System.Data.SqlDbType.Date);
                            date.Value = dtpFillDate.Value;
                            myCommand.Parameters.Add(date);

                            myConnection.Open();
                            myCommand.ExecuteNonQuery();

                            myConnection.Close();
                        }
                    }
                    catch (Exception exception)
                    {
                        lblResult.ForeColor = System.Drawing.Color.Red;
                        lblResult.Text = exception.Message;
                    }

                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = " Validation de la commande Réussi.";
                }
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (isOrderID())
            {
                using (SqlConnection myConnection = new SqlConnection(Utility.GetConnectionString()))
                {
                    try
                    {
                        using (SqlCommand myCommand = new SqlCommand("uspCancelOrder", myConnection))
                        {
                            myCommand.CommandType = CommandType.StoredProcedure;

                            // @Amount int, @OrderDate date
                            SqlParameter id = new SqlParameter("@OrderID", System.Data.SqlDbType.Int);
                            id.Value = parsedOrderID;
                            myCommand.Parameters.Add(id);

                            myConnection.Open();
                            myCommand.ExecuteNonQuery();

                            myConnection.Close();
                        }
                    }
                    catch (Exception exception)
                    {
                        lblResult.ForeColor = System.Drawing.Color.Red;
                        lblResult.Text = exception.Message;
                    }

                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = " Annulation de la commande Réussi.";
                }
            }
        }


        private bool isOrderID()
        {
            if(txtOrderID.Text == "")
            {
                MessageBox.Show("Veuillez spécifier le numéro de commande");
                return false;
            }
            else if (Regex.IsMatch(txtOrderID.Text, @"^\D+$"))
            {
                MessageBox.Show("Un numéro de commande est composé que de chiffre");
                txtOrderID.Clear();
                return false;
            }
            else
            {
                parsedOrderID = Int32.Parse(txtOrderID.Text);
                return true;
            }
        }

        private void dtgCustomerOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFinishUpdates_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
