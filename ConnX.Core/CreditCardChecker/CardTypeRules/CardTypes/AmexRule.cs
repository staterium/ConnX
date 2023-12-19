using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.CardTypeRules.Common;

namespace ConnX.Core.CreditCardChecker.CardTypeRules.CardTypes
{
    public class AmexRule : CardTypeRuleBase, ICardTypeRule
    {
        public AmexRule(CreditCard creditCard) : base(
            creditCard: creditCard,
            cardType: "AMEX",
            validStartsWith: new List<int> { 34, 37 },
            validLength: new List<int> { 15 })
        {
        
        }
    }
}
