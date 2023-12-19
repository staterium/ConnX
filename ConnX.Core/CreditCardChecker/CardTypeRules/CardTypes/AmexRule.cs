using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.CardTypeRules.Common;
using ConnX.Core.CreditCardChecker.Common;

namespace ConnX.Core.CreditCardChecker.CardTypeRules.CardTypes
{
    public class AmexRule : CreditCardRuleBase, ICardTypeRule
    {
        public string CardType => "AMEX";

        public AmexRule(CreditCard creditCard) : base(creditCard)
        {
        }
        
        public CardTypeValidationResult Check()
        {
            throw new NotImplementedException();
        }
    }
}
