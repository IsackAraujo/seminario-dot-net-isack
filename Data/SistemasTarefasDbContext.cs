using Microsoft.EntityFrameworkCore;
using PW45S.Data.Map;
using PW45S.Models;

namespace PW45S.Data
{
    public class SistemasTarefasDbContext : DbContext
    {
     public SistemasTarefasDbContext(DbContextOptions<SistemasTarefasDbContext> options) : base(options) {}

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap()); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
