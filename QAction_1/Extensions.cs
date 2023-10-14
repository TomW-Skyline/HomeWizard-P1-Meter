namespace Skyline.Protocol
{
	using System;

	using Skyline.DataMiner.Scripting;

	public static class Extensions
    {
		public static void SetParameters(this SLProtocol protocol, params (int Id, object Value)[] requests)
		{
			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			if (requests == null)
			{
				throw new ArgumentNullException("requests");
			}

			if (requests.Length == 0)
			{
				return;
			}

			var ids = new int[requests.Length];
			var values = new object[requests.Length];

			for (int i = 0; i < requests.Length; i++)
			{
				ids[i] = requests[i].Id;
				values[i] = requests[i].Value;
			}

			protocol.SetParameters(ids, values);
		}
	}
}