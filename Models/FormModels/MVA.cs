namespace Paradise.Models.FormModels
{
    public class MVA
    {
        public int Id { get; set; }
        public BasicInfo? BasicInfo { get; set; }
        public LeadToken? LeadToken { get; set; }
        public bool AccidentInLastYear { get; set; }
        public DateTime DateOfAccident {  get; set; } 
        public bool YourFault { get; set; }
        
        public MVA()
        {
            YourFault = false;
            AccidentInLastYear = false;
            BasicInfo = new BasicInfo();
        }
    }
}
