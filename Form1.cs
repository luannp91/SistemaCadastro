using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class Form1 : Form
    {
        List<Pessoa> pessoas;

        public Form1()
        {
            InitializeComponent();

            pessoas = new List<Pessoa>();

            comboEC.Items.Add("Solteiro");
            comboEC.Items.Add("Casado");
            comboEC.Items.Add("Separado");
            comboEC.Items.Add("Divorciado");
            comboEC.Items.Add("Viúvo");

            comboEC.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int index = -1;

            foreach (Pessoa pessoa in pessoas)
            {
                if (pessoa.Nome == txtName.Text)
                {
                    index = pessoas.IndexOf(pessoa);
                }
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Preencha o campo Nome!!!");
                txtName.Focus();
                return;
            }

            if (txtPhone.Text == "(  )      -")
            {
                MessageBox.Show("Preencha o campo Telefone!!!");
                txtPhone.Focus();
                return;
            }

            char sexo;

            if (radioM.Checked)
            {
                sexo = 'M';
            }
            else if (radioF.Checked)
            {
                sexo = 'F';
            }
            else
            {
                sexo = 'O';
            }

            Pessoa p = new Pessoa();
            p.Nome = txtName.Text;
            p.DataNascimento = txtData.Text;
            p.EstadoCivil = comboEC.SelectedItem.ToString();
            p.Telefone = txtPhone.Text;
            p.CasaPropria = checkHouse.Checked;
            p.Veiculo = checkCar.Checked;
            p.Sexo = sexo;

            if (index < 0)
            {
                pessoas.Add(p);
            }
            else
            {
                pessoas[index] = p;
            }

            btnLimpar_Click(btnLimpar, EventArgs.Empty);

            Listar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int index = lista.SelectedIndex;
            pessoas.RemoveAt(index);
            Listar();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtData.Text = "";
            comboEC.SelectedIndex = 0;
            txtPhone.Text = "";
            checkHouse.Checked = false;
            checkCar.Checked = false;
            radioF.Checked = true;
            radioM.Checked = false;
            radioO.Checked = false;
            txtName.Focus();
        }

        private void Listar()
        {
            lista.Items.Clear();

            foreach (Pessoa pessoa in pessoas)
            {
                lista.Items.Add(pessoa.Nome);
            }
        }

        private void lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lista.SelectedIndex;
            Pessoa pessoa = pessoas[index];
            txtName.Text = pessoa.Nome;
            txtData.Text = pessoa.DataNascimento;
            comboEC.SelectedItem = pessoa.EstadoCivil;
            txtPhone.Text = pessoa.Telefone;
            checkHouse.Checked = pessoa.CasaPropria;
            checkCar.Checked = pessoa.Veiculo;

            switch (pessoa.Sexo)
            {
                case 'M':
                    radioM.Checked = true;
                    break;
                case 'F':
                    radioF.Checked = true;
                    break;
                default:
                    radioO.Checked = true;
                    break;
            }
        }
    }
}
