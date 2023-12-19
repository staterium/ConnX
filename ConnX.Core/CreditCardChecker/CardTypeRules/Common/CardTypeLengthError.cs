namespace ConnX.Core.CreditCardChecker.CardTypeRules.Common
{
    public class CardTypeLengthError : ICardTypeValidationError
    {
        public string ErrorMessage { get; }

        public CardTypeLengthError(string cardType) 
        {
            ErrorMessage = $"Invalid length for card type '{cardType}'";
        }
    }
}
