using Microsoft.AspNetCore.Mvc;
using WebApplication5.EditModel;
using WebApplication5.ViewModel;

namespace WebApplication5.Repositories
{
    public interface ITourRepository
    {
        //Task<TourModel> create(TourModel model);
        Task<List<ViewModel.TourVM>> getAllTour();
        Task<TourVM> getTour(int id);
        Task<List<TourVM>> filterPrice(int price);
    }
}
