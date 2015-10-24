
using System.ComponentModel.Composition;

namespace ExtensibleLoanCalculator
{
    [InheritedExport(typeof(ILoanCalculator))]
    public interface ILoanCalculator
    {
        decimal GetInterest(decimal amount, double interestRate, int noOfMonths);
    }
}
