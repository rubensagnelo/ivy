using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;


namespace ivy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class loginNovoUsuario : ContentPage
    {
        public loginNovoUsuario()
        {
            InitializeComponent();
        }

        

        private async void Button_Clicked(object sender, EventArgs e)
        {
            estrutura.ivy.usuario.EstruturaUsuarioIncluirEntrada ent = new estrutura.ivy.usuario.EstruturaUsuarioIncluirEntrada();
            ent.email = this.txtemail.Text;
            ent.nome = this.txtNome.Text;
            ent.senha = this.txtSenha.Text;
            ent.senhaConfirmacao = this.txtSenhaConfirmacao.Text;

            estrutura.ivy.usuario.EstruturaUsuarioIncluirRetorno usu = 
                await proxy.proxy.post<estrutura.ivy.usuario.EstruturaUsuarioIncluirRetorno>(ivy.Config.config.Service_usuario_incluir, ent);

            if (usu.IdcErr > 0)
            {
                lblResult.Text = usu.msg;
                await Task.Delay(3000);
                lblResult.Text = string.Empty;
            }
            else
            {
                //NavigationPage.SetTitleIcon.
                //new direcionador().TelaDominio(Navigation);
                lblResult.TextColor = Color.FromHex("2E8B57");
                lblResult.Text = usu.msg;
                await Task.Delay(3000);
                lblResult.Text = string.Empty;
                direcionador.VoltarModal(this.Navigation);
            }





        }

        private void Button_Cancelar_Clicked(object sender, EventArgs e)
        {
            direcionador.VoltarModal(this.Navigation);
        }
    }
}