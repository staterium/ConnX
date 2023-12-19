using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.AlgorithmicRules.Algorithms;
using ConnX.Core.CreditCardChecker.AlgorithmicRules.Common;
using ConnX.Core.CreditCardChecker.Common;

namespace ConnX.Core.CreditCardChecker.AlgorithmicRules
{
    internal class AlgorithmicRuleChecker : ICreditCardRule
    {
        private readonly List<IAlgorithmicRule> _rules;

        public AlgorithmicRuleChecker()
        {
            _rules =
            [
                new LuhnRule()
            ];
        }

        public ValidationResult Check(CreditCard creditCard)
        {
            var result = new ValidationResult
            {
                IsValid = true
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
