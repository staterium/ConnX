using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.CardTypeRules.CardTypes;
using ConnX.Core.CreditCardChecker.CardTypeRules.Common;
using ConnX.Core.CreditCardChecker.Common;

namespace ConnX.Core.CreditCardChecker.CardTypeRules
{
    internal class CardTypeRuleChecker(CreditCard creditCard) : ICreditCardRule
    {
        private readonly List<ICardTypeRule> _rules =
            [
                new AmexRule(creditCard),
                new DiscoverRule(creditCard),
                new MasterCardRule(creditCard),
                new VisaRule(creditCard)
            ];

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
