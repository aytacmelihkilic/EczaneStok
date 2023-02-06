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

namespace EczaneStokKontrol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int i = 0;
        SqlConnection baglan = new SqlConnection("data source=ITOCH\\ITOCH;Initial Catalog=EczaneStok;Integrated Security=true");
        private void veriyigoster()
        {

            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from ilac ", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                // ekle.Text = oku[1].ToString();

                ListViewItem item = new ListViewItem(oku[0].ToString());
                item.SubItems.Add(oku[1].ToString());
                item.SubItems.Add(oku[2].ToString());
                item.SubItems.Add(oku[3].ToString());
                item.SubItems.Add(oku[4].ToString());
                listView1.Items.Add  (item);
              

            }
            baglan.Close();
            }
        
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            veriyigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into ilac values ('"+t1.Text.ToString()+"','"+t2.Text.ToString()+"','"+t3.Text.ToString()+ "','" + t4.Text.ToString() + "','" + t5.Text.ToString() + "')",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            t1.Clear();
            t2.Clear();
            t3.Clear();
            t4.Clear();
            t5.Clear();


        }
        int idler = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from ilac where id=("+idler+") ",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            veriyigoster();

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            idler = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
     
            t1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            t2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            t3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            t4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            t5.Text = listView1.SelectedItems[0].SubItems[4].Text;
            veriyigoster();
        }
    }
}
