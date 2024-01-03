using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavTekrar.Models
{
    public class Db
    {
        public static AppDbContext Context;

        public static void Initalize()
        {
            Context = new AppDbContext();
            Context.Database.EnsureCreated();
        }
    }
}
