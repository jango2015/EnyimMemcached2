﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Enyim.Caching.Memcached.Protocol.Binary
{
	/// <summary>
	/// SASL auth step.
	/// </summary>
	public class SaslContinue : SaslStep
	{
		private byte[] continuation;

		public SaslContinue(ISaslAuthenticationProvider provider, byte[] continuation)
			: base(provider)
		{
			this.continuation = continuation;
		}

		protected override BinaryRequest Build()
		{
			var request = new BinaryRequest(OpCode.SaslStep)
			{
				Key = this.Provider.Type,
				Data = new ArraySegment<byte>(this.Provider.Continue(this.continuation))
			};

			return request;
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
