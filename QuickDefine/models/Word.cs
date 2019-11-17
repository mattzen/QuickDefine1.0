using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickDefine.models
{
    public class Word
    {
        public int wordId { get; set; }
        [MaxLength(50)]
        public string word { get; set; }
        [MaxLength(100)] 
        public string type { get; set; }
        public ICollection<Definition> definitions { get; set; }
        public ICollection<PolishWords> polwords { get; set; }
        //public ICollection<RussianWord> ruswords { get; set; }
    }

    public class Definition
    {
        public int definitionId { get; set; }
        public string definition { get; set; }
        public int wordId { get; set; }
        public string type { get; set; }
        public ICollection<Example> examples { get; set; }
    }

    public class Example
    {
        public int exampleId { get; set; }
        public string example { get; set; }
        public int definitionId { get; set; }
    }

    public class Synonyms
    {
        public int synonymId { get; set; }
        public string word { get; set; }
        public int wordId { get; set; }
    }

    public class PolishWords
    {
        [Key]
        public int polwordId { get; set; }
        public string word { get; set; }
        public int wordId { get; set; }
        [MaxLength(50)]
        public string type { get; set; }
    }

    public class RussianWord
    {
        [Key]
        public int russianId { get; set; }
        public string word { get; set; }
        public int wordId { get; set; }
        [MaxLength(50)]
        public string type { get; set; }
    }
}
