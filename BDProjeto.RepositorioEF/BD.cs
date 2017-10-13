﻿using BDProjeto.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProjeto.RepositorioEF
{
    public class BD : DbContext
    {
        public BD() : base("ConexaoBD") 
        {

        }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<Usuario>().Property(x => x.Cargo).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<Usuario>().Property(x => x.Data).IsRequired().HasColumnType("date");
        }
    }
}
