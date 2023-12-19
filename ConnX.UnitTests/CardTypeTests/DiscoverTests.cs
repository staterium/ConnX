namespace ConnX.UnitTests.CardTypeTests
{
    public class DiscoverTests
    {
        [Fact]
        public void CardNumber_ThatStartsWith6011AndIs16CharactersLong_IsValid()
        {
            //arrange
            var creditCard = new CreditCard("6011234567890123");
            var discoverRule = new DiscoverRule(creditCard);

            //act
            var result = discoverRule.Check();

            //assert
            result.IsValid.ShouldBe(true);
        }

        [Theory]
        [InlineData("1212345678901231")]
        [InlineData("9912345678901232")]
        [InlineData("2812345678901233")]
        [InlineData("5512345678901234")]
        [InlineData("6112345678901235")]
        [InlineData("7412345678901236")]
        public void CardNumber_ThatDoesNotStartWith6011AndIs16CharactersLong_IsInValid(string number)
        {
            //arrange
            var creditCard = new CreditCard(number);
            var discoverRule = new DiscoverRule(creditCard);

            //act
            var result = discoverRule.Check();

            //assert
            result.IsValid.ShouldBe(false);
            result.Error.ShouldBeAssignableTo<CardTypeStartsWithError>();
        }

        [Theory]
        [InlineData("6011678903")]
        [InlineData("60114161234567890123")]
        public void CardNumber_ThatDoesStartWith6011AndIsNot16CharactersLong_IsInValid(string number)
        {
            //arrange
            var creditCard = new CreditCard(number);
            var discoverRule = new DiscoverRule(creditCard);

            //act
            var result = discoverRule.Check();

            //assert
            result.IsValid.ShouldBe(false);
            result.Error.ShouldBeAssignableTo<CardTypeLengthError>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("6846846851")]
        public void CardNumber_ThatDoesNotStartWith6011AndIsNot16CharactersLong_IsInValid(string number)
        {
            //arrange
            var creditCard = new CreditCard(number);
            var discoverRule = new DiscoverRule(creditCard);

            //act
            var result = discoverRule.Check();

            //assert
            result.IsValid.ShouldBe(false);
            result.Error.ShouldBeAssignableTo<CardTypeLengthError>();
        }

        [Fact]
        public void CardNumber_ThatIsntNumberis_IsInvalid()
        {
            //arrange
            var creditCard = new CreditCard("adfadsffadfadsff");
            var discoverRule = new DiscoverRule(creditCard);

            //act
            var result = discoverRule.Check();

            //assert
            result.IsValid.ShouldBe(false);
            result.Error.ShouldBeAssignableTo<CardTypeFormatError>();
        }
    }
}
