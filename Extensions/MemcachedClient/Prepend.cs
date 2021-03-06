﻿using System;
using System.Threading.Tasks;
using Enyim.Caching.Memcached.Results;

namespace Enyim.Caching.Memcached
{
	public static partial class MemcachedClientExtensions
	{
		public static Task<IOperationResult> PrependAsync(this IMemcachedClient self, string key, ArraySegment<byte> data)
		{
			return self.ConcateAsync(ConcatenationMode.Prepend, key, data, Protocol.NO_CAS);
		}

		public static Task<IOperationResult> PrependAsync(this IMemcachedClient self, string key, byte[] data, ulong cas = Protocol.NO_CAS)
		{
			return self.ConcateAsync(ConcatenationMode.Prepend, key, new ArraySegment<byte>(data), cas);
		}

		public static IOperationResult Prepend(this IMemcachedClient self, string key, byte[] data, ulong cas = Protocol.NO_CAS)
		{
			return self.ConcateAsync(ConcatenationMode.Prepend, key, new ArraySegment<byte>(data), cas).RunAndUnwrap();
		}

		public static IOperationResult Prepend(this IMemcachedClient self, string key, ArraySegment<byte> data, ulong cas = Protocol.NO_CAS)
		{
			return self.ConcateAsync(ConcatenationMode.Prepend, key, data, cas).RunAndUnwrap();
		}
	}
}

#region [ License information          ]

/* ************************************************************
 *
 *    Copyright (c) Attila Kiskó, enyim.com
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *
 * ************************************************************/

#endregion
