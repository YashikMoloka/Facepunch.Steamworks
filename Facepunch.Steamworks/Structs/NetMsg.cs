﻿using Steamworks.Data;
using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	[StructLayout( LayoutKind.Sequential )]
	internal struct NetMsg
	{
		// #32bit
		internal IntPtr DataPtr;
		internal int DataSize;
		internal NetConnection Connection;
		internal NetworkIdentity Identity;
		internal long ConnectionUserData;
		internal SteamNetworkingMicroseconds TimeRecv;
		internal long MessageNumber;
		internal IntPtr FreeDataPtr;
		internal IntPtr ReleasePtr;
		internal int Channel;


		internal delegate void ReleaseDelegate( IntPtr msg );

		public void Release( IntPtr data )
		{
			//
			// I think this function might be a static global, so we could probably
			// cache this release call.
			//
			var d = Marshal.GetDelegateForFunctionPointer<ReleaseDelegate>( ReleasePtr );
			d( data );
		}
	}
}