using ConnX.Core.Common;

namespace ConnX.Core.CreditCardChecker.CardTypeRules.Common
{
    internal interface ICardTypeRule
    {
        bool TypeMatches { get; }

        ValidationResult Check(CreditCard creditCard);
    }
}
