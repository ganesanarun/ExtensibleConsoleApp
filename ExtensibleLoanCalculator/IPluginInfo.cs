using System;

namespace ExtensibleLoanCalculator
{
    public interface IPluginInfo
    {
        string DisplayName { get; }
        string Description { get; }
        string Version { get; }
    }
}
