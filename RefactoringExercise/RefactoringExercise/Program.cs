using System;

namespace RefactoringExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            // US
            int? countryId = 1;
            string countryName = null;
            string postalCode = "12345";
            var usAddress = AddressHandler.PopulateDetails(countryId, countryName, postalCode);
            Console.WriteLine("Address country: {0}", usAddress.Country.Name);
            Console.WriteLine("Address postal code: {0}", usAddress.PostalCode);

            Console.WriteLine();

            // Canada
            countryId = new int?();
            countryName = "Canada";
            postalCode = "CAN-123";
            var canadaAddress = AddressHandler.PopulateDetails(countryId, countryName, postalCode);
            Console.WriteLine("Address country: {0}", canadaAddress.Country.Name);
            Console.WriteLine("Address postal code: {0}", canadaAddress.PostalCode);

            Console.ReadKey();
        }
    }
}
