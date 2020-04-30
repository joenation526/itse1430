/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Nile.Windows;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            //TODO: Check arguments
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product is null");

            // Validate product
            ObjectValidator.Validate(product);

            try
            {
                //TODO: Do not duplicate products.
                // Probably not the correct way to do this, but I'll fix it later
                var sameProduct = FindProduct(product.Id);
                if (sameProduct != null && sameProduct.Id == product.Id)
                    throw new InvalidOperationException("Products must be unique");

                //Emulate database by storing copy
                return AddCore(product);

            } catch
            { 
                return null;
            };
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            //TODO: Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Cannot retrieve non-existent product");

            return GetCore(id);
        }
        
        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }
        
        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        public void Remove ( int id )
        {
            //TODO: Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Cannot retrieve non-existent product");

            RemoveCore(id);
        }
        
        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( Product product )
        {
            //TODO: Check arguments
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product is null");

            if (product.Id <= 0)
                throw new ArgumentOutOfRangeException(nameof(product.Id), "Id must be greater than zero");


            // Validate product
             ObjectValidator.Validate(product);

            try
            {
                //TODO: Do not duplicate products.
                // Probably not the correct way to do this, but I'll fix it later
                var sameProduct = FindProduct(product.Id);
                if (sameProduct != null && sameProduct.Id == product.Id)
                    throw new InvalidOperationException("Products must be unique");

                //Get existing product
                var existing = GetCore(product.Id);
                if (existing == null)
                    throw new ArgumentNullException(nameof(product), "Product doesn't exist.");

                return UpdateCore(existing, product);

            } catch
            {
                return null;
            };
        }


        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );

        protected abstract Product FindProduct ( int id );

        protected abstract Product FindByName ( string products );

        #endregion
    }
}
