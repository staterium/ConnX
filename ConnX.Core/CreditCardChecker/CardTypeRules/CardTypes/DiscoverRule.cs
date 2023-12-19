using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.CardTypeRules.Common;
using ConnX.Core.CreditCardChecker.Common;

namespace ConnX.Core.CreditCardChecker.CardTypeRules.CardTypes
{
    public class DiscoverRule : CreditCardRuleBase, ICardTypeRule
    {
        public string CardType => "Discover";
        
        public DiscoverRule(CreditCard creditCard) : base(creditCard)
        {
        }
                
        public CardTypeValidationResult Check()
        {
            if (string.IsNullOrEmpty(CreditCard.Number))
            {
                return new CardTypeValidationResult(
                    startsWithRightNumbers: false,
                    isRightLength: false,
                    error: new CardTypeLengthError(CardType));
            }

            if (CreditCard.Number.Length != 16)
            {
                return new CardTypeValidationResult(
                    startsWithRightNumbers: false,
                    isRightLength: false,
                    error: new CardTypeLengthError(CardType));
            }

            if (CreditCard.Number[0..4] != "6011")
            {
                return new CardTypeValidationResult(
                    startsWithRightNumbers: false,
                    isRightLength: false,
                    error: new CardTypeStartsWithError(CardType));
            }

            return new CardTypeValidationResult(
                    startsWithRightNumbers: true,
                    isRightLength: true);
        }
    }
}
