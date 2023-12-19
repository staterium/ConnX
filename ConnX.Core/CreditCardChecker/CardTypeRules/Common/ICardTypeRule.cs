namespace ConnX.Core.CreditCardChecker.CardTypeRules.Common
{
    /// <summary>
    /// Represents a card type rule. This allws us to have a list of rules that we can iterate over and check the card against, and add more rules as needed.
    /// </summary>
    internal interface ICardTypeRule
    {
        string CardType { get; }

        CardTypeValidationResult Check();
    }
}
