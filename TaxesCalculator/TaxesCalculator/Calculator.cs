using System;

namespace TaxesCalculator
{
    public class Calculator
    {
        public static float Calculate(object p1, string taxType)
        {
            if(p1 is Person p)
            {
                // no taxes
                if (taxType == "none")
                {
                    return p.SalaryBeforeTaxes;
                }
                // fixed taxes
                else if (taxType == "fixed")
                {
                    return p.SalaryBeforeTaxes * 0.95f;
                }
                // progressive taxes
                else if(taxType == "progressive")
                {
                    if (p.SalaryBeforeTaxes < 1000)
                    {
                        return p.SalaryBeforeTaxes;
                    }
                    else if (p.SalaryBeforeTaxes > 1000 && p.SalaryBeforeTaxes < 2000)
                    {
                        return p.SalaryBeforeTaxes * 0.9f;
                    }
                    else if (p.SalaryBeforeTaxes > 2000 && p.SalaryBeforeTaxes < 10000)
                    {
                        return p.SalaryBeforeTaxes * 0.8f;
                    }
                    else if (p.SalaryBeforeTaxes > 10000)
                    {
                        return p.SalaryBeforeTaxes * 0.7f;
                    }

                    // this should never happen.
                    throw new ApplicationException();
                }
                else
                {
                    throw new ApplicationException("Unrecognized tax");
                }
            }
            else
            {
                throw new ApplicationException("Not a person");
            }

        }
    }
}
