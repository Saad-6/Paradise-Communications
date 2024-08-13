namespace Paradise.Models.FormModels
{
    public class Medicare
    {
        public int Id { get; set; }
        public BasicInfo? BasicInfo { get; set; }
        public LeadToken? LeadToken { get; set; }

        public Medicare()
        {
        BasicInfo = new BasicInfo();
        }
    }
}
