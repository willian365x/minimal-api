using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db;

public class DbContexto : DbContext
{
    public DbSet<Administrador>? Administradores { get; set; }
    private readonly IConfiguration? _configuracaoAppSettings;

    public DbContexto(IConfiguration configuracaoAppSettings)
    {
        this._configuracaoAppSettings = configuracaoAppSettings;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var stringConexao = this._configuracaoAppSettings?.GetConnectionString("mysql")?.ToString();

            if (!string.IsNullOrEmpty(stringConexao))
            {
                optionsBuilder.UseMySql(stringConexao,
                    ServerVersion.AutoDetect(stringConexao));
            }
        }


    }
}