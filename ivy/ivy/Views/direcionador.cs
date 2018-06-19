using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ivy.Views;


namespace ivy.Views
{
    public class direcionador
    {
        public static async void  TelaDominio(INavigation Navigation)
        {


            await Navigation.PushAsync(new

                 TabbedPage
            {
                Children =
                             {
                                 new NavigationPage(new ItemsPage())
                                 {
                                     Title = "Browse",
                                     Icon = Device.OnPlatform("tab_feed.png",null,null)
                                 },
                                 new NavigationPage(new AboutPage())
                                 {
                                     Title = "About",
                                     Icon = Device.OnPlatform("tab_about.png",null,null)
                                 },
                             }
            }

                );
        }

        public static async void TelaNovoUsuario(INavigation Navigation)
        {
            await Navigation.PushModalAsync(new loginNovoUsuario());
        }


        public static async void TelaHome(INavigation Navigation)
        {
            await Navigation.PushAsync(new home());
        }

        public static async void TelaDominiosLista(INavigation Navigation)
        {
            await Navigation.PushAsync(new ItemsDominioPage());
        }

        


        public static async void VoltarModal(INavigation Navigation)
        {
            await Navigation.PopModalAsync(true);
        }




    }
}
