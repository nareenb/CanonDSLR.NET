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

    public enum CameraCommand : uint
    {

        TakePicture             = 0x00000000,
        ExtendShutDownTimer     = 0x00000001,
        BulbStart			    = 0x00000002,
        BulbEnd				    = 0x00000003,
        PressShutterButton      = 0x00000004,

        DoEvfAf                 = 0x00000102,
        DriveLensEvf            = 0x00000103,
        DoClickWBEvf            = 0x00000104

    }

}
