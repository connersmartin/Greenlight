using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenlightConsole
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instrument { get; set; }
        public int Status { get; set; }

        public Member(int id,string name, string instrument, int status = 0){
            Id = id;
            Name = name;
            Instrument = instrument;
            Status = status;
        }

    }


}
