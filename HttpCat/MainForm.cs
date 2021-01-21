using System;
using System.Windows.Forms;
using MyProgram.Provider;

namespace HttpCat
{
    public partial class MainForm : Form 
    {
        public MainForm()
        {
            InitializeComponent();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            CategoriesForm categoriesForm = new CategoriesForm();
            categoriesForm.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            var SelectedItem = textBox1.Text;

            if(SelectedItem != "" && SelectedItem.Length == 4)
            {
                this.Visible = false;

                var modal = new SearchBreedModal
                {
                    SelectedId = SelectedItem
                };

                var collector = new ApiHelper();
                var data = collector.GetBreeds(modal);
                new BreedInfoForm(data).Show();

            }
            else
            {
                MessageBox.Show("Please, pick a valid Breed Id!");
                Visible = true;
                return;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var listViewItem = ApiHelper.GetCats();
            foreach (var c in listViewItem)
            {
                var item = new ListViewItem(new[] { c.catId, c.name, c.origin });
                item.Tag = c;
                listView1.Items.Add(item);
            }
        }
    }
}
