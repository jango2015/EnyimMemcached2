using System;

namespace Enyim.Caching.Memcached
{
	public struct Expiration
	{
		private const int MaxSeconds = 60 * 60 * 24 * 30;
		private static readonly DateTime UnixEpochUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public static readonly Expiration Never = new Expiration { IsAbsolute = true, IsForever = true, Value = 0 };

		public bool IsAbsolute { get; private set; }
		public bool IsForever { get; private set; }
		public uint Value { get; private set; }

		public static implicit operator Expiration(TimeSpan validFor)
		{
			// infinity
			if (validFor == TimeSpan.Zero || validFor == TimeSpan.MaxValue)
				return Never;

			var seconds = (uint)validFor.TotalSeconds;
			if (seconds < MaxSeconds) return new Expiration { Value = seconds };

			return (SystemTime.Now() + validFor);
		}

		public static implicit operator Expiration(DateTime expiresAt)
		{
			if (expiresAt == DateTime.MaxValue || expiresAt == DateTime.MinValue)
				return Never;

			if (expiresAt <= UnixEpochUtc)
				throw new ArgumentOutOfRangeException("expiresAt must be > " + UnixEpochUtc);

			return new Expiration
			{
				IsAbsolute = true,
				Value = (uint)(expiresAt.ToUniversalTime() - UnixEpochUtc).TotalSeconds
			};
		}

		public static implicit operator Expiration(uint value)
		{
			return value == 0 || value == UInt32.MaxValue
					? Never
					: value < MaxSeconds
						? new Expiration { Value = value }
						: new Expiration { IsAbsolute = true, Value = value };
		}
	}
}