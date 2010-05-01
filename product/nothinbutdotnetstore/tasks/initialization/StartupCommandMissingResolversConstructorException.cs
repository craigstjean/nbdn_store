using System;

namespace nothinbutdotnetstore.tasks.initialization
{
	public class StartupCommandMissingResolversConstructorException : Exception
	{
		public StartupCommandMissingResolversConstructorException()
		{
		}

		public StartupCommandMissingResolversConstructorException(string message) : base(message)
		{
		}
	}
}