using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace incicavusvize
{
    public partial class frmGuncelle : Form
    {
        public frmGuncelle()
        {
            InitializeComponent();
            
        }

        

        SqlConnection con = new SqlConnection(@"server=WIN7-BILGISAYAR\SQLEXPRESS; database=northwnd; integrated security=true");

        private void frmGuncelle_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Products where ProductID=@id", con);
            adp.SelectCommand.Parameters.AddWithValue("@id", Form1.UrunID);

            DataTable dt = new DataTable();
            adp.Fill(dt);

            txtName.Text = dt.Rows[0]["productName"].ToString();
            txtPrice.Text = dt.Rows[0]["UnitPrice"].ToString();
            txtQuantity.Text = dt.Rows[0]["QuantityPerUnit"].ToString();
            txtStock.Text = dt.Rows[0]["UnitsInStock"].ToString();
        }

        private void btnSakla_Click(object sender, EventArgs e)
        {
            SqlCommand update = new SqlCommand("update Products set ProductName=@name, UnitPrice=@price, QuantityPerUnit=@quantity, UnitsInStock=@stok where ProductID=@id", con);

            update.Parameters.AddWithValue("@name", txtName.Text);
            update.Parameters.Add(new SqlParameter { SqlDbType = SqlDbType.Money, Value = txtPrice.Text, ParameterName = "@price" });
            update.Parameters.AddWithValue("@id", Form1.UrunID);
            update.Parameters.AddWithValue("@quantity", txtQuantity.Text);
            update.Parameters.AddWithValue("@stok", txtStock.Text);

            con.Open();
            update.ExecuteNonQuery();
            con.Close();
        }
        
       

       
    }
}
