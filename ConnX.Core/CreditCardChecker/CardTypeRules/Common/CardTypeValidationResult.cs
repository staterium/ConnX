using ConnX.Core.CreditCardChecker.CardTypeRules.Errors;

namespace ConnX.Core.CreditCardChecker.CardTypeRules.Common
{
    public class CardTypeValidationResult
    {
        public bool IsValid => StartsWithRightNumbers && IsRightLength;

        public ICardTypeValidationError Error { get; private set; }

        public bool StartsWithRightNumbers { get; set; }

        public bool IsRightLength { get; set; }

        public CardTypeValidationResult(bool startsWithRightNumbers, bool isRightLength, ICardTypeValidationError error = null)
        {
            StartsWithRightNumbers = startsWithRightNumbers;
            IsRightLength = isRightLength;
            Error = error;
        }
    }
}
