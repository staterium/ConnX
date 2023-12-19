using ConnX.Core.Common;

namespace ConnX.Core.CreditCardChecker.AlgorithmicRules.Common
{
    /// <summary>
    /// Represents an algorithmic rule, which allows us to add more rules in the future.
    /// </summary>
    internal interface IAlgorithmicRule
    {
        GenericValidationResult Check();
    }
}
