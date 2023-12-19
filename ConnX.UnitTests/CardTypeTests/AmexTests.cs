namespace ConnX.UnitTests.CardTypeTests
{
    public class AmexTests
    {
        [Fact]
        public void CardNumber_ThatStartsWith34AndIs15CharactersLong_IsValid()
        {
            //arrange
            var creditCard = new CreditCard("341234567890123");
            var amexRule = new AmexRule(creditCard);

            //act
            var result = amexRule.Check();

            //assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void CardNumber_ThatStartsWith37AndIs15CharactersLong_IsValid()
        {
            //arrange
            var creditCard = new CreditCard("371234567890123");
            var amexRule = new AmexRule(creditCard);

            //act
            var result = amexRule.Check();

            //assert
            result.IsValid.ShouldBeTrue();
        }

        [Theory]
        [InlineData("121234567890123")]
        [InlineData("991234567890123")]
        [InlineData("281234567890123")]
        [InlineData("551234567890123")]
        [InlineData("611234567890123")]
        [InlineData("741234567890123")]
        public void CardNumber_ThatDoesNotStartWith34Or37AndIs15CharactersLong_IsInValid(string number)
        {
            //arrange
            var creditCard = new CreditCard(number);
            var amexRule = new AmexRule(creditCard);

            //act
            var result = amexRule.Check();

            //assert
            result.IsValid.ShouldBeFalse();
            result.Error.ShouldBeAssignableTo<CardTypeStartsWithError>();
        }

        [Theory]
        [InlineData("3445678903")]
        [InlineData("3768161234567890123")]
        public void CardNumber_ThatDoesStartWith34Or37AndIsNot15CharactersLong_IsInValid(string number)
        {
            //arrange
            var creditCard = new CreditCard(number);
            var amexRule = new AmexRule(creditCard);

            //act
            var result = amexRule.Check();

            //assert
            result.IsValid.ShouldBeFalse();
            result.Error.ShouldBeAssignableTo<CardTypeLengthError>();
        }

        [Theory]
        [InlineData("", typeof(CardTypeLengthError))]
        [InlineData(null, typeof(CardTypeLengthError))]
        [InlineData("6846846851", typeof(CardTypeStartsWithError))]
        public void CardNumber_ThatDoesNotStartWith34Or37AndIsNot15CharactersLong_IsInValid(string number, Type errorType)
        {
            //arrange
            var creditCard = new CreditCard(number);
            var amexRule = new AmexRule(creditCard);

            //act
            var result = amexRule.Check();

            //assert
            result.IsValid.ShouldBeFalse();
            result.Error.ShouldBeAssignableTo(errorType);
        }

        [Fact]
        public void CardNumber_ThatIsntNumberis_IsInvalid()
        {
            //arrange
            var creditCard = new CreditCard("adfadsffadfadsf");
            var amexRule = new AmexRule(creditCard);

            //act
            var result = amexRule.Check();

            //assert
            result.IsValid.ShouldBeFalse();
            result.Error.ShouldBeAssignableTo<CardTypeFormatError>();
        }
    }
}
