//  
//  NSAppleScript.cs
//  
//  Author:
//       Frederic Forjan <fforjan@free.fr>
// 
//  Copyright (c) 2011 
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;

namespace MonoDevelop.MacHint.Items
{
	/// <summary>
	/// Defines the NSAppleScript interface 
	/// </summary>
	[Register("NSAppleScript")]
	public class NSAppleScript: NSObject
	{
		
		static Selector selInit       = new Selector("initWithSource:");  
		static Selector selExecuteAndReturnError = new Selector("executeAndReturnError:");
		
		/// <summary>
		/// Construct a new applescript with content from string
		/// </summary>
		/// <param name="source">
		/// The source code of the script.
		/// </param>
		/// <returns>
		/// </returns>
		[Export("initWithSource:")]
        public NSAppleScript(string source) : base(NSObjectFlag.Empty)
		{
			var nsSource = new NSString(source);
			Handle = Messaging.IntPtr_objc_msgSend_IntPtr(this.Handle, selInit.Handle,nsSource.Handle);
		}
		
		/// <summary>
		/// Mandatory constructor
		/// </summary>
		/// <param name="handle">
		/// Handle <see cref="IntPtr"/>
		/// </param>
		public NSAppleScript(IntPtr handle)  
            : base(handle)  
        {  
        }  
			
		/// <summary>
		/// 
		/// </summary>
		/// <param name="errorInfo">
		/// </param>
		/// <returns>
		/// A <see cref="NSObject"/>
		/// </returns>
		[Export ("executeAndReturnError:")]
        public NSAppleEventDescriptor Execute(ref NSDictionary errorInfo)
		{
			var eventDescriptor = 	Messaging.IntPtr_objc_msgSend_IntPtr(this.Handle, selExecuteAndReturnError.Handle,errorInfo.Handle);
			return new NSAppleEventDescriptor(eventDescriptor);
		}

        
	}
}

