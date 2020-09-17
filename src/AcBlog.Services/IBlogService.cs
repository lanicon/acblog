﻿using AcBlog.Data.Models;
using System.Threading;
using System.Threading.Tasks;

namespace AcBlog.Services
{
    public interface IBlogService
    {
        IPostService PostService { get; }

        IPageService PageService { get; }

        ILayoutService LayoutService { get; }

        ICommentService CommentService { get; }

        IStatisticService StatisticService { get; }

        IFileService FileService { get; }

        Task<BlogOptions> GetOptions(CancellationToken cancellationToken = default);
    }
}