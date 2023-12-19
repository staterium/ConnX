using ConnX.Core.CreditCardChecker.CardTypeRules.Errors;

namespace ConnX.Core.CreditCardChecker.CardTypeRules.Common
{
    public class CardTypeValidationResult
    {
        public bool IsValid => _startsWithRightNumbers && _isRightLength;

        public ICardTypeValidationError Error { get; private set; }

        private bool _startsWithRightNumbers { get; set; }

        private bool _isRightLength { get; set; }


        public CardTypeValidationResult(bool startsWithRightNumbers, bool isRightLength, ICardTypeValidationError error = null)
        {
            _startsWithRightNumbers = startsWithRightNumbers;
            _isRightLength = isRightLength;
            Error = error;
        }
    }
}
