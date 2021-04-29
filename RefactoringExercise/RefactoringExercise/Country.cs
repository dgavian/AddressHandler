using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringExercise
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool PostalCodeRequired => ShortName == "US";
        public List<StateProvince> StateProvinces { get; set; }
    }
}
