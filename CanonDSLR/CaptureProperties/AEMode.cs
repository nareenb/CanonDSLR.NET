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
    
    /// <summary>
    /// The capture mode.
    /// </summary>
    public enum AEMode : uint
    {

        Program          =  0,
        Tv               =  1,
        Av               =  2,
        Manual           =  3,
        Bulb             =  4,
        A_DEP            =  5,
        DEP              =  6,
        Custom           =  7,
        Lock             =  8,
        Green            =  9,
        NightPortrait    = 10,
        Sports           = 11,
        Portrait         = 12,
        Landscape        = 13,
        Closeup          = 14,
        FlashOff         = 15,
        Unknown          = 0xffffffff

    }

}
