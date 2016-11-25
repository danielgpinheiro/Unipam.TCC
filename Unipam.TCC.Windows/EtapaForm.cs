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
    public partial class EtapaForm : Form
    {
        private ITipoEntregaBLL tipoEntregaBLL;
        private IEtapaBLL etapaBLL;
        private Etapa etapa;

        public EtapaForm()
        {
            this.tipoEntregaBLL = new TipoEntregaBLL();
            this.etapaBLL = new EtapaBLL();
            InitializeComponent();
        }

        private void EtapaForm_Load(object sender, EventArgs e)
        {
            cb_tipoentrega.DataSource = tipoEntregaBLL.Todos();
            cb_tipoentrega.DisplayMember = "Descricao";//A descricao do tipo de entrega será apresentado ao usuário
            cb_tipoentrega.ValueMember = "IdTipoEntrega";

            tabela.EditMode = DataGridViewEditMode.EditProgrammatically;
            tabela.ColumnCount = 5;
            tabela.MultiSelect = false;
            tabela.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            tabela.Columns[0].HeaderText = "Código";
            tabela.Columns[0].DataPropertyName = "IdEtapa";//Deve ser igual a consulta
            tabela.Columns[0].Width = 100;

            tabela.Columns[1].HeaderText = "Tipo de entrega";
            tabela.Columns[1].DataPropertyName = "TipoEntrega";//Deve ser igual a consulta
            tabela.Columns[1].Width = 100;

            tabela.Columns[2].HeaderText = "Data de Início";
            tabela.Columns[2].DataPropertyName = "DataInicio";//Deve ser igual a consulta
            tabela.Columns[2].Width = 100;

            tabela.Columns[3].HeaderText = "Data de Final";
            tabela.Columns[3].DataPropertyName = "DataFim";//Deve ser igual a consulta
            tabela.Columns[3].Width = 100;

            tabela.Columns[4].HeaderText = "Nota Miníma";
            tabela.Columns[4].DataPropertyName = "NotaMinima";//Deve ser igual a consulta
            tabela.Columns[4].Width = 100;

            CarregarTabela();
        }

        public void CarregarTabela()
        {
            this.EtapaBLL = new EtapaBLL();

            tabela.DataSource = EtapaBLL.Todas().Select(x => 
                    new { x.IdEtapa,
                        TipoEntrega = x.TipoEntrega.Descricao,
                        x.DataInicio,
                        x.DataFim,
                        x.NotaMinima
                    }).ToList();

            this.EtapaBLL.Dispose();

        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            this.EtapaBLL = new EtapaBLL();


            //Alterar e cadastrar
            etapa = new Etapa();

            if(txt_codigo.Text != "")
            {
                etapa.IdEtapa = int.Parse(txt_codigo.Text);
            }

            //Para calendario: value
            etapa.DataInicio = dt_datainicio.Value;
            etapa.DataFim = dt_datafinal.Value;

            //SelectValue para caixa de seleção
            etapa.IdTipoEntrega = (int) cb_tipoentrega.SelectedValue;

            //Text para caixa de texto
            //Se o tipo for object (int)
            //Se for text int.Parse(texto)
            try
            {
                etapa.NotaMinima = decimal.Parse(txt_notaminima.Text);
            }catch(Exception ex)
            {
                MessageBox.Show("Nota miníma deve ser um decimal");
                return;
            }


            var erro = EtapaBLL.Salvar(etapa);

            if(erro != null)
            {
                MessageBox.Show("Erro ao salvar: "+erro);
            }
            else
            {
                MessageBox.Show("Salvo com sucesso.");

                CarregarTabela();

                //Limpa os campos
                txt_notaminima.Clear();
                dt_datainicio.ResetText();
                dt_datafinal.ResetText();
                cb_tipoentrega.SelectedIndex = 0;
            }

            this.UsuarioBLL.Dispose();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {

            if(tabela.SelectedRows.Count > 0)
            {

                int idEtapa = (int) tabela.CurrentRow.Cells[0].Value;

                this.UsuarioBLL = new EtapaBLL();

                var erro = this.UsuarioBLL.Excluir(idEtapa);

                if(erro != null)
                {
                    MessageBox.Show("Erro ao excluir: " + erro);
                }
                else
                {
                    MessageBox.Show("Excluído com sucesso!" );
                    CarregarTabela();
                }

                this.UsuarioBLL.Dispose();

            }

        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            this.UsuarioBLL = new EtapaBLL();

            int idEtapa = (int) tabela.CurrentRow.Cells[0].Value;

            Etapa etapa = EtapaBLL.ObterPorId(idEtapa);

            dt_datafinal.Value = etapa.DataFim;
            dt_datainicio.Value = etapa.DataInicio;
            cb_tipoentrega.SelectedValue = etapa.IdTipoEntrega;
            txt_notaminima.Text = etapa.NotaMinima.ToString();
            txt_codigo.Text = etapa.IdEtapa.ToString();

            this.UsuarioBLL.Dispose();

        }
    }
}
