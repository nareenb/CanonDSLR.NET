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

    public enum ShutterButton : uint
    {

        [DescriptionAttribute("Released")]
	    Released          = 0x00000000,

        [DescriptionAttribute("Halfway")]
	    Halfway			  = 0x00000001,

        [DescriptionAttribute("Completely")]
	    Completely		  = 0x00000003,

        [DescriptionAttribute("Half way, without auto focus")]
        Halfway_NonAF	  = 0x00010001,

        [DescriptionAttribute("Completely, without auto focus")]
	    Completely_NonAF  = 0x00010003

    }

}
