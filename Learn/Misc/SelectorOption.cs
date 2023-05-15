using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Misc
{
    public class SelectorOption
    {
        int _Id;
        string _Title;
        object _DataContext;

        public int Id
        {
            get
            {
                return _Id;
            }
        }
        public string Title
        {
            get
            {
                return _Title;
            }
        }
        public object DataContext
        {
            get
            {
                return _DataContext;
            }
        }
        public SelectorOption(int Id, string Title, object DataContext = null)
        {
            _Id = Id;
            _Title = Title;
            _DataContext = DataContext;
        }
    }
}
