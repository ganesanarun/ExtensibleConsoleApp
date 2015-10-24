using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensibleLoanCalculator.AccruedLoanCalculator
{
    [Export(typeof(ILoanCalculator))]
    [ExportMetadata("DisplayName", "Accured Loan Calculator")]
    [ExportMetadata("Description", "Using accrued loan calculation")]
    [ExportMetadata("Version", "1.1")]
    public class AccruedLoanCalculator : ILoanCalculator
    {

        #region ILoanCalculator Members

        public decimal GetInterest(decimal amount, double interestRate, int noOfMonths)
        {
            return (amount * noOfMonths * GetPNR(interestRate));
        }

        private decimal GetPNR(double interestRate)
        {
            return (decimal)interestRate * 5 / 100;
        }

        #endregion
    }
}
