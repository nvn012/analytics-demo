using AnalyticsDemo.Application;
using AnalyticsDemo.Infra;
using Serilog;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Host.UseSerilog();

// Register Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "AnalyticsDemo API",
        Version = "v2"
    });
});

builder.Services.RegisterApplicationDependencies();
builder.Services.RegisterInfraDependencies();
builder.Services.AddHttpContextAccessor();

#region HealthCheks skiping it for demo
//builder.Services.AddHealthChecks()
//    .AddNpgSql(
//        builder.Configuration["Tenants:ReadConnectionString"],
//        name: "postgres-read",
//        tags: ["db", "sql", "postgres"])
//    .AddNpgSql(
//        builder.Configuration["Tenants:WriteConnectionString"],
//        name: "postgres-write",
//        tags: ["db", "sql", "postgres"])
//    .AddRedis(
//        builder.Configuration["Redis:ConnectionString"],
//        name: "redis",
//        tags: ["cache", "redis"]);
#endregion

#region Redis confg

var redisConfig = builder.Configuration.GetSection("Redis:Configuration").Value;
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration = ConfigurationOptions.Parse(redisConfig);
    configuration.AbortOnConnectFail = false;
    return ConnectionMultiplexer.Connect(configuration);
});

#endregion

#region Auth, skipping it for demo

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = builder.Configuration["Jwt:Issuer"],
//            IssuerSigningKey = new SymmetricSecurityKey(
//                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//        };
//    });

#endregion

#region cross region

//for spa
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
        policy.WithOrigins(allowedOrigins ?? new[] { "http://localhost:3000" })
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

#endregion

var app = builder.Build();

// Serve Swagger in all environments for now
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "AnalyticsDemo API v2");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();
app.UseAuthorization();
//app.UseCors("AllowSpecificOrigins");
//app.UseAuthentication();
app.MapControllers();
app.Run();
