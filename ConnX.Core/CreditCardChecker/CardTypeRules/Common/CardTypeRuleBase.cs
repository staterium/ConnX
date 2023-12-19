using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.CardTypeRules.Errors;

namespace ConnX.Core.CreditCardChecker.CardTypeRules.Common
{
    /// <summary>
    /// A common base class that all card type rules inherit from.
    /// </summary>
    public class CardTypeRuleBase
    {
        /// <summary>
        /// The name of the card type.
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// The credit card to check.
        /// </summary>
        public CreditCard CreditCard { get; set; }

        /// <summary>
        /// The valid start numbers for the card type.
        /// </summary>
        public List<int> ValidStartsWith { get; set; }

        /// <summary>
        /// The valid lengths for the card type.
        /// </summary>
        public List<int> ValidLength { get; set; }

        public CardTypeRuleBase(CreditCard creditCard, string cardType, List<int> validStartsWith, List<int> validLength)
        {
            if (creditCard == null)
            {
                throw new ArgumentNullException(nameof(creditCard));
            }

            if (string.IsNullOrEmpty(cardType))
            {
                throw new ArgumentNullException(nameof(cardType));
            }

            if (!validStartsWith.Any())
            {
                throw new ArgumentNullException(nameof(validStartsWith));
            }

            if (!validLength.Any())
            {
                throw new ArgumentNullException(nameof(validLength));
            }

            CreditCard = creditCard;
            CardType = cardType;
            ValidStartsWith = validStartsWith;
            ValidLength = validLength;
        }

        /// <summary>
        /// Performs the card type checks as determined by the paramaters of the card type.
        /// </summary>
        /// <returns>
        /// A <see cref="CardTypeValidationResult"/> containing the results of the card type checks.
        /// </returns>
        public CardTypeValidationResult Check()
        {
            if (string.IsNullOrEmpty(CreditCard.Number))
            {
                return new CardTypeValidationResult(
                    startsWithRightNumbers: false,
                    isRightLength: false,
                    error: new CardTypeLengthError(CardType));
            }

            if (!long.TryParse(CreditCard.Number, out _))
            {
                return new CardTypeValidationResult(
                    startsWithRightNumbers: false,
                    isRightLength: false,
                    error: new CardTypeFormatError(CardType));
            }

            var startsWithLength = ValidStartsWith.First().ToString().Length;

            if (!ValidStartsWith.Contains(int.Parse(CreditCard.Number[0..startsWithLength])))
            {
                return new CardTypeValidationResult(
                    startsWithRightNumbers: false,
                    isRightLength: false,
                    error: new CardTypeStartsWithError(CardType));
            }

            if (!ValidLength.Contains(CreditCard.Number.Length))
            {
                return new CardTypeValidationResult(
                    startsWithRightNumbers: false,
                    isRightLength: false,
                    error: new CardTypeLengthError(CardType));
            }
            return new CardTypeValidationResult(
                startsWithRightNumbers: true,
                isRightLength: true);
        }
    }
}
