﻿using SULS.App.ViewModels.Submissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Problems
{
  public  class ProblemDetailsViewModel
    {
        public string Name { get; set; }

        public string ProblemId { get; set; }

        public IEnumerable<SubmissionDetailsViewModel> Submissions { get; set; }
    }
}
