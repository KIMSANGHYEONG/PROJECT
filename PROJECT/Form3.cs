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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            Text = "선수 관리";

            dataGridView1.DataSource = DataManager.Players;
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;

            button1.Click += (sender, e) =>
            {
                try
                {
                    if (DataManager.Players.Exists(x => x.Name == textBox1.Text))
                    {
                        MessageBox.Show("이미 존재하는 선수입니다.");
                    }
                    else
                    {


                        Player player = new Player()
                        {
                            Name = textBox1.Text,
                            Position = textBox2.Text,
                            OTeam = textBox3.Text,
                            Game = int.Parse(textBox4.Text),
                            Goal = int.Parse(textBox5.Text),
                            Assist = int.Parse(textBox6.Text),
                            Value = int.Parse(textBox7.Text)
                        };
                        DataManager.Players.Add(player);
                    }

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Players;
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
                    Player player = DataManager.Players.Single(x => x.Name == textBox1.Text);
                    player.Position = textBox2.Text;
                    player.OTeam = textBox3.Text;
                    player.Game = int.Parse(textBox4.Text);
                    player.Goal = int.Parse(textBox5.Text);
                    player.Assist = int.Parse(textBox6.Text);
                    player.Value = int.Parse(textBox7.Text);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Players;
                    DataManager.Save();
                }
                catch (Exception ex)
                {

                }
            };
            button3.Click += (sender, e) =>
            {

                try
                {
                    Player player = DataManager.Players.Single(x => x.Name == textBox1.Text);
                    DataManager.Players.Remove(player);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Players;
                    DataManager.Save();

                }
                catch (Exception ex)
                {

                }

            };
        }

        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Player player = dataGridView1.CurrentRow.DataBoundItem as Player;
                textBox1.Text = player.Name;
                textBox2.Text = player.Position;
                textBox3.Text = player.OTeam;
                textBox4.Text = player.Game.ToString();
                textBox5.Text = player.Goal.ToString();
                textBox6.Text = player.Assist.ToString();
                textBox7.Text = player.Value.ToString();


            }
            catch (Exception ex)
            {

            }
        }
    }
}
