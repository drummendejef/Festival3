using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.viewmodel
{
    class StagesVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "StagesVM"; }
        }
    }
}
