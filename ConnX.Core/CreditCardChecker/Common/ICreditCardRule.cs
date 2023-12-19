using ConnX.Core.Common;

namespace ConnX.Core.CreditCardChecker.Common
{
    internal interface ICreditCardRule
    {
        ValidationResult Check(CreditCard creditCard);
    }
}
