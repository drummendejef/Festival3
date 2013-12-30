using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.model
{
    class Band
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }
    }
}
