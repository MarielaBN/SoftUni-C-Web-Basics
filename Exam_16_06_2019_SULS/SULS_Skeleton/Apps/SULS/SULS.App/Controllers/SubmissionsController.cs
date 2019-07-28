using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Submissions;
using SULS.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.Controllers
{
   public class SubmissionsController: Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }

        [Authorize]
        public IActionResult Create(string id)
        {

            var createSubmissionView = new SubmissionViewModel
            {
                Name = this.problemsService.GetProblemName(id),
                ProblemId = id,
            };
            return this.View(createSubmissionView);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(SubmissionInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect($"/Submissions/Create?id={input.ProblemId}");
            }

            var userId = this.User.Id;

            this.submissionsService.CreateSubmission(userId, input.ProblemId, input.Code);

            return this.Redirect("/");
        }

        //[Authorize]
        //public IActionResult Delete(string id)
        //{
        //    this.packagesService.Deliver(id);
        //    return this.Redirect("/Packages/Delivered");
        //}
    }
}
