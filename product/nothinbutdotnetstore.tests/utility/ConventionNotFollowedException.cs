using System;

namespace nothinbutdotnetstore.tests.utility
{
    public class ConventionNotFollowedException : Exception
    {
        public ConventionNotFollowedException(string message) :base(message)
        {
        }
    }
}