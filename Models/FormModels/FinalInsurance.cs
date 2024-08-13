namespace Paradise.Models.FormModels
{
    public class FinalInsurance
    {
        public int Id { get; set; }
        public BasicInfo? BasicInfo { get; set; }
        public LeadToken? LeadToken { get; set; }
        public FinalInsurance()
        {
            BasicInfo = new BasicInfo();
        }
    }
}
