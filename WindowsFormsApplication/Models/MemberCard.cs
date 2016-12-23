using System;
using System.Collections.Generic;

namespace Models
{
    public class MemberCard : BaseModel
    {
        private int id;
        private String cardNo;
        private int categoryId;
        private int createdAt;
        private int updatedAt;
        private MemberCardCategory category;
        private MemberCardRecord record;
        private List<MemberCardRecord> records;

        public MemberCardRecord Record
        {
            get
            {
                if (record == null)
                {
                    //new MemberCardRecordDAL().find(card.CategoryId);
                }
                return record;
            }

            set
            {
                record = value;
            }
        }

        public List<MemberCardRecord> Records
        {
            get
            {
                return records;
            }

            set
            {
                records = value;
            }
        }

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

        public string CardNo
        {
            get
            {
                return cardNo;
            }

            set
            {
                cardNo = value;
            }
        }

        public int CategoryId
        {
            get
            {
                return categoryId;
            }

            set
            {
                categoryId = value;
            }
        }

        public MemberCardCategory Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
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
