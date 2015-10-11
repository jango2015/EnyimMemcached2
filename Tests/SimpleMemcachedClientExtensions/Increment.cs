﻿using System;
using System.Collections.Generic;
using System.Linq;
using Enyim.Caching.Memcached;
using Xunit;

namespace Enyim.Caching.Tests
{
	public partial class SimpleMemcachedClientExtensionsTests
	{
		[Fact]
		public void IncrementAsync_WithDefaults()
		{
			Verify(c => c.IncrementAsync(Key),
					c => c.MutateAsync(MutationMode.Increment, Key, Expiration.Never, Protocol.MUTATE_DEFAULT_DELTA, Protocol.MUTATE_DEFAULT_VALUE));
		}

		[Fact]
		public void IncrementAsync_NoExpire()
		{
			Verify(c => c.IncrementAsync(Key, MutateDelta, MutateDefault),
					c => c.MutateAsync(MutationMode.Increment, Key, Expiration.Never, MutateDelta, MutateDefault));
		}

		[Fact]
		public void IncrementAsync_Expire()
		{
			Verify(c => c.IncrementAsync(Key, HasExpiration, MutateDelta, MutateDefault),
					c => c.MutateAsync(MutationMode.Increment, Key, HasExpiration, MutateDelta, MutateDefault));
		}

		[Fact]
		public void Increment_WithDefaults()
		{
			Verify(c => c.Increment(Key),
					c => c.MutateAsync(MutationMode.Increment, Key, Expiration.Never, Protocol.MUTATE_DEFAULT_DELTA, Protocol.MUTATE_DEFAULT_VALUE));
		}

		[Fact]
		public void Increment_NoExpire()
		{
			Verify(c => c.Increment(Key, MutateDelta, MutateDefault),
					c => c.MutateAsync(MutationMode.Increment, Key, Expiration.Never, MutateDelta, MutateDefault));
		}

		[Fact]
		public void Increment_Expire()
		{
			Verify(c => c.Increment(Key, HasExpiration, MutateDelta, MutateDefault),
					c => c.MutateAsync(MutationMode.Increment, Key, HasExpiration, MutateDelta, MutateDefault));
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
