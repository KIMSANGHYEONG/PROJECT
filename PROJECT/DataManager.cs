using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PROJECT
{
    class DataManager
    {
        public static List<Player> Players = new List<Player>();
        public static List<Team> Teams = new List<Team>();

        static DataManager()
        {
            Load();
        }

        public static void Load()
        {
            try
            {


                string playersOutput = File.ReadAllText(@"./Players.xml");
                XElement playersXElement = XElement.Parse(playersOutput);

                Players = (from item in playersXElement.Descendants("player")
                           select new Player()
                           {
                               Name = item.Element("name").Value,
                               Position = item.Element("position").Value,
                               OTeam = item.Element("oTeam").Value,
                               Game = int.Parse(item.Element("game").Value),
                               Goal = int.Parse(item.Element("goal").Value),
                               Assist = int.Parse(item.Element("assist").Value),
                               Value = int.Parse(item.Element("value").Value),
                               NTeam = item.Element("nTeam").Value,
                               Deal = int.Parse(item.Element("deal").Value),
                               IsDealt = item.Element("isDealt").Value != "0" ? true : false

                           }).ToList<Player>();

                string teamsOutput = File.ReadAllText(@",/Teams.xml");
                XElement teamsXElement = XElement.Parse(teamsOutput);
                Teams = (from item in teamsXElement.Descendants("team")
                         select new Team()
                         {
                             Id = int.Parse(item.Element("id").Value),
                             Name = item.Element("name").Value
                         }).ToList<Team>();
            }
            catch (FileNotFoundException e)
            {
                Save();
            }

        }
        public static void Save()
        {
            string playersOutput = "";
            playersOutput += "<players>\n";
            foreach (var item in Players)
            {
                playersOutput += "<player>\n";

                playersOutput += "<name>" + item.Name + "</name>\n";
                playersOutput += "<position>" + item.Position + "</position>\n";
                playersOutput += "<oTeam>" + item.OTeam + "</oTeam>\n";
                playersOutput += "<game>" + item.Game + "</game>\n";
                playersOutput += "<goal>" + item.Goal + "</goal>\n";
                playersOutput += "<assist>" + item.Assist + "</assist>\n";
                playersOutput += "<value>" + item.Value + "</value>\n";
                playersOutput += "<nTeam>" + item.NTeam + "</nTeam>\n";
                playersOutput += "<deal>" + item.Deal + "</deal>\n";
                playersOutput += "<isDealt>" + (item.IsDealt ? 1 : 0) + "</isDealt>\n";

                playersOutput += "</player>\n";

            }
            playersOutput += "</players>";

            string teamsOutput = "";
            teamsOutput += "<teams>\n";
            foreach (var item in Teams)
            {
                teamsOutput += "<team>\n";
                teamsOutput += "<id>\n" + item.Id + "</id>\n";
                teamsOutput += "<name>\n" + item.Name + "</name>\n";
                teamsOutput += "</team>\n";
            }

            teamsOutput += "</teams>";
            File.WriteAllText(@"./Players.xml", playersOutput);
            File.WriteAllText(@"./Teams.xml", teamsOutput);
        }
    }
}
