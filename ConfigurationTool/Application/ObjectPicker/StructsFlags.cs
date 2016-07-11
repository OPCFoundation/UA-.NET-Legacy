/* ========================================================================
 * Copyright (c) 2005-2016 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Runtime.InteropServices;

namespace CubicOrange.Windows.Forms.ActiveDirectory
{
	/// <summary>
	/// This structure is used as a parameter in OLE functions and methods that require data format information.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
    internal struct FORMATETC
	{
		public int cfFormat;
		public IntPtr ptd;
		public uint dwAspect;
		public int lindex;
		public uint tymed;
	}

	/// <summary>
	/// The STGMEDIUM structure is a generalized global memory handle used for data transfer operations by the IDataObject
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
    internal struct STGMEDIUM
	{
		public uint tymed;
		public IntPtr hGlobal;
		public Object pUnkForRelease;
	}

	/// <summary>
	/// The DSOP_INIT_INFO structure contains data required to initialize an object picker dialog box. 
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
    internal struct DSOP_INIT_INFO
	{
		public uint cbSize;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzTargetComputer;
		public uint cDsScopeInfos;
		public IntPtr aDsScopeInfos;
		public uint flOptions;
		public uint cAttributesToFetch;
		public IntPtr apwzAttributeNames;
	}


	/// <summary>
	/// The DSOP_SCOPE_INIT_INFO structure describes one or more scope types that have the same attributes. 
    /// A scope type is a type of location, for example a domain, computer, or Global Catalog, 
    /// from which the user can select objects.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto), Serializable]
    internal struct DSOP_SCOPE_INIT_INFO
	{
		public uint cbSize;
		public uint flType;
		public uint flScope;
		[MarshalAs(UnmanagedType.Struct)]
		public DSOP_FILTER_FLAGS FilterFlags;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzDcName; 
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzADsPath;
		public uint hr;
	}

	/// <summary>
	/// The DSOP_UPLEVEL_FILTER_FLAGS structure contains flags that indicate the filters to use for an up-level scope. 
    /// An up-level scope is a scope that supports the ADSI LDAP provider.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
    internal struct DSOP_UPLEVEL_FILTER_FLAGS
	{
		public uint flBothModes;
		public uint flMixedModeOnly;
		public uint flNativeModeOnly;
	}

	/// <summary>
	/// The DSOP_FILTER_FLAGS structure contains flags that indicate the types of objects presented to the user 
    /// for a specified scope or scopes.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
    internal struct DSOP_FILTER_FLAGS
	{
		public DSOP_UPLEVEL_FILTER_FLAGS Uplevel;
		public uint flDownlevel;
	}

    /// <summary>
    /// The DS_SELECTION structure contains data about an object the user selected from an object picker dialog box. 
	/// The DS_SELECTION_LIST structure contains an array of DS_SELECTION structures.
    /// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
    internal struct DS_SELECTION
	{
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzName;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzADsPath;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzClass;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzUPN;
		public IntPtr pvarFetchedAttributes;
		public uint flScopeType;
	}
	/// <summary>
	/// The DS_SELECTION_LIST structure contains data about the objects the user selected from an object picker dialog box.
	/// This structure is supplied by the IDataObject interface supplied by the IDsObjectPicker::InvokeDialog method 
    /// in the CFSTR_DSOP_DS_SELECTION_LIST data format.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
    internal struct DS_SELECTION_LIST
	{
		public uint cItems;
		public uint cFetchedAttributes;
		public DS_SELECTION[] aDsSelection;
	}

	/// <summary>
	/// Flags that indicate the scope types described by this structure. You can combine multiple scope types 
    /// if all specified scopes use the same settings. 
	/// </summary>
    internal class DSOP_SCOPE_TYPE_FLAGS
	{
		public const uint DSOP_SCOPE_TYPE_TARGET_COMPUTER = 0x00000001;
		public const uint DSOP_SCOPE_TYPE_UPLEVEL_JOINED_DOMAIN = 0x00000002;
		public const uint DSOP_SCOPE_TYPE_DOWNLEVEL_JOINED_DOMAIN = 0x00000004;
		public const uint DSOP_SCOPE_TYPE_ENTERPRISE_DOMAIN = 0x00000008;
		public const uint DSOP_SCOPE_TYPE_GLOBAL_CATALOG = 0x00000010;
		public const uint DSOP_SCOPE_TYPE_EXTERNAL_UPLEVEL_DOMAIN = 0x00000020;
		public const uint DSOP_SCOPE_TYPE_EXTERNAL_DOWNLEVEL_DOMAIN = 0x00000040;
		public const uint DSOP_SCOPE_TYPE_WORKGROUP = 0x00000080;
		public const uint DSOP_SCOPE_TYPE_USER_ENTERED_UPLEVEL_SCOPE = 0x00000100;
		public const uint DSOP_SCOPE_TYPE_USER_ENTERED_DOWNLEVEL_SCOPE = 0x00000200;
	}

	/// <summary>
	/// Flags that determine the object picker options.
	/// </summary>
    internal class DSOP_INIT_INFO_FLAGS
	{
		public const uint DSOP_FLAG_MULTISELECT = 0x00000001;
		public const uint DSOP_FLAG_SKIP_TARGET_COMPUTER_DC_CHECK = 0x00000002;
	}

	/// <summary>
	/// Flags that indicate the format used to return ADsPath for objects selected from this scope. 
    /// The flScope member can also indicate the initial scope displayed in the Look in drop-down list. 
	/// </summary>
    internal class DSOP_SCOPE_INIT_INFO_FLAGS
	{
		public const uint DSOP_SCOPE_FLAG_STARTING_SCOPE =0x00000001;
		public const uint DSOP_SCOPE_FLAG_WANT_PROVIDER_WINNT =0x00000002;
		public const uint DSOP_SCOPE_FLAG_WANT_PROVIDER_LDAP =0x00000004;
		public const uint DSOP_SCOPE_FLAG_WANT_PROVIDER_GC =0x00000008;
		public const uint DSOP_SCOPE_FLAG_WANT_SID_PATH =0x00000010;
		public const uint DSOP_SCOPE_FLAG_WANT_DOWNLEVEL_BUILTIN_PATH =0x00000020;
		public const uint DSOP_SCOPE_FLAG_DEFAULT_FILTER_USERS =0x00000040;
		public const uint DSOP_SCOPE_FLAG_DEFAULT_FILTER_GROUPS =0x00000080;
		public const uint DSOP_SCOPE_FLAG_DEFAULT_FILTER_COMPUTERS =0x00000100;
		public const uint DSOP_SCOPE_FLAG_DEFAULT_FILTER_CONTACTS =0x00000200;
	}

	/// <summary>
	/// Filter flags to use for an up-level scope, regardless of whether it is a mixed or native mode domain. 
	/// </summary>
    internal class DSOP_FILTER_FLAGS_FLAGS
	{
		public const uint DSOP_FILTER_INCLUDE_ADVANCED_VIEW = 0x00000001;
		public const uint DSOP_FILTER_USERS = 0x00000002;
		public const uint DSOP_FILTER_BUILTIN_GROUPS = 0x00000004;
		public const uint DSOP_FILTER_WELL_KNOWN_PRINCIPALS = 0x00000008;
		public const uint DSOP_FILTER_UNIVERSAL_GROUPS_DL = 0x00000010;
		public const uint DSOP_FILTER_UNIVERSAL_GROUPS_SE = 0x00000020;
		public const uint DSOP_FILTER_GLOBAL_GROUPS_DL = 0x00000040;
		public const uint DSOP_FILTER_GLOBAL_GROUPS_SE = 0x00000080;
		public const uint DSOP_FILTER_DOMAIN_LOCAL_GROUPS_DL = 0x00000100;
		public const uint DSOP_FILTER_DOMAIN_LOCAL_GROUPS_SE = 0x00000200;
		public const uint DSOP_FILTER_CONTACTS = 0x00000400;
		public const uint DSOP_FILTER_COMPUTERS = 0x00000800;
	}

	/// <summary>
	/// Contains the filter flags to use for down-level scopes
	/// </summary>
    internal class DSOP_DOWNLEVEL_FLAGS
	{
		public const uint DSOP_DOWNLEVEL_FILTER_USERS = 0x80000001;
		public const uint DSOP_DOWNLEVEL_FILTER_LOCAL_GROUPS = 0x80000002;
		public const uint DSOP_DOWNLEVEL_FILTER_GLOBAL_GROUPS = 0x80000004;
		public const uint DSOP_DOWNLEVEL_FILTER_COMPUTERS = 0x80000008;
		public const uint DSOP_DOWNLEVEL_FILTER_WORLD = 0x80000010;
		public const uint DSOP_DOWNLEVEL_FILTER_AUTHENTICATED_USER = 0x80000020;
		public const uint DSOP_DOWNLEVEL_FILTER_ANONYMOUS = 0x80000040;
		public const uint DSOP_DOWNLEVEL_FILTER_BATCH = 0x80000080;
		public const uint DSOP_DOWNLEVEL_FILTER_CREATOR_OWNER = 0x80000100;
		public const uint DSOP_DOWNLEVEL_FILTER_CREATOR_GROUP = 0x80000200;
		public const uint DSOP_DOWNLEVEL_FILTER_DIALUP = 0x80000400;
		public const uint DSOP_DOWNLEVEL_FILTER_INTERACTIVE = 0x80000800;
		public const uint DSOP_DOWNLEVEL_FILTER_NETWORK = 0x80001000;
		public const uint DSOP_DOWNLEVEL_FILTER_SERVICE = 0x80002000;
		public const uint DSOP_DOWNLEVEL_FILTER_SYSTEM = 0x80004000;
		public const uint DSOP_DOWNLEVEL_FILTER_EXCLUDE_BUILTIN_GROUPS = 0x80008000;
		public const uint DSOP_DOWNLEVEL_FILTER_TERMINAL_SERVER = 0x80010000;
		public const uint DSOP_DOWNLEVEL_FILTER_ALL_WELLKNOWN_SIDS = 0x80020000;
		public const uint DSOP_DOWNLEVEL_FILTER_LOCAL_SERVICE = 0x80040000;
		public const uint DSOP_DOWNLEVEL_FILTER_NETWORK_SERVICE = 0x80080000;
		public const uint DSOP_DOWNLEVEL_FILTER_REMOTE_LOGON = 0x80100000;
	}

	/// <summary>
	/// The IDsObjectPicker.InvokeDialog result
	/// </summary>
    internal class HRESULT
	{
		public const int S_OK = 0; // The method succeeded. 
		public const int S_FALSE = 1; // The user cancelled the dialog box. ppdoSelections receives NULL. 
		public const int E_NOTIMPL = unchecked((int)0x80004001); // ?
	}

	/// <summary>
	/// The CFSTR_DSOP_DS_SELECTION_LIST clipboard format is provided by the IDataObject obtained by calling IDsObjectPicker.InvokeDialog
	/// </summary>
    internal class CLIPBOARD_FORMAT
	{
		public const string CFSTR_DSOP_DS_SELECTION_LIST =
			"CFSTR_DSOP_DS_SELECTION_LIST";
	}

	/// <summary>
	/// The TYMED enumeration values indicate the type of storage medium being used in a data transfer. 
	/// </summary>
    internal enum TYMED
	{
		TYMED_HGLOBAL = 1,
		TYMED_FILE = 2,
		TYMED_ISTREAM = 4,
		TYMED_ISTORAGE = 8,
		TYMED_GDI = 16,
		TYMED_MFPICT = 32,
		TYMED_ENHMF = 64,
		TYMED_NULL = 0
	}

	/// <summary>
	/// The DVASPECT enumeration values specify the desired data or view aspect of the object when drawing or getting data.
	/// </summary>
    internal enum DVASPECT
	{
		DVASPECT_CONTENT = 1,
		DVASPECT_THUMBNAIL = 2,
		DVASPECT_ICON = 4,
		DVASPECT_DOCPRINT = 8
	}

}
