namespace Models
{
    public class MemberCardRecord : BaseModel
    {
        private int id;
        private int memberCardId;
        private decimal balance;
        private int beginAt;
        private int expiredAt;
        private int createdAt;
        private int updatedAt;
        private MemberCard card;

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

        public int MemberCardId
        {
            get
            {
                return memberCardId;
            }

            set
            {
                memberCardId = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
            }
        }

        public int BeginAt
        {
            get
            {
                return beginAt;
            }

            set
            {
                beginAt = value;
            }
        }

        public int ExpiredAt
        {
            get
            {
                return expiredAt;
            }

            set
            {
                expiredAt = value;
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

        public MemberCard Card
        {
            get
            {
                return card;
            }

            set
            {
                card = value;
            }
        }
    }
}
