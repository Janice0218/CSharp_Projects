using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicLinq
{

class Program
    {
        static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            var mvArtist = Artists.Where(a => a.Hometown == "Mount Vernon")
                .Select(artist => new {artist.Age, artist.ArtistName});
            foreach (var artist in mvArtist)
            {
                Console.WriteLine(artist.ArtistName + " is " + artist.Age);
            }

           


            //Who is the youngest artist in our collection of artists?
            var youngest = Artists.OrderByDescending(a => a.Age).Last();
            Console.WriteLine(youngest.ArtistName + " " + youngest.Age);
            
            //Display all artists with 'William' somewhere in their real name

            var williams = Artists.Where(a => a.RealName.Contains("William")).Select(a => a.RealName);

            foreach (var william in williams)
            {
                Console.WriteLine(william);
            }

            //Display the 3 oldest artist from Atlanta
            var atlanta = Artists.Where(a => a.Hometown == "Atlanta").OrderByDescending(a => a.Age).Take(3);
            foreach (var artist in atlanta)
            {
                Console.WriteLine(artist.RealName + " is " + artist.Age + " years old and is from " + artist.Hometown);
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            var WuTangClan = Groups.Where(g => g.GroupName == "Wu-Tang Clan").Select(g => g.Members.Select(m => m.ArtistName));
            foreach (var wu in WuTangClan)
            {
                Console.WriteLine(wu + " is a member of Wu-Tang Clan");
            }
        }   
    }
}

