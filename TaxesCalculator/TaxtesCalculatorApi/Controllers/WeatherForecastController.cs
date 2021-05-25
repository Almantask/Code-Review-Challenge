using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxesCalculator;

namespace TaxtesCalculatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet("{taxType}")]
        public IEnumerable<Person> GetSalaryAfterTaxesReport(string taxType)
        {
            const string connStr = "Server=production.totally;Database=workplace22;User Id=Admin1;Password=abc123";
            var r = new RepositoryOfAllThePeople(connStr);
            // Getting people
            var p = r.getData().Result;

            // Calculating salaries after taxes
            Console.WriteLine("Calculating Salary after taxes");
            foreach (var p1 in p)
            {
                if (p1 != null)
                {
                    // Logging secret data
                    Console.WriteLine("Calculating data of person " +
                                      "with private identifier: " + p1.SecretId +
                                      "name: " + p1.Name +
                                      "salary: " + p1.SalaryBeforeTaxes);

                    // Calculating salary
                    var s = Calculator.Calculate(p1, taxType);
                    p1.SalaryBeforeTaxes = s;
                    // Printing salary after taxes
                    Console.WriteLine(p1.SalaryBeforeTaxes);
                }
                else
                {
                    Console.WriteLine("Invalid person- skipping");
                }
            }

            return p;
        }
    }
}
