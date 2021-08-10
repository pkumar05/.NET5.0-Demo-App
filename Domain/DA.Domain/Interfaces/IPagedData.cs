using System.Collections.Generic;

namespace DA.Domain.Interfaces
{
    public interface IPagedData<T>
    {
        int PageCount { get; }
        int TotalItemCount { get; }
        int PageIndex { get; }
        int PageNumber { get; }
        int PageSize { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        bool IsFirstPage { get; }
        bool IsLastPage { get; }
        int ItemStart { get; }
        int ItemEnd { get; }
        IList<T> Data { get; }
    }
}
