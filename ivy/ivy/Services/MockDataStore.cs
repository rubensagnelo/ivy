using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ivy.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(ivy.Services.MockDataStore))]
namespace ivy.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        bool isInitialized;
        List<Item> items;

        public async Task<bool> AddItemAsync(Item item)
        {
            await InitializeAsync();

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            items = new List<Item>();
            var _items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Funid="1", Text = "Domínio", Description="Empresa ou filial detentora dos itens."},
                new Item { Id = Guid.NewGuid().ToString(), Funid="2", Text = "Setor", Description="Setor responsável pelo item."},
                new Item { Id = Guid.NewGuid().ToString(), Funid="3", Text = "Responsável", Description="Pessoa responsável pelo item"},
                new Item { Id = Guid.NewGuid().ToString(), Funid="4", Text = "Item", Description="Produto/equipamento regirado."},
                new Item { Id = Guid.NewGuid().ToString(), Funid="5", Text = "Evento", Description="Evento associado ao produto"},
                new Item { Id = Guid.NewGuid().ToString(), Funid="6", Text = "Emprestimo", Description="Evento associado ao produto"},
            };

            foreach (Item item in _items)
            {
                items.Add(item);
            }

            isInitialized = true;
        }
    }
}
