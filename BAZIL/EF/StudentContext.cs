using BAZIL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BAZIL.EF
{
    public class StudentContext: DbContext
    {
        public StudentContext(): base("MyConnSt")
        {

        }
        public DbSet<Student> Students { get; set; }

    }
}