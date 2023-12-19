namespace ConnX.UnitTests.CardTypeTests
{
    public class VisaTests
    {
        [Fact]
        public void CardNumber_ThatStartsWith4AndIs13CharactersLong_IsValid()
        {
            //arrange
            var creditCard = new CreditCard("4123456789012");
            var visaRule = new VisaRule(creditCard);

            //act
            var result = visaRule.Check();

            //assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void CardNumber_ThatStartsWith4AndIs14CharactersLong_IsValid()
        {
            //arrange
            var creditCard = new CreditCard("41234567890124");
            var visaRule = new VisaRule(creditCard);

            //act
            var result = visaRule.Check();

            //assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void CardNumber_ThatStartsWith4AndIs15CharactersLong_IsValid()
        {
            //arrange
            var creditCard = new CreditCard("412345678901268");
            var visaRule = new VisaRule(creditCard);

            //act
            var result = visaRule.Check();

            //assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void CardNumber_ThatStartsWith4AndIs16CharactersLong_IsValid()
        {
            //arrange
            var creditCard = new CreditCard("4123456789012154");
            var visaRule = new VisaRule(creditCard);

            //act
            var result = visaRule.Check();

            //assert
            result.IsValid.ShouldBeTrue();
        }

        [Theory]
        [InlineData("1212345678901231")]
        [InlineData("9912345678901232")]
        [InlineData("2812345678901233")]
        [InlineData("5512345678901234")]
        [InlineData("6112345678901235")]
        [InlineData("7412345678901236")]
        public void CardNumber_ThatDoesNotStartWith4AndIs16CharactersLong_IsInValid(string number)
        {
            //arrange
            var creditCard = new CreditCard(number);
            var visaRule = new VisaRule(creditCard);

            //act
            var result = visaRule.Check();

            //assert
            result.IsValid.ShouldBeFalse();
            result.Error.ShouldBeAssignableTo<CardTypeStartsWithError>();
        }

        [Theory]
        [InlineData("4445678903")]
        [InlineData("4768161234567890123")]
        public void CardNumber_ThatDoesStartWith4AndIsNot13To16CharactersLong_IsInValid(string number)
        {
            //arrange
            var creditCard = new CreditCard(number);
            var visaRule = new VisaRule(creditCard);

            //act
            var result = visaRule.Check();

            //assert
            result.IsValid.ShouldBeFalse();
            result.Error.ShouldBeAssignableTo<CardTypeLengthError>();
        }

        [Theory]
        [InlineData("", typeof(CardTypeLengthError))]
        [InlineData(null, typeof(CardTypeLengthError))]
        [InlineData("6846846851", typeof(CardTypeStartsWithError))]
        public void CardNumber_ThatDoesNotStartWith4AndIsNot13To16CharactersLong_IsInValid(string number, Type errorType)
        {
            //arrange
            var creditCard = new CreditCard(number);
            var visaRule = new VisaRule(creditCard);

            //act
            var result = visaRule.Check();

            //assert
            result.IsValid.ShouldBeFalse();
            result.Error.ShouldBeAssignableTo(errorType);
        }

        [Fact]
        public void CardNumber_ThatIsntNumberis_IsInvalid()
        {
            //arrange
            var creditCard = new CreditCard("adfadsffadfadsff");
            var visaRule = new VisaRule(creditCard);

            //act
            var result = visaRule.Check();

            //assert
            result.IsValid.ShouldBeFalse();
            result.Error.ShouldBeAssignableTo<CardTypeFormatError>();
        }
    }
}
