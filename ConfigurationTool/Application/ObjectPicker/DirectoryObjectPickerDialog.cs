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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CubicOrange.Windows.Forms.ActiveDirectory
{
    /// <summary>
    /// Represents a common dialog that allows a user to select directory objects.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The directory object picker dialog box enables a user to select one or more objects 
    /// from either the global catalog, a Microsoft Windows 2000 domain or computer, 
    /// a Microsoft Windows NT 4.0 domain or computer, or a workgroup. The object types 
    /// from which a user can select include user, contact, group, and computer objects.
    /// </para>
    /// <para>
    /// This managed class wraps the Directory Object Picker common dialog from 
    /// the Active Directory UI.
    /// </para>
    /// <para>
    /// It simplifies the scope (Locations) and filter (ObjectTypes) selection by allowing a single filter to be
    /// specified which applies to all scopes (translating to both up-level and down-level
    /// filter flags as necessary).
    /// </para>
    /// <para>
    /// The object type filter is also simplified by combining different types of groups (local, global, etc)
    /// and not using individual well known types in down-level scopes (only all well known types
    /// can be specified).
    /// </para>
    /// <para>
    /// The scope location is also simplified by combining down-level and up-level variations
    /// into a single locations flag, e.g. external domains.
    /// </para>
    /// </remarks>
	public class DirectoryObjectPickerDialog : CommonDialog
	{
        private Locations allowedLocations;
        private ObjectTypes allowedTypes;
        private Locations defaultLocations;
        private ObjectTypes defaultTypes;
        private bool multiSelect;
        private DirectoryObject[] selectedObjects;
        private bool showAdvancedView;
        private string targetComputer;

        /// <summary>
        /// Constructor. Sets all properties to their default values.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The default values for the DirectoryObjectPickerDialog properties are:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader><term>Property</term><description>Default value</description></listheader>
        /// <item><term>AllowedLocations</term><description>All locations.</description></item>
        /// <item><term>AllowedObjectTypes</term><description>All object types.</description></item>
        /// <item><term>DefaultLocations</term><description>None. (Will default to first location.)</description></item>
        /// <item><term>DefaultObjectTypes</term><description>All object types.</description></item>
        /// <item><term>MultiSelect</term><description>false.</description></item>
        /// <item><term>SelectedObject</term><description>null.</description></item>
        /// <item><term>SelectedObjects</term><description>Empty array.</description></item>
        /// <item><term>ShowAdvancedView</term><description>false.</description></item>
        /// <item><term>TargetComputer</term><description>null.</description></item>
        /// </list>
        /// </para>
        /// </remarks>
        public DirectoryObjectPickerDialog()
        {
            Reset();
        }

        /// <summary>
        /// Gets or sets the scopes the DirectoryObjectPickerDialog is allowed to search.
        /// </summary>
        public Locations AllowedLocations
        {
            get { return allowedLocations; }
            set { allowedLocations = value; }
        }

        /// <summary>
        /// Gets or sets the types of objects the DirectoryObjectPickerDialog is allowed to search for.
        /// </summary>
        public ObjectTypes AllowedObjectTypes
        {
            get { return allowedTypes; }
            set { allowedTypes = value; }
        }

        /// <summary>
        /// Gets or sets the initially selected scope in the DirectoryObjectPickerDialog.
        /// </summary>
        public Locations DefaultLocations
        {
            get { return defaultLocations; }
            set { defaultLocations = value; }
        }

        /// <summary>
        /// Gets or sets the initially seleted types of objects in the DirectoryObjectPickerDialog.
        /// </summary>
        public ObjectTypes DefaultObjectTypes
        {
            get { return defaultTypes; }
            set { defaultTypes = value; }
        }

        /// <summary>
        /// Gets or sets whether the user can select multiple objects.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If this flag is false, the user can select only one object.
        /// </para>
        /// </remarks>
        public bool MultiSelect
        {
            get { return multiSelect; }
            set { multiSelect = value; }
        }

        /// <summary>
        /// Gets the directory object selected in the dialog, or null if no object was selected.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If MultiSelect is enabled, then this property returns only the first selected object.
        /// Use SelectedObjects to get an array of all objects selected.
        /// </para>
        /// </remarks>
        public DirectoryObject SelectedObject
        {
            get
            {
                if (selectedObjects == null | selectedObjects.Length == 0)
                {
                    return null;
                }
                return selectedObjects[0];
            }
        }

        /// <summary>
        /// Gets an array of the directory objects selected in the dialog.
        /// </summary>
        public DirectoryObject[] SelectedObjects
        {
            get
            {
                if (selectedObjects == null)
                {
                    return new DirectoryObject[0];
                }
                return (DirectoryObject[])selectedObjects.Clone();
            }
        }

        /// <summary>
        /// Gets or sets whether objects flagged as show in advanced view only are displayed (up-level).
        /// </summary>
        public bool ShowAdvancedView
        {
            get { return showAdvancedView; }
            set { showAdvancedView = value; }
        }

        /// <summary>
        /// Gets or sets the name of the target computer. 
        /// </summary>
        /// <remarks>
        /// <para>
        /// The dialog box operates as if it is running on the target computer, using the target computer 
        /// to determine the joined domain and enterprise. If this value is null or empty, the target computer 
        /// is the local computer.
        /// </para>
        /// </remarks>
        public string TargetComputer
        {
            get { return targetComputer; }
            set { targetComputer = value; }
        }

        /// <summary>
        /// Resets all properties to their default values. 
        /// </summary>
        public override void Reset()
        {
            allowedLocations = Locations.All;
            allowedTypes = ObjectTypes.All;
            defaultLocations = Locations.None;
            defaultTypes = ObjectTypes.All;
            multiSelect = false;
            selectedObjects = null;
            showAdvancedView = false;
            targetComputer = null;
        }

        /// <summary>
        /// Displays the Directory Object Picker (Active Directory) common dialog, when called by ShowDialog.
        /// </summary>
        /// <param name="hwndOwner">Handle to the window that owns the dialog.</param>
        /// <returns>If the user clicks the OK button of the Directory Object Picker dialog that is displayed, true is returned; 
        /// otherwise, false.</returns>
        protected override bool RunDialog(IntPtr hwndOwner)
        {
            IDataObject dataObj = null;
            IDsObjectPicker ipicker = Initialize();
            if (ipicker == null)
            {
                selectedObjects = null;
                return false;
            }
            int hresult = ipicker.InvokeDialog(hwndOwner, out dataObj);
            selectedObjects = ProcessSelections(dataObj);
            return (hresult == HRESULT.S_OK);
        }

        #region Private implementation

        // Convert ObjectTypes to DSCOPE_SCOPE_INIT_INFO_FLAGS
        private uint GetDefaultFilter()
        {
            uint defaultFilter = 0;
            if (((defaultTypes & ObjectTypes.Users) == ObjectTypes.Users) ||
                ((defaultTypes & ObjectTypes.WellKnownPrincipals) == ObjectTypes.WellKnownPrincipals))
            {
                defaultFilter |= DSOP_SCOPE_INIT_INFO_FLAGS.DSOP_SCOPE_FLAG_DEFAULT_FILTER_USERS;
            }
            if (((defaultTypes & ObjectTypes.Groups) == ObjectTypes.Groups) ||
                ((defaultTypes & ObjectTypes.BuiltInGroups) == ObjectTypes.BuiltInGroups))
            {
                defaultFilter |= DSOP_SCOPE_INIT_INFO_FLAGS.DSOP_SCOPE_FLAG_DEFAULT_FILTER_GROUPS;
            }
            if ((defaultTypes & ObjectTypes.Computers) == ObjectTypes.Computers)
            {
                defaultFilter |= DSOP_SCOPE_INIT_INFO_FLAGS.DSOP_SCOPE_FLAG_DEFAULT_FILTER_COMPUTERS;
            }
            if ((defaultTypes & ObjectTypes.Contacts) == ObjectTypes.Contacts)
            {
                defaultFilter |= DSOP_SCOPE_INIT_INFO_FLAGS.DSOP_SCOPE_FLAG_DEFAULT_FILTER_CONTACTS;
            }
            return defaultFilter;
        }

        // Convert ObjectTypes to DSOP_DOWNLEVEL_FLAGS
        private uint GetDownLevelFilter()
        {
            uint downlevelFilter = 0;
            if ((allowedTypes & ObjectTypes.Users) == ObjectTypes.Users)
            {
                downlevelFilter |= DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_USERS;
            }
            if ((allowedTypes & ObjectTypes.Groups) == ObjectTypes.Groups)
            {
                downlevelFilter |= DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_LOCAL_GROUPS |
                                    DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_GLOBAL_GROUPS;
            }
            if ((allowedTypes & ObjectTypes.Computers) == ObjectTypes.Computers)
            {
                downlevelFilter |=  DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_COMPUTERS;
            }
            // Contacts not available in downlevel scopes
            //if ((allowedTypes & ObjectTypes.Contacts) == ObjectTypes.Contacts)
            // Exclude build in groups if not selected
            if ((allowedTypes & ObjectTypes.BuiltInGroups) == 0)
            {
                downlevelFilter |= DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_EXCLUDE_BUILTIN_GROUPS;
            }
            if ((allowedTypes & ObjectTypes.WellKnownPrincipals) == ObjectTypes.WellKnownPrincipals)
            {
                downlevelFilter |= DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_ALL_WELLKNOWN_SIDS;
                // This includes all the following:
                //DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_WORLD |
                //DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_AUTHENTICATED_USER |
                //DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_ANONYMOUS |
                //DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_BATCH |
                //DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_CREATOR_OWNER |
                //DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_CREATOR_GROUP |
                //DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_DIALUP |
                //DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_INTERACTIVE |
                //DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_NETWORK |
                //DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_SERVICE |
                //DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_SYSTEM |
                //DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_TERMINAL_SERVER |
                //DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_LOCAL_SERVICE |
                //DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_NETWORK_SERVICE |
                //DSOP_DOWNLEVEL_FLAGS.DSOP_DOWNLEVEL_FILTER_REMOTE_LOGON;
            }
            return downlevelFilter;
        }

        // Convert Locations to DSOP_SCOPE_TYPE_FLAGS
        private static uint GetScope( Locations locations )
        {
            uint scope = 0;
            if ((locations & Locations.LocalComputer) == Locations.LocalComputer)
            {
                scope |= DSOP_SCOPE_TYPE_FLAGS.DSOP_SCOPE_TYPE_TARGET_COMPUTER;
            }
            if ((locations & Locations.JoinedDomain) == Locations.JoinedDomain)
            {
                scope |= DSOP_SCOPE_TYPE_FLAGS.DSOP_SCOPE_TYPE_DOWNLEVEL_JOINED_DOMAIN |
                        DSOP_SCOPE_TYPE_FLAGS.DSOP_SCOPE_TYPE_UPLEVEL_JOINED_DOMAIN;
            }
            if ((locations & Locations.EnterpriseDomain) == Locations.EnterpriseDomain)
            {
                scope |= DSOP_SCOPE_TYPE_FLAGS.DSOP_SCOPE_TYPE_ENTERPRISE_DOMAIN;
            }
            if ((locations & Locations.GlobalCatalog) == Locations.GlobalCatalog)
            {
                scope |= DSOP_SCOPE_TYPE_FLAGS.DSOP_SCOPE_TYPE_GLOBAL_CATALOG;
            }
            if ((locations & Locations.ExternalDomain) == Locations.ExternalDomain)
            {
                scope |= DSOP_SCOPE_TYPE_FLAGS.DSOP_SCOPE_TYPE_EXTERNAL_DOWNLEVEL_DOMAIN |
                        DSOP_SCOPE_TYPE_FLAGS.DSOP_SCOPE_TYPE_EXTERNAL_UPLEVEL_DOMAIN;
            }
            if ((locations & Locations.Workgroup) == Locations.Workgroup)
            {
                scope |= DSOP_SCOPE_TYPE_FLAGS.DSOP_SCOPE_TYPE_WORKGROUP;
            }
            if ((locations & Locations.UserEntered) == Locations.UserEntered)
            {
                scope |= DSOP_SCOPE_TYPE_FLAGS.DSOP_SCOPE_TYPE_USER_ENTERED_DOWNLEVEL_SCOPE |
                DSOP_SCOPE_TYPE_FLAGS.DSOP_SCOPE_TYPE_USER_ENTERED_UPLEVEL_SCOPE;
            }
            return scope;
        }

        // Convert scope for allowed locations other than the default
        private uint GetOtherScope()
        {
            Locations otherLocations = allowedLocations & (~defaultLocations);
            return GetScope(otherLocations);
        }

        // Convert scope for default locations
        private uint GetStartingScope()
        {
            return GetScope(defaultLocations);
        }

        // Convert ObjectTypes to DSOP_FILTER_FLAGS_FLAGS
        private uint GetUpLevelFilter()
        {
            uint uplevelFilter = 0;
            if ((allowedTypes & ObjectTypes.Users) == ObjectTypes.Users)
            {
                uplevelFilter |= DSOP_FILTER_FLAGS_FLAGS.DSOP_FILTER_USERS;
            }
            if ((allowedTypes & ObjectTypes.Groups) == ObjectTypes.Groups)
            {
                uplevelFilter |= DSOP_FILTER_FLAGS_FLAGS.DSOP_FILTER_UNIVERSAL_GROUPS_DL |
                                DSOP_FILTER_FLAGS_FLAGS.DSOP_FILTER_UNIVERSAL_GROUPS_SE |
                                DSOP_FILTER_FLAGS_FLAGS.DSOP_FILTER_GLOBAL_GROUPS_DL |
                                DSOP_FILTER_FLAGS_FLAGS.DSOP_FILTER_GLOBAL_GROUPS_SE |
                                DSOP_FILTER_FLAGS_FLAGS.DSOP_FILTER_DOMAIN_LOCAL_GROUPS_DL |
                                DSOP_FILTER_FLAGS_FLAGS.DSOP_FILTER_DOMAIN_LOCAL_GROUPS_SE;
            }
            if ((allowedTypes & ObjectTypes.Computers) == ObjectTypes.Computers)
            {
                uplevelFilter |= DSOP_FILTER_FLAGS_FLAGS.DSOP_FILTER_COMPUTERS;
            }
            if ((allowedTypes & ObjectTypes.Contacts) == ObjectTypes.Contacts)
            {
                uplevelFilter |= DSOP_FILTER_FLAGS_FLAGS.DSOP_FILTER_CONTACTS;
            }
            if ((allowedTypes & ObjectTypes.BuiltInGroups) == ObjectTypes.BuiltInGroups)
            {
                uplevelFilter |= DSOP_FILTER_FLAGS_FLAGS.DSOP_FILTER_BUILTIN_GROUPS;
            }
            if ((allowedTypes & ObjectTypes.WellKnownPrincipals) == ObjectTypes.WellKnownPrincipals)
            {
                uplevelFilter |= DSOP_FILTER_FLAGS_FLAGS.DSOP_FILTER_WELL_KNOWN_PRINCIPALS;
            }
            if( showAdvancedView ) {
                uplevelFilter |= DSOP_FILTER_FLAGS_FLAGS.DSOP_FILTER_INCLUDE_ADVANCED_VIEW;
            }
            return uplevelFilter;
        }

		private IDsObjectPicker Initialize()
		{
			DSObjectPicker picker = new DSObjectPicker();
			IDsObjectPicker ipicker = (IDsObjectPicker)picker;

            List<DSOP_SCOPE_INIT_INFO> scopeInitInfoList = new List<DSOP_SCOPE_INIT_INFO>();

            // Note the same default and filters are used by all scopes
            uint defaultFilter = GetDefaultFilter();
            uint upLevelFilter = GetUpLevelFilter();
            uint downLevelFilter = GetDownLevelFilter();
            // Internall, use one scope for the default (starting) locations.
            uint startingScope = GetStartingScope();
            if (startingScope > 0)
            {
                DSOP_SCOPE_INIT_INFO startingScopeInfo = new DSOP_SCOPE_INIT_INFO();
                startingScopeInfo.cbSize = (uint)Marshal.SizeOf(typeof(DSOP_SCOPE_INIT_INFO));
                startingScopeInfo.flType = startingScope;
                startingScopeInfo.flScope = DSOP_SCOPE_INIT_INFO_FLAGS.DSOP_SCOPE_FLAG_STARTING_SCOPE | defaultFilter;
                startingScopeInfo.FilterFlags.Uplevel.flBothModes = upLevelFilter;
                startingScopeInfo.FilterFlags.flDownlevel = downLevelFilter;
                startingScopeInfo.pwzADsPath = null;
                startingScopeInfo.pwzDcName = null;
                startingScopeInfo.hr = 0;
                scopeInitInfoList.Add(startingScopeInfo);
            }

            // And another scope for all other locations (AllowedLocation values not in DefaultLocation)
            uint otherScope = GetOtherScope();
            if (otherScope > 0)
            {
                DSOP_SCOPE_INIT_INFO otherScopeInfo = new DSOP_SCOPE_INIT_INFO();
                otherScopeInfo.cbSize = (uint)Marshal.SizeOf(typeof(DSOP_SCOPE_INIT_INFO));
                otherScopeInfo.flType = otherScope;
                otherScopeInfo.flScope = defaultFilter;
                otherScopeInfo.FilterFlags.Uplevel.flBothModes = upLevelFilter;
                otherScopeInfo.FilterFlags.flDownlevel = downLevelFilter;
                otherScopeInfo.pwzADsPath = null;
                otherScopeInfo.pwzDcName = null;
                otherScopeInfo.hr = 0;
                scopeInitInfoList.Add(otherScopeInfo);
            }

            DSOP_SCOPE_INIT_INFO[] scopeInitInfo = scopeInitInfoList.ToArray();

            // TODO: Scopes for alternate ADs, alternate domains, alternate computers, etc

			// Allocate memory from the unmananged mem of the process, this should be freed later!??
			IntPtr refScopeInitInfo = Marshal.AllocHGlobal
                (Marshal.SizeOf(typeof(DSOP_SCOPE_INIT_INFO)) * scopeInitInfo.Length);
			
			// Marshal structs to pointers
            for (int index = 0; index < scopeInitInfo.Length; index++)
            {
                //Marshal.StructureToPtr(scopeInitInfo[0],
                //    refScopeInitInfo, true);

                Marshal.StructureToPtr(scopeInitInfo[index],
                    (IntPtr)((int)refScopeInitInfo + index * Marshal.SizeOf(typeof(DSOP_SCOPE_INIT_INFO))),
                    true);
            }

			// Initialize structure with data to initialize an object picker dialog box. 
			DSOP_INIT_INFO initInfo = new DSOP_INIT_INFO (); 						
			initInfo.cbSize = (uint) Marshal.SizeOf (initInfo); 
			//initInfo.pwzTargetComputer = null; // local computer
            initInfo.pwzTargetComputer = targetComputer;
            initInfo.cDsScopeInfos = (uint)scopeInitInfo.Length; 
			initInfo.aDsScopeInfos = refScopeInitInfo;  
			// Flags that determine the object picker options. 
            uint flOptions = 0; 
            // Only set DSOP_INIT_INFO_FLAGS.DSOP_FLAG_SKIP_TARGET_COMPUTER_DC_CHECK
            // if we know target is not a DC (which then saves initialization time).
            if (multiSelect)
            {
                flOptions |= DSOP_INIT_INFO_FLAGS.DSOP_FLAG_MULTISELECT;
            }
			initInfo.flOptions = flOptions;
			
			// We're not retrieving any additional attributes
            //string[] attributes = new string[] { "sAMaccountName" };
            //initInfo.cAttributesToFetch = (uint)attributes.Length; 
            //initInfo.apwzAttributeNames = Marshal.StringToHGlobalUni( attributes[0] );
            initInfo.cAttributesToFetch = 0;
            initInfo.apwzAttributeNames = IntPtr.Zero;
			
			// Initialize the Object Picker Dialog Box with our options
			int hresult = ipicker.Initialize (ref initInfo);

            if (hresult != HRESULT.S_OK)
            {
                return null;
            }
			return ipicker;
		}

		private DirectoryObject[] ProcessSelections(IDataObject dataObj)
		{
			if(dataObj == null)
				return null;			

			DirectoryObject[] selections = null;

			// The STGMEDIUM structure is a generalized global memory handle used for data transfer operations
			STGMEDIUM stg = new STGMEDIUM();
			stg.tymed = (uint)TYMED.TYMED_HGLOBAL;
			stg.hGlobal = IntPtr.Zero;
			stg.pUnkForRelease = null;

			// The FORMATETC structure is a generalized Clipboard format.
			FORMATETC fe = new FORMATETC();
            fe.cfFormat = System.Windows.Forms.DataFormats.GetFormat(CLIPBOARD_FORMAT.CFSTR_DSOP_DS_SELECTION_LIST).Id; 
            // The CFSTR_DSOP_DS_SELECTION_LIST clipboard format is provided by the IDataObject obtained 
            // by calling IDsObjectPicker::InvokeDialog
			fe.ptd = IntPtr.Zero;
			fe.dwAspect = 1; //DVASPECT_CONTENT    = 1,  
			fe.lindex = -1; // all of the data
			fe.tymed = (uint)TYMED.TYMED_HGLOBAL; //The storage medium is a global memory handle (HGLOBAL)

			dataObj.GetData(ref fe, ref stg);
	
			IntPtr pDsSL = PInvoke.GlobalLock(stg.hGlobal);

			try
			{
				// the start of our structure
				IntPtr current = pDsSL;
				// get the # of items selected
				int cnt = Marshal.ReadInt32(current);
				
				// if we selected at least 1 object
				if (cnt > 0)
				{				
					selections = new DirectoryObject[cnt];
					// increment the pointer so we can read the DS_SELECTION structure
					current = (IntPtr)((int)current + (Marshal.SizeOf(typeof(uint))*2));
					// now loop through the structures
					for (int i = 0; i < cnt; i++)
					{
						// marshal the pointer to the structure
						DS_SELECTION s = (DS_SELECTION)Marshal.PtrToStructure(current, typeof(DS_SELECTION));
						Marshal.DestroyStructure(current, typeof(DS_SELECTION));

						// increment the position of our pointer by the size of the structure
						current = (IntPtr)((int)current + Marshal.SizeOf(typeof(DS_SELECTION)));

                        string name = s.pwzName;
                        string path = s.pwzADsPath;
                        string schemaClassName = s.pwzClass;
                        string upn =  s.pwzUPN;

                        //string temp = Marshal.PtrToStringUni( s.pvarFetchedAttributes );
                        selections[i] = new DirectoryObject( name, path, schemaClassName, upn );
					}
				}
			}			
			finally
			{
				PInvoke.GlobalUnlock(pDsSL);
			}		
			return selections;
        }

        #endregion
    }
}
