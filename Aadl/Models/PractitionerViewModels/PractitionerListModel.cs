using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Domains.Utility;

namespace Aadl.Models.PractitionerViewModels
{
	public class PractitionerListViewModel : PractitionerViewModel
    {
      
        public List<string>PractitionerCases { get; set; } = null!;
        public string CreatedByUserName {  get; set; }=null!;

    }

}
