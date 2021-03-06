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
    public struct PropertyDescription
    {

        public Int32   Form;
        public UInt32  Access;
        public Int32   NumElements;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public Int32[] PropDesc;

    }

}
