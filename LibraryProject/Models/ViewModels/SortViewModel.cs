using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Models
{
    public class SortViewModel
    {
        public SortState BookNameSort { get; private set; } // значение для сортировки по имени
        public SortState AuthorSort { get; private set; }    // значение для сортировки по возрасту
        public SortState CategorySort { get; private set; }   // значение для сортировки по компании
        public SortState Current { get; private set; }     // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            BookNameSort = sortOrder == SortState.BookNameAsc ? SortState.BookNamDesc : SortState.BookNameAsc;
            AuthorSort = sortOrder == SortState.AuthorAsc ? SortState.AuthorDesc : SortState.AuthorAsc;
            CategorySort = sortOrder == SortState.CategoryAsc ? SortState.CategoryDesc : SortState.CategoryAsc;
            Current = sortOrder;
        }
    }
    public enum SortState
    {
        BookNameAsc,    // по имени по возрастанию
        BookNamDesc,   // по имени по убыванию
        AuthorAsc, // по возрасту по возрастанию
        AuthorDesc,    // по возрасту по убыванию
        CategoryAsc, // по компании по возрастанию
        CategoryDesc // по компании по убыванию
    }
}
