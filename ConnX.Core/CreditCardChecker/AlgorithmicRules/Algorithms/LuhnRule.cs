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
            throw new NotImplementedException();
        }
    }
}
