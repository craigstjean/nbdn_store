using System;
using System.Data.SqlClient;

namespace nothinbutdotnetstore.infrastructure.containers
{
	public class SqlConnectionContainerResolver : ContainerResolver
	{
		string connection_string;

		public SqlConnectionContainerResolver(string connection_string)
		{
			this.connection_string = connection_string;
		}

		public object resolve()
		{
			return new SqlConnection(connection_string);
		}
	}
}