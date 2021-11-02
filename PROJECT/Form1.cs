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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "Transfer Market";

            label7.Text = DataManager.Players.Count.ToString();
            label8.Text = DataManager.Players.Where((x) => x.IsDealt).Count().ToString();
            label9.Text = DataManager.Teams.Count.ToString();

            dataGridView1.DataSource = DataManager.Players;
            dataGridView2.DataSource = DataManager.Teams;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {

            }
            else if (textBox2.Text.Trim() == "")
            {

            }
            else
            {
                try
                {
                    Player player = DataManager.Players.Single(x => x.Name == textBox1.Text);
                    if (player.IsDealt)
                    {
                        MessageBox.Show("이미 거래된 선수입니다.");
                    }
                    else
                    {
                        Team team = DataManager.Teams.Single(x => x.Id.ToString() == textBox2.Text);
                        player.NTeam = team.Name;
                        player.IsDealt = true;
                        player.Deal = int.Parse(textBox3.Text);

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = DataManager.Players;
                        DataManager.Save();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("존재하지 않는 선수/구단 입니다.");
                }
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Player player = dataGridView1.CurrentRow.DataBoundItem as Player;
                textBox1.Text = player.Name;

            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Team team = dataGridView2.CurrentRow.DataBoundItem as Team;
                textBox2.Text = team.Id.ToString();
            }
            catch (Exception ex)
            {

            }

        }

        private void 구단관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void 선수관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }
    }
}
