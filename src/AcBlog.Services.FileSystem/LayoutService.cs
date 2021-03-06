﻿using AcBlog.Data.Extensions;
using AcBlog.Data.Models;
using AcBlog.Data.Models.Actions;
using AcBlog.Data.Repositories;
using AcBlog.Data.Repositories.FileSystem.Readers;
using AcBlog.Data.Repositories.Searchers;
using StardustDL.Extensions.FileProviders;

namespace AcBlog.Services.FileSystem
{
    internal class LayoutService : RecordRepoBasedService<Layout, string, LayoutQueryRequest, ILayoutRepository>, ILayoutService
    {
        public LayoutService(IBlogService blog, string rootPath, IFileProvider fileProvider) : base(blog, new LayoutFSReader(rootPath, fileProvider))
        {
        }
    }
}
