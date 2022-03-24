using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Library
{
    public class Player : IEquatable<Player>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public int ContractLength { get; set; }
        public string Position { get; set; }
        public int ClubId { get; set; }

        public bool Equals(Player? other)
        {
            if(Object.ReferenceEquals(other, null)) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName);
        }

        public override int GetHashCode()
        {
            int hashFirstName = FirstName == null ? 0: FirstName.GetHashCode();

            int hashLastName = LastName == null ? 0 : LastName.GetHashCode();

            return hashFirstName ^ hashLastName;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old, plays as a {Position} for {Salary} mil.euro/ year, with {ContractLength} years remaining in contract";
        }

    }
}
