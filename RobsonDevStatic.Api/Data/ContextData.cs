using RobsonDevStatic.Api.Models;

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
