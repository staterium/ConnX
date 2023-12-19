using ConnX.Core.Common;

namespace ConnX.Core.CreditCardChecker.AlgorithmicRules.Common
{
    internal interface IAlgorithmicRule
    {
        ValidationResult Check(CreditCard creditCard);
    }
}
