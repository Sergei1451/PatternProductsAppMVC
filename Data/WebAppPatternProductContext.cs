using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppPatternProduct.Models;

namespace WebAppPatternProduct.Data
{
    public class WebAppPatternProductContext : DbContext
    {
        public WebAppPatternProductContext (DbContextOptions<WebAppPatternProductContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppPatternProduct.Models.ProductPOCO>? ProductPOCO { get; set; }
    }
}
