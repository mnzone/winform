namespace DataMigrations
{
    internal class Member
    {
        public Member()
        {
        }

        public object CategoryId { get; internal set; }
        public string CreatedAt { get; internal set; }
        public string EndAt { get; internal set; }
        public string Money { get; internal set; }
        public string No { get; internal set; }
        public string BeginAt { get; set; }
        public int Id { get; set; }
    }
}