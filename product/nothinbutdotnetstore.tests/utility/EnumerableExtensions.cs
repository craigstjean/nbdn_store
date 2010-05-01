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

		public static IEnumerable<Exception> exceptions_for<T>(this IEnumerable<T> items, Action<T> convention)
		{
			var exceptions = new List<Exception>();
			items.each(x =>
			{
				try
				{
					convention(x);
				}
				catch (Exception exception)
				{
					exceptions.Add(exception);
				}
			});
			return exceptions;
		}
    }
}