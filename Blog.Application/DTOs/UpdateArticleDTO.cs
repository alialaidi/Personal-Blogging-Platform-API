using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.DTOs
{
    public class UpdateArticleDTO
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string? Tags { get; set; }

        public DateTime PublishedAt { get; set; }
    }
}
