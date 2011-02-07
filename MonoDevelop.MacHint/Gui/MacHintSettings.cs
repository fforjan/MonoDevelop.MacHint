//  
//  MacHintSettings.cs
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
using MonoDevelop.Ide.Gui.Dialogs;
namespace MonoDevelop.MacHint.Gui
{
	/// <summary>
	/// Our settings panelfor MacHint
	/// </summary>
	public class MacHintSettings : OptionsPanel
	{
		
		/// <summary>
		/// The widget displaying our settings
		/// </summary>
		MacHintSettingsWidget _widget;
		
		/// <summary>
		/// This method instantiate our widget.
		/// A local reference is keep.
		/// </summary>
		/// <returns>
		/// The widget
		/// </returns>
		public override Gtk.Widget CreatePanelWidget ()
		{
			return _widget = new MacHintSettingsWidget();
		}
		
		/// <summary>
		/// The data are saves from the UI into the properties.
		/// </summary>
		public override void ApplyChanges ()
		{
			_widget.ApplyChanges();
		}
	}
}

