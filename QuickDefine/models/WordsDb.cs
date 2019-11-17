using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickDefine.models
{
    public class WordsDb : DbContext
    {

        public WordsDb()
            : base("wordsDb1")
        {
           // Database.SetInitializer<WordsDb>(null);
        }

        public DbSet<Word> word { get; set; }
        public DbSet<Definition> definition { get; set; }
        public DbSet<Example> example { get; set; }
        public DbSet<PolishWords> polishWords { get; set; }
        //public DbSet<RussianWord> russianWords { get; set; }
    }







}
