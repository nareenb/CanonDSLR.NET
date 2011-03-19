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
     PictureStyle
    -----------------------------------------------------------------------------*/
    public enum PictureStyle : uint
    {
        Standard     = 0x0081,
        Portrait     = 0x0082,
        Landscape    = 0x0083,
        Neutral      = 0x0084,
        Faithful     = 0x0085,
        Monochrome   = 0x0086,
        User1        = 0x0021,
        User2        = 0x0022,
        User3        = 0x0023,
        PC1          = 0x0041,
        PC2          = 0x0042,
        PC3          = 0x0043
    }

}
