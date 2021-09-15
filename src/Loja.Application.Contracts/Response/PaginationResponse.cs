namespace Loja.Application.Contracts.Response
{
    using System.Collections.Generic;
    using System.Linq;

    public class PaginationResponse <T> where T : class
    {
        public PaginationResponse(IEnumerable<T> data, int pageIndex, int pageSize)
        {
            int totalItens = data.Count();

            Data = data;
            TotalItens = totalItens;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (totalItens + pageSize - 1) / pageSize;
            HasNextPage = PageIndex < TotalPages;
            HasPreviousPage = PageIndex > 1;
        }

        public IEnumerable<T> Data { get; }

        public int TotalItens { get; }

        public int PageSize { get; }

        public int PageIndex { get; }

        public int TotalPages { get; }

        public bool HasNextPage { get; }

        public bool HasPreviousPage { get; }
    }
}
