using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using Blog.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DbConnectionFactory _connectionString;

        public ArticleRepository(DbConnectionFactory connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Article>> GetAllAsync()
        {
            var articles = new List<Article>();

            using SqlConnection connection = _connectionString.CreateConnection();

            using SqlCommand command = new SqlCommand(
                "SP_Articles_GetAll",
                connection);

            command.CommandType = CommandType.StoredProcedure;

            await connection.OpenAsync();

            using SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                Article article = new Article
                {
                    ArticleId = reader.GetInt32(reader.GetOrdinal("ArticleId")),
                    Title = reader.GetString(reader.GetOrdinal("Title")),
                    Content = reader.GetString(reader.GetOrdinal("Content")),
                    Tags = reader.IsDBNull(reader.GetOrdinal("Tags"))
                        ? null
                        : reader.GetString(reader.GetOrdinal("Tags")),
                    PublishedAt = reader.GetDateTime(reader.GetOrdinal("PublishedAt"))
                };

                articles.Add(article);
            }

            return articles;
        }

        public async Task<Article?> GetByIdAsync(int articleId)
        {
            using SqlConnection connection = _connectionString.CreateConnection();

            using SqlCommand command = new SqlCommand(
                "SP_Articles_GetById",
                connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ArticleId", articleId);

            await connection.OpenAsync();

            using SqlDataReader reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Article
                {
                    ArticleId = reader.GetInt32(reader.GetOrdinal("ArticleId")),
                    Title = reader.GetString(reader.GetOrdinal("Title")),
                    Content = reader.GetString(reader.GetOrdinal("Content")),
                    Tags = reader.IsDBNull(reader.GetOrdinal("Tags"))
                        ? null
                        : reader.GetString(reader.GetOrdinal("Tags")),
                    PublishedAt = reader.GetDateTime(reader.GetOrdinal("PublishedAt"))
                };
            }

            return null;
        }

        public async Task<int> AddAsync(Article article)
        {
            using SqlConnection connection = _connectionString.CreateConnection();

            using SqlCommand command = new SqlCommand(
                "SP_Articles_Add",
                connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Title", article.Title);
            command.Parameters.AddWithValue("@Content", article.Content);
            command.Parameters.AddWithValue("@Tags",
                (object?)article.Tags ?? DBNull.Value);
            command.Parameters.AddWithValue("@PublishedAt", article.PublishedAt);

            await connection.OpenAsync();

            object? result = await command.ExecuteScalarAsync();

            return Convert.ToInt32(result);
        }

        public async Task<bool> UpdateAsync(Article article)
        {
            using SqlConnection connection = _connectionString.CreateConnection();

            using SqlCommand command = new SqlCommand(
                "SP_Articles_Update",
                connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ArticleId", article.ArticleId);
            command.Parameters.AddWithValue("@Title", article.Title);
            command.Parameters.AddWithValue("@Content", article.Content);
            command.Parameters.AddWithValue("@Tags",
                (object?)article.Tags ?? DBNull.Value);
            command.Parameters.AddWithValue("@PublishedAt", article.PublishedAt);

            await connection.OpenAsync();

            int rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }

        public async Task<bool> DeleteAsync(int articleId)
        {
            using SqlConnection connection = _connectionString.CreateConnection();

            using SqlCommand command = new SqlCommand(
                "SP_Articles_Delete",
                connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ArticleId", articleId);

            await connection.OpenAsync();

            int rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }
    }
}
