using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update.Models
{
    public class SoftPackage : Model
    {
        public SoftPackage() { }

        public SoftPackage(JObject json) {
            this.id = Convert.ToInt32(json["id"]);
            this.name = json["name"].ToString();
            this.path = json["path"].ToString();
            this.soft_id = Convert.ToInt32(json["soft_id"]);
            this.summary = json["summary"].ToString();
            this.version = json["version"].ToString();
            this.password = json["password"].ToString();
            this.buid = Convert.ToInt64(json["build"]);
            this.createdAt = this.ConvertIntDateTime(Convert.ToInt64(json["created_at"].ToString()));
            this.updatedAt = this.ConvertIntDateTime(Convert.ToInt64(json["updated_at"].ToString()));
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int soft_id;

        public int Soft_id
        {
            get { return soft_id; }
            set { soft_id = value; }
        }
        private Soft soft;

        public Soft Soft
        {
            get { return soft; }
            set { soft = value; }
        }
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private String password;

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        private String path;

        public String Path
        {
            get { return path; }
            set { path = value; }
        }
        private String version;

        public String Version
        {
            get { return version; }
            set { version = value; }
        }
        private String summary;

        public String Summary
        {
            get { return summary; }
            set { summary = value; }
        }
        private long buid;

        public long Buid
        {
            get { return buid; }
            set { buid = value; }
        }
        private DateTime createdAt;

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }
        private DateTime updatedAt;

        public DateTime UpdatedAt
        {
            get { return updatedAt; }
            set { updatedAt = value; }
        }

    }
}
