﻿﻿/*
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

using System;
using System.Runtime.InteropServices;

#endregion

namespace com.aperis.CanonDSLR.CanonSDK
{

    [StructLayout(LayoutKind.Sequential)]
    public struct ImageInfo
    {

        public UInt32    Width;
        public UInt32    Height;

        public UInt32    NumOfColorComponents;
        
        /// <summary>
        /// Bits per sample (8 or 16).
        /// </summary>
        public UInt32    ComponentDepth;

        /// <summary>
        /// Effective rectangles except.
        /// </summary>
        public Rectangle EffectiveRect;
        // a black line of the image. 
        // A black line might be in the top and bottom
        // of the thumbnail image. 

        public UInt32    Reserved1;
        public UInt32    Reserved2;

    }

}
