using System.Collections.Generic;
using System.IO;
using DealerTrack.Core.Domain;
using DealerTrack.Core.Repository;
using DealerTrack.Core.Utility;

namespace DealerTrack.Data.Repository
{
    public class DealDetailsRepository : IDealDetailsRepository
    {
        public List<DealDetails> GetDealDataFromCsv(StreamReader srCsv)
        {
            var lstDeal = new List<DealDetails>();
            var firstRow = true; //skip header row
            while (!srCsv.EndOfStream)
            {
                var dealDetailRow = srCsv.ReadLine();
                //skip header row
                if (firstRow)
                {
                    firstRow = false;
                    continue;
                }

                if (!string.IsNullOrEmpty(dealDetailRow))
                {
                    var dealDetail = StringUtility.SplitCsvRow(dealDetailRow);
                    var deal = new DealDetails()
                    {
                        DealerNumber = StringUtility.GetInteger(dealDetail[0]),
                        CustomerName = dealDetail[1],
                        DealerShipName = dealDetail[2],
                        Vehicle = dealDetail[3],
                        Price = StringUtility.GetDecimal(dealDetail[4]),
                        Date = StringUtility.GetDateTime(dealDetail[5])
                    };
                    lstDeal.Add(deal);
                }
            }
            return lstDeal;
        }
    }
}
