//  
//  Properties.cs
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
using MonoDevelop.Core;
namespace MonoDevelop.MacHint
{
	/// <summary>
	/// Manage the Properties
	/// </summary>
	public static class Properties
	{
		#region AlwaysDisplayBuildResult
		/// <summary>
		/// AlwaysDisplayBuildResult property ID
		/// </summary>
		private const string BuildNotificationId = "MonoDevelop.MacHint.BuildNotification";
		
		/// <summary>
		/// AlwaysDisplayBuildResult default value;
		/// </summary>
		private const bool  BuildNotificationDefault = true;
		
		/// <summary>
		/// AlwaysDisplayBuildResult property
		/// </summary>
		public static bool BuildNotification
		{
			get
			{
				return PropertyService.Get(BuildNotificationId, BuildNotificationDefault);
			}	
			set
			{
				PropertyService.Set(BuildNotificationId,value);	
			}
			
		}
		#endregion
		
		#region MinimumBuildTime
		/// <summary>
		/// MinimumBuildTime property ID
		/// </summary>
		private const string MinimumBuildTimeId = "MonoDevelop.MacHint.MinimumBuildTime";
		
		/// <summary>
		/// MinimumBuildTime default value;
		/// </summary>
		private const double  MinimumBuildTimeDefault = 2.0;
		
		/// <summary>
		/// MinimumBuildTime property
		/// </summary>
		public static double MinimumBuildTime
		{
			get
			{
				return PropertyService.Get(MinimumBuildTimeId, MinimumBuildTimeDefault);
			}	
			set
			{
				PropertyService.Set(MinimumBuildTimeId,value);	
			}
			
		}
		
		
		#endregion
		
		
		#region AutoSaveInterfaceBuilderDoc
		/// <summary>
		/// AutoSaveInterfaceBuilderDoc property ID
		/// </summary>
		private const string AutoSaveInterfaceBuilderDocId = "MonoDevelop.MacHint.AutoSaveInterfaceBuilderDoc";
		
		/// <summary>
		/// AutoSaveInterfaceBuilderDoc default value;
		/// </summary>
		private const bool  AutoSaveInterfaceBuilderDocDefault = true;
		
		/// <summary>
		/// AutoSaveInterfaceBuilderDoc property
		/// </summary>
		public static bool AutoSaveInterfaceBuilderDoc
		{
			get
			{
				return PropertyService.Get(AutoSaveInterfaceBuilderDocId, AutoSaveInterfaceBuilderDocDefault);
			}	
			set
			{
				PropertyService.Set(AutoSaveInterfaceBuilderDocId,value);	
			}
			
		}
		
		#endregion  
		
		#region AutoSaveInterfaceBuilderDoc
		/// <summary>
		/// AlwaysNotifyBuild property ID
		/// </summary>
		private const string BuildNotificationOnlyWhenNotActiveId = "MonoDevelop.MacHint.BuildNotificationOnlyWhenNotActive";
		
		/// <summary>
		/// AlwaysNotifyBuild default value;
		/// </summary>
		private const bool  BuildNotificationOnlyWhenNotActiveDefault = false;
		
		/// <summary>
		/// AlwaysNotifyBuild property
		/// </summary>
		public static bool BuildNotificationOnlyWhenNotActive
		{
			get
			{
				return PropertyService.Get(BuildNotificationOnlyWhenNotActiveId, BuildNotificationOnlyWhenNotActiveDefault);
			}	
			set
			{
				PropertyService.Set(BuildNotificationOnlyWhenNotActiveId,value);	
			}
			
		}
		
		#endregion  AlwaysNotifyBuild
	}
}

