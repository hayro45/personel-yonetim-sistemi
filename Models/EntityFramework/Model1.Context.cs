﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonelMVCUI.Models.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DepartmanMVCEntities6 : DbContext
    {
        public DepartmanMVCEntities6()
            : base("name=DepartmanMVCEntities6")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Departman> Departman { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
    }
}
