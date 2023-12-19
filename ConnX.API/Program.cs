using ConnX.Core.CreditCardChecker;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/checkcard/{cardNumber}", (string cardNumber) =>
{
    var creditCard = new ConnX.Core.Common.CreditCard(cardNumber);
    var checker = new CreditCardChecker(creditCard);
    var result = checker.Check();
    return result;
})
.WithName("CheckCard")
.WithOpenApi();

app.Run();
