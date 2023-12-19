using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.AlgorithmicRules.Algorithms;
using ConnX.Core.CreditCardChecker.AlgorithmicRules.Common;
using ConnX.Core.CreditCardChecker.Common;

namespace ConnX.Core.CreditCardChecker.AlgorithmicRules
{
    /// <summary>
    /// This class is responsible for checking the credit card number against all the algorithmic rules.
    /// </summary>
    internal class AlgorithmicRuleChecker : ICreditCardRule
    {
        private readonly List<IAlgorithmicRule> _rules;

        public AlgorithmicRuleChecker(CreditCard creditCard)
        {
            _rules =
            [
                new LuhnRule(creditCard)
            ];
        }

        public GenericValidationResult Check()
        {
            var result = new GenericValidationResult
            {
                IsValid = true
            };

            foreach (var rule in _rules)
            {
                result = rule.Check();
                break;
            }

            return result;
        }
    }
}
