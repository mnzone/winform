namespace DataMigrations
{
    internal class SaleLog
    {
        public int MemberId { get; internal set; }
        public string MemberNo { get; set; }
        public int CategoryId { get; set; }
        public string CreatedAt { get; internal set; }
        public string BeginAt { get; internal set; }
        public string EndAt { get; internal set; }
        public string Money { get; internal set; }
        public int Id { get; internal set; }
    }
}