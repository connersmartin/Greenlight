using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenlightConsole
{
    class Program
    {
   
        const string line = "";
        public static int width = 2;
        public static int boxWidth = 15;
        public static Show show = new Show(1, "Mannequins By Day", "test", new List<Member>());
        public static string Red = "R";
        public static string Yel = "Y";
        public static string Gre = "G";
        

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Manually added, but would use input eventually
            Member Conner = new Member(1, "Conner", "Drums");
            Member Vince = new Member(2, "Vince", "Guitar");
            Member Evan = new Member(3, "Evan", "Bass");
            Member Melinda = new Member(4, "Melinda", "Vox");
            Member Megan = new Member(5, "Megan", "Vox");


            show.Band.Add(Conner);
            show.Band.Add(Vince);
            show.Band.Add(Evan);
            show.Band.Add(Melinda);
            show.Band.Add(Megan);

            width = show.Band.Count() * boxWidth + 2;

            bool start = false;

            //constantly repeating until everyone's status is g
            while (!start)
            {
                //clear the console and draw box
                Console.Clear();
                Console.WriteLine("Polling for status of "+ show.Name + ": ");
                BoxFill();

                //draw band member names
                foreach (Member member in show.Band)
                {
                    WriteName(member.Name);
                }

                Console.WriteLine();
                //capture current status
                foreach (Member member in show.Band)
                {
                    if (member.Status != 2)
                    {
                        Console.WriteLine(member.Name + "- R, Y, G: ");
                        string stat = Console.ReadKey().ToString();

                        switch(stat)
                        {
                            case "r":
                                member.Status = 0;
                                break;
                            case "y":
                                member.Status = 1;
                                break;
                            case "g":
                                member.Status = 2;
                                break;
                            default:
                                break;
                        }
                    }
                }
                //exits the loop if everyone is ready
                if (Ready(show))
                {
                    start = true;
                }
            }         
            Console.ReadLine();
        }


        //Writes the band member name to fit in the box width
        public static void WriteName(string name)
        {
            Console.Write(name);
            for (int i = 0; i < width / show.Band.Count - name.Length; i++)
            {
                Console.Write(" ");
            }
        }

        //fills the box with stars
        public static void BoxFill()
        {
            Console.WriteLine(line.PadRight(width, '*'));
            Console.WriteLine(StatusFill() + " *");
            Console.WriteLine(line.PadRight(width, '*'));
        }

        //fills band member status
        public static string StatusFill()
        {
            foreach (Member member in show.Band)
            {
                switch(member.Status)
                {
                    case 0:
                        Console.Write(Red.PadRight(boxWidth));
                        break;
                    case 1:
                        Console.Write(Yel.PadRight(boxWidth));
                        break;
                    case 2:
                        Console.Write(Gre.PadRight(boxWidth));
                        break;
                    default:
                        break;
                }
            }
            return null;
        }

        //checks to see if everyone has a green status, need a better way for a global status check... if all are red, red, if at least one is green, yellow
        public static bool Ready(Show show)
        {
            var check = 0;

            foreach (Member member in show.Band)
            {
                if (member.Status == 2)
                {
                    check++;
                }
            }
            return check == show.Band.Count();
        }

    }
}
