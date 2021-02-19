using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTakeApp
{
    public partial class Form1 : Form
    {
        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Text", typeof(String));

            dataGridView1.DataSource = table;
            dataGridView1.Columns["Text"].Visible = false;
            dataGridView1.Columns["Title"].Width = 235;

            lblWarning.Visible = false;
            btnWarning1.Visible = false;
            btnWarning2.Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if ( txtboxTitle.TextLength == 0 && txtboxText.TextLength == 0)
            {
                txtboxText.Clear();
                txtboxTitle.Clear();
            }
            else //verifying if the title & text is already saved
            {
                bool verify = false;
                int numOfRows = table.Rows.Count;
                for(int index = 0; index < numOfRows; index++)
                {
                    if (txtboxTitle.Text == table.Rows[index].ItemArray[0].ToString())
                        if (txtboxText.Text == table.Rows[index].ItemArray[1].ToString())
                            verify = true;
                }
                switch (verify)
                {
                    case true:
                        txtboxText.Clear();
                        txtboxTitle.Clear();
                        break;
                    case false:
                        lblWarning.Text = " Warning: your text is not saved. Pressing  okay will delete it forever. ";
                        lblWarning.Visible = true;
                        btnWarning1.Visible = true;
                        break;
                }
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblWarning.Visible = false;
            btnWarning1.Visible = false;
            if (txtboxTitle.TextLength != 0 || txtboxText.TextLength != 0)
            {
                bool verify = false;
                int numOfRows = table.Rows.Count;
                for (int index = 0; index < numOfRows; index++)
                {
                    if (txtboxTitle.Text == table.Rows[index].ItemArray[0].ToString())
                        if (txtboxText.Text == table.Rows[index].ItemArray[1].ToString())
                            verify = true;
                        
                }
                switch (verify)
                {
                    case false:
                        table.Rows.Add(txtboxTitle.Text, txtboxText.Text);
                        txtboxText.Clear();
                        txtboxTitle.Clear();
                        break;
                    case true:
                        lblWarning.Text = "Warning: You cannot save the same thing twice!";
                        lblWarning.Visible = true;
                        btnWarning2.Visible = true;
                        break;

                }
            }
           
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            int numOfRows = table.Rows.Count;
            if( numOfRows >=1 )
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                if (index >= 0)
                {
                    txtboxTitle.Text = table.Rows[index].ItemArray[0].ToString();
                    txtboxText.Text = table.Rows[index].ItemArray[1].ToString();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.RowCount != 0)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                table.Rows[index].Delete();
            }

        }

        private void btnWarning1_Click(object sender, EventArgs e)
        {
            txtboxText.Clear();
            txtboxTitle.Clear();
            lblWarning.Visible = false;
            btnWarning1.Visible = false; 
        }

        private void btnWarning2_Click(object sender, EventArgs e)
        {
            txtboxText.Clear();
            txtboxTitle.Clear();
            lblWarning.Visible = false;
            btnWarning2.Visible = false;
        }
    }
}
