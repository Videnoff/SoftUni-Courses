using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public CarService(IRepository repo, IValidationService validationService)
        {
            this.repo = repo;
            this.validationService = validationService;
        }

        public (bool added, string error) AddCar(AddCarViewModel model, string userId)
        {
            bool added = false;

            (bool isValid, string error) = validationService.ValidateModel(model);

            int year = 0;

            if (!isValid)
            {
                //if (!decimal.TryParse(model.Price, NumberStyles.Float, CultureInfo.InvariantCulture, out price) || price < 0.05M || price > 1000M)
                if (!int.TryParse(model.Year, out year))
                {
                    return (isValid, $"{error}, Year must be a valid number");
                }

                return (isValid, error);
            }

            var car = new Car();

            //if (!decimal.TryParse(model.Price, NumberStyles.Float, CultureInfo.InvariantCulture, out price) || price < 0.05M || price > 1000M)
            if (!int.TryParse(model.Year, out year))
            {
                return (false, "Year must be a valid number");
            }

            car.Model = model.Model;
            car.Year = year;
            car.PictureUrl = model.ImageUrl;
            car.PlateNumber = model.PlateNumber;
            car.OwnerId = userId;

            try
            {
                repo.Add(car);
                repo.SaveChanges();
                added = true;
            }
            catch (Exception)
            {
                error = "Could not save car in DB";
            }

            return (added, error);
        }

        public IEnumerable<AllCarsViewModel> GetCars(string userId)
        {
            if (isMechanic(userId))
            {
                return repo.All<Car>()
                .Where(w => w.Issues.Count(c => !c.IsFixed) >= 1)
                .Select(s => new AllCarsViewModel
                {
                    Id = s.Id,
                    CarPlate = s.PlateNumber,
                    Year = s.Year.ToString(),
                    Model = s.Model,
                    Img = s.PictureUrl,
                    RemIssues = s.Issues.Count(c => !c.IsFixed).ToString(),
                    FixIssues = s.Issues.Count(c => c.IsFixed).ToString()
                })
                .ToArray();
            }

            else
            {
                return repo.All<Car>()
                .Where(w => w.OwnerId == userId)
                .Select(s => new AllCarsViewModel
                {
                    Id = s.Id,
                    CarPlate = s.PlateNumber,
                    Year = s.Year.ToString(),
                    Model = s.Model,
                    Img = s.PictureUrl,
                    RemIssues = s.Issues.Count(c => !c.IsFixed).ToString(),
                    FixIssues = s.Issues.Count(c => c.IsFixed).ToString()
                })
                .ToArray();
            }
        }

        public bool isMechanic(string userId)
        {
            return repo.All<User>().Where(w => w.Id == userId).Select(s => s.IsMechanic).FirstOrDefault();
        }
    }
}