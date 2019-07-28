using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SULS.Data;
using SULS.Models;

namespace SULS.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly SULSContext db;

        public SubmissionsService(SULSContext db)
        {
            this.db = db;
        }

        public void CreateSubmission(string userId, string problemId, string code)
        {
            var problemTotalPoints = this.db.Problems.Where(x => x.Id == problemId).Select(x => x.Points).FirstOrDefault();

            if (problemTotalPoints == 0)
            {
                return;               
            }

            Random rnd = new Random();            
            int result = rnd.Next(problemTotalPoints+1);

            var submission = new Submission
            {
                Code = code,
                AchievedResult = result,
                CreatedOn =DateTime.UtcNow,
                ProblemId = problemId,
                UserId = userId,
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public int GetSubmissionsCount(string userId, string problemId)
        {
            if (userId == null || problemId == null)
            {
                return 0;
            }
            else
            {
                var allSubmissionsCount = this.db.Submissions.Where(x => x.UserId == userId && x.ProblemId == problemId).ToList().Count();
                return allSubmissionsCount;
            }            
        }

        public IQueryable<Submission> GetAllSubmissions(string userId, string problemId)
        {
            var allSubmissions = this.db.Submissions.Where(x => x.UserId == userId && x.ProblemId == problemId);
            return allSubmissions;
        }

        //public void Delete(string submissionId)
        //{
        //    var submissionToDelete = this.db.Submissions.Where(x => x.Id == submissionId).FirstOrDefault();
            
        //}
    }
}
