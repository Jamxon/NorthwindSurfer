using Dapper;
using NorthwindSurfer.Data;
using NorthwindSurfer.Model;

namespace NorthwindSurfer.Service
{
    public class CustomerService
    {
        public DbContext _dbContext;

        public CustomerService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateCustomerAsync(
            string CompanyName,
            string ContactName,
            string ContactTitle,
            string Address,
            string City,
            string Region,
            string PostalCode,
            string Country,
            string Phone,
            string Fax
            )
        {
            string sql = @"INSERT INTO Customers (CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax)
                           VALUES (@CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax)";

            var parameters = new Dictionary<string, object>
            {
                { "@CompanyName", CompanyName },
                { "@ContactName", ContactName },
                { "@ContactTitle", ContactTitle },
                { "@Address", Address },
                { "@City", City },
                { "@Region", Region },
                { "@PostalCode", PostalCode },
                { "@Country", Country },
                { "@Phone", Phone },
                { "@Fax", Fax }
            };

            await _dbContext.Connection.ExecuteAsync(sql, parameters);
        }

        public async Task<List<Customers>> GetAllCustomersAsync()
        {
            string sql = "SELECT * FROM Customers";

            List<Customers> customers = (await _dbContext.Connection.QueryAsync<Customers>(sql)).ToList();

            return customers;
        }

        public async Task<Customers> GetCustomerByIdAsync(string id)
        {
            string sql = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";
            var parameters = new Dictionary<string, object>
            {
                { "@CustomerID", id }
            };
            Customers customer = await _dbContext.Connection.QueryFirstOrDefaultAsync<Customers>(sql, parameters);
            return customer;
        }

        public async Task UpdateCustomerAsync(
            string CustomerID,
            string CompanyName,
            string ContactName,
            string ContactTitle,
            string Address,
            string City,
            string Region,
            string PostalCode,
            string Country,
            string Phone,
            string Fax
            )
        {
            string sql = @"UPDATE Customers 
                           SET CompanyName = @CompanyName, 
                               ContactName = @ContactName, 
                               ContactTitle = @ContactTitle, 
                               Address = @Address, 
                               City = @City, 
                               Region = @Region, 
                               PostalCode = @PostalCode, 
                               Country = @Country, 
                               Phone = @Phone, 
                               Fax = @Fax
                           WHERE CustomerID = @CustomerID";
            var parameters = new Dictionary<string, object>
            {
                { "@CustomerID", CustomerID },
                { "@CompanyName", CompanyName },
                { "@ContactName", ContactName },
                { "@ContactTitle", ContactTitle },
                { "@Address", Address },
                { "@City", City },
                { "@Region", Region },
                { "@PostalCode", PostalCode },
                { "@Country", Country },
                { "@Phone", Phone },
                { "@Fax", Fax }
            };
            await _dbContext.Connection.ExecuteAsync(sql, parameters);
        }

        public async Task DeleteCustomerAsync(string id)
        {
            string sql = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
            var parameters = new Dictionary<string, object>
            {
                { "@CustomerID", id }
            };
            await _dbContext.Connection.ExecuteAsync(sql, parameters);
        }
    }
}
