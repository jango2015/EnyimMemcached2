﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Enyim.Caching.Memcached;

namespace Enyim.Caching.Tests
{
	public partial class MemcachedClientTests
	{
		[Fact]
		public void When_Appending_To_Existing_Value_Result_Is_Successful()
		{
			const string ToAppend = "The End";
			var key = GetUniqueKey("Append_Success");
			var value = GetRandomString();

			Assert.True(Store(key: key, value: value));
			Assert.True(client.Append(key, Encoding.UTF8.GetBytes(ToAppend)));
			Assert.Equal(value + ToAppend, client.Get(key));
		}

		[Fact]
		public void When_Appending_To_Invalid_Key_Result_Is_Not_Successful()
		{
			const string ToAppend = "The End";
			var key = GetUniqueKey("Append_Fail");

			Assert.False(client.Append(key, Encoding.UTF8.GetBytes(ToAppend)));
			Assert.Null(client.Get(key));
		}

		[Fact]
		public void When_Prepending_To_Existing_Value_Result_Is_Successful()
		{
			const string ToPrepend = "The Beginning";
			var key = GetUniqueKey("Prepend_Success");
			var value = GetRandomString();

			Assert.True(Store(key: key, value: value));
			Assert.True(client.Prepend(key, Encoding.UTF8.GetBytes(ToPrepend)));
			Assert.Equal(ToPrepend + value, client.Get(key));
		}

		[Fact]
		public void When_Prepending_To_Invalid_Key_Result_Is_Not_Successful()
		{
			const string ToPrepend = "The Beginning";
			var key = GetUniqueKey("Prepend_Fail");

			Assert.False(client.Prepend(key, Encoding.UTF8.GetBytes(ToPrepend)));
			Assert.Null(client.Get(key));
		}

		//[Fact]
		//public void When_Appending_To_Existing_Value_Result_Is_Successful_With_Valid_Cas()
		//{
		//	const string ToAppend = "The End";
		//	var key = GetUniqueKey("Append_Cas_Success");
		//	var value = GetRandomString();

		//	var storeResult = Assert.True(Store(key: key, value: value));
		//	ShouldPass(clientWR.Append(key, Encoding.UTF8.GetBytes(ToAppend), storeResult.Cas));
		//	ShouldPass(clientWR.Get(key), value + ToAppend);
		//}

		//[Fact]
		//public void When_Appending_To_Existing_Value_Result_Is_Not_Successful_With_Invalid_Cas()
		//{
		//	const string ToAppend = "The End";
		//	var key = GetUniqueKey("Append_Cas_Fail");
		//	var value = GetRandomString();

		//	var storeResult = ShouldPass(Store(key: key, value: value));
		//	ShouldFail(clientWR.Append(key, Encoding.UTF8.GetBytes(ToAppend), storeResult.Cas - 1));
		//	ShouldPass(clientWR.Get(key), value);
		//}

		//[Fact]
		//public void When_Prepending_To_Existing_Value_Result_Is_Successful_With_Valid_Cas()
		//{
		//	const string ToPrepend = "The Beginning";
		//	var key = GetUniqueKey("Prepend_Cas_Success");
		//	var value = GetRandomString();

		//	var storeResult = ShouldPass(Store(key: key, value: value));
		//	ShouldPass(clientWR.Prepend(key, Encoding.UTF8.GetBytes(ToPrepend), storeResult.Cas));
		//	ShouldPass(clientWR.Get(key), ToPrepend + value);
		//}

		//[Fact]
		//public void When_Prepending_To_Existing_Value_Result_Is_Not_Successful_With_Invalid_Cas()
		//{
		//	const string ToPrepend = "The Beginning";
		//	var key = GetUniqueKey("Prepend_Cas_Fail");
		//	var value = GetRandomString();

		//	var storeResult = ShouldPass(Store(key: key, value: value));
		//	ShouldFail(clientWR.Prepend(key, Encoding.UTF8.GetBytes(ToPrepend), storeResult.Cas - 1));
		//	ShouldPass(clientWR.Get(key), value);
		//}
	}
}

#region [ License information          ]

/* ************************************************************
 *
 *    @author Couchbase <info@couchbase.com>
 *    @author Attila Kiskó <a@enyim.com>
 *    @copyright 2012 Couchbase, Inc.
 *    @copyright 2014 Attila Kiskó, enyim.com
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