//  
//  Initializer.cs
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
using MonoMac.AppKit;
using MonoMac.Foundation;
namespace MonoDevelop.MacHint
{
	/// <summary>
	/// This class provides access to the growl service.
	/// </summary>
	public static class GrowlService
	{
	
		/// <summary>
		/// The list of notification available
		/// </summary>
		public enum NotificationId
		{
			/// <summary>
			/// Use this id to identiy a notification link to build result
			/// </summary>
			BuildResult,
		}
		
		/// <summary>
		/// Default Icon -i.e. application icon- to be used within the Notify method.
		/// </summary>
		public static readonly NSData DefaultIcon = new NSData();
		
		/// <summary>
		/// The service implementation itself
		/// </summary>
		public static SimpleGrowlNotifier<NotificationId> GrowlServiceInstance {get;private set;}
		
		/// <summary>
		/// Static constructor, it initialized the growl connection as soon as possible.
		/// </summary>
		static GrowlService ()
		{
			try
			{
				SimpleGrowlNotifier<NotificationId>.ConfigureGrowl();
				NSApplication.Init();
				GrowlServiceInstance = new SimpleGrowlNotifier<NotificationId>("MonoDevelop","MonoDevelop.MacHint.0.1");
			}
			catch(Exception ex)
			{
				MonoDevelop.Core.LoggingService.LogError("Error during initializing the GrowlService",ex);
			}
			
		}
	}
}

