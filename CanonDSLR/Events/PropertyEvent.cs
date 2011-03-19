﻿/*
 * Copyright (c) 2011, Aperis GmbH <agplsources@aperis.com>
 * Autor: Achim 'ahzf' Friedland <code@ahzf.de>
 * This file is part of CanonDSLR
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

namespace com.aperis.CanonDSLR.CanonSDK
{

    public enum PropertyEvent : uint
    {

        /// <summary>
        /// Notifies all property events. 
        /// </summary>
        All                     = 0x00000100,

        /// <summary>
        /// Notifies that a camera property value has been changed. 
        /// The changed property can be retrieved from event data. 
        /// The changed value can be retrieved by means of EdsGetPropertyData. 
        /// In the case of type 1 protocol standard cameras, 
        /// notification of changed properties can only be issued for custom functions (CFn). 
        /// If the property type is 0x0000FFFF, the changed property cannot be identified. 
        /// Thus, retrieve all required properties repeatedly. 
        /// </summary>
        PropertyChanged         = 0x00000101,

        /// <summary>
        /// Notifies of changes in the list of camera properties with configurable values. 
        /// The list of configurable values for property IDs indicated in event data 
        /// can be retrieved by means of EdsGetPropertyDesc. 
        /// For type 1 protocol standard cameras, the property ID is identified as "Unknown"
        /// during notification. 
        /// Thus, you must retrieve a list of configurable values for all properties and
        /// retrieve the property values repeatedly. 
        /// (For details on properties for which you can retrieve a list of configurable
        /// properties, see the description of EdsGetPropertyDesc).
        /// </summary>
        PropertyDescChanged     = 0x00000102
           
    }

}
