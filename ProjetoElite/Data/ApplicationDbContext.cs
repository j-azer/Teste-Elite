using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projeto_Elite.Models;

namespace Projeto_Elite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoDisciplina> AlunoDisciplinas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AlunoDisciplina>()
                .HasKey(ad => new { ad.AlunoId, ad.DisciplinaId });

            modelBuilder.Entity<AlunoDisciplina>()
                .HasOne(ad => ad.Aluno)
                .WithMany(a => a.AlunoDisciplinas)
                .HasForeignKey(ad => ad.AlunoId);

            modelBuilder.Entity<AlunoDisciplina>()
                .HasOne(ad => ad.Disciplina)
                .WithMany(d => d.AlunoDisciplinas)
                .HasForeignKey(ad => ad.DisciplinaId);
        }
        public DbSet<Projeto_Elite.Models.Arquivo> Arquivo { get; set; } = default!;

    }
}
