//  
//  RegistrationDictionnary.cs
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
using MonoMac.Growl;
using System.Reflection;
using System.IO;
namespace MonoDevelop.MacHint
{
	/// <summary>
	/// This class is providing the registration of the Growl application it self
	/// The registration need the application ID but also the list of notification
	/// </summary>
	internal class RegistrationDictionnary : NSObject
	{
			
		/// <summary>
		/// the list of notifications
		/// </summary>
		private string[] _notifications;
		
		/// <summary>
		/// the application ID
		/// </summary>
		private NSString _applicationID;
		
		/// <summary>
		/// the application name
		/// </summary>
		private NSString _applicationName;
		/// <summary>
		/// the application icon
		/// </summary>
		private NSData _applicationIcon;
			
		/// <summary>
		/// 
		/// </summary>
		/// <param name="applicationID">
		/// Describes the application ID
		/// </param>
		/// <param name="applicationName">
		/// Describes the application Name 
		/// </param>
		/// <param name="applicationIcon">
		/// Describes the application icon 
		/// </param>
		/// <param name="notifications">
		/// The list of notification
		/// </param>
		public RegistrationDictionnary(String applicationName,String applicationID,Stream applicationIcon, string[] notifications)
		{
			if(String.IsNullOrEmpty(applicationID)) 
			{ 
				throw new ArgumentNullException("applicationID");
			}
			if(String.IsNullOrEmpty(applicationName)) 
			{ 
				throw new ArgumentNullException("applicationName");
			}
			if(applicationIcon == null) 
			{ 
				throw new ArgumentNullException("applicationIcon");
			}
			if(notifications == null)
			{
				throw new ArgumentNullException("notifications");
			}
			
			_applicationID = new NSString(applicationID);
			_applicationName = new NSString(applicationName);
			_applicationIcon = NSData.FromStream(applicationIcon);
			_notifications = notifications;
			
			GrowlApplicationBridge.WeakDelegate = this;	
		}
		
		
		/// <summary>
		/// Provide the application name for growl
		/// </summary>
		/// <returns>
		/// Application name <see cref="String"/>
		/// </returns>
		[MonoMac.Foundation.Export("applicationNameForGrowl")]
		private NSString ApplicationName()
		{
			return _applicationName;	
		}
		
		/// <summary>
		/// Return the default application icon to use
		/// We can't find it from our bundle since we are not a real Cocoa application.
		/// </summary>
		/// <returns>
		/// A <see cref="NSData"/>
		/// </returns>
		[MonoMac.Foundation.Export("applicationIconDataForGrowl")]
		private NSData ApplicationIcon()
		{
			
			return _applicationIcon;
		}
		
		
		/// <summary>
		/// Construct the dictionnary for the configuration of Growl for our application
		/// </summary>
		/// <returns>
		/// A <see cref="NSDictionary"/>
		/// </returns>
		[MonoMac.Foundation.Export("registrationDictionaryForGrowl")]
		private NSDictionary RegistrationDictionaryForGrowl () {
 			
			//FIXME : No automatic conversion from string to NSString ???
			var keys = new NSObject[] { 
					new NSString("TicketVersion"), 
					new NSString("DefaultNotifications"),
                    new NSString("AllNotifications"),
					new NSString("ApplicationId")
			};

			var objects = new NSObject[] {NSNumber.FromInt32(1),
                                               NSArray.FromStrings(_notifications),
                                               NSArray.FromStrings(_notifications),
											   _applicationID};
			
       		
			var configurationDictionnary = NSMutableDictionary.FromObjectsAndKeys(objects,keys);
			return configurationDictionnary;
			
		}			
	}
	
}

