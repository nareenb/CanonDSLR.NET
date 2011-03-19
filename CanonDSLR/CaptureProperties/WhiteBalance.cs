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

    /*-----------------------------------------------------------------------------
     White Balance
    -----------------------------------------------------------------------------*/
    public enum WhiteBalance : int
    {
        Click           = -1,
        Auto            =  0,
        Daylight        =  1,
        Cloudy          =  2,
        Tangsten        =  3,
        Fluorescent     =  4,
        Flash           =  5,
        WhitePaper      =  6,
        Shade           =  8,
        ColorTemp       =  9,
        PCSet1          = 10,
        PCSet2          = 11,
        PCSet3          = 12
    }

}
