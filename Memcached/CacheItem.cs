﻿using System;
using System.Net;
using System.Collections.Generic;
using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Operations;

namespace Enyim.Caching.Memcached
{
	/// <summary>
	/// Represents an object either being retrieved from the cache
	/// or being sent to the cache.
	/// </summary>
	public struct CacheItem
	{
		private uint flags;
		private ArraySegment<byte> data;

		/// <summary>
		/// Initializes a new instance of <see cref="T:CacheItem"/>.
		/// </summary>
		/// <param name="flags">Custom item data.</param>
		/// <param name="data">The serialized item.</param>
		public CacheItem(uint flags, ArraySegment<byte> data)
		{
			this.flags = flags;
			this.data = data;
		}

		/// <summary>
		/// Flags set for this instance.
		/// </summary>
		public uint Flags
		{
			get { return this.flags; }
		}

		/// <summary>
		/// The data representing the item being stored/retireved.
		/// </summary>
		public ArraySegment<byte> Data
		{
			get { return this.data; }
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