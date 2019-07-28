using SULS.Data;
using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly SULSContext db;

        public ProblemsService(SULSContext db)
        {
            this.db = db;
        }

        public void Create(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points,
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public IQueryable<Problem> GetAllProblems()
        {
            var allProblems = this.db.Problems;
            return allProblems;
        }

        public string GetProblemName(string id)
        {
            var name = this.db.Problems.Where(x => x.Id == id).Select(x => x.Name).FirstOrDefault();
            //if (name == null)
            //{
            //    return "";
            //}
            return name;
        }
    }
}
