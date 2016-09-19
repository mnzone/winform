using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update.Models
{
    public class Soft : Model
    {
        public Soft() { }

        public Soft(JObject json) {
            this.id = Convert.ToInt32(json["id"].ToString());
            this.build = Convert.ToInt64(json["build"].ToString());
            this.desc = json["desc"].ToString();
            this.name = json["name"].ToString();
            this.version = json["version"].ToString();
            this.createdAt = this.ConvertIntDateTime(Convert.ToInt64(json["created_at"].ToString()));
            this.updatedAt = this.ConvertIntDateTime(Convert.ToInt64(json["updated_at"].ToString()));
            JArray packages = json["packages"] as JArray;
            this.packages = new List<SoftPackage>();
            foreach(JObject package in packages){
                this.packages.Add(new SoftPackage(package));
            }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private String desc;

        public String Desc
        {
            get { return desc; }
            set { desc = value; }
        }
        private String version;

        public String Version
        {
            get { return version; }
            set { version = value; }
        }
        private long build;

        public long Build
        {
            get { return build; }
            set { build = value; }
        }
        private DateTime updatedAt;

        public DateTime UpdatedAt
        {
            get { return updatedAt; }
            set { updatedAt = value; }
        }
        private DateTime createdAt;

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }
        private List<SoftPackage> packages;

        public List<SoftPackage> Packages
        {
            get { return packages; }
            set { packages = value; }
        }
    }
}
