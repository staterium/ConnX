namespace ConnX.Core.CreditCardChecker.CardTypeRules.Errors
{
    public class CardTypeStartsWithError : ICardTypeValidationError
    {
        public string ErrorMessage { get; }

        public CardTypeStartsWithError(string cardType)
        {
            ErrorMessage = $"Invalid starting numbers for card type '{cardType}'";
        }
    }
}
