using System.Collections.Generic;
using TaxesCalculator;

namespace TaxtesCalculatorApi.Controllers
{
    public interface ITaxesController
    {
        IEnumerable<Person> GetSalaryAfterTaxesReport(string taxType);
    }
}