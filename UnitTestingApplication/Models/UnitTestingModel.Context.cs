﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnitTestingApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UnitTestingDatabaseEntities : DbContext
    {
        private static UnitTestingDatabaseEntities _context = new UnitTestingDatabaseEntities();

        public UnitTestingDatabaseEntities()
            : base("name=UnitTestingDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        /// <summary>
        /// Получение конекта Базы Данных.
        /// </summary>
        /// <returns> Контекст Базы Данных. </returns>
        public static UnitTestingDatabaseEntities GetContext()
        {
            if (_context == null)
                _context = new UnitTestingDatabaseEntities();
            return _context;
        }
    
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
