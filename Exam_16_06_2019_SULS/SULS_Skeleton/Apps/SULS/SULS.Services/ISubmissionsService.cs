using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.Services
{
   public interface ISubmissionsService
    {
        int GetSubmissionsCount(string userId, string problemId);

        void CreateSubmission(string userId, string ProblemId, string Code);

        IQueryable<Submission> GetAllSubmissions(string userId, string problemId);

       bool Delete(string submissionId);
    }
}
