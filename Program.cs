//Essas 2 primeiras linhas são responsável por criar o hosting que vai ficar escutando a aplicação 
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//primeiro end poind ou nossa primeira rota

/*EndPoint é uma tabela virtual onde colocamos todos os caminhos na qual nossa aplicação pode ser acessado
e também qual rotina será executado
para acessar um endpoint usamos os seguinte métodos GET,POST,PUT,DELETE*/


app.MapGet("/", () => "Hello World 2!");
app.MapGet("/user", () => "Milton Fragoso");

app.MapPost("/", () => new { Nome = "Milton Fragoso Quicuto", Idade = 35 });


//Alterar o header de resposta Response= resposta
app.MapGet("/AddHeader", (HttpResponse response) =>
{
    response.Headers.Add("Test", "Milton Fragoso Quicuto");
    return new { Nome = "Milton Fragoso Quicuto", Idade = 35 };
});


//Neste endpoint abordamos como o solicitante consegue trocar informações com o endpoint

//Parâmetro pelo body
//vamos ver uma troca de mensagem atraves do body onde o solicitante envia dados apartir do bady 
//para prencher e a classe Product
app.MapPost("/saveproduct", (Product product) =>
{
    return product.Code + " - " + product.Nome;
});

//Parâmetro pela Url para obter uma informação da minha URL por meio de parâmetros podemos fazer isso
//Podemos passar parâmetro de 2 formas
//QueryParametro = api.app/useres?datestart={date}&dateend={date} onde tudo depois do interrogação e parâmetro
app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string dateEnd) =>
{
    return dateStart + " - " + dateEnd;
});

//RoutParâmetro api.app.com/user/{code} aqui passamos parâmetros atraves da rota
app.MapGet("/getproduct/{code}", ([FromRoute]  string code) =>
{
    return code;
});





//Adicionando ou alterando alguma informação no header do solicitante e enviar por parâmetro 
app.MapGet("/getproductbyheader", (HttpRequest request) =>
{
    return request.Headers["product-code"].ToString();
});

//rodar aplicação
app.Run();


public class Product
{
    public string Code { get; set; }
    public string Nome { get; set; }
}