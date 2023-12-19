using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.CardTypeRules.CardTypes;
using ConnX.Core.CreditCardChecker.CardTypeRules.Common;
using ConnX.Core.CreditCardChecker.Common;

namespace ConnX.Core.CreditCardChecker.CardTypeRules
{
    /// <summary>
    /// Constructs and uses a list of card type rules to use for validation, which allows for easy extensibility.
    /// Note that the order of the rules is important, as the first valid result is returned.
    /// </summary>
    /// <param name="creditCard"></param>
    internal class CardTypeRuleChecker(CreditCard creditCard) : ICreditCardRule
    {
        private readonly List<ICardTypeRule> _rules =
            [
                new AmexRule(creditCard),
                new DiscoverRule(creditCard),
                new MasterCardRule(creditCard),
                new VisaRule(creditCard)
            ];

        /// <summary>
        /// Checks the credit card against the list of rules and returns the first valid result.
        /// </summary>
        /// <returns></returns>
        public GenericValidationResult Check()
        {
            var result = new GenericValidationResult
            {
                IsValid = false,
                CardType = "Unknown",
                ErrorMessage = "Unknown Card Type"
            };

            foreach (var rule in _rules)
            {
                var typeCheckResult = rule.Check();

                if(typeCheckResult.IsValid)
                {
                    return new GenericValidationResult
                    {
                        IsValid = true,
                        CardType = rule.CardType
                    };
                }                
            }

            return result;
        }
    }
}
