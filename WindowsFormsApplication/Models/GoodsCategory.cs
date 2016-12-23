using System;

namespace Models
{
    public class GoodsCategory
    {
        private int id;
        private String name;
        private int parentId;
        private int sort;
        private int createdAt;
        private int updatedAt;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int ParentId
        {
            get
            {
                return parentId;
            }

            set
            {
                parentId = value;
            }
        }

        public int Sort
        {
            get
            {
                return sort;
            }

            set
            {
                sort = value;
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
    }
}