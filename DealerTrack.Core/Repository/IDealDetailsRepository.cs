using System.Collections.Generic;
using System.IO;
using DealerTrack.Core.Domain;

namespace DealerTrack.Core.Repository
{
    public interface IDealDetailsRepository
    {
        List<DealDetails> GetDealDataFromCsv(StreamReader srCsv);
    }
}
