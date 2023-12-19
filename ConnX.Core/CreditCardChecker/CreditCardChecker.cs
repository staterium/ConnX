using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.AlgorithmicRules;
using ConnX.Core.CreditCardChecker.CardTypeRules;
using ConnX.Core.CreditCardChecker.CardTypeRules.Common;
using ConnX.Core.CreditCardChecker.Common;

namespace ConnX.Core.CreditCardChecker
{
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
