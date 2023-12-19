using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.CardTypeRules.CardTypes;
using ConnX.Core.CreditCardChecker.CardTypeRules.Common;
using ConnX.Core.CreditCardChecker.Common;

namespace ConnX.Core.CreditCardChecker.CardTypeRules
{
    internal class CardTypeRuleChecker : ICreditCardRule
    {
        private readonly List<ICardTypeRule> _rules;

        public CardTypeRuleChecker() 
        {
            _rules = 
            [
                new AmexRule(),
                new DiscoverRule(),
                new MasterCardRule(),
                new VisaRule()
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
                if (rule.TypeMatches)
                {
                    result = rule.Check(creditCard);
                    break;
                }
            }

            return result;
        }
    }
}
