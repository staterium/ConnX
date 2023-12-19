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
            if(string.IsNullOrEmpty(CreditCard.Number))
            {
                return new CardTypeValidationResult(
                    startsWithRightNumbers: false,
                    isRightLength: false,
                    error: new CardTypeLengthError(CardType));
            }

            if(CreditCard.Number.Length != 15)
            {
                return new CardTypeValidationResult(
                    startsWithRightNumbers: false, 
                    isRightLength: false,
                    error: new CardTypeLengthError(CardType));
            }

            if (CreditCard.Number[0..2] != "34" && CreditCard.Number[0..2] != "37")
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
