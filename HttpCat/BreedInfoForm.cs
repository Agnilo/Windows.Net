using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyProgram.Provider;

namespace HttpCat
{

    public partial class BreedInfoForm : Form
    {
        public BreedInfoForm(IList<BreedInfoModel> data)
        {
            InitializeComponent();
            if (data.Count > 0)
            {
                txtOfcName.Text = data[0].name;
                txtOrigin.Text = data[0].origin;
                rTxtDesc.Text = data[0].description;
                rTxtTemp.Text = data[0].temperament;
                pictureBox1.ImageLocation = data[0].url;
            }
            else
            {
                MessageBox.Show("Enter valid Breed Id!");
            }

        }
        private void BreedInfoForm_Load(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtOfcName.Text))
            {
                this.Close();
                MainForm main = new MainForm();
                main.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm main = new MainForm();
            main.Show();
        }


    }
}
