using CM.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CM.Customers.Repositories
{
    public class AddressRepository : IRepository<Address>
    {
        private readonly string connectionString;
        public AddressRepository()
        {
            connectionString = @"Data Source=DESKTOP-JDONGM6\SQLEXPRESS;Database=CustomerLib_Timoschenko;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        public AddressRepository(string ConnectionString)
        {
            connectionString = ConnectionString;
        }
        public void Create(Address entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                   "INSERT INTO dbo.[Addresses](customer_ID,address_Line,address_Line_2,address_type,city,postal_code,[state],country)VALUES(@customerID,@addressLine,@addressLine2,@addressType,@city,@postalCode,@state,@country)", connection);
                var customerIDParam = new SqlParameter("@customerID", SqlDbType.Int)
                {
                    Value = entity.CustomerID
                };

                var addressLineParam = new SqlParameter("@addressLine", SqlDbType.VarChar, 100)
                {
                    Value = entity.AddressLine
                };

                var addressLine2Param = new SqlParameter("@addressLine2", SqlDbType.VarChar, 100)
                {
                    Value = entity.AddressLine2
                };

                var addressTypeParam = new SqlParameter("@addressType", SqlDbType.Int)
                {
                    Value = entity.AddressType
                };

                var cityParam = new SqlParameter("@city", SqlDbType.VarChar, 50)
                {
                    Value = entity.City
                };

                var postalCodeParam = new SqlParameter("@postalCode", SqlDbType.VarChar, 6)
                {
                    Value = entity.PostalCode
                };

                var stateParam = new SqlParameter("@state", SqlDbType.VarChar, 50)
                {
                    Value = entity.State
                };

                var countryParam = new SqlParameter("@country", SqlDbType.VarChar, 40)
                {
                    Value = entity.Country
                };

                command.Parameters.Add(customerIDParam);
                command.Parameters.Add(addressLineParam);
                command.Parameters.Add(addressLine2Param);
                command.Parameters.Add(addressTypeParam);
                command.Parameters.Add(cityParam);
                command.Parameters.Add(postalCodeParam);
                command.Parameters.Add(stateParam);
                command.Parameters.Add(countryParam);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int entityCode)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "DELETE FROM dbo.[Addresses] WHERE address_ID = @addressID", connection);
                var addressIDParam = new SqlParameter("@addressID", SqlDbType.Int)
                {
                    Value = entityCode
                };
                command.Parameters.Add(addressIDParam);
                command.ExecuteNonQuery();
            }
        }

        public Address Read(int? entityCode)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT * FROM dbo.[Addresses] WHERE address_ID = @addressID", connection);
                var addressIDParam = new SqlParameter("@addressID", SqlDbType.Int)
                {
                    Value = entityCode
                };
                command.Parameters.Add(addressIDParam);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Address()
                        {
                            CustomerID = Convert.ToInt32(reader["customer_ID"]),
                            AddressLine = reader["address_Line"].ToString(),
                            AddressLine2 = reader["address_Line_2"].ToString(),
                            AddressType = Convert.ToInt32(reader["address_type"]),
                            City = reader["city"].ToString(),
                            State = reader["state"].ToString(),
                            Country = reader["country"].ToString(),
                            PostalCode = reader["postal_code"].ToString()
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void Update(Address entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                   "UPDATE dbo.[Addresses] SET customer_ID=@customerID,address_Line=@addressLine,address_Line_2=@addressLine2,address_type=@addressType,city=@city,postal_code=@postalCode,[state]=@state,country=@country WHERE address_ID = @addressID", connection);
                var addressIDParam = new SqlParameter("@addressID", SqlDbType.Int)
                {
                    Value = entity.AddressID
                };
                var customerIDParam = new SqlParameter("@customerID", SqlDbType.Int)
                {
                    Value = entity.CustomerID
                };

                var addressLineParam = new SqlParameter("@addressLine", SqlDbType.VarChar, 100)
                {
                    Value = entity.AddressLine
                };

                var addressLine2Param = new SqlParameter("@addressLine2", SqlDbType.VarChar, 100)
                {
                    Value = entity.AddressLine2
                };

                var addressTypeParam = new SqlParameter("@addressType", SqlDbType.Int)
                {
                    Value = entity.AddressType
                };

                var cityParam = new SqlParameter("@city", SqlDbType.VarChar, 50)
                {
                    Value = entity.City
                };

                var postalCodeParam = new SqlParameter("@postalCode", SqlDbType.VarChar, 6)
                {
                    Value = entity.PostalCode
                };

                var stateParam = new SqlParameter("@state", SqlDbType.VarChar, 50)
                {
                    Value = entity.State
                };

                var countryParam = new SqlParameter("@country", SqlDbType.VarChar, 40)
                {
                    Value = entity.Country
                };
                command.Parameters.Add(addressIDParam);
                command.Parameters.Add(customerIDParam);
                command.Parameters.Add(addressLineParam);
                command.Parameters.Add(addressLine2Param);
                command.Parameters.Add(addressTypeParam);
                command.Parameters.Add(cityParam);
                command.Parameters.Add(postalCodeParam);
                command.Parameters.Add(stateParam);
                command.Parameters.Add(countryParam);
                command.ExecuteNonQuery();
            }
        }

        public int GetCustomerID()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT customer_ID FROM dbo.Customers", connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["customer_ID"]);
                }
                else
                    return 0;
            }
        }
        public void DeleteAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "DELETE FROM dbo.Addresses WHERE address_ID > 135", connection);
                command.ExecuteNonQuery();
            }
        }
        public int GetID()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT address_ID FROM dbo.Addresses", connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["address_ID"]);
                }
                else
                    return 0;
            }
        }


        public List<Address> GetAll()
        {
            List<Address> addresses = new List<Address>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT * FROM dbo.[Addresses]", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addresses.Add(new Address()
                        {
                            AddressID = Convert.ToInt32(reader["address_ID"]),
                            CustomerID = Convert.ToInt32(reader["customer_ID"]),
                            AddressLine = reader["address_Line"].ToString(),
                            AddressLine2 = reader["address_Line_2"].ToString(),
                            AddressType = Convert.ToInt32(reader["address_type"]),
                            City = reader["city"].ToString(),
                            State = reader["state"].ToString(),
                            Country = reader["country"].ToString(),
                            PostalCode = reader["postal_code"].ToString()
                        }); 
                    }
                }
            }
            return addresses;
        }

        public List<int> GetAllId()
        {
            var allId = new List<int>(); 
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT DISTINCT customer_ID FROM dbo.[Customers]", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allId.Add(Convert.ToInt32(reader["customer_ID"]));
                    }
                }
            }
            return allId;
        }

        public List<Address> GetAll(int? entityCode)
        {
            List<Address> addresses = new List<Address>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT * FROM dbo.[Addresses] WHERE customer_ID = @customerId", connection);
                var addressIDParam = new SqlParameter("@customerId", SqlDbType.Int)
                {
                    Value = entityCode
                };
                command.Parameters.Add(addressIDParam);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addresses.Add(new Address()
                        {
                            AddressID = Convert.ToInt32(reader["address_ID"]),
                            CustomerID = Convert.ToInt32(reader["customer_ID"]),
                            AddressLine = reader["address_Line"].ToString(),
                            AddressLine2 = reader["address_Line_2"].ToString(),
                            AddressType = Convert.ToInt32(reader["address_type"]),
                            City = reader["city"].ToString(),
                            State = reader["state"].ToString(),
                            Country = reader["country"].ToString(),
                            PostalCode = reader["postal_code"].ToString()
                        });
                    }
                }
            }
            return addresses;
        }
    }

}
