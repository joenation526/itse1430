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
            // Check arguments
            if (product == null)
                return null;

            if (product.Id <= 0)
            {
                DisplayError("Id is invalid");
                return null;
            };

            // Validate product
            var errors = ObjectValidator.Validate(product);
            var error = errors.FirstOrDefault();
            if (errors.Any())
            {
                var errorMessage = error?.ErrorMessage;
                DisplayError(errorMessage);
                return null;
            };

            //Emulate database by storing copy
            return AddCore(product);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            // Check arguments
            if (id <= 0)
            {
                return null;
            }

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
            // Check arguments
            if (id <= 0)
            {
                return;
            }

            RemoveCore(id);
        }
        
        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( Product product )
        {
            // Check arguments
            if (product == null)
            {
                DisplayError("Product is null");
                return null;
            }

            if (product.Id <= 0)
            {
                DisplayError("Id is invalid");
                return null;
            }

            // Validate product
            var errors = ObjectValidator.Validate(product);
            var error = errors.FirstOrDefault();
            if (errors.Any())
            {
                var errorMessage = error?.ErrorMessage;
                DisplayError(errorMessage);
                return null;
            };

            //Get existing product
            var existing = GetCore(product.Id);
            if (existing == null)
            {
                DisplayError("Product is not found");
                return null;
            }

            return UpdateCore(existing, product);
        }

        private void DisplayError ( string errors )
        {
            MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );

        #endregion
    }
}
