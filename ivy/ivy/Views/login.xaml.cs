using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using RAGI;
using ivy.Services;
using estrutura.ivy.usuario;

namespace ivy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            resetpage();
        }


        public async void OnSignUpButtonClicked(object sender, EventArgs e)
        {


        }

        private void resetpage()
        {

            this.email.Text = string.Empty;
            this.Password.Text = string.Empty;
            email.Focus();

        }



        public async void Button_OnClicked(object sender, EventArgs e)
        {


            EstruturaUsuarioLoginEntrada ent = new EstruturaUsuarioLoginEntrada();
            ent.usuario = this.email.Text;
            ent.senha = this.Password.Text;

            EstruturaUsuarioLoginRetorno sai = new EstruturaUsuarioLoginRetorno();

            lblResult.TextColor = Color.FromHex("2E8B57");
            lblResult.Text = "Autenticando ...";

            sai = await svrusuario.login(ent);

            if (sai.IdcErr > 0)
            {
                lblResult.TextColor = Color.FromHex("B22222");
                lblResult.Text = sai.msg;
                await Task.Delay(3000);
                lblResult.Text = string.Empty;
            }
            else
            {
                await Task.Delay(3000);
                lblResult.Text = string.Empty;
                lblResult.TextColor = Color.FromHex("2E8B57");
                lblResult.Text = "Autorizado!";
                await Task.Delay(1000);
                lblResult.Text = string.Empty;
                direcionador.TelaHome(this.Navigation);
            }



            //    await Navigation.PushAsync(new

            //         TabbedPage
            //    {
            //        Children =
            //                     {
            //                         new NavigationPage(new ItemsPage())
            //                         {
            //                             Title = "Browse",
            //                             Icon = Device.OnPlatform("tab_feed.png",null,null)
            //                         },
            //                         new NavigationPage(new AboutPage())
            //                         {
            //                             Title = "About",
            //                             Icon = Device.OnPlatform("tab_about.png",null,null)
            //                         },
            //                     }
            //    }

            //        , true);
        }

        private void ButtonInscrever_OnClicked(object sender, EventArgs e)
        {
            direcionador.TelaNovoUsuario(this.Navigation);
        }
    }
}