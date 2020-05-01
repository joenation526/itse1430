/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public class MemoryProductDatabase : ProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        protected override Product AddCore ( Product product )
        {
            var newProduct = CloneProduct(product);
            _products.Add(newProduct);

            if (newProduct.Id <= 0)
                newProduct.Id = _nextId++;
            else if (newProduct.Id >= _nextId)
                _nextId = newProduct.Id + 1;

            return CloneProduct(newProduct);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        protected override Product GetCore ( int id )
        {
            var product = FindProduct(id);

            return (product != null) ? CloneProduct(product) : null;
        }

        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        protected override IEnumerable<Product> GetAllCore ()
        {
            foreach (var product in _products)
                yield return CloneProduct(product);
        }

        /// <summary>Removes the product.</summary>
        /// <param name="product">The product to remove.</param>
        protected override void RemoveCore ( int id )
        {
            var product = FindProduct(id);
            if (product != null)
                _products.Remove(product);
        }

        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        protected override void UpdateCore ( int id, Product product )
        {
            //Replace 
            var existing = FindProduct(product.Id);

            CopyProduct(existing, product, false);
        }
        
        private void CopyProduct ( Product target, Product source, bool includeId )
        {
            if (includeId)
                target.Id = source.Id;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Price = source.Price;
            target.IsDiscontinued = source.IsDiscontinued;
        }

        private Product CloneProduct ( Product newProduct )
        {
            var product = new Product();
            CopyProduct(product, newProduct, true);

            return product; 
        }

        //Find a product by ID
        protected override Product FindProduct ( int id )
        {
            foreach (var product in _products)
            {
                if (product.Id == id)
                    return product;
            };

            return null;
        }

        protected override Product FindByName ( string products ) => (from product in _products
                                                                   where String.Compare(product.Name, products, true) == 0
                                                                  select product).FirstOrDefault();

        private List<Product> _products = new List<Product>();
        private int _nextId = 1;
    }
}
