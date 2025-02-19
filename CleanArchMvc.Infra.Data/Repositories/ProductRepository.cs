using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {

        ApplicationDbContext _productContext;

        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            //return await _productContext.Products.FindAsync(id);
            return await _productContext.Products.Include(c => c.Category)
               .SingleOrDefaultAsync(p => p.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        //public async Task<Product> GetProductCategoryAsync(int? id)
        //{
        //    //eager loading
        //    #pragma warning disable CS8603 // Possible null reference return.
        //    return await _productContext.Products.Include(c => c.Category)
        //        .SingleOrDefaultAsync(p => p.Id == id);
        //    #pragma warning disable CS8603 // Possible null reference return.

        //    //return await _productContext.Products.Include(c => c.Category)
        //    //   .SingleOrDefaultAsync(p => p.Category.Id == id);
        //}

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
