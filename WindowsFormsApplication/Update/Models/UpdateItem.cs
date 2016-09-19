using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update.Models
{
    public class UpdateItem : Model
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private String from;

        public String From
        {
            get { return from; }
            set { from = value; }
        }
        private String to;

        public String To
        {
            get { return to; }
            set { to = value; }
        }
        private String backup;

        public String Backup
        {
            get { return backup; }
            set { backup = value; }
        }

        private String title;

        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        private String desc;

        public String Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        private String fileName;

        public String FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
    }
}
