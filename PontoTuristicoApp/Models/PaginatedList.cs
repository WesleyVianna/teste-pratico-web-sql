using System;
using System.Collections.Generic;

namespace PontoTuristicoApp.Models
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; private set; }
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalItems { get; private set; }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public PaginatedList(List<T> items, int totalItems, int pageIndex, int pageSize)
        {
            Items = items;
            TotalItems = totalItems;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        }
    }
}
