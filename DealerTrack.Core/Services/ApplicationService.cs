using DealerTrack.Core.Repository;
namespace DealerTrack.Core.Services
{
    public class ApplicationService
    {
        #region Declaration
        public IDealDetailsRepository DealDetailsRepository { get; }
        #endregion

       
        public ApplicationService(IDealDetailsRepository dealDetailsRepository)
        {
            DealDetailsRepository = dealDetailsRepository;
        }
    }
}
