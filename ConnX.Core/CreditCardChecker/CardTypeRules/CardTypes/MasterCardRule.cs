using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.CardTypeRules.Common;

namespace ConnX.Core.CreditCardChecker.CardTypeRules.CardTypes
{
    /// <summary>
    /// A validation rule that checks if a credit card is a MasterCard.
    /// </summary>
    public class MasterCardRule : CardTypeRuleBase, ICardTypeRule
    {
        public MasterCardRule(CreditCard creditCard) : base(
            creditCard: creditCard,
            cardType: "MasterCard",
            validStartsWith: new List<int> { 51, 52, 53, 54, 55 },
            validLength: new List<int> { 16 })
        { 
        
        }        
    }
}
