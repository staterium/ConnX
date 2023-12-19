using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.AlgorithmicRules;
using ConnX.Core.CreditCardChecker.CardTypeRules;
using ConnX.Core.CreditCardChecker.Common;

namespace ConnX.Core.CreditCardChecker
{
    /// <summary>
    /// Constructs and uses a list of card rules to use for validation, which allows for easy extensibility.
    /// In this instance we check the card type rule (which is in iteslf a list of rules), as well as an algorithmic Luhn rule.
    /// Note the order of the rules is important, as the first invalid result is returned.
    /// </summary>
    /// <param name="creditCard"></param>
    public class CreditCardChecker(CreditCard creditCard)
    {
        private readonly List<ICreditCardRule> _rules =
            [
                new CardTypeRuleChecker(creditCard),
                new AlgorithmicRuleChecker(creditCard)
            ];

        public GenericValidationResult Check()
        {
            var result = new GenericValidationResult
            {
                IsValid = false,
                CardType = "Unknown"
            };

            foreach (var rule in _rules)
            {
                var ruleCheck = rule.Check();

                if (!ruleCheck.IsValid)
                {
                    result.ErrorMessage = ruleCheck.ErrorMessage;
                    return result;
                }

                if (ruleCheck.IsValid && rule is CardTypeRuleChecker)
                {
                    result.CardType = ruleCheck.CardType;
                }

            }

            result.IsValid = true;
            return result;
        }
    }
}
