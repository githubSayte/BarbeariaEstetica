using Barbearia_Est�tica.ORM;
using Microsoft.EntityFrameworkCore;
using SiteAgendamento.Repositorio;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Authentication.Cookies;  // Necess�rio para usar sess�es

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registrar o DbContext se necess�rio
builder.Services.AddDbContext<BdEsteticaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar o reposit�rio (UsuarioRepositorio)
builder.Services.AddScoped<UsuarioRepositorio>();  // Ou AddTransient ou AddSingleton dependendo do caso

// Registrar outros servi�os, como controllers com views
builder.Services.AddControllersWithViews();

// Registrar o reposit�rio (ServicoRepositorio)
builder.Services.AddScoped<ServicoRepositorio>();

// Registrar o reposit�rio (AgendamentoRepositorio)
builder.Services.AddScoped<AgendamentoRepositorio>();

// Adicionar suporte a sess�es
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Defina o tempo de expira��o da sess�o
    options.Cookie.HttpOnly = true;  // Tornar o cookie da sess�o apenas para HTTP
    options.Cookie.IsEssential = true;  // Garantir que o cookie seja essencial para o funcionamento da aplica��o
});

// Adicionar suporte a autentica��o com cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Usuario/Login";  // Caminho para a p�gina de login
        options.LogoutPath = "/Usuario/Logout";  // Caminho para a p�gina de logout
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);  // Tempo de expira��o do cookie
    });


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Ativar o uso de sess�es
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
