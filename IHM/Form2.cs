using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IHM
{
    public partial class Form2 : Form
    {
        private int CustomerID = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            
            if (txtCustomerName.Text != "")
            {


                using (SqlConnection myConnection = new SqlConnection(Utility.GetConnectionString()))
                {
                    try
                    {
                        using (SqlCommand myCommand = new SqlCommand("uspNewCustomer", myConnection))
                        {
                            myCommand.CommandType = CommandType.StoredProcedure;

                            SqlParameter p = new SqlParameter("@customerName", System.Data.SqlDbType.VarChar, 40);
                            p.Value = txtCustomerName.Text;
                            myCommand.Parameters.Add(p);

                            myCommand.Parameters.Add(new SqlParameter("@CustomerID", System.Data.SqlDbType.Int));
                            myCommand.Parameters["@CustomerID"].Direction = ParameterDirection.Output;
                           

                            myConnection.Open();
                            myCommand.ExecuteNonQuery();
                            this.CustomerID = (int)myCommand.Parameters["@CustomerID"].Value;

                            this.txtCustomerID.Text = Convert.ToString(CustomerID);
                            
                            myConnection.Close();
                        }
                    }
                    catch (Exception exception)
                    {
                        lblEtat.ForeColor = System.Drawing.Color.Red;
                        lblEtat.Text = exception.Message;
                    }

                    lblEtat.ForeColor = System.Drawing.Color.Green;
                    lblEtat.Text = "Ajout de " + txtCustomerName.Text + " Réussi.";

                }
            }
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnAddAnotherAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (numOrderAmount.Value != 0)
            {
                using (SqlConnection myConnection = new SqlConnection(Utility.GetConnectionString()))
                {
                    try
                    {
                        using (SqlCommand myCommand = new SqlCommand("uspPlaceNewOrder", myConnection))
                        {
                            myCommand.CommandType = CommandType.StoredProcedure;

                            // @Amount int, @OrderDate date
                            SqlParameter id = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int);
                            id.Value = this.CustomerID;
                            myCommand.Parameters.Add(id);

                            SqlParameter amount = new SqlParameter("@Amount", System.Data.SqlDbType.Int);
                            amount.Value = numOrderAmount.Value;
                            myCommand.Parameters.Add(amount);

                            SqlParameter date = new SqlParameter("@OrderDate", System.Data.SqlDbType.Date);
                            date.Value = dtpOrderDate.Value;
                            myCommand.Parameters.Add(date);



                            myConnection.Open();
                            myCommand.ExecuteNonQuery();

                            myConnection.Close();
                        }
                    }
                    catch (Exception exception)
                    {
                        lbletatCreer.ForeColor = System.Drawing.Color.Red;
                        lbletatCreer.Text = exception.Message;
                    }

                    lbletatCreer.ForeColor = System.Drawing.Color.Green;
                    lbletatCreer.Text = " Création de la commande Réussi.";
                }
            }
        }

        private void btnAddFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
