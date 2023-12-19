using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.AlgorithmicRules;
using ConnX.Core.CreditCardChecker.CardTypeRules;
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
