//  
//  SaveModifiedInterfaceBuilder.cs
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
using System.Reflection;
using System.IO;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;
namespace MonoDevelop.MacHint.Items
{
	/// <summary>
	/// This class enables to check if there is any interface builder document opened
	/// </summary>
	public class SaveModifiedInterfaceBuilder : ProjectServiceExtension
	{
		/// <summary>
		/// our private member for the save script singleton
		/// </summary>
		static NSAppleScript _saveDocumentScript;
		
		/// <summary>
		/// Our save script singleton
		/// </summary>
		static public NSAppleScript SaveDocumentScript
		{
			get
			{
				if(_saveDocumentScript ==null)
				{
					var sourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MonoDevelop.MacHint.Resources.SavingInterfaceBuilder.scpt");
			
					var scriptContent = new StreamReader(sourceStream).ReadToEnd();
		
					_saveDocumentScript = new NSAppleScript(scriptContent);
				}
				return _saveDocumentScript;
			}
			
		}
		
		/// <summary>
		/// This method execute an AppleScript to save document Into the interface builder
		/// </summary>
		private void SaveInterfaceBuilderDocument()
		{
			NSDictionary errors = new NSDictionary();
			SaveDocumentScript.Execute(ref errors);
		}
		/// <summary>
		/// Before doing any build, run our appliscript to save any document
		/// TODO : Check/Save only the one in the target
		/// </summary>
		protected override BuildResult Build (Core.IProgressMonitor monitor, Solution solution, ConfigurationSelector configuration)
		{
			SaveInterfaceBuilderDocument();
			
			return base.Build (monitor, solution, configuration);
		}
		
		
	}
}

