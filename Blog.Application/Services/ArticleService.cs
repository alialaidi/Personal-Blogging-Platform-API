using Blog.Application.DTOs;
using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }


        public async Task<List<ArticleDTO>> GetAllAsync()
        {
            var articles = await _articleRepository.GetAllAsync();

            return articles.Select(article => new ArticleDTO
            {
                ArticleId = article.ArticleId,
                Title = article.Title,
                Content = article.Content,
                Tags = article.Tags,
                PublishedAt = article.PublishedAt
            }).ToList();
        }

        public async Task<ArticleDTO?> GetByIdAsync(int articleId)
        {
            var article = await _articleRepository.GetByIdAsync(articleId);

            if (article == null)
                return null;

            return new ArticleDTO
            {
                ArticleId = article.ArticleId,
                Title = article.Title,
                Content = article.Content,
                Tags = article.Tags,
                PublishedAt = article.PublishedAt
            };
        }

        public async Task<int> CreateAsync(CreateArticleDTO dto)
        {
            var article = new Article
            {
                Title = dto.Title,
                Content = dto.Content,
                Tags = dto.Tags,
                PublishedAt = dto.PublishedAt
            };

            return await _articleRepository.AddAsync(article);
        }

        public async Task<bool> UpdateAsync(int articleId, UpdateArticleDTO dto)
        {
            var article = new Article
            {
                ArticleId = articleId,
                Title = dto.Title,
                Content = dto.Content,
                Tags = dto.Tags,
                PublishedAt = dto.PublishedAt
            };

            return await _articleRepository.UpdateAsync(article);
        }

        public async Task<bool> DeleteAsync(int articleId)
        {
            return await _articleRepository.DeleteAsync(articleId);
        }


    }
}
