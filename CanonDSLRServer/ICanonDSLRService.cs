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
using de.ahzf.Hermod.HTTP.Common;

#endregion

namespace com.aperis.CanonDSLRServer
{

    /// <summary>
    /// The CanonDSLR service interface mapping HTTP/REST URIs onto .NET methods.
    /// </summary>
    //[HTTPService(Host: "localhost:8080", ForceAuthentication: true)]
    public interface ICanonDSLRService : IHTTPService
    {


        #region GetLandingpage

        /// <summary>
        /// Get all the graphs.
        /// </summary>
        /// <returns>Multiple graphs.</returns>
        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/")]
        HTTPResponse GetLandingpage();

        #endregion

        #region Camera Properties

        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/{myCamera}/properties/TvMap")]
        HTTPResponse GetTvMap(String myCamera);

        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/{myCamera}/properties/AvMap")]
        HTTPResponse GetAvMap(String myCamera);

        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/{myCamera}/properties/ISOMap")]
        HTTPResponse GetISOMap(String myCamera);

        #endregion

        #region Camera Actions

        /// <summary>
        /// Get the graph.
        /// </summary>
        /// <param name="myGraph">The name of the graph.</param>
        /// <returns>A single graph.</returns>
        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/{myCamera}/takepicture")]
        HTTPResponse TakePicture(String myCamera);

        #endregion


        #region Utilities

        /// <summary>
        /// Returns internal resources embedded within the assembly.
        /// </summary>
        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/resources/{myResource}")]
        HTTPResponse GetResources(String myResource);

        /// <summary>
        /// Returns internal resources embedded within the assembly.
        /// </summary>
        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/resources/jquery/{myResource}")]
        HTTPResponse GetResources_JQuery(String myResource);


        /// <summary>
        /// Generate the WADL description of this service.
        /// </summary>
        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/application.wadl")]
        HTTPResponse GenerateWADL();


        /// <summary>
        /// Returns the favicon.ico.
        /// </summary>
        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/favicon.ico")]
        HTTPResponse GetFavicon();


        /// <summary>
        /// Get a http error for debugging purposes.
        /// An additional error reason may be given via the
        /// QueryString (e.g. "/error/204&reason=unknown")
        /// </summary>
        /// <param name="myHTTPStatusCode">The http status code.</param>
        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/error/{myHTTPStatusCode}")]
        HTTPResponse GetError(String myHTTPStatusCode);

        #endregion


    }

}
