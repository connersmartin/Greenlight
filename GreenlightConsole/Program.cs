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
        public static Show show; 
        public static string Red = "N";
        public static string Gre = "Y";
        

        static void Main(string[] args)
        {
            show = GetShow();
            GetMembers();

            width = show.Band.Count() * boxWidth + 2;

            bool start = false;

            //constantly repeating until everyone's status is y
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
                    if (member.Status != 1)
                    {
                        Console.Write(member.Name + " Ready? - y, n: ");
                        string stat = Console.ReadKey().KeyChar.ToString();
                        Console.WriteLine();

                        switch(stat)
                        {
                            case "n":
                                member.Status = 0;
                                break;
                            case "y":
                                member.Status = 1;
                                break;
                            default:
                                break;
                        }
                    }
                }
                //exits the loop if everyone is ready
                if (Ready(show) == (ConsoleColor)10)
                {
                    start = true;
                    Console.Clear();
                    Console.WriteLine(show.Name + ": Go Time!");
                    BoxFill();
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
            //need to refactor for red/yellow/green box 12,14,10 in ConsoleColor
            Console.BackgroundColor = Ready(show);
            Console.WriteLine(line.PadRight(width, ' '));
            Console.WriteLine(StatusFill() + "  ");
            Console.WriteLine(line.PadRight(width, ' '));
            Console.BackgroundColor = 0;
        }

        //fills band member status
        public static string StatusFill()
        {
            foreach (Member member in show.Band)
            {
                Console.BackgroundColor = 0;
                switch(member.Status)
                {
                    
                    case 0:
                        Console.Write(Red.PadRight(boxWidth));
                        break;
                    case 1:
                        Console.Write(Gre.PadRight(boxWidth));
                        break;
                    default:
                        break;
                }
            Console.BackgroundColor = Ready(show);
        }
            return null;
        }

        //checks to see if everyone has a green status, need a better way for a global status check... if all are red, red, if at least one is green, yellow
        public static ConsoleColor Ready(Show show)
        {
            var check = 0;

            foreach (Member member in show.Band)
            {
                if (member.Status == 1)
                {
                    check++;
                }
            }

            if (check == show.Band.Count())
            {
                return (ConsoleColor)10;
            }
            else if (check < show.Band.Count() && check > 0)
            {
                return (ConsoleColor)14;
            }
            else
            {
                return (ConsoleColor)12;
            }
        }

        //adds a show 
        public static void AddShow(string band, string code)
        {
            show = new Show(0, band, code, new List<Member>());
        }


        //adds a member to the band
        public static void AddMember(int id, string name, string instrument)
        {
            show.Band.Add(new Member(id, name, instrument));
        }

        //gets the show for testing
        private static Show GetShow()
        {
            //would enter in show information
            return new Show(1, "Mannequins By Day", "test", new List<Member>());
        }

        //gets test members
        private static void GetMembers()
        {
            //would want to have option for using name or instrument depending on familiarity

            //Manually added, but would use AddMember eventually

            show.Band.Add(new Member(1, "Conner", "Drums"));
            show.Band.Add(new Member(2, "Vince", "Guitar"));
            show.Band.Add(new Member(3, "Evan", "Bass"));
            show.Band.Add(new Member(4, "Melinda", "Vox"));
            show.Band.Add(new Member(5, "Megan", "Vox"));
        }
    }
}
