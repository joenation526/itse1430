/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Nile.Stores
{
    /// <summary>Provides an implementation of <see cref="IProductDatabase"> using SQL server</summary>
    public class SqlProductDatabase : ProductDatabase
    {
        public SqlProductDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }

        protected override Product AddCore ( Product product )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("AddProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                var result = cmd.ExecuteScalar();

                var id = Convert.ToInt32(result);
                product.Id = id;

                return product;
            };
        }

        protected override Product FindByName ( string products )
        {
            throw new NotImplementedException();
        }

        protected override Product FindProduct ( int id )
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Product> GetAllCore ()
        {
            using (var conn = OpenConnection())
            {
                
            };

            //return _products;
        }

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn; 
        }

        protected override Product GetCore ( int id )
        {
            throw new NotImplementedException();
        }

        protected override void RemoveCore ( int id )
        {
            throw new NotImplementedException();
        }

        protected override Product UpdateCore ( Product existing, Product newItem )
        {
            throw new NotImplementedException();
        }

        private readonly string _connectionString;
    }
}
