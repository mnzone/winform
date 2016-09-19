using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loader.ViewModel
{
    public class UpdateInfo
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private String ver;

        public String Ver
        {
            get { return ver; }
            set { ver = value; }
        }

        private List<UpdateItem> items = null;

        public List<UpdateItem> Items
        {
            get { return items; }
            set { items = value; }
        }
    }
}
