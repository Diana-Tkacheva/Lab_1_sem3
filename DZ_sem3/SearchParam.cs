using System.Collections.Generic;

namespace DZ_sem3
{
    public class SearchParam
    {
        public List<string> Words { get; set; }
        public string Sample { get; set; }
        public int Distance { get; set; }
        public int ThreadNumber { get; set; }
    }
}
