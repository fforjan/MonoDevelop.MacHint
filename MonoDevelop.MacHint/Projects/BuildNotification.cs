//  
//  BuildNotification.cs
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
using MonoDevelop.Projects;
using MonoDevelop.Core;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoDevelop.Ide;
namespace MonoDevelop.MacHint.Projects
{
	/// <summary>
	/// This class implements the project service extension
	/// This extension determines when the build is succedded or failed
	/// </summary>
	public class BuildNotification: ProjectServiceExtension  
	{  
		/// <summary>
		/// This method is call during a solution build
		/// </summary>
		protected override BuildResult Build (IProgressMonitor monitor, Solution solution, ConfigurationSelector configuration)
		{			
			var startTime = DateTime.Now;
			var result = base.Build (monitor, solution, configuration);
		
			var ellapsedTime = DateTime.Now - startTime;
			
			if(Properties.BuildNotification 
			    // we only display if the build time is enough...
			   && ( ellapsedTime.TotalSeconds > Properties.MinimumBuildTime)  
			   && (
			       //but we also check if MonoDevelop has the focus and our properties
			       (!Properties.BuildNotificationOnlyWhenNotActive) || !IdeApp.Workbench.RootWindow.HasToplevelFocus)
			      )
			{
				GrowlService.Instance.Notify(
			                                 "Build Result",
			                                 String.Format("{0} is {1}", result.SourceTarget.Name ,result.Failed ? "Failed" : "Succeeded"),
			                                 GrowlService.NotificationId.BuildResult,
			                                 GrowlService.DefaultIcon,0,false,null);
			}
			return result;
		}
		
  
	}
}

