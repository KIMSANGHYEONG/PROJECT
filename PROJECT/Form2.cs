using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            Text = "구단 관리";

            dataGridView1.DataSource = DataManager.Teams;
            dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;

            button1.Click += (sender, e) =>
            {
                try
                {
                    if (DataManager.Teams.Exists(x => x.Id.ToString() == textBox1.Text))
                    {
                        MessageBox.Show("이미 존재하는 ID입니다.");
                    }
                    else
                    {
                        Team team = new Team()
                        {
                            Id = int.Parse(textBox1.Text),
                            Name = textBox2.Text
                        };
                        DataManager.Teams.Add(team);
                    }

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Teams;
                    DataManager.Save();
                }
                catch (Exception ex)
                {

                }
            };
            button2.Click += (sender, e) =>
            {
                try
                {
                    Team team = DataManager.Teams.Single(x => x.Id.ToString() == textBox1.Text);
                    DataManager.Teams.Remove(team);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Teams;
                    DataManager.Save();

                }
                catch (Exception ex)
                {

                }
            };
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Team team = dataGridView1.CurrentRow.DataBoundItem as Team;
                textBox1.Text = team.Id.ToString();
                textBox2.Text = team.Name;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
