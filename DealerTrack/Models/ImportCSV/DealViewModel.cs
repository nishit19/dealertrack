using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using DealerTrack.Core.Domain;

namespace DealerTrack.Models.ImportCSV
{
    public class DealViewModel
    {
        [Required(ErrorMessage = "Please select a file")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.csv)$", ErrorMessage = "Please select a CSV file")]
        public HttpPostedFileBase PostedFile { get; set; }
        public string DealGrid { get; set; }
    }
    public class DealGridViewModel
    {
        public IEnumerable<DealDetails> DealDetails { get; set; }
    }
}