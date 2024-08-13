namespace Paradise.Models.FormModels
{
    public class ACA
    {
        public int Id { get; set; }
        public BasicInfo? BasicInfo { get; set; }
        public LeadToken? LeadToken { get; set; }
        public ACA() 
        {
        BasicInfo = new BasicInfo(); 
        }
    }
}
