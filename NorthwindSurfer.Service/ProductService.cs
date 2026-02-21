using Dapper;
using NorthwindSurfer.Data;
using NorthwindSurfer.Model;

namespace NorthwindSurfer.Service
{
    public class ProductService
    {
        public DbContext _dbContext;

        public ProductService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateProductAsync(
            string ProductName,
            int SupplierID,
            int CategoryID,
            string QuantityPerUnit,
            decimal UnitPrice,
            short UnitsInStock,
            short UnitsOnOrder,
            short ReorderLevel,
            bool Discontinued
            )
        {
            string sql = @"INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
                           VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)";
            var parameters = new Dictionary<string, object>
            {
                { "@ProductName", ProductName },
                { "@SupplierID", SupplierID },
                { "@CategoryID", CategoryID },
                { "@QuantityPerUnit", QuantityPerUnit },
                { "@UnitPrice", UnitPrice },
                { "@UnitsInStock", UnitsInStock },
                { "@UnitsOnOrder", UnitsOnOrder },
                { "@ReorderLevel", ReorderLevel },
                { "@Discontinued", Discontinued }
            };
            await _dbContext.Connection.ExecuteAsync(sql, parameters);
        }

        public async Task<List<Products>> GetAllProductsAsync()
        {
            string sql = @"
    SELECT * 
    FROM Products p
    JOIN Categories c ON p.CategoryID = c.CategoryID";

            var result = await _dbContext.Connection.QueryAsync<Products, Categories, Products>(
                sql,
                (product, category) =>
                {
                    product.Category = category;
                    return product;
                },
                splitOn: "CategoryID"
            );

            return result.ToList();
        }


        public async Task<Products?> GetProductByIdAsync(int id)
            {
                string sql = @"
            SELECT 
                p.ProductID, p.ProductName, p.CategoryID,
                c.CategoryID, c.CategoryName
            FROM Products p
            JOIN Categories c ON p.CategoryID = c.CategoryID
            WHERE p.ProductID = @ProductID";

                var result = await _dbContext.Connection.QueryAsync<Products, Categories, Products>(
                    sql,
                    (product, category) =>
                    {
                        product.Category = category;
                        return product;
                    },
                    new { ProductID = id },
                    splitOn: "CategoryID"
                );

                return result.FirstOrDefault();
            }

    public async Task UpdateProductAsync(
            int ProductID,
            string ProductName,
            int SupplierID,
            int CategoryID,
            string QuantityPerUnit,
            decimal UnitPrice,
            short UnitsInStock,
            short UnitsOnOrder,
            short ReorderLevel,
            bool Discontinued
            )
        {
            string sql = @"UPDATE Products SET ProductName = @ProductName, SupplierID = @SupplierID, CategoryID = @CategoryID, QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock, UnitsOnOrder = @UnitsOnOrder, ReorderLevel = @ReorderLevel, Discontinued = @Discontinued
                           WHERE ProductID = @ProductID";
            var parameters = new Dictionary<string, object>
            {
                {"@ProductName", ProductName},
                { "@SupplierID", SupplierID},
                {"@CategoryID", CategoryID},
                {"@QuantityPerUnit", QuantityPerUnit},
                {"@UnitPrice", UnitPrice},
                {"@UnitsInStock", UnitsInStock},
                {"@UnitsOnOrder", UnitsOnOrder},
                {"@ReorderLevel", ReorderLevel},
                {"@Discontinued", Discontinued},
                {"@ProductID", ProductID}
            };

            await _dbContext.Connection.ExecuteAsync(sql, parameters);
        }

        public async Task DeleteProductAsync(int id)
        {
            string sql = "DELETE FROM Products WHERE ProductID = @ProductID";
            var parameters = new Dictionary<string, object>
            {
                { "@ProductID", id }
            };
            await _dbContext.Connection.ExecuteAsync(sql, parameters);
        }
    }
}
