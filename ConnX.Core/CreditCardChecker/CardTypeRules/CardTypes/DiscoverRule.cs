using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.CardTypeRules.Common;

namespace ConnX.Core.CreditCardChecker.CardTypeRules.CardTypes
{
    /// <summary>
    /// A validation rule that checks if a credit card is a Discover card.
    /// </summary>
    public class DiscoverRule : CardTypeRuleBase, ICardTypeRule
    {
        public DiscoverRule(CreditCard creditCard) : base(
            creditCard: creditCard,
            cardType: "Discover",
            validStartsWith: new List<int> { 6011 },
            validLength: new List<int> { 16 })
        { 
        
        }
    }
}
