using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
     public interface IArticleRepository
    {
        Task<List<Article>> GetAllAsync();

        Task<Article?> GetByIdAsync(int articleId);

        Task<int> AddAsync(Article article);

        Task<bool> UpdateAsync(Article article);

        Task<bool> DeleteAsync(int articleId);
    }
}
