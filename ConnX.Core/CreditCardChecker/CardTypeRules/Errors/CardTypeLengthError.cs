namespace ConnX.Core.CreditCardChecker.CardTypeRules.Errors
{
    /// <summary>
    /// Represents a card type validation error which occurs when an input has an incorrect length
    /// </summary>
    public class CardTypeLengthError : ICardTypeValidationError
    {
        public string ErrorMessage { get; }

        public CardTypeLengthError(string cardType)
        {
            ErrorMessage = $"Invalid length for card type '{cardType}'";
        }
    }
}
