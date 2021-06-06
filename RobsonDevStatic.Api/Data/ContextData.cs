using RobsonDevStatic.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobsonDevStatic.Api.Data
{
    public class ContextData
    {
        public People People { get; set; }
        public SocialMedia SocialMedia { get; set; }


        public ContextData()
        {
            //People = new();
            //SocialMedia = new();
        }
    }
}
