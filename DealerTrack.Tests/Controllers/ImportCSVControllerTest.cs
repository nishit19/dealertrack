using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DealerTrack.Core.Repository;
using DealerTrack.Data.Repository;

namespace DealerTrack.Tests.Controllers
{
    [TestClass]
    public class ImportCSVControllerTest
    {
        [TestMethod]
        public void CheckIfFileIsNotEmpty()
        {
            var csvPath = Path.GetFullPath(@"CSV\Dealertrack-CSV-Example.csv");
            var fileStream = new StreamReader(csvPath, Encoding.Default,true);
            IDealDetailsRepository dealRepository = new DealDetailsRepository();
            var lstDeals = dealRepository.GetDealDataFromCsv(fileStream);
            Assert.AreNotEqual(lstDeals.Count,0);
        }

    }
}
