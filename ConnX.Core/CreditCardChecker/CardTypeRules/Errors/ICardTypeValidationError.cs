namespace ConnX.Core.CreditCardChecker.CardTypeRules.Errors
{
    /// <summary>
    /// Represents a card type validation error.
    /// </summary>
    public interface ICardTypeValidationError
    {
        public string ErrorMessage { get; }
    }
}
