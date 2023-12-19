using ConnX.Core.CreditCardChecker;

var allowAllOrigins = "_allowAllOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: allowAllOrigins,
        policy =>
        {
            policy.AllowAnyOrigin();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(allowAllOrigins);


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

public partial class Program { }
