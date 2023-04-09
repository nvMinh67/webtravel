using WebApplication5.ViewModel;

namespace WebApplication5.Repositories
{
    public interface ILocationRepository
    {
        public Task<List<Location>> getAllLocationAsyn();
    }
}
