namespace ConnX.Core.CreditCardChecker.CardTypeRules.Errors
{
    /// <summary>
    /// Represents a card type validation error which occurs when an input has an incorrect format
    /// </summary>
    public class CardTypeFormatError : ICardTypeValidationError
    {
        public string ErrorMessage { get; }

        public CardTypeFormatError(string cardType)
        {
            ErrorMessage = $"Invalid format for card type '{cardType}'";
        }
    }
}
