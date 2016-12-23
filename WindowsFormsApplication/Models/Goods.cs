using System;

namespace Models
{
    public class Goods : BaseModel
    {
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
        private int sort;

        public int Sort
        {
            get { return sort; }
            set { sort = value; }
        }
        private int categoryId;

        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        public int Visibile
        {
            get
            {
                return visibile;
            }

            set
            {
                visibile = value;
            }
        }

        public int CreatedAt
        {
            get
            {
                return createdAt;
            }

            set
            {
                createdAt = value;
            }
        }

        public int UpdatedAt
        {
            get
            {
                return updatedAt;
            }

            set
            {
                updatedAt = value;
            }
        }

        public int IsDeleted
        {
            get
            {
                return isDeleted;
            }

            set
            {
                isDeleted = value;
            }
        }

        private int visibile;

        private int createdAt;
        private int updatedAt;
        private int isDeleted;
    }
}
