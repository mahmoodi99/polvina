using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonBaseType.Model
{
    public class SearchViewModel
    {
        public string Value { get; set; }

        public SearchType SearchType { get; set; }

    }

    public enum SearchType
    {
        BaseTypeTitle,
        BaseTypeCode
    }
}
