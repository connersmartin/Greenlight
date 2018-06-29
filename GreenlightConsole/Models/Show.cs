using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenlightConsole
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Member> Band { get; set; }

        public Show(int id, string name, string code, List<Member> band) {
            Id = id;
            Name = name;
            Code = code;
            Band = band;
        }

    }
}
