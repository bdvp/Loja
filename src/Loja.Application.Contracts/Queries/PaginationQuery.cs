namespace Loja.Application.Contracts.Queries
{
    using System.ComponentModel.DataAnnotations;

    public abstract class PaginationQuery
    {
        protected const int Maximum = 100;

        public PaginationQuery(int pageSize, int pageIndex)
        {
            PageSize = pageSize > Maximum ? Maximum : pageSize;
            PageIndex = pageIndex == 0 ? ++pageIndex : pageIndex;
        }

        [Required]
        public int PageSize { get; }

        [Required]
        public int PageIndex { get; }
    }
}
