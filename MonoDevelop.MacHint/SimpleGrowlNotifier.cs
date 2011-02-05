//  
//  SimpleGrowlNotifier.cs
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
using System.IO;
using MonoMac.Foundation;
using MonoMac.Growl;
using MonoMac.ObjCRuntime;
using MonoMac.AppKit;
using System.Reflection;

namespace MonoDevelop.MacHint
{
	/// <summary>
	/// Our Growl notifier.
	/// It's a bridge to the GrowlApplicationBridge but use a C# enum for the notification id
	/// You're still able to use the GrowlApplicationBridge methods but it's refactoring-safe by
	/// using enum.
	/// </summary>
	public class SimpleGrowlNotifier<TNotifications>  : IDisposable
	{
		
		/// <summary>
		/// our registration
		/// </summary>
		private RegistrationDictionnary _registration;
		
		/// <summary>
		/// Initialize and register the notification from TNotifications to Growl
		/// By attaching it to the applicationID
		/// </summary>
		/// <param name="applicationName">
		/// the application nane
		/// </param>
		/// <param name="applicationID">
		/// the application id
		/// </param>
		/// <param name="applicationIcon">
		/// the application icon
		/// </param>
		public SimpleGrowlNotifier (String applicationName,String applicationID,Stream applicationIcon)
		{
			if( !typeof(TNotifications).IsEnum )
			{
				throw new NotSupportedException( "TNotifications must be an Enum" );
			}	
			
			_registration = new RegistrationDictionnary(applicationName,applicationID,applicationIcon,GetNotificationsList());
			
		}
		
		/// <summary>
		/// Notification thu Growl. See MonoMac.Growl.GrowlApplicationBridge.Notify />
		/// </summary>
		/// <param name="title">
		/// Title 
		/// </param>
		/// <param name="description">
		/// Description 
		/// </param>
		/// <param name="notification">
		/// Notification id
		/// </param>
		/// <param name="iconData">
		/// the icon data - use NSIMage.AsTiff to get it or Growl.DefaultIcon for the default icon
		/// </param>
		/// <param name="priority">
		/// Priority 
		/// </param>
		/// <param name="isSticky">
		/// Is Sticky 
		/// </param>
		/// <param name="clickContext">
		/// Callback context 
		/// </param>
		public  void Notify (string title, string description, TNotifications notification, NSData iconData, int priority, bool isSticky, NSObject clickContext)
		{
			GrowlApplicationBridge.Notify(title,description,notification.ToString(),iconData,priority,isSticky,clickContext);	
		}
		
		/// <summary>
		/// Notification thu Growl. See MonoMac.Growl.GrowlApplicationBridge.Notify />
		/// </summary>
		/// <param name="title">
		/// Title 
		/// </param>
		/// <param name="description">
		/// Description 
		/// </param>
		/// <param name="notification">
		/// Notification id
		/// </param>
		/// <param name="iconData">
		/// the icon data - use NSIMage.AsTiff to get it or Growl.DefaultIcon for the default icon
		/// </param>
		/// <param name="priority">
		/// Priority 
		/// </param>
		/// <param name="isSticky">
		/// Is Sticky 
		/// </param>
		/// <param name="clickContext">
		/// Callback context 
		/// </param>
		/// <param name="identifier">
		/// identifier for the callback 
		/// </param>
		public  void Notify (string title, string description, TNotifications notification, NSData iconData, int priority, bool isSticky, NSObject clickContext,string identifier)
		{
			GrowlApplicationBridge.Notify(title,description,notification.ToString(),iconData,priority,isSticky,clickContext,identifier);	
		}
		
		/// <summary>
		/// Retrieve the notification as string list.
		/// </summary>
		/// <returns>
		/// Notification ID list
		/// </returns>
		private string[] GetNotificationsList()
		{
			return Enum.GetNames(typeof(TNotifications));
		}
		/// <summary>
		/// Configure growl, to be done before initializing the Coca application.
		/// </summary>
		public static void ConfigureGrowl()
		{
			var assemblyDirectory = Assembly.GetExecutingAssembly().Location;
			var growlPath = Path.Combine(Directory.GetParent(assemblyDirectory).ToString(), "Growl");
			Dlfcn.dlopen (growlPath, 0);;	
		}
		
		#region IDisposable implementation
	
		/// <summary>
		/// Dipose method
		/// </summary>
		public void Dispose ()
		{
			_registration.Dispose();
			_registration = null;
		}
		#endregion
	}
}

