using ApiVacinas.Services.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Configurando os controllers da aplicação
builder.Services.AddControllers();

//Adicionando a configuração do Swagger parte01
SwaggerConfiguration.AddSwagger(builder);

//Adidionando a configuração do EntityFramework / Automapper / JwtTOKEN / Email
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

//Adicionando a configuração do JwtTOKEN parte02
app.UseAuthentication();
app.UseAuthorization();

//Configurando o descritor da API - Adicionando a configuração do Swagger parte02 
app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoAPI");
});

app.UseCors("DefaultPolicy");

//Executar os serviços
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
