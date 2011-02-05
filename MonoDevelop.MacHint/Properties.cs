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
		/// <summary>
		/// AlwaysDisplayBuildResult property ID
		/// </summary>
		public const string AlwaysDisplayBuildResultId = "MonoDevelop.MacHint.AlwaysDisplayBuildResult";
		
		/// <summary>
		/// AlwaysDisplayBuildResult default value;
		/// </summary>
		public const bool  AlwaysDisplayBuildResultDefault = true;
		
		/// <summary>
		/// AlwaysDisplayBuildResult property
		/// </summary>
		public static bool AlwaysDisplayBuildResult
		{
			get
			{
				return PropertyService.Get(AlwaysDisplayBuildResultId, AlwaysDisplayBuildResultDefault);
			}	
			set
			{
				PropertyService.Set(AlwaysDisplayBuildResultId,value);	
			}
			
		}
	}
}

