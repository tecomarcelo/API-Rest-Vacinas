using ApiVacinas.Services.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Configurando os controllers da aplica��o
builder.Services.AddControllers();

//Adicionando a configura��o do Swagger parte01
SwaggerConfiguration.AddSwagger(builder);

//Adidionando a configura��o do EntityFramework / Automapper / JwtTOKEN / Email
EntityFrameworkConfiguration.AddEntityFramework(builder);
AutoMapperConfiguration.AddAutoMapper(builder);
JwtConfiguration.AddJwt(builder);
MailConfiguration.AddMail(builder);

builder.Services.AddCors(s => s.AddPolicy("DefaultPolicy", builder => {
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

// Add services to the container.
var app = builder.Build();

//habilitar as rotas e endpoints da API
app.UseRouting();

//Adicionando a configura��o do JwtTOKEN parte02
app.UseAuthentication();
app.UseAuthorization();

//Configurando o descritor da API - Adicionando a configura��o do Swagger parte02 
app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoAPI");
});

app.UseCors("DefaultPolicy");

//Executar os servi�os
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
