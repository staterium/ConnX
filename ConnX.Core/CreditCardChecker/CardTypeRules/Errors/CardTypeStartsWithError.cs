namespace ConnX.Core.CreditCardChecker.CardTypeRules.Errors
{
    /// <summary>
    /// Represents a card type validation error which occurs when an input starts with an invalid number
    /// </summary>
    public class CardTypeStartsWithError : ICardTypeValidationError
    {
        public string ErrorMessage { get; }

        public CardTypeStartsWithError(string cardType)
        {
            ErrorMessage = $"Invalid starting numbers for card type '{cardType}'";
        }
    }
}
