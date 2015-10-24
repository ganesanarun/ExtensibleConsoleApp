using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using ExtensibleLoanCalculator.Lab;

namespace ExtensibleLoanCalculator.Lab
{
    public class LoanCalculatorContainer
    {
        private CompositionContainer container;
        private DirectoryCatalog catalog;

        [ImportMany(AllowRecomposition = true)]
        public List<Lazy<ILoanCalculator, IPluginInfo>> Extensions { get; set; }

        public LoanCalculatorContainer(string extensionsPath)
        {
            catalog = new DirectoryCatalog(extensionsPath);
            container = new CompositionContainer(catalog);

            LoadExtensions();
        }

        public void LoadExtensions()
        {
            try
            {
                catalog.Refresh();
                container.ComposeParts(this);    
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
    }
}
