using Microsoft.Identity.Client;

namespace Paradise.Models.FormModels
{
    public class AutoInsurance
    {
        public int Id { get; set; }
        public BasicInfo? BasicInfo { get; set; }
        public string? CarYear { get; set; }
        public string? CarMake { get; set; }
        public string? CarModel { get; set; }
        public string? InsuranceCompany  { get; set; }
        public LeadToken? LeadToken { get; set; }
        public  AutoInsurance()
        {
            BasicInfo = new BasicInfo();
        }
    }
}
