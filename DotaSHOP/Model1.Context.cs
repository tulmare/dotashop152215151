﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DotaSHOP
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cart> cart { get; set; }
        public virtual DbSet<favorites> favorites { get; set; }
        public virtual DbSet<offers> offers { get; set; }
        public virtual DbSet<reviews> reviews { get; set; }
        public virtual DbSet<skins> skins { get; set; }
        public virtual DbSet<statuses> statuses { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<transactions> transactions { get; set; }
        public virtual DbSet<users> users { get; set; }
    }
}
