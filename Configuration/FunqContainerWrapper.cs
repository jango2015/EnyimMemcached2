﻿using System;
using System.Collections.Generic;
using System.Linq;
using Funq;

namespace Enyim.Caching.Memcached.Configuration
{
	internal class FunqContainerWrapper : IContainer
	{
		private readonly Container root;

		public FunqContainerWrapper(Container root)
		{
			this.root = root;
		}

		public TService Resolve<TService>()
		{
			lock (root)
				return root.Resolve<TService>();
		}

		public void Dispose()
		{
			root.Dispose();
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
