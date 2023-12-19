using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.CardTypeRules.Common;
using ConnX.Core.CreditCardChecker.Common;

namespace ConnX.Core.CreditCardChecker.CardTypeRules.CardTypes
{
    public class MasterCardRule : CreditCardRuleBase, ICardTypeRule
    {
        public string CardType => "MasterCard";

        public MasterCardRule(CreditCard creditCard) : base(creditCard)
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

            var firstTwoDigits = int.Parse(CreditCard.Number[0..2]);

            if (firstTwoDigits < 51 || firstTwoDigits > 55)
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
