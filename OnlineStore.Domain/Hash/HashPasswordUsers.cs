﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Hash
{
	public static class HashPasswordUsers
	{
		public static string HashPassowrd(string password)
		{
			using (var sha256 = SHA256.Create())
			{
				var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
				var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

				return hash;
			}
		}
	}
}
