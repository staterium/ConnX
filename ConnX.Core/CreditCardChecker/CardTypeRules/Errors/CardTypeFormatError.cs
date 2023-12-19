namespace ConnX.Core.CreditCardChecker.CardTypeRules.Errors
{
    public class CardTypeFormatError : ICardTypeValidationError
    {
        public string ErrorMessage { get; }

        public CardTypeFormatError(string cardType)
        {
            ErrorMessage = $"Invalid format for card type '{cardType}'";
        }
    }
}
