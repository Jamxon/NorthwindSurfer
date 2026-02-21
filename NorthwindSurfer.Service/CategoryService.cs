using Dapper;
using NorthwindSurfer.Data;
using NorthwindSurfer.Model;

namespace NorthwindSurfer.Service
{
    public class CategoryService
    {
        public DbContext _dbContext;
        public CategoryService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateCategoryAsync(string CategoryName, string Description)
        {
            string sql = @"INSERT INTO Categories (CategoryName, Description)
                           VALUES (@CategoryName, @Description)";
            var parameters = new Dictionary<string, object>
            {
                { "@CategoryName", CategoryName },
                { "@Description", Description }
            };
            await _dbContext.Connection.ExecuteAsync(sql, parameters);
        }

        public async Task<List<Categories>> GetAllCategoriesAsync()
        {
            string sql = "SELECT * FROM Categories";
            List<Categories> categories = (await _dbContext.Connection.QueryAsync<Categories>(sql)).ToList();
            return categories;
        }

        public async Task<Categories> GetCategoryByIdAsync(int id)
        {
            string sql = "SELECT * FROM Categories WHERE CategoryID = @CategoryID";
            var parameters = new Dictionary<string, object>
            {
                { "@CategoryID", id }
            };
            Categories category = await _dbContext.Connection.QueryFirstOrDefaultAsync<Categories>(sql, parameters);
            return category;
        }

        public async Task UpdateCategoryAsync(int CategoryID, string CategoryName, string Description)
        {
            string sql = @"UPDATE Categories
                           SET CategoryName = @CategoryName, Description = @Description
                           WHERE CategoryID = @CategoryID";
            var parameters = new Dictionary<string, object>
            {
                { "@CategoryID", CategoryID },
                { "@CategoryName", CategoryName },
                { "@Description", Description }
            };
            await _dbContext.Connection.ExecuteAsync(sql, parameters);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            string sql = "DELETE FROM Categories WHERE CategoryID = @CategoryID";
            var parameters = new Dictionary<string, object>
            {
                { "@CategoryID", id }
            };
            await _dbContext.Connection.ExecuteAsync(sql, parameters);
        }
    }
}
