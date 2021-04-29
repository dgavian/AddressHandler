using System.Collections.Generic;

namespace RefactoringExercise
{
    public class CountryRepository
    {
        public List<Country> GetCountries()
        {
            var countries = new List<Country>
            {
                new Country
                {
                    CountryId = 1,
                    Name = "United States",
                    ShortName = "US",
                    StateProvinces = new List<StateProvince>
                    {
                        new StateProvince
                        {
                            Name = "Colorado",
                            ShortName = "CO",
                            StateProvinceId = 6
                        },
                        new StateProvince
                        {
                            Name = "Nevada",
                            ShortName = "NV",
                            StateProvinceId = 28
                        }
                    }
                },
                                new Country
                {
                    CountryId = 2,
                    Name = "Canada",
                    ShortName = "CA",
                    StateProvinces = new List<StateProvince>
                    {
                        new StateProvince
                        {
                            Name = "Quebec",
                            ShortName = "Quebec",
                            StateProvinceId = 52
                        }
                    }
                }
            };

            return countries;
        }
    }
}
