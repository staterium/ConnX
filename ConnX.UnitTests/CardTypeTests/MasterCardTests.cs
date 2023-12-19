namespace ConnX.UnitTests.CardTypeTests
{
    public class MasterCardTests
    {
        [Fact]
        public void CardNumber_ThatStartsWith51AndIs16CharactersLong_IsValid()
        {
            //arrange
            var creditCard = new CreditCard("5112345678901231");
            var masterCardRule = new MasterCardRule(creditCard);

            //act
            var result = masterCardRule.Check();

            //assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void CardNumber_ThatStartsWith52AndIs16CharactersLong_IsValid()
        {
            //arrange
            var creditCard = new CreditCard("5212345678901231");
            var masterCardRule = new MasterCardRule(creditCard);

            //act
            var result = masterCardRule.Check();

            //assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void CardNumber_ThatStartsWith53AndIs16CharactersLong_IsValid()
        {
            //arrange
            var creditCard = new CreditCard("5312345678901231");
            var masterCardRule = new MasterCardRule(creditCard);

            //act
            var result = masterCardRule.Check();

            //assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void CardNumber_ThatStartsWith54AndIs16CharactersLong_IsValid()
        {
            //arrange
            var creditCard = new CreditCard("5412345678901231");
            var masterCardRule = new MasterCardRule(creditCard);

            //act
            var result = masterCardRule.Check();

            //assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void CardNumber_ThatStartsWith55AndIs16CharactersLong_IsValid()
        {
            //arrange
            var creditCard = new CreditCard("5512345678901231");
            var masterCardRule = new MasterCardRule(creditCard);

            //act
            var result = masterCardRule.Check();

            //assert
            result.IsValid.ShouldBeTrue();
        }

        [Theory]
        [InlineData("1212345678901231")]
        [InlineData("9912345678901232")]
        [InlineData("2812345678901233")]
        [InlineData("5612345678901234")]
        [InlineData("6112345678901235")]
        [InlineData("7412345678901236")]
        public void CardNumber_ThatDoesNotStartWith51To55AndIs16CharactersLong_IsInValid(string number)
        {
            //arrange
            var creditCard = new CreditCard(number);
            var masterCardRule = new MasterCardRule(creditCard);

            //act
            var result = masterCardRule.Check();

            //assert
            result.IsValid.ShouldBeFalse();
            result.Error.ShouldBeAssignableTo<CardTypeStartsWithError>();
        }

        [Theory]
        [InlineData("5145678903")]
        [InlineData("5368161234567890123")]
        public void CardNumber_ThatDoesStartWith51To55AndIsNot16CharactersLong_IsInValid(string number)
        {
            //arrange
            var creditCard = new CreditCard(number);
            var masterCardRule = new MasterCardRule(creditCard);

            //act
            var result = masterCardRule.Check();

            //assert
            result.IsValid.ShouldBeFalse();
            result.Error.ShouldBeAssignableTo<CardTypeLengthError>();
        }

        [Theory]
        [InlineData("", typeof(CardTypeLengthError))]
        [InlineData(null, typeof(CardTypeLengthError))]
        [InlineData("6846846851", typeof(CardTypeStartsWithError))]
        public void CardNumber_ThatDoesNotStartWith51To55AndIsNot16CharactersLong_IsInValid(string number, Type errorType)
        {
            //arrange
            var creditCard = new CreditCard(number);
            var masterCardRule = new MasterCardRule(creditCard);

            //act
            var result = masterCardRule.Check();

            //assert
            result.IsValid.ShouldBeFalse();
            result.Error.ShouldBeAssignableTo(errorType);
        }

        [Fact]
        public void CardNumber_ThatIsntNumberis_IsInvalid()
        {
            //arrange
            var creditCard = new CreditCard("adfadsffadfadsff");
            var masterCardRule = new MasterCardRule(creditCard);

            //act
            var result = masterCardRule.Check();

            //assert
            result.IsValid.ShouldBeFalse();
            result.Error.ShouldBeAssignableTo<CardTypeFormatError>();
        }
    }
}
