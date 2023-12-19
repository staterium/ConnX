using ConnX.Core.Common;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using System.Net.Http.Json;

namespace ConnX.IntegrationTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task CheckValidVisaCard()
        {
            //arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            //act
            var response = await client.GetAsync("/checkcard/4111111111111111");           
            var validationResult = await response.Content.ReadFromJsonAsync<GenericValidationResult>();

            //assert
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            validationResult.ShouldNotBeNull();
            validationResult.IsValid.ShouldBeTrue();
            validationResult.CardType.ShouldBe("Visa");
        }

        [Fact]
        public async Task CheckInalidVisaCard()
        {
            //arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            //act
            var response = await client.GetAsync("/checkcard/4111111111111");
            var validationResult = await response.Content.ReadFromJsonAsync<GenericValidationResult>();

            //assert
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            validationResult.ShouldNotBeNull();
            validationResult.IsValid.ShouldBeFalse();
            validationResult.CardType.ShouldBe("Visa");
        }

        [Fact]
        public async Task CheckInvalidUnknownCard()
        {
            //arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            //act
            var response = await client.GetAsync("/checkcard/9111111111111111");
            var validationResult = await response.Content.ReadFromJsonAsync<GenericValidationResult>();

            //assert
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            validationResult.ShouldNotBeNull();
            validationResult.IsValid.ShouldBeFalse();
            validationResult.CardType.ShouldBe("Unknown");
        }
    }
}