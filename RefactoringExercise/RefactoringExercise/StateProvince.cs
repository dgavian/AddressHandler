using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringExercise
{
    public class StateProvince
    {
        public int StateProvinceId { get; set; }
        public string ShortName { get; internal set; }
        public string Name { get; internal set; }
    }
}
