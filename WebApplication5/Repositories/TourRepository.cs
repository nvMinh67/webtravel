using Azure.Core;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication5.EditModel;
using WebApplication5.Entity;
using WebApplication5.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace WebApplication5.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly MyDbContext _context;

        public TourRepository(MyDbContext context) {
            _context = context;
        }

        public async Task<List<TourVM>> filterPrice(int price)
        {
            var tours = await(from t in _context.tours.AsNoTracking()
                              where t.Price <= price
                              select new TourVM()
                              {
                                  Id = t.Id,
                                  Name = t.Name,
                                  Description = t.Description,
                                  startDate = t.startDate,
                                  endDate = t.endDate,
                                  Price = t.Price,
                                  Amount = t.Amount,
                                  num_day = t.num_day,
                                  diadiem = (from de in _context.detailTours.AsNoTracking()
                                             join imt in _context.DIADIEMs on de.id_diadiem equals imt.ID
                                             where de.id_tour == t.Id
                                             select new Location()
                                             {
                                                 DIACHI = imt.DIACHI,
                                                 TENDIADIEM = imt.TENDIADIEM,
                                                 MAP = imt.MAP,
                                                 MOTA = imt.MOTA,
                                                 Images = (from img in _context.image_DIADIEMs.AsNoTracking()
                                                           where img.id_DIADIEM == imt.ID
                                                           select img.Name).ToList(),
                                             }).ToList(),

                              }).ToListAsync();


            return tours;
        }

        public async Task<List<TourVM>> getAllTour()
        {
           var tours = await (from t in _context.tours.AsNoTracking()
                             select new TourVM()
                      {
                                 Id= t.Id,
                          Name = t.Name,
                          Description = t.Description,
                          startDate = t.startDate,
                          endDate = t.endDate,  
                          Price = t.Price,
                          Amount = t.Amount,
                          num_day = t.num_day,
                          diadiem = (from  de in _context.detailTours.AsNoTracking() 
                                    join imt in _context.DIADIEMs on de.id_diadiem equals imt.ID
                                     where de.id_tour == t.Id
                                    select new Location()
                                    {
                                        DIACHI = imt.DIACHI,
                                        TENDIADIEM = imt.TENDIADIEM,
                                        MAP = imt.MAP,
                                        MOTA = imt.MOTA,
                                        Images = (from img in _context.image_DIADIEMs.AsNoTracking()
                                                  where img.id_DIADIEM == imt.ID select img.Name).ToList(),
                                    } ).ToList(),

                      }).ToListAsync();
            return tours;
        }

        public async Task<TourVM> getTour(int id)
        {
            var tour = await (from t in _context.tours.AsNoTracking()
                              where t.Id == id
                              select new TourVM()
                              {
                                  Id = t.Id,
                                  Name = t.Name,
                                  Description = t.Description,
                                  startDate = t.startDate,
                                  endDate = t.endDate,
                                  Price = t.Price,
                                  Amount = t.Amount,
                                  num_day = t.num_day,
                                  diadiem = (from de in _context.detailTours.AsNoTracking()
                                             join imt in _context.DIADIEMs on de.id_diadiem equals imt.ID
                                             where de.id_tour == t.Id
                                             select new Location()
                                             {
                                                 DIACHI = imt.DIACHI,
                                                 TENDIADIEM = imt.TENDIADIEM,
                                                 MAP = imt.MAP,
                                                 MOTA = imt.MOTA,
                                                 Images = (from img in _context.image_DIADIEMs.AsNoTracking()
                                                           where img.id_DIADIEM == imt.ID
                                                           select img.Name).ToList(),
                                             }).ToList(),

                              }).FirstOrDefaultAsync();
            return tour;
        }


        //public Task<List<ViewModel.TourVM>> getAllTour()
        //{
        //    var tour = (from t in _context.tours.AsNoTracking()
        //                select new Tou
        //                {

        //                });
        //}
        //public Task<List<TourModel>> getAllTour()
        //{
        //    var tour = from t in _context.tours.AsNoTracking()
        //               select new Tour
        //}
    }
}
