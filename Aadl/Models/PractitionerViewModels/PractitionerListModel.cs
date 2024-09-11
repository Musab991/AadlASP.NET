using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Aadl.Models.PractitionerViewModels
{
	public class PractitionerListViewModel
    {
        public int PractitionerId { get; set; }
        public string FullName { get; set; } = null!;
        public string PractitionerType { get; set; } = null!;
        public List<string> PractitionerCases { get; set; } = null!;
        public string CreatedByUser { get; set; } = null!;
        public string SubscriptionType { get; set; } = null!;
        public string SubscriptionWay { get; set; } = null!;
        public bool IsActive { get; set; }

    }

}
