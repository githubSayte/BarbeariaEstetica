using Barbearia_Estética.ORM;
using Microsoft.EntityFrameworkCore;
using SiteAgendamento.Repositorio;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Authentication.Cookies;  // Necessário para usar sessões

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registrar o DbContext se necessário
builder.Services.AddDbContext<BdEsteticaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar o repositório (UsuarioRepositorio)
builder.Services.AddScoped<UsuarioRepositorio>();  // Ou AddTransient ou AddSingleton dependendo do caso

// Registrar outros serviços, como controllers com views
builder.Services.AddControllersWithViews();

// Registrar o repositório (ServicoRepositorio)
builder.Services.AddScoped<ServicoRepositorio>();

// Registrar o repositório (AgendamentoRepositorio)
builder.Services.AddScoped<AgendamentoRepositorio>();

// Adicionar suporte a sessões
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Defina o tempo de expiração da sessão
    options.Cookie.HttpOnly = true;  // Tornar o cookie da sessão apenas para HTTP
    options.Cookie.IsEssential = true;  // Garantir que o cookie seja essencial para o funcionamento da aplicação
});

// Adicionar suporte a autenticação com cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Usuario/Login";  // Caminho para a página de login
        options.LogoutPath = "/Usuario/Logout";  // Caminho para a página de logout
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);  // Tempo de expiração do cookie
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

// Ativar o uso de sessões
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
