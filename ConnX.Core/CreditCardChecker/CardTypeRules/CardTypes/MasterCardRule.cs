using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.CardTypeRules.Common;

namespace ConnX.Core.CreditCardChecker.CardTypeRules.CardTypes
{
    internal class MasterCardRule : ICardTypeRule
    {
        public bool TypeMatches => throw new NotImplementedException();

        public ValidationResult Check(CreditCard creditCard)
        {
            throw new NotImplementedException();
        }
    }
}
