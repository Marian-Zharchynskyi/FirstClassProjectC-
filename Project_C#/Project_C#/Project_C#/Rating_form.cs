using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_C_
{
    public partial class Rating_form : Form
    {
        public Rating_form()
        {
            InitializeComponent();
            //this.base_form = base_form;
        }
        private void btn_apply_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("You haven't already written some info ");
            }
            else
            {
                Player player = new Player(textBox1.Text);

                this.Close();
            }
        }
    }
}
