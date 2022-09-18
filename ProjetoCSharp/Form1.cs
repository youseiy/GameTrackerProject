using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mostrarDados();
        }
        private void mostrarDados()
        {
            MySqlConnection conn = new MySqlConnection("Server=localhost;Database=gamestracker;User=root;Passworld=");
            conn.Open();
            string query = "SELECT * FROM jogos";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            listarJogosDG.DataSource = dt;
            conn.Close();
        }
        private void limparDados()
        {
            nomeJogotxt.Text = "";
            notatxt.Text = "";
            horastxt.Text = "";
            completoCheckbox.Checked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(852, 480);
            this.MaximumSize = new Size(852, 480);
            limparDados();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            if (nomeJogotxt.Text != "" && notatxt.Text != "" && horastxt.Text != "")
            {
                 
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=gamestracker;User=root;Passworld=");
                conn.Open();
                string query = "INSERT INTO `jogos` (`Nome`, `Nota`, `Horas`, `Completo?`) VALUES ('" + nomeJogotxt.Text + "', '" + notatxt.Text + "','" + horastxt.Text + "','" + completoCheckbox.Checked.GetHashCode() + "')";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int val = cmd.ExecuteNonQuery();
                if (val == 1)
                    MessageBox.Show("Jogo inserido com sucesso");
                else
                    MessageBox.Show("Jogo não inserido com sucesso");
                conn.Close();
            }
            else
                MessageBox.Show("Introduza todos os dados!");
            mostrarDados();
            limparDados();
        }
    }
}
