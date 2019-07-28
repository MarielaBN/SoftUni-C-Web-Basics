using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.Services
{
   public interface IProblemsService
    {
        void Create(string name, int points);

        IQueryable<Problem> GetAllProblems();

        string GetProblemName(string id);
    }
}
