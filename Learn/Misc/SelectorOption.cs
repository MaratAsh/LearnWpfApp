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
        
        public string Title
        {
            get
            {
                return _Title;
            }
        }
        public SelectorOption(int Id, string Title)
        {
            _Id = Id;
            _Title = Title;
        }
    }
}
