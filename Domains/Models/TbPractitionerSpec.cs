namespace Domains.Models
{
    public class TbPractitionerSpec
    {
        [Key]
        [ValidateNever]
        public int Id {  get; set; }
 
        [Required]
        [ValidateNever]
        public int PractitionerId {  get; set; }

        //Regulator protperties
        public string ?RegulatorMembershipNumber { get; set; }
        public  SubscriptionTypeEnum? RegulatorSubscriptionType {  get; set; }
        public SubscriptionWayEnum? RegulatorSubscriptionWay { get; set; }
    
        //Sharia protperties
        public string? ShariaLicenseNubmer { get; set; }
        public SubscriptionTypeEnum? ShariaSubscriptionType { get; set; }
        public SubscriptionWayEnum? ShariaSubscriptionWay { get; set; }

        //Judger protperties

        public SubscriptionTypeEnum? JudgerSubscriptionType { get; set; }
        public SubscriptionWayEnum? JudgerSubscriptionWay { get; set; }

        //Expert protperties
        public SubscriptionTypeEnum? ExpertSubscriptionType { get; set; }
        public SubscriptionWayEnum? ExpertSubscriptionWay { get; set; }

    }

}
