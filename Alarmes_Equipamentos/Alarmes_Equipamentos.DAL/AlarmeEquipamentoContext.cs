using Alarmes_Equipamentos.DAL.Model;
using System.Data.Entity;

namespace Alarmes_Equipamentos.DAL
{
    public partial class AlarmeEquipamentoContext : DbContext
    {
        public AlarmeEquipamentoContext()
            : base("name=AlarmeEquipamentoContext")
        {
        }

        public virtual DbSet<Equipamento> Equipamento { get; set; }
        public virtual DbSet<Alarme> Alarme { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipamento>()
                .Property(e => e.Nome)
                .IsRequired();

            modelBuilder.Entity<Equipamento>()
                .Property(e => e.NumeroSerie)
                .IsRequired();

            modelBuilder.Entity<Equipamento>()
                .Property(e => e.Tipo)
                .IsOptional();

            modelBuilder.Entity<Equipamento>()
                .Property(e => e.DataCadastro)
                .IsRequired();


            modelBuilder.Entity<Alarme>()
                .Property(e => e.Descricao)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Alarme>()
                .Property(e => e.Classificacao)
                .IsRequired();

            modelBuilder.Entity<Alarme>()
                .Property(e => e.DataCadastro)
                .IsRequired();
            
            //modelBuilder.Entity<Alarme>()
            //    .HasMany(e => e.Equipamento)
            //    .WithRequired(e => e.Alarme)
            //    .HasForeignKey(e => e.IdEquipamento)
            //    .WillCascadeOnDelete(false);
        }
    }
}
