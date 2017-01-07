namespace Models
{
    public class MemberCardRecord : BaseModel
    {
        private int id;
        private int memberCardId;
        private decimal balance;
        private long beginAt;
        private long expiredAt;
        private long createdAt;
        private long updatedAt;
        private Status status;
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

        public long BeginAt
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

        public long ExpiredAt
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

        public long CreatedAt
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

        public long UpdatedAt
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

        public Status Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }
    }
}
