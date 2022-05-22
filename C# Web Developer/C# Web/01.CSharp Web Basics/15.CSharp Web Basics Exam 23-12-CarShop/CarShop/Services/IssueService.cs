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
    public class IssueService : IIssueService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public IssueService(IRepository repo, IValidationService validationService)
        {
            this.repo = repo;
            this.validationService = validationService;
        }

        public (bool added, string error) AddIssue(AddIssuesViewModel model)
        {
            bool added = false;

            (bool isValid, string error) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, error);
            }

            var issue = new Issue { Description = model.Description, CarId = model.CarId, IsFixed = false };

            try
            {
                repo.Add(issue);
                repo.SaveChanges();
                added = true;
            }
            catch (Exception)
            {
                error = "Could not save issue in DB";
            }

            return (added, error);
        }

        public IEnumerable<TestViewModel> GetIssues2(string carId)
        {
            return repo.All<Issue>().Where(w => w.CarId == carId).Select(s => new TestViewModel { Description = s.Description, Fixed = s.IsFixed, IssueId = s.Id }).ToArray();
        }

        public CarIssuesViewModel GetIssues(string carId)
        {
            return repo.All<Car>()
                .Where(w => w.Id == carId)
                .Select(s => new CarIssuesViewModel
                {
                    Year = s.Year.ToString(),
                    Model = s.Model,
                    CarId = carId
                })
                .FirstOrDefault();
        }

        public void FixIssue(string issueId, string userId)
        {
            bool isClient = repo.All<User>().Where(w => w.Id == userId).Select(s => !s.IsMechanic).FirstOrDefault();

            if (isClient)
            {
                return;
            }

            var issue = repo.All<Issue>()
                .Where(w => w.Id == issueId)
                .FirstOrDefault();

            issue.IsFixed = true;

            repo.SaveChanges();
        }

        public void DeleteIssue(string issueId)
        {
            var issue = repo.All<Issue>()
                .Where(w => w.Id == issueId)
                .FirstOrDefault();

            repo.Remove<Issue>(issue);
            repo.SaveChanges();
        }

        //public IEnumerable<CarIssuesViewModel> GetIssues(string carId)
        //{
        //    //var issues = repo.All<Issue>().Where(w => w.CarId == carId).Select(s => new CarIssuesViewModel { Model = s.Car.Model, Year = s.Car.Year.ToString(), Description = s.Description }).ToArray();

        //    //return issues.Select(s => new CarIssuesViewModel { Model = s.Car.Model, Year = s.Car.Year.ToString(), Description = s.Description, Fixed = s.IsFixed })

        //    return repo.All<Issue>()
        //        .Where(w => w.CarId == carId)
        //        .Select(s => new CarIssuesViewModel 
        //        {
        //            Description = s.Description, 
        //            Fixed = s.IsFixed 
        //        })
        //        .ToArray();
        //}
    }
}