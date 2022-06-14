using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTools
{
    public interface IFieldConfig
    {
        public abstract int Index_headRow { get;}
        public abstract int Index_nameRow { get; }
        public abstract int Index_typeRow { get; }
        public abstract int Index_dataRow { get; }
        public abstract int Index_dataCol { get; }


    }
}
