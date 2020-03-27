using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sistema.Entidades;
using Sistema.Models;

namespace Sistema.Data
{
  public class Contexto : DbContext
    {
         public  DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Clientes> clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().UseSqlite(@"Data Source = Data/DataBase.db");
        }
    }
}
