using System;
using System.Collections.Generic;
using developwithpassion.bdd.core.extensions;

namespace nothinbutdotnetstore.tests.utility
{
    public static class EnumerableExtensions
    {
        public static void ensure_all_follow<T>(this IEnumerable<T> items,
                                                Action<T> convention)
        {
            items.each(convention);
        } 
    }
}