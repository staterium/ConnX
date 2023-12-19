using ConnX.Core.CreditCardChecker.CardTypeRules.Errors;

namespace ConnX.Core.CreditCardChecker.CardTypeRules.Common
{
    /// <summary>
    /// Represents a card type validation result.
    /// </summary>
    public class CardTypeValidationResult
    {
        /// <summary>
        /// Indicates whether the card type is valid, meaning the card is of the correct type and length.
        /// </summary>
        public bool IsValid => StartsWithRightNumbers && IsRightLength;

        /// <summary>
        /// The error that occurred during validation.
        /// </summary>
        public ICardTypeValidationError Error { get; private set; }

        /// <summary>
        /// Indicates whether the card number starts with the correct numbers for the card type.
        /// </summary>
        public bool StartsWithRightNumbers { get; set; }

        /// <summary>
        /// Indicates whether the card number is the correct length for the card type.
        /// </summary>
        public bool IsRightLength { get; set; }

        public CardTypeValidationResult(bool startsWithRightNumbers, bool isRightLength, ICardTypeValidationError error = null)
        {
            StartsWithRightNumbers = startsWithRightNumbers;
            IsRightLength = isRightLength;
            Error = error;
        }
    }
}
