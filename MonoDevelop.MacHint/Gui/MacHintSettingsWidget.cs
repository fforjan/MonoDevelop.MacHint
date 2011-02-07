//  
//  MacHintSettingsWidget.cs
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
namespace MonoDevelop.MacHint.Gui
{
	/// <summary>
	/// Widget for our settings
	/// </summary>
	public partial class MacHintSettingsWidget : Gtk.Bin
	{
		/// <summary>
		/// Default constructor.
		/// the value are set according to the properties.
		/// </summary>
		public MacHintSettingsWidget ()
		{
			this.Build ();
			
			//Notification
			this.buildNotification.Active = Properties.BuildNotification;
			this.minimumBuildTime.Value = Properties.MinimumBuildTime;
			this.minimumBuildTime.Sensitive = this.buildNotification.Active;
			
			this.onlyNotActiveApplication.Active = Properties.BuildNotificationOnlyWhenNotActive;
			this.onlyNotActiveApplication.Sensitive = this.buildNotification.Active;
			
			//auto-save
			this.autoSaveInterfaceBuilder.Active = Properties.AutoSaveInterfaceBuilderDoc;
			
		}

		
		/// <summary>
		/// This method saves the current information from the UI into the properties
		/// </summary>
		public void ApplyChanges()
		{
			//Notification
			Properties.MinimumBuildTime = this.minimumBuildTime.Value;
			Properties.BuildNotification = this.buildNotification.Active;
			Properties.BuildNotificationOnlyWhenNotActive = this.onlyNotActiveApplication.Active;
			
			//auto-save
			Properties.AutoSaveInterfaceBuilderDoc = this.autoSaveInterfaceBuilder.Active;
			
		}
		
		/// <summary>
		/// When the build notification is activated or deactivate, the spin button is sensitive or not
		/// </summary>
		/// <param name="sender">
		/// event sender
		/// </param>
		/// <param name="args">
		/// event args
		/// </param>
		protected virtual void OnBuildNotificationToggled (object sender, System.EventArgs args)
		{
			this.minimumBuildTime.Sensitive = this.buildNotification.Active;
			this.onlyNotActiveApplication.Sensitive = this.buildNotification.Active;
		}
		
		
	}
}

