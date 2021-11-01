using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliaControleContas.Data
{
    public class FamiliaControleContasDbContext : DbContext
    {
        public FamiliaControleContasDbContext()
        {
        }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        #region Entities



        #endregion
    }
}
