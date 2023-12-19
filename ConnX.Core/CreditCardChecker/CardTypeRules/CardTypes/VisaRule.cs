using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.CardTypeRules.Common;

namespace ConnX.Core.CreditCardChecker.CardTypeRules.CardTypes
{
    public class VisaRule : CardTypeRuleBase, ICardTypeRule
    {
        public VisaRule(CreditCard creditCard) : base(
            creditCard: creditCard,
            cardType: "Visa",
            validStartsWith: new List<int> { 4 },
            validLength: new List<int> { 13, 14, 15, 16 })
        { }        
    }
}
