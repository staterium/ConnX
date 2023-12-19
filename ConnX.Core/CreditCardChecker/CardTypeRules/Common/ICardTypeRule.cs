namespace ConnX.Core.CreditCardChecker.CardTypeRules.Common
{
    internal interface ICardTypeRule
    {
        string CardType { get; }

        CardTypeValidationResult Check();
    }
}
