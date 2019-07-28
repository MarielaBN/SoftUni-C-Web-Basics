using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.App.ViewModels.Submissions;
using SULS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.App.Controllers
{
  public  class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public ProblemsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }

        [Authorize]
        public IActionResult Create()
        {            
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Problems/Create");
            }

            this.problemsService.Create(input.Name, input.Points);
            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var userId = this.User.Id;

            var userAllSubmissions = this.submissionsService.GetAllSubmissions(userId, id)
                    .Select(x => new SubmissionDetailsViewModel
                    {
                        SubmissionId = x.Id,
                        Username = x.User.Username,
                        AchievedResult = x.AchievedResult,
                        MaxPoints = x.Problem.Points,
                        CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy"),
                        //CreatedOn = x.CreatedOn.ToShortDateString(),
                    }).ToList();


            var createProblemDetailsView = new ProblemDetailsViewModel
            {
                Name = this.problemsService.GetProblemName(id),
                ProblemId = id,
                Submissions = userAllSubmissions,
            };
            return this.View(createProblemDetailsView);
        }
    }
}
