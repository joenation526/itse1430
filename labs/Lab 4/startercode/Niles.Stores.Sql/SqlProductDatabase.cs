/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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

        protected override IEnumerable<Product> GetAllCore ()
        {
            var items = new List<Product>();

            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "GetProduct";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);
            };

            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    var product = new Product() {
                        Id = Convert.ToInt32(row[0]),
                        Name = row["Name"].ToString(),
                        Price = row.Field<decimal>("Price"),
                        Description = row.Field<string>(2),
                        IsDiscontinued = row.Field<bool>("IsDiscontinued")
                    };

                    items.Add(product);
                }
            }

            return items;
        }

     

        protected override void RemoveCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DeleteProduct";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery(); 
            }
        }

        // Needs to return void
        protected override void UpdateCore ( int id, Product newItem )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("UpdateProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", newItem.Id);
                cmd.Parameters.AddWithValue("@name", newItem.Name);
                cmd.Parameters.AddWithValue("@price", newItem.Price);
                cmd.Parameters.AddWithValue("@description", newItem.Description);
                cmd.Parameters.AddWithValue("@isDiscontinued", newItem.IsDiscontinued);

               cmd.ExecuteNonQuery();
            };
        }
        protected override Product GetCore ( int id ) => FindProduct(id);

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }
        protected override Product FindByName ( string name )
        {
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "FindName";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);

                // Error - clean up reader
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product() {
                            Id = Convert.ToInt32(reader[0]),                
                            Name = reader["Name"]?.ToString(),              
                            Description = reader.GetString(2),              
                            Price = reader.GetFieldValue<decimal>(4),           
                            IsDiscontinued = reader.GetBoolean(5)
                        };
                        return product;
                    };
                };
            };
            return null;
        }

        protected override Product FindProduct ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "GetProduct";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                //Error - clean up reader
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product() {

                            Id = Convert.ToInt32(reader[0]),                
                            Name = reader["Name"]?.ToString(),              
                            Description = reader.GetString(2),              
                            Price = reader.GetFieldValue<decimal>(4),           
                            IsDiscontinued = reader.GetBoolean(5)
                        };
                        return product;
                    };
                };
            };
            return null;
        }

        private readonly string _connectionString;
    }
}
