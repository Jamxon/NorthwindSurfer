using Dapper;
using NorthwindSurfer.Data;
using NorthwindSurfer.Model;

namespace NorthwindSurfer.Service
{
    public class OrderService
    {
        public DbContext _dbContext;
        public OrderService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateOrderAsync(
            int CustomerID,
            int EmployeeID,
            DateTime? OrderDate,
            DateTime? RequiredDate,
            DateTime? ShippedDate,
            int ShipVia,
            decimal Freight,
            string ShipName,
            string ShipAddress,
            string ShipCity,
            string ShipRegion,
            string ShipPostalCode,
            string ShipCountry
            )
        {
            string sql = @"INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry)
                            VALUES (@CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry)";
            var parameters = new Dictionary<string, object>
            {
                { "@CustomerID", CustomerID },
                { "@EmployeeID", EmployeeID },
                { "@OrderDate", OrderDate },
                { "@RequiredDate", RequiredDate },
                { "@ShippedDate", ShippedDate },
                { "@ShipVia", ShipVia },
                { "@Freight", Freight },
                { "@ShipName", ShipName },
                { "@ShipAddress", ShipAddress },
                { "@ShipCity", ShipCity },
                { "@ShipRegion", ShipRegion },
                { "@ShipPostalCode", ShipPostalCode },
                { "@ShipCountry", ShipCountry }
            };
            await _dbContext.Connection.ExecuteAsync(sql, parameters);

        }

        public async Task<List<Orders>> GetAllOrdersAsync()
        {
            string sql = @"SELECT * FROM Orders o
                            JOIN Customers c ON o.CustomerID = c.CustomerID";

            var orders = await _dbContext.Connection.QueryAsync<Orders, Customers, Orders>(sql, (order, customer) =>
            {
                order.Customer = customer;
                return order;
            }, splitOn: "CustomerID");
            return orders.ToList();
        }

        public async Task<Orders> GetOrderByIdAsync(int orderId)
        {
            string sql = @"SELECT * FROM Orders o
                            JOIN Customers c ON o.CustomerID = c.CustomerID
                            WHERE o.OrderID = @OrderID";
            var order = await _dbContext.Connection.QueryAsync<Orders, Customers, Orders>(sql, (o, c) =>
            {
                o.Customer = c;
                return o;
            }, new { OrderID = orderId }, splitOn: "CustomerID");
            return order.FirstOrDefault();
        }

        public async Task UpdateOrderAsync(
            int OrderID,
            int CustomerID,
            int EmployeeID,
            DateTime? OrderDate,
            DateTime? RequiredDate,
            DateTime? ShippedDate,
            int ShipVia,
            decimal Freight,
            string ShipName,
            string ShipAddress,
            string ShipCity,
            string ShipRegion,
            string ShipPostalCode,
            string ShipCountry
            )
        {
            string sql = @"UPDATE Orders 
                            SET CustomerID = @CustomerID, EmployeeID = @EmployeeID, OrderDate = @OrderDate, RequiredDate = @RequiredDate, ShippedDate = @ShippedDate, ShipVia = @ShipVia, Freight = @Freight, ShipName = @ShipName, ShipAddress = @ShipAddress, ShipCity = @ShipCity, ShipRegion = @ShipRegion, ShipPostalCode = @ShipPostalCode, ShipCountry = @ShipCountry
                            WHERE OrderID = @OrderID";
            var parameters = new Dictionary<string, object>
            {
                { "@OrderID", OrderID },
                { "@CustomerID", CustomerID },
                { "@EmployeeID", EmployeeID },
                { "@OrderDate", OrderDate },
                { "@RequiredDate", RequiredDate },
                { "@ShippedDate", ShippedDate },
                { "@ShipVia", ShipVia },
                { "@Freight", Freight },
                { "@ShipName", ShipName },
                { "@ShipAddress", ShipAddress },
                { "@ShipCity", ShipCity },
                { "@ShipRegion", ShipRegion },
                { "@ShipPostalCode", ShipPostalCode },
                { "@ShipCountry", ShipCountry }
            };
            await _dbContext.Connection.ExecuteAsync(sql, parameters);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            string sql = @"DELETE FROM Orders WHERE OrderID = @OrderID";
            await _dbContext.Connection.ExecuteAsync(sql, new { OrderID = orderId });
        }
    }
}
