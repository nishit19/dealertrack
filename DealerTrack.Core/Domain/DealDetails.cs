using DealerTrack.Core.Utility;
using System;
namespace DealerTrack.Core.Domain
{
    public class DealDetails
    {
        public int DealerNumber { get; set; }
        public string CustomerName { get; set; }
        public string DealerShipName { get; set; }
        public string Vehicle { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string PriceFormatted => StringUtility.FormatCurrency(Price);
        public string DateFormatted => StringUtility.FormatDate(Date);
    }
}
