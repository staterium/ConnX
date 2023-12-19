using ConnX.Core.Common;
using ConnX.Core.CreditCardChecker.AlgorithmicRules.Common;
using ConnX.Core.CreditCardChecker.Common;

namespace ConnX.Core.CreditCardChecker.AlgorithmicRules.Algorithms
{
    public class LuhnRule : CreditCardRuleBase, IAlgorithmicRule
    {
        public LuhnRule(CreditCard creditCard) : base(creditCard)
        {
        }

        public GenericValidationResult Check()
        {
            var numbers = CreditCard.Number.ToCharArray().Select(s => s - '0').ToList();

            for (var i = numbers.Count - 2; i >= 0; i -= 2)
            {
                var doubled = numbers[i] * 2;
                numbers[i] = doubled > 9 ? doubled - 9 : doubled;
            }

            var luhnResult = numbers.Sum() % 10 == 0;

            return new GenericValidationResult
            {
                IsValid = luhnResult,
                ErrorMessage = luhnResult ? "" : "Invalid Luhn number"
            };
        }
    }
}
