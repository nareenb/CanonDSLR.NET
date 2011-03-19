﻿/*
 * Copyright (c) 2011, Aperis GmbH <agplsources@aperis.com>
 * Autor: Achim 'ahzf' Friedland <code@ahzf.de>
 * This file is part of CanonDSLRServer
 *
 * Licensed under the Affero GPL license, Version 3.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.gnu.org/licenses/agpl.html
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using System;

using de.ahzf.Hermod.HTTP;
using de.ahzf.Hermod.Datastructures;
using com.aperis.CanonDSLR;

#endregion

namespace com.aperis.CanonDSLRServer
{

    /// <summary>
    /// A tcp/http based CanonDSLR server.
    /// </summary>
    public class CanonDSLRServer : HTTPServer<CanonDSLRService>
    {

        #region Data

        #endregion

        #region Properties

        #region DefaultServerName

        private const String _DefaultServerName = "CanonDSLR HTTP/TCP Server v0.1";

        /// <summary>
        /// The default server name.
        /// </summary>
        public override String DefaultServerName
        {
            get
            {
                return _DefaultServerName;
            }
        }

        #endregion

        #region CanonDSLRWrapper

        public CanonDSLRWrapper CanonDSLRWrapper { get; private set; }

        #endregion

        #endregion

        #region Constructor(s)

        #region CanonDSLRServer()

        /// <summary>
        /// Initialize the CanonDSLRServer using IPAddress.Any, http port 8182 and start the server.
        /// </summary>
        public CanonDSLRServer()
            : base(IPv4Address.Any, new IPPort(8080), Autostart: true)
        {

            ServerName       = _DefaultServerName;
            CanonDSLRWrapper = CanonDSLRWrapper.Instance;

            base.OnNewHTTPService += CanonDSLRService => { CanonDSLRService.CanonDSLRWrapper = CanonDSLRWrapper; };

        }

        #endregion

        #region CanonDSLRServer(myPort, myAutoStart = false)

        /// <summary>
        /// Initialize the CanonDSLRServer using IPAddress.Any and the given parameters.
        /// </summary>
        /// <param name="myPort">The listening port</param>
        /// <param name="Autostart"></param>
        public CanonDSLRServer(IPPort myPort, Boolean Autostart = false)
            : base(IPv4Address.Any, myPort, Autostart: true)
        {

            ServerName = _DefaultServerName;

            base.OnNewHTTPService += CanonDSLRService => { CanonDSLRService.CanonDSLRWrapper = CanonDSLRWrapper; };

        }

        #endregion

        #region CanonDSLRServer(myIIPAddress, myPort, myAutoStart = false)

        /// <summary>
        /// Initialize the CanonDSLRServer using the given parameters.
        /// </summary>
        /// <param name="myIIPAddress">The listening IP address(es)</param>
        /// <param name="myPort">The listening port</param>
        /// <param name="Autostart"></param>
        public CanonDSLRServer(IIPAddress myIIPAddress, IPPort myPort, Boolean Autostart = false)
            : base(myIIPAddress, myPort, Autostart: true)
        {

            ServerName = _DefaultServerName;

            base.OnNewHTTPService += CanonDSLRService => { CanonDSLRService.CanonDSLRWrapper = CanonDSLRWrapper; };

        }

        #endregion

        #region CanonDSLRServer(myIPSocket, Autostart = false)

        /// <summary>
        /// Initialize the CanonDSLRServer using the given parameters.
        /// </summary>
        /// <param name="myIPSocket">The listening IPSocket.</param>
        /// <param name="Autostart"></param>
        public CanonDSLRServer(IPSocket myIPSocket, Boolean Autostart = false)
            : base(myIPSocket.IPAddress, myIPSocket.Port, Autostart: true)
        {

            ServerName = _DefaultServerName;

            base.OnNewHTTPService += CanonDSLRService => { CanonDSLRService.CanonDSLRWrapper = CanonDSLRWrapper; };

        }

        #endregion

        #endregion


    }

}
