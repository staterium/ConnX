namespace ConnX.UnitTests
{
    public class AlgorithmTests
    {
        [Theory]
        [InlineData("4111111111111111", true)]
        [InlineData("4111111111111", false)]
        [InlineData("4012888888881881", true)]
        [InlineData("378282246310005", true)]
        [InlineData("6011111111111117", true)]
        [InlineData("5105105105105100", true)]
        [InlineData("5105105105105106", false)]
        [InlineData("9111111111111111", false)]
        public void LuhnRule_ShouldReturn_ExpectedResult(string cardNumber, bool expectedResult)
        {
            // Arrange
            var creditCard = new CreditCard(cardNumber);
            var luhnRule = new LuhnRule(creditCard);
            
            // Act
            var result = luhnRule.Check();

            // Assert
            result.IsValid.ShouldBe(expectedResult);
        }
    }
}
