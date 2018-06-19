using System;

using ivy.Models;
using ivy.ViewModels;

using Xamarin.Forms;

namespace ivy.Views
{
    public partial class ItemsDominioPage : ContentPage
    {
        ItemsDominioViewModel viewModel;

        public ItemsDominioPage()
        {
            //InitializeComponent();

            BindingContext = viewModel = new ItemsDominioViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsDominioListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
