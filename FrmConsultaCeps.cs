using EO.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultaCEP
{
    public partial class FrmConsultaCeps : Form
    {
        public FrmConsultaCeps()
        {
            InitializeComponent();
        }

        private void  btnConsultar_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(txtCeps.Text))
            {
                using (var ws = new WSCorreios.AtendeClienteClient())
                try
                {
                    var endereco = ws.consultaCEP(txtCeps.Text.Trim());
                        txtEstado.Text = endereco.uf;
                        txtCidade.Text = endereco.cidade;
                        txtBairro.Text = endereco.bairro;
                        txtRua.Text = endereco.end;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else

            {
                MessageBox.Show("Informe um cep valido", this.Text, MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCeps.Text = string.Empty;    
            txtEstado.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtRua.Text = string.Empty;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
