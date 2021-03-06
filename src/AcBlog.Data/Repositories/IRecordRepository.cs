﻿using AcBlog.Data.Models;
using AcBlog.Data.Models.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AcBlog.Data.Repositories
{

    public interface IRecordRepository<T, TId, TQuery> : IRepository where TId : class where T : class, IHasId<TId> where TQuery : QueryRequest, new()
    {
        Task<RepositoryStatus> GetStatus(CancellationToken cancellationToken = default);

        IAsyncEnumerable<TId> All(CancellationToken cancellationToken = default);

        Task<bool> Exists(TId id, CancellationToken cancellationToken = default);

        Task<T?> Get(TId id, CancellationToken cancellationToken = default);

        Task<bool> Delete(TId id, CancellationToken cancellationToken = default);

        Task<bool> Update(T value, CancellationToken cancellationToken = default);

        Task<TId?> Create(T value, CancellationToken cancellationToken = default);

        IAsyncEnumerable<TId> Query(TQuery query, CancellationToken cancellationToken = default);

        Task<QueryStatistic> Statistic(TQuery query, CancellationToken cancellationToken = default);
    }

    public class EmptyRecordRepository<T, TId, TQuery> : IRecordRepository<T, TId, TQuery> where TId : class where T : class, IHasId<TId> where TQuery : QueryRequest, new()
    {
        private static readonly RepositoryStatus _status = new RepositoryStatus
        {
            CanRead = false,
            CanWrite = false
        };

        public virtual RepositoryAccessContext Context { get; set; } = new RepositoryAccessContext();

        public virtual IAsyncEnumerable<TId> All(CancellationToken cancellationToken = default) => AsyncEnumerable.Empty<TId>();

        public virtual Task<TId?> Create(T value, CancellationToken cancellationToken = default) => Task.FromResult<TId?>(null);

        public virtual Task<bool> Delete(TId id, CancellationToken cancellationToken = default) => Task.FromResult(false);

        public virtual Task<bool> Exists(TId id, CancellationToken cancellationToken = default) => Task.FromResult(false);

        public virtual Task<T?> Get(TId id, CancellationToken cancellationToken = default) => Task.FromResult<T?>(null);

        public virtual Task<RepositoryStatus> GetStatus(CancellationToken cancellationToken = default) => Task.FromResult(_status);

        public virtual IAsyncEnumerable<TId> Query(TQuery query, CancellationToken cancellationToken = default) => AsyncEnumerable.Empty<TId>();

        public virtual Task<bool> Update(T value, CancellationToken cancellationToken = default) => Task.FromResult(false);

        public virtual Task<QueryStatistic> Statistic(TQuery query, CancellationToken cancellationToken = default) => Task.FromResult(QueryStatistic.Empty());
    }
}
