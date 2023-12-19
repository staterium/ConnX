namespace ConnX.UnitTests
{
    public class CardCheckerTests
    {
        [Theory]
        [InlineData("4111111111111111", true, "Visa")]
        [InlineData("4111111111111", false, "Visa")]
        [InlineData("4012888888881881", true, "Visa")]
        [InlineData("378282246310005", true, "AMEX")]
        [InlineData("6011111111111117", true, "Discover")]
        [InlineData("5105105105105100", true, "MasterCard")]
        [InlineData("5105105105105106", false, "MasterCard")]
        [InlineData("9111111111111111", false, "Unknown")]
        public void CardChecker_ShouldReturn_ExpectedResult(string cardNumber, bool expectedResult, string cardType)
        {
            // Arrange
            var creditCard = new CreditCard(cardNumber);
            var creditCardChecker = new CreditCardChecker(creditCard);

            // Act
            var result = creditCardChecker.Check();

            // Assert
            result.IsValid.ShouldBe(expectedResult);
            result.CardType.ShouldBe(cardType);
        }
    }
}
