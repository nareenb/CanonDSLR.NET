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

#region Usings

using System.ComponentModel;

#endregion

namespace com.aperis.CanonDSLR.CanonSDK
{

    /// <summary>
    /// The exposure compensation.
    /// </summary>
    public enum ExposureCompensation : uint
    {
        
        /// <summary>
        /// +3
        /// </summary>
        [Description("+3")]
        p3       = 0x18,

        /// <summary>
        /// +2 2/3
        /// </summary>
        [Description("+2 2/3")]
        p2_2_3   = 0x15,

        /// <summary>
        /// +2 1/2
        /// </summary>
        [Description("+2 1/2")]
        p2_1_2   = 0x14,

        /// <summary>
        /// +2 1/3
        /// </summary>
        [Description("+2 1/3")]
        p2_1_3   = 0x13,

        /// <summary>
        /// +2
        /// </summary>
        [Description("+2")]
        p2       = 0x10,

        /// <summary>
        /// +1 2/3
        /// </summary>
        [Description("+1 2/3")]
        p1_2_3   = 0x0D,

        /// <summary>
        /// +2 1/2
        /// </summary>
        [Description("+2 1/2")]
        p1_1_2   = 0x0C,

        /// <summary>
        /// +2 1/3
        /// </summary>
        [Description("+2 1/3")]
        p1_1_3   = 0x0B,

        /// <summary>
        /// +1
        /// </summary>
        [Description("+1")]
        p1       = 0x08,

        /// <summary>
        /// +1 2/3
        /// </summary>
        [Description("+1 2/3")]
        p2_3     = 0x05,

        /// <summary>
        /// +1 1/2
        /// </summary>
        [Description("+1 1/2")]
        p1_2     = 0x04,

        /// <summary>
        /// +1 1/3
        /// </summary>
        [Description("+1 1/3")]
        p1_3     = 0x03,


        /// <summary>
        /// Zero
        /// </summary>
        [Description("Zero")]
        Zero     = 0x00,


        /// <summary>
        /// -1/3
        /// </summary>
        [Description("-1/3")]
        m1_3     = 0x18,

        /// <summary>
        /// -1/2
        /// </summary>
        [Description("-1/2")]
        m1_2     = 0x18,

        /// <summary>
        /// -2/3
        /// </summary>
        [Description("-2/3")]
        m2_3     = 0x18,

        /// <summary>
        /// -1
        /// </summary>
        [Description("-1")]
        m1       = 0x18,

        /// <summary>
        /// -1 1/3
        /// </summary>
        [Description("-1 1/3")]
        m1_1_3   = 0x18,

        /// <summary>
        /// -1 1/2
        /// </summary>
        [Description("-1 1/2")]
        m1_1_2   = 0x18,

        /// <summary>
        /// -1 2/3
        /// </summary>
        [Description("-1 2/3")]
        m1_2_3   = 0x18,

        /// <summary>
        /// -2
        /// </summary>
        [Description("-2")]
        m2       = 0x18,

        /// <summary>
        /// -2 1/3
        /// </summary>
        [Description("-2 1/3")]
        m2_1_3   = 0x18,

        /// <summary>
        /// -2 1/2
        /// </summary>
        [Description("-2 1/2")]
        m2_1_2   = 0x18,

        /// <summary>
        /// -2 2/3
        /// </summary>
        [Description("-2 2/3")]
        m2_2_3   = 0x18,

        /// <summary>
        /// -3
        /// </summary>
        [Description("-3")]
        m3       = 0x18,


        /// <summary>
        /// Not Valid / no changes
        /// </summary>
        [Description("Not Valid / no changes")]
        NotValid = 0xFFFFFFFF,


    }

}
