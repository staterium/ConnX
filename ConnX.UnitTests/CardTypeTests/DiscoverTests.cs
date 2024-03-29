﻿namespace ConnX.UnitTests.CardTypeTests
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
            result.IsValid.ShouldBeTrue();
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
            result.IsValid.ShouldBeFalse();
            result.Error.ShouldBeAssignableTo<CardTypeStartsWithError>();
        }

        [Theory]
        [InlineData("6011678903", typeof(CardTypeLengthError))]
        [InlineData("60114161234567890123", typeof(CardTypeFormatError))]
        public void CardNumber_ThatDoesStartWith6011AndIsNot16CharactersLong_IsInValid(string number, Type errorType)
        {
            //arrange
            var creditCard = new CreditCard(number);
            var discoverRule = new DiscoverRule(creditCard);

            //act
            var result = discoverRule.Check();

            //assert
            result.IsValid.ShouldBe(false);
            result.Error.ShouldBeAssignableTo(errorType);
        }

        [Theory]
        [InlineData("", typeof(CardTypeLengthError))]
        [InlineData(null, typeof(CardTypeLengthError))]
        [InlineData("6846846851", typeof(CardTypeStartsWithError))]
        public void CardNumber_ThatDoesNotStartWith6011AndIsNot16CharactersLong_IsInValid(string number, Type errorType)
        {
            //arrange
            var creditCard = new CreditCard(number);
            var discoverRule = new DiscoverRule(creditCard);

            //act
            var result = discoverRule.Check();

            //assert
            result.IsValid.ShouldBeFalse();
            result.Error.ShouldBeAssignableTo(errorType);
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
            result.IsValid.ShouldBeFalse();
            result.Error.ShouldBeAssignableTo<CardTypeFormatError>();
        }
    }
}
