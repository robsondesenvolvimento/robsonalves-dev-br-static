using System;

namespace RobsonDevStatic.Api.Models
{
    public class People
    {
        public string Nickname { get; init; }
        public string Name { get; init; }
        public DateTime Birthday { get; init; }
        public string Country { get; init; }
        public string State { get; init; }
        public string Email { get; init; }
    }
}
