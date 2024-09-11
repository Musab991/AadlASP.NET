namespace Domains.Models
{
    public class ViewPractitioner
    {
        //start person
        public int PersonId { get; set; }
        public string FullName {  get; set; }
        public string Phone {  get; set; }
        public string Email {  get; set; }
        //end person
        ///////////////////////
        
        //start practitioner 
        public int PractitionerId { get; set; } 
        public PractitionerTypeEnum PractitionerType { get; set; }
        public DateTime CreationDate { get; set; }//practitioner
        public int CreatedByUserId {  get; set; }//practitioner

        //Regulator protperties
        public string? RegulatorMembershipNumber { get; set; }
        public SubscriptionTypeEnum? RegulatorSubscriptionType { get; set; }
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

        //end practitioner



    }

}

