using CarShop.ViewModels;

namespace CarShop.Contracts
{
    public interface IIssueService
    {
        (bool added, string error) AddIssue(AddIssuesViewModel model);

        CarIssuesViewModel GetIssues(string carId);

        IEnumerable<TestViewModel> GetIssues2(string carId);

        void FixIssue(string issueId, string userId);

        void DeleteIssue(string issueId);
    }
}