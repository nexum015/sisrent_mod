namespace SisRent.Entidades.Entidades
{
    using System.Data.Entity;

    public partial class SisRentModel : DbContext
    {
        public SisRentModel()
            : base("name=SisRentEntities")
        {
        }

        public virtual DbSet<Accesos> Accesos { get; set; }
        public virtual DbSet<Comunas> Comunas { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Reservas> Reservas { get; set; }
        public virtual DbSet<ReservaServicio> ReservaServicio { get; set; }
        public virtual DbSet<RolAcceso> RolAcceso { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Servicios> Servicios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Vehiculos> Vehiculos { get; set; }
        public virtual DbSet<VehMarcas> VehMarcas { get; set; }
        public virtual DbSet<VehModelos> VehModelos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accesos>()
                .HasMany(e => e.Accesos1)
                .WithOptional(e => e.Accesos2)
                .HasForeignKey(e => e.IdAccesoPadre);

            modelBuilder.Entity<Comunas>()
                .HasMany(e => e.Reservas)
                .WithRequired(e => e.Comunas)
                .HasForeignKey(e => e.IdComunaRetiro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comunas>()
                .HasMany(e => e.Reservas1)
                .WithOptional(e => e.Comunas1)
                .HasForeignKey(e => e.IdComunaEntrega);

            modelBuilder.Entity<Comunas>()
                .HasMany(e => e.Reservas2)
                .WithOptional(e => e.Comunas2)
                .HasForeignKey(e => e.IdComuna);

            modelBuilder.Entity<Estados>()
                .HasMany(e => e.Reservas)
                .WithRequired(e => e.Estados)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reservas>()
                .Property(e => e.ValorFinal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Reservas>()
                .HasMany(e => e.ReservaServicio)
                .WithRequired(e => e.Reservas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReservaServicio>()
                .Property(e => e.ValorServicio)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Servicios>()
                .Property(e => e.Valor)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Servicios>()
                .HasMany(e => e.ReservaServicio)
                .WithRequired(e => e.Servicios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Reservas)
                .WithRequired(e => e.Usuarios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vehiculos>()
                .Property(e => e.Valor)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Vehiculos>()
                .HasMany(e => e.Reservas)
                .WithRequired(e => e.Vehiculos)
                .WillCascadeOnDelete(false);
        }
    }
}
