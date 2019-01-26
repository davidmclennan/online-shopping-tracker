using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineShoppingTracker.Models;
using SQLite;

namespace OnlineShoppingTracker.Data
{
    public class ProductDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ProductDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Product>().Wait();
        }

        public Task<Product> GetProductAsync(int id)
        {
            return database.Table<Product>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return database.Table<Product>().ToListAsync();
        }

        public Task<List<Product>> GetProductsWishListAsync()
        {
            return database.QueryAsync<Product>("SELECT * FROM [Product] WHERE [Stage] = Wish List");
        }

        public Task<List<Product>> GetProductsPurchasesAsync()
        {
            return database.QueryAsync<Product>("SELECT * FROM [Product] WHERE [Stage] = Purchases");
        }

        public Task<List<Product>> GetProductsReturnsAsync()
        {
            return database.QueryAsync<Product>("SELECT * FROM [Product] WHERE [Stage] = Returns");
        }

        public Task<int> SaveProductAsync(Product product)
        {
            if (product.ID != 0)
            {
                return database.UpdateAsync(product);
            }
            else
            {
                return database.InsertAsync(product);
            }
        }

        public Task<int> DeleteProductAsync(Product product)
        {
            return database.DeleteAsync(product);
        }
    }
}
