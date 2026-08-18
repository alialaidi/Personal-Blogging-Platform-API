using Blog.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface IArticleService
    {
        Task<List<ArticleDTO>> GetAllAsync();

        Task<ArticleDTO?> GetByIdAsync(int articleId);

        Task<int> CreateAsync(CreateArticleDTO dto);

        Task<bool> UpdateAsync(int articleId, UpdateArticleDTO dto);

        Task<bool> DeleteAsync(int articleId);
    }
}
