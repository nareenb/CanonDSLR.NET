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

namespace com.aperis.CanonDSLR.CanonSDK
{

    /*-----------------------------------------------------------------------------
     Target Image Types
    -----------------------------------------------------------------------------*/
    public enum TargetImageType : uint
    {
        Unknown = 0x00000000,
        JPEG    = 0x00000001,
        TIFF    = 0x00000007,
        TIFF16  = 0x00000008,
        RGB     = 0x00000009,
        RGB16   = 0x0000000A
    }

}
