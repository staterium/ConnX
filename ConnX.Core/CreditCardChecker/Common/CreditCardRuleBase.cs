using ConnX.Core.Common;

namespace ConnX.Core.CreditCardChecker.Common
{
    public class CreditCardRuleBase
    {
        public CreditCard CreditCard { get; set; }

        public CreditCardRuleBase(CreditCard creditCard)
        {
            CreditCard = creditCard;
        }
    }
}
