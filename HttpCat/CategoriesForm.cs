﻿using System;
using System.Windows.Forms;
using MyProgram.Provider;

namespace HttpCat
{
    public partial class CategoriesForm : Form
    {
        public CategoriesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm main = new MainForm();
            main.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var SelectedItem = listView1.SelectedItems[0].SubItems[0].Text;

                if (SelectedItem != "")
                {
                    var modal = new SearchCategoryModal
                    {
                        categoryId = SelectedItem
                    };

                    var collector = new ApiHelper();
                    var data = collector.GetCategory(modal);

                    pictureBox1.ImageLocation = data[0].url;
                }
                
            }else MessageBox.Show("Select category in the list!");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var item = listView1.SelectedItems[0];
                textBox1.Text = item.SubItems[1].Text;
            }

        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            var listViewItem = ApiHelper.GetCategories();
            foreach (var c in listViewItem)
            {
                var item = new ListViewItem(new[] { c.id, c.name });
                item.Tag = c;
                listView1.Items.Add(item);
            }
        }


    }
}
