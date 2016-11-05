using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unipam.TCC.BLL.ImplementationBLL;
using Unipam.TCC.BLL.InterfacesBLL;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.Windows
{
    public partial class AlunoForm : Form
    {
        private readonly ICursoBLL CursoBLL;
        private readonly IPessoaBLL PessoaBLL;
        private readonly IAlunoBLL AlunoBLL;
        private Aluno Aluno;

        public AlunoForm()
        {
            this.CursoBLL = new CursoBLL();
            this.PessoaBLL = new PessoaBLL();
            this.AlunoBLL = new AlunoBLL();
            InitializeComponent();
        }

        private void comboBoxCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private bool salvarPessoa(string nome)
        {
            if (nome != null && nome.Trim() != "")
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Nome = nome;
                var error = this.PessoaBLL.Salvar(pessoa);
                if (error == null)
                {
                    MessageBox.Show("Pessoa salvar com sucesso!");
                    this.Aluno.IdPessoa = ((PessoaBLL)this.PessoaBLL).ObterPorNome(textBoxAluno.Text).IdPessoa;
                    return true;
                } else
                {
                    MessageBox.Show("Nao foi possivel salvar a pessoa entao ela morreu!" + error);
                }
            }
            return false;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (this.Aluno == null)
            {
                this.Aluno = new Aluno();
            }
            
            bool foiSalvo = salvarPessoa(textBoxAluno.Text);

            if (foiSalvo)
            {

                this.Aluno.IdCurso = (int)comboBoxCurso.SelectedValue;

                var error = AlunoBLL.Salvar(Aluno);
                if (error == null)
                {
                    MessageBox.Show("Salvo com sucesso");
                }
                else
                {
                    MessageBox.Show("Erro ao salvar: " + error);
                }
            }
        }

        private void AlunoForm_Load(object sender, EventArgs e)
        {
            comboBoxCurso.DataSource = this.CursoBLL.Todas();
            comboBoxCurso.DisplayMember = "NomeCurso";
            comboBoxCurso.ValueMember = "IdCurso";
        }
    }
}
