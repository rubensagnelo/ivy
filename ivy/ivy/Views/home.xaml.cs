using ivy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Forms.Button;
using static Xamarin.Forms.Button.ButtonContentLayout;

namespace ivy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class home : ContentPage
    {


        public home()
        {
            InitializeComponent();

            Title = "Menu";
            BackgroundColor = Color.FromHex(ivy.Config.config.corpadrao);

            var plainButton = new Style(typeof(Button))
            {
                Setters = {
                  new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#ddd") },
                  new Setter { Property = Button.TextColorProperty, Value = Color.Black },
                  new Setter { Property = Button.BorderRadiusProperty, Value = 0 },
                  new Setter { Property = Button.FontSizeProperty, Value = 40 }
                }
            };

            var controlGrid = new Grid { RowSpacing = 1, ColumnSpacing = 1 };
            controlGrid.BackgroundColor = Color.FromHex(ivy.Config.config.corpadrao);
              

            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            List<itemMenu> menu = MOC_MENU();
            int botoes = menu.Count;
            int BotoesPorLinha = 2;
            int Linhas = botoes / BotoesPorLinha;
            if (menu.Count % BotoesPorLinha > 0)
                Linhas++;

            for (int L = 0; L < Linhas; L++)
            {


                controlGrid.RowDefinitions.Add(
                    new RowDefinition { Height = new GridLength(0.2, GridUnitType.Auto) }
                    );


                for (int C = 0; C < (BotoesPorLinha) ; C++)
                {
                    if (L * BotoesPorLinha + C >= botoes) break;

                    itemMenu itm = menu[L*BotoesPorLinha+C];

                    Action<object> execMenu;
                    execMenu = onexecmenu;



                    Button ctrl = new Button()
                    {

                        FontSize = 18,
                        FontAttributes = FontAttributes.Bold,
                        //Opacity =0,
                        ContentLayout = new ButtonContentLayout(ImagePosition.Top, 1),
                        Text = itm.texto,
                        TextColor = Color.FromHex(ivy.Config.config.corpadrao),
                        Style = plainButton,
                        Image = (FileImageSource)(ImageSource.FromFile(itm.imagem)),
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        BorderWidth = 5,
                        BorderRadius = 5,
                        BorderColor = Color.White,
                        InputTransparent = true,
                        BackgroundColor = Color.White,
                        Command = new Command(execMenu),
                        CommandParameter = itm
                    };

                    
                    /*
                    Button ctrl = new Button()
                    {
                        
                        FontSize = 24,
                        //Opacity =0,
                        ContentLayout = new ButtonContentLayout(ImagePosition.Top, 1),
                        Text = new StringBuilder("").Append(L.ToString()).Append(",").Append(C.ToString()).ToString(),
                        Style = plainButton,
                        Image = (FileImageSource)(ImageSource.FromFile("ic_dominio.png")),
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        BorderWidth = 5,
                        BorderRadius = 5,
                        BorderColor= Color.White,
                        InputTransparent = true,
                        BackgroundColor = Color.White,
                        Command = new Command(param)
                    };
                    */


                    controlGrid.Children.Add(ctrl, C, L);
                }
            }




            stkmenu.Children.Add(controlGrid);

            ScrollView Scroll = new ScrollView
            {
                Orientation = ScrollOrientation.Vertical
            };

            Scroll.Content = stkmenu;

        }

        private void onexecmenu(object obj)
        {
            if (obj == null)
                return;

            itemMenu itm = ((itemMenu)obj);

            if (itm.id == "1") {
                direcionador.TelaDominiosLista(Navigation);
            }



            //ItemsDominioPage

            string x = obj.GetType().ToString();
        }

        private List<itemMenu> MOC_MENU()
        {
            List<itemMenu> result = new List<itemMenu>();
            result.Add(new itemMenu()
            {
                id = "1",
                idPai = string.Empty,
                texto = "Domínio",
                filhos = null,
                imagem = "ic_dominio",
                visivel = true,
                habilitado = true
            });


            result.Add(new itemMenu()
            {
                id = "2",
                idPai = string.Empty,
                texto = "Setor",
                filhos = null,
                imagem = "ic_setor",
                visivel = true,
                habilitado = true
            });

            result.Add(new itemMenu()
            {
                id = "3",
                idPai = string.Empty,
                texto = "Responsável",
                filhos = null,
                imagem = "ic_responsavel",
                visivel = true,
                habilitado = true
            });

            result.Add(new itemMenu()
            {
                id = "4",
                idPai = string.Empty,
                texto = "Item",
                filhos = null,
                imagem = "ic_item",
                visivel = true,
                habilitado = true
            });


            return result;
        }


    }
}