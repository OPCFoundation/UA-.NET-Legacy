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
using System.Xml;
using System.IO;
using System.Text;
using System.Reflection;
using System.Threading;
using System.Globalization;
using Opc.Ua;
using Opc.Ua.Server;

namespace FileSystem
{
    public partial class AreaState
    {
        #region Constructors
        /// <summary>
        /// Initializes an area from a directory.
        /// </summary>
        public AreaState(ISystemContext context, DirectoryInfo directoryInfo) : base(null)
        {
            directoryInfo.Refresh();

            string name = directoryInfo.Name;
            
            // need to read the correct casing from the file system.
            if (directoryInfo.Exists)
            {
                DirectoryInfo[] directories = directoryInfo.Parent.GetDirectories(name);

                if (directories != null && directories.Length > 0)
                {
                    name = directories[0].Name;
                }
            }

            // get the system to use.
            FileSystemMonitor system = context.SystemHandle as FileSystemMonitor;

            if (system != null)
            {
                this.NodeId = system.CreateNodeIdFromDirectoryPath(ObjectTypes.AreaType, directoryInfo.FullName);
                this.BrowseName = new QualifiedName(name, system.NamespaceIndex);
                this.OnValidate = system.ValidateArea;
            }

            this.DisplayName = new LocalizedText(name);
            this.EventNotifier = EventNotifiers.None;
            this.TypeDefinitionId = GetDefaultTypeDefinitionId(context.NamespaceUris);
        }
        #endregion

        #region Public Members
        /// <summary>
        /// Checks if the directory has changed since the last check.
        /// </summary>
        public void CheckForChanges(ISystemContext context)
        {
            DirectoryInfo directory = GetDirectory(context, this.NodeId);

            if (directory == null)
            {
                return;
            }

            directory.Refresh();

            DateTime lastWriteTime = DateTime.MinValue;

            if (!directory.Exists)
            {
                if (m_lastWriteTime == DateTime.MinValue)
                {
                    return;
                }
            }
            else
            {
                lastWriteTime = directory.LastWriteTime.ToUniversalTime();

                if (lastWriteTime == m_lastWriteTime)
                {
                    return;
                }
            }
            
            this.LastUpdateTime.UpdateChangeMasks(NodeStateChangeMasks.Value);
            this.CreateController.UpdateChangeMasks(NodeStateChangeMasks.NonValue);

            m_lastWriteTime = lastWriteTime;
        }

        /// <summary>
        /// Whether the area is the root area.
        /// </summary>
        public bool IsRoot
        {
            get
            {                
                if (this.NodeId == null || this.NodeId.IdType != IdType.String)
                {
                    return false;
                }

                if (((string)this.NodeId.Identifier).EndsWith(":"))
                {
                    return true;
                }
                
                return false;
            }
        }

        /// <summary>
        /// Returns the directory for the area.
        /// </summary>
        public static DirectoryInfo GetDirectory(ISystemContext context, NodeId areaId)
        {
            FileSystemMonitor system = context.SystemHandle as FileSystemMonitor;

            if (system == null)
            {
                return null;
            }
            
            string directoryPath = system.ExtractPathFromNodeId(areaId);
            return new DirectoryInfo(directoryPath);
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Creates an object which can browse the controller files in the directory.
        /// </summary>
        public override INodeBrowser CreateBrowser(
            ISystemContext context, 
            ViewDescription view, 
            NodeId referenceType, 
            bool includeSubtypes, 
            BrowseDirection browseDirection, 
            QualifiedName browseName,
            IEnumerable<IReference> additionalReferences,
            bool internalOnly)
        {
            NodeBrowser browser = new AreaBrowser(
                context,
                view,
                referenceType,
                includeSubtypes,
                browseDirection,
                browseName,
                additionalReferences,
                internalOnly,
                this);

            PopulateBrowser(context, browser);

            return browser;
        }

        /// <summary>
        /// Sets op callbacks for methods and dynamic variables.
        /// </summary>
        protected override void OnAfterCreate(ISystemContext context, NodeState node)
        {
            base.OnAfterCreate(context, node);
            
            this.CreateController.OnCall = OnCreateController;
            this.LastUpdateTime.OnSimpleReadValue = ReadLastUpdateTime;
        }
        
        /// <summary>
        /// Reads the last update time for the directory.
        /// </summary>
        private ServiceResult ReadLastUpdateTime(ISystemContext context, NodeState node, ref object value)
        {            
            DirectoryInfo directory = GetDirectory(context, this.NodeId);

            if (directory == null || !directory.Exists)
            {
                return StatusCodes.BadOutOfService;
            }

            directory.Refresh();

            value = directory.LastWriteTime.ToUniversalTime();

            return ServiceResult.Good;
        }
         
        /// <summary>
        /// Creates a new controller file.
        /// </summary>
        private ServiceResult OnCreateController(
            ISystemContext context,
            MethodState method,
            NodeId objectId,
            string name,
            ref NodeId nodeId)
        {
            nodeId = null;

            // get the system to use.
            FileSystemMonitor system = context.SystemHandle as FileSystemMonitor;

            if (system == null)
            {
                return StatusCodes.BadOutOfService;
            }

            // get the current dierctory.
            DirectoryInfo directory = GetDirectory(context, this.NodeId);

            if (directory == null || !directory.Exists)
            {
                return StatusCodes.BadOutOfService;
            }

            // build the file path.
            StringBuilder filePath = new StringBuilder();

            filePath.Append(directory.FullName);
            filePath.Append('\\');
            filePath.Append(name);
            filePath.Append(".csv");

            if (File.Exists(filePath.ToString()))
            {
                return StatusCodes.BadNodeIdExists;
            }

            // write a dummy configuration file.
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath.ToString()))
                {
                    writer.WriteLine("Temperature, Double, 15");
                    writer.WriteLine("TemperatureSetPoint, Double, 15");
                }
            }
            catch (Exception e)
            {
                return new ServiceResult(e, StatusCodes.BadUnexpectedError);
            }

            // return the node id.
            nodeId = system.CreateNodeIdFromFilePath(ObjectTypes.ControllerType, filePath.ToString());
            
            return ServiceResult.Good;
        }
        #endregion

        #region Private Fields
        private DateTime m_lastWriteTime;
        #endregion
    }
}
