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

    public enum DataType : uint
    {       

        Unknown             = 0,

        Bool                = 1,
        String              = 2,
        Int8                = 3,
        UInt8               = 6,
        Int16               = 4,
        UInt16              = 7,
        Int32               = 8,
        UInt32              = 9,
        Int64               = 10,
        UInt64              = 11,
        Float               = 12,
        Double              = 13,
        ByteBlock           = 14,
        Rational            = 20,
        Point               = 21,
        Rect                = 22,
        Time                = 23,

        Bool_Array          = 30,
        Int8_Array          = 31,
        Int16_Array         = 32,
        Int32_Array         = 33,
        UInt8_Array         = 34,
        UInt16_Array        = 35,
        UInt32_Array        = 36,
        Rational_Array      = 37,

        FocusInfo           = 101,
        PictureStyleDesc

    }

}
