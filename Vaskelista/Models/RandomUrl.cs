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
            "stor",
            "liten",
            "farlig",
            "dum",
            "gretten",
            "glad",
            "morsom",
            "brun",
            "svart",
            "hvit",
            "tynn",
            "lang",
            "kort"
        };

        private static string[] animals = new string[]{
            "giraff",
            "tiger",
            "katt",
            "hund",
            "ulv",
            "gaupe",
            "jerv",
            "hubro",
            "rev",
            "rype",
            "huggorm",
            "due",
            "falk",
            "rotte",
            "mus",
            "mink",
            "oter",
            "bever",
            "elg",
            "rein"
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