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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        public static string UrunID;

        

        SqlConnection con = new SqlConnection(@"server=WIN7-BILGISAYAR\SQLEXPRESS; database=northwnd; integrated security=true");

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
           
            SqlDataAdapter adp = new SqlDataAdapter("select * from Categories", con);

            
            adp.Fill(dtKategori);

            cbKategoriler.DisplayMember = "CategoryName";
            cbKategoriler.ValueMember = "CategoryID";
            cbKategoriler.DataSource = dtKategori;

        }
        DataTable dtKategori = new DataTable();
        DataTable dtUrun = new DataTable();
        private void cbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            SqlDataAdapter adp = new SqlDataAdapter(string.Format("select * from Products where CategoryID={0}", cbKategoriler.SelectedValue.ToString()), con);
            dtUrun = new DataTable();
           
            adp.Fill(dtUrun);

            gvUrunler.DataSource = dtUrun;

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            frmGuncelle frm = new frmGuncelle();
            frm.ShowDialog();

            
          

        }
       string  id;
       private void gvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
       {
           id = dtUrun.Rows[e.RowIndex]["ProductID"].ToString();

           UrunID = id;
          
       }

       private void Form1_Activated(object sender, EventArgs e)
       {
           cbKategoriler_SelectedIndexChanged(sender, e);
       }
       

       

        

       
    }
}
