using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vaskelista.Models
{
    public class RandomUrl
    {
        private static Random rnd = new Random();
        private static string[] adjectives = new string[]{
            "snill",
            "vemmelig",
            "koselig",
            "tjukk",
            "fryktelig",
            "utrolig",
            "gul",
            "stor"
        };

        private static string[] animals = new string[]{
            "giraff",
            "tiger",
            "katt",
            "hund",
            "ulv",
            "gaupe",
            "jerv",
            "hubro"
        };

        private static string GetRandomAdjective(){
            return adjectives[rnd.Next(adjectives.Length)].CapitalizeFirstLetter();
        }

        private static string GetRandomAnimal(){
            return animals[rnd.Next(adjectives.Length)].CapitalizeFirstLetter();
        }

        public static string GetUrl() {
            return GetRandomAdjective() + GetRandomAdjective() + GetRandomAnimal();
        }
    }
}