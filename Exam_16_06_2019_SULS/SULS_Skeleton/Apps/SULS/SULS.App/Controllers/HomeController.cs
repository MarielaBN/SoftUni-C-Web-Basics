using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Home;
using SULS.Services;
using System.Linq;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISubmissionsService submissionsService;
        private readonly IProblemsService problemsService;

        public HomeController(ISubmissionsService submissionsService, IProblemsService problemsService)
        {
            this.submissionsService = submissionsService;
            this.problemsService = problemsService;
        }

        // /
        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        // /Home/Index
        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
               return this.IndexLoggedIn();
            }
            else
            {
                return this.View();
            }

            // return this.Json(new { prop = "a"});  
        }

        // /Home/Index
        [Authorize]
        public IActionResult IndexLoggedIn()
        {
            if (this.IsLoggedIn())
            {
                var userId = this.User.Id;               

                var problems = this.problemsService.GetAllProblems()
                    .Select(x => new HomeViewModel
                    {
                        Name = x.Name,
                        Count = this.submissionsService.GetSubmissionsCount(userId, x.Id),
                        Id=x.Id,
                    }).ToList();

                return this.View(new ProblemsListViewModel { Problems = problems });
            }
            else
            {
                return this.View();
            }
        }
    }
}