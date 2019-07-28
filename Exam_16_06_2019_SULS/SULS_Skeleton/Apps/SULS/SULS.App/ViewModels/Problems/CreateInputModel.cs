using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Problems
{
  public class CreateInputModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, "Name should be between 5 and 20 characters")]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(50, 300, "Points should be an integer between 50 and 300 ")]
        public int Points { get; set; }
    }
}
