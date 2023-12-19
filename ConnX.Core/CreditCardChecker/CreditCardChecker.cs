using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.AlgorithmicRules;
using ConnX.Core.CreditCardChecker.CardTypeRules;
using ConnX.Core.CreditCardChecker.Common;

namespace ConnX.Core.CreditCardChecker
{
    public class CreditCardChecker
    {
        private readonly List<ICreditCardRule> _rules;

        public CreditCardChecker()
        {
            _rules =
            [
                new CardTypeRuleChecker(),
                new AlgorithmicRuleChecker()
            ];
        }

        public ValidationResult Check(CreditCard creditCard)
        {
            var result = new ValidationResult
            {
                IsValid = false,
                Error = "Unknown Card Type"
            };

            foreach (var rule in _rules)
            {
                result = rule.Check(creditCard);
                break;
            }

            return result;
        }
    }
}
