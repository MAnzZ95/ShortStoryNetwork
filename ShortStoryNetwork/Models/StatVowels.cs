using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortStoryNetwork.Models
{
    public class StatVowels
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SingleVowelCount { get; set; }
        public int PairVowelCount { get; set; }
        public int TotalWordCount { get; set; }
    }
}
