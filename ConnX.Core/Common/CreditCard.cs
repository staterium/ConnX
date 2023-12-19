namespace ConnX.Core.Common
{
    /// <summary>
    /// Represents an instance of a credit card
    /// </summary>
    public class CreditCard
    {
        public CreditCard(string number)
        {
            Number = number;
        }

        public string Number { get; set; }
    }
}
