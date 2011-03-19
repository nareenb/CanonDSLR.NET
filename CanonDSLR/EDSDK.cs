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

using System;
using System.Runtime.InteropServices;

#endregion

namespace com.aperis.CanonDSLR.CanonSDK
{

    public class EDSDK
    {

        #region Definition of base Structures

        public const int EDS_MAX_NAME            = 256;
        public const int EDS_TRANSFER_BLOCK_SIZE = 512;

        #endregion

        #region Callback Functions

        public delegate uint EdsProgressCallback     (uint   inPercent, IntPtr myContext, ref bool outCancel);
        public delegate uint EdsCameraAddedHandler   (IntPtr myContext);
        public delegate uint EdsPropertyEventHandler (uint   inEvent, uint inPropertyID, uint inParam, IntPtr myContext); 
        public delegate uint EdsObjectEventHandler   (uint   inEvent, IntPtr inRef, IntPtr myContext); 
        public delegate uint EdsStateEventHandler    (uint   inEvent, uint inParameter, IntPtr myContext);

        #endregion

        #region Proto type definition of EDSDK API

        /*----------------------------------
         Basic functions
        ----------------------------------*/
        #region EdsInitializeSDK();

        [DllImport("DLLs\\EDSDK.dll")]
        private extern static UInt32 EdsInitializeSDK();

        /// <summary>
        /// Initializes the libraries.
        /// When using the EDSDK libraries, you must call this API once before using EDSDK APIs.
        /// </summary>
        /// <returns>Any of the sdk errors.</returns>
        public static CanonSDKError InitializeSDK()
        {
            return (CanonSDKError) EdsInitializeSDK();
        }

        #endregion

        #region EdsTerminateSDK()

        [DllImport("DLLs\\EDSDK.dll")]
        private extern static UInt32 EdsTerminateSDK();

        /// <summary>
        /// Terminates use of the libraries.
        /// This function muse be called when ending the SDK.
        /// Calling this function releases all resources allocated by the libraries.
        /// </summary>
        /// <returns>Any of the sdk errors.</returns>
        public static CanonSDKError TerminateSDK()
        {
            return (CanonSDKError) EdsTerminateSDK();
        }

        #endregion


        /*-------------------------------------------
         Reference-counter operating functions
        --------------------------------------------*/
        #region EdsRetain(myIntPtr)

        [DllImport("DLLs\\EDSDK.dll")]
        private extern static UInt32 EdsRetain(IntPtr myIntPtr);

        /// <summary>
        /// Increments the reference counter of existing objects.
        /// </summary>
        /// <param name="myIntPtr">The reference for the item.</param>
        /// <returns>Any of the sdk errors.</returns>
        public static CanonSDKError Retain(IntPtr myIntPtr)
        {
            return (CanonSDKError) EdsRetain(myIntPtr);
        }

        #endregion

        #region EdsRelease(myIntPtr)

        [DllImport("DLLs\\EDSDK.dll")]
        private extern static UInt32 EdsRelease(IntPtr myIntPtr);

        /// <summary>
        /// Decrements the reference counter to an object.
        /// When the reference counter reaches 0, the object is released.
        /// </summary>
        /// <param name="myIntPtr">The reference of the item.</param>
        /// <returns>Any of the sdk errors.</returns>
        public static CanonSDKError Release(IntPtr myIntPtr)
        {
            return (CanonSDKError) EdsRelease(myIntPtr);
        }

        #endregion


        /*----------------------------------
         Item-tree operating functions
        ----------------------------------*/
        #region EdsGetChildCount(myIntPtr, out outCount)

        /// <summary>
        /// Gets the number of child objects of the designated object.
        /// </summary>
        /// <example>Number of files in a directory.</example>
        /// <param name="myIntPtr">The reference of the list.</param>
        /// <param name="outCount">Number of elements in this list.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static UInt32 EdsGetChildCount(IntPtr myIntPtr, out int outCount);

        #endregion

        #region EdsGetChildAtIndex(myIntPtr, out outRef)

        /// <summary>
        /// Gets an indexed child object of the designated object.
        /// </summary>
        /// <param name="myIntPtr">The reference of the item.</param>
        /// <param name="inIndex">The index that is passed in, is zero based.</param>
        /// <param name="outRef">The pointer which receives reference of the specified index.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static UInt32 EdsGetChildAtIndex(IntPtr myIntPtr, Int32 inIndex, out IntPtr outRef);

        #endregion

        #region EdsGetParent(myIntPtr, out outParentRef)

        /// <summary>
        /// Gets the parent object of the designated object.
        /// </summary>
        /// <param name="myIntPtr">The reference of the item.</param>
        /// <param name="outParentRef">The pointer which receives reference.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static UInt32 EdsGetParent(IntPtr myIntPtr, out IntPtr outParentRef);
        
        #endregion


        /*----------------------------------
          Property operating functions
        ----------------------------------*/
        #region EdsGetPropertySize(myIntPtr, myPropertyID, inParam, out outDataType, out outSize)

        [DllImport("DLLs\\EDSDK.dll")]
        private extern static UInt32 EdsGetPropertySize(IntPtr myIntPtr, UInt32 myPropertyID, Int32 inParam, out DataType outDataType, out Int32 outSize);

        /// <summary>
        /// Gets the byte size and data type of a designated property from a camera object or image object.
        /// </summary>
        /// <param name="myIntPtr">The reference of the item.</param>
        /// <param name="myPropertyID">The ProprtyID</param>
        /// <param name="inParam">Additional information of property. We use this parameter in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outDataType">Pointer to the buffer that is to receive the property type data.</param>
        /// <param name="outSize">Pointer to the buffer that is to receive the property size.</param>
        /// <returns>Any of the sdk errors.</returns>
        public static CanonSDKError EdsGetPropertySize(IntPtr myIntPtr, PropertyID myPropertyID, Int32 inParam, out DataType outDataType, out Int32 outSize)
        {
            return (CanonSDKError) EdsGetPropertySize(myIntPtr, (uint)myPropertyID, inParam, out outDataType, out outSize);
        }

        #endregion

        #region EdsGetPropertyData(myIntPtr, myPropertyID, myParameter, myPropertySize, outPropertyData)

        // inPropertySize - The number of bytes of the prepared buffer for receive property-value.

        [DllImport("DLLs\\EDSDK.dll")]
        private extern static UInt32 EdsGetPropertyData(IntPtr myIntPtr, UInt32 myPropertyID, Int32 myParameter, Int32 myPropertySize, IntPtr outPropertyData);

        /// <summary>
        /// Gets property information from the object designated in myIntPtr.
        /// </summary>
        /// <param name="myIntPtr">The reference of the item.</param>
        /// <param name="myPropertyID">The ProprtyID</param>
        /// <param name="myParameter">Additional information of property. We use this parameter in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The buffer pointer to receive property-value.</param>
        /// <returns>Any of the sdk errors.</returns>
        public static CanonSDKError EdsGetPropertyData(IntPtr myIntPtr, PropertyID myPropertyID, Int32 myParameter, out UInt32 outPropertyData)
        {

            var size = Marshal.SizeOf(typeof(UInt32));
            var ptr  = Marshal.AllocHGlobal(size);
            var err  = (CanonSDKError) EdsGetPropertyData(myIntPtr, (UInt32) myPropertyID, myParameter, size, ptr);

            outPropertyData = (UInt32) Marshal.PtrToStructure(ptr, typeof(UInt32));
            Marshal.FreeHGlobal(ptr);
            
            return err;

        }

        /// <summary>
        /// Gets property information from the object designated in myIntPtr.
        /// </summary>
        /// <param name="myIntPtr">The reference of the item.</param>
        /// <param name="myPropertyID">The ProprtyID</param>
        /// <param name="myParameter">Additional information of property. We use this parameter in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The buffer pointer to receive property-value.</param>
        /// <returns>Any of the sdk errors.</returns>
        public static UInt32 EdsGetPropertyData(IntPtr myInRef, PropertyID myPropertyID, Int32 myParameter, out Time outPropertyData)
        {
            
            var size = Marshal.SizeOf(typeof(Time));
            var ptr  = Marshal.AllocHGlobal(size);
            var err  = EdsGetPropertyData(myInRef, (UInt32) myPropertyID, myParameter, size, ptr);

            outPropertyData = (Time) Marshal.PtrToStructure(ptr, typeof(Time));
            Marshal.FreeHGlobal(ptr);
            
            return err;

        }

        /// <summary>
        /// Gets property information from the object designated in myIntPtr.
        /// </summary>
        /// <param name="myIntPtr">The reference of the item.</param>
        /// <param name="myPropertyID">The ProprtyID</param>
        /// <param name="myParameter">Additional information of property. We use this parameter in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The buffer pointer to receive property-value.</param>
        /// <returns>Any of the sdk errors.</returns>
        public static UInt32 EdsGetPropertyData(IntPtr myInRef, PropertyID myPropertyID, Int32 myParameter, out String outPropertyData)
        {

            var ptr = Marshal.AllocHGlobal(256);
            var err = EdsGetPropertyData(myInRef, (UInt32) myPropertyID, myParameter, 256, ptr);

            outPropertyData = Marshal.PtrToStringAnsi(ptr);
            Marshal.FreeHGlobal(ptr);

            return err;

        }

        /// <summary>
        /// Gets property information from the object designated in myIntPtr.
        /// </summary>
        /// <param name="myIntPtr">The reference of the item.</param>
        /// <param name="myPropertyID">The ProprtyID</param>
        /// <param name="myParameter">Additional information of property. We use this parameter in order to specify an index in case there are two or more values over the same ID.</param>
        /// <param name="outPropertyData">The buffer pointer to receive property-value.</param>
        /// <returns>Any of the sdk errors.</returns>
        public static UInt32 EdsGetPropertyData<T>(IntPtr myInRef, PropertyID myPropertyID, Int32 myParameter, out T outPropertyData)
        {

            Int32 _Size;

            if (typeof(T).IsEnum)
                _Size = Marshal.SizeOf(Enum.GetUnderlyingType(typeof(T)));
            else
                _Size = Marshal.SizeOf(typeof(T));

            var ptr  = Marshal.AllocHGlobal(_Size);
            var err  = EdsGetPropertyData(myInRef, (UInt32) myPropertyID, myParameter, _Size, ptr);

            if (typeof(T).IsEnum)
                outPropertyData = (T) Marshal.PtrToStructure(ptr, Enum.GetUnderlyingType(typeof(T)));
            else
                outPropertyData = (T) Marshal.PtrToStructure(ptr, typeof(T));

            Marshal.FreeHGlobal(ptr);
            
            return err;

        }

        #endregion

        #region EdsSetPropertyData(inRef, myPropertyID, inParam, inPropertySize, inPropertyData)

        [DllImport("DLLs\\EDSDK.dll")]
        private extern static UInt32 EdsSetPropertyData(IntPtr inRef, UInt32 myPropertyID, Int32 inParam, Int32 inPropertySize, [MarshalAs(UnmanagedType.AsAny), In] Object inPropertyData);

        /// <summary>
        /// Sets property data for the object designated in inRef.
        /// </summary>
        /// <param name="inRef">The reference of the item.</param>
        /// <param name="myPropertyID">The ProprtyID</param>
        /// <param name="inParam">Additional information of property.</param>
        /// <param name="inPropertySize">The number of bytes of the prepared buffer for set property-value.</param>
        /// <param name="inPropertyData">The buffer pointer to set property-value.</param>
        /// <returns>Any of the sdk errors.</returns>
        public static CanonSDKError EdsSetPropertyData(IntPtr inRef, PropertyID myPropertyID, Int32 inParam, Int32 inPropertySize, [MarshalAs(UnmanagedType.AsAny), In] Object inPropertyData)
        {
            return (CanonSDKError) EdsSetPropertyData(inRef, (uint)myPropertyID, inParam, inPropertySize, inPropertyData);
        }

        #endregion
    
        #region EdsGetPropertyDesc(inRef, myPropertyID, out outPropertyDesc)

        [DllImport("DLLs\\EDSDK.dll")]
        private extern static UInt32 EdsGetPropertyDesc(IntPtr inRef, UInt32 inPropertyID, out PropertyDescription outPropertyDesc);

        /// <summary>
        /// Gets a list of property data that can be set for the object designated in inRef, as well as maximum and minimum values.
        /// This API is intended for only some shooting-related properties.
        /// </summary>
        /// <param name="inRef">The reference of the camera.</param>
        /// <param name="myPropertyID">The Property ID.</param>
        /// <param name="outPropertyDesc">Array of the value which can be set up.</param>
        /// <returns>Any of the sdk errors.</returns>
        public static CanonSDKError EdsGetPropertyDesc(IntPtr inRef, PropertyID myPropertyID, out PropertyDescription outPropertyDesc)
        {
            return (CanonSDKError) EdsGetPropertyDesc(inRef, (uint)myPropertyID, out outPropertyDesc);
        }

        #endregion


        /*--------------------------------------------
          Device-list and device operating functions
        ---------------------------------------------*/
        #region EdsGetCameraList(out outCameraListRef)

        /// <summary>
        /// Gets camera list objects.
        /// </summary>
        /// <param name="outCameraListRef">Pointer to the camera-list.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static UInt32 EdsGetCameraList(out IntPtr outCameraListRef);

        #endregion


        /*--------------------------------------------
          Camera operating functions
        ---------------------------------------------*/
        #region EdsGetDeviceInfo(inCameraRef, out outDeviceInfo)

        /// <summary>
        /// Gets device information, such as the device name.
        /// Because device information of remote cameras is stored on the host computer, you can use this API
        /// before the camera object initiates communication (that is, before a session is opened).
        /// </summary>
        /// <param name="inCameraRef">The reference of the camera.</param>
        /// <param name="outDeviceInfo">Information as device of camera.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsGetDeviceInfo(IntPtr myCameraRef, out DeviceInfo outDeviceInfo);

        #endregion

        #region EdsOpenSession(inCameraRef)

        /// <summary>
        /// Establishes a logical connection with a remote camera.
        /// Use this API after getting the camera's EdsCamera object.
        /// </summary>
        /// <param name="inCameraRef">The reference of the camera </param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsOpenSession(IntPtr myCameraRef);

        #endregion

        #region EdsCloseSession(inCameraRef)
        
        /// <summary>
        /// Closes a logical connection with a remote camera.
        /// </summary>
        /// <param name="inCameraRef">The reference of the camera.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsCloseSession(IntPtr myCameraRef);

        #endregion

        #region EdsSendCommand(myCamera, myCameraCommand, myCommandParameter)

        [DllImport("DLLs\\EDSDK.dll")]
        private extern static UInt32 EdsSendCommand(IntPtr myCamera, UInt32 myCameraCommand, Int32 myCommandParameter);

        /// <summary>
        /// Sends a command such as "Shoot" to a remote camera.
        /// </summary>
        /// <param name="myCamera">The reference of the camera which will receive the command.</param>
        /// <param name="myCameraCommand">Specifies the command to be sent.</param>
        /// <param name="myCommandParameter">Specifies additional command-specific information.</param>
        /// <returns>Any of the sdk errors.</returns>
        public static UInt32 EdsSendCommand(IntPtr myCamera, CameraCommand myCameraCommand, Int32 myCommandParameter)
        {
            return EdsSendCommand(myCamera, (uint) myCameraCommand, myCommandParameter);
        }

        #endregion

        #region EdsSendStatusCommand(inCameraRef, inCameraState, inParam)

        /// <summary>
        /// Sets the remote camera state or mode.
        /// </summary>
        /// <param name="inCameraRef">The reference of the camera which will receive the command.</param>
        /// <param name="inCameraState">Specifies the command to be sent.</param>
        /// <param name="inParam">Specifies additional command-specific information.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsSendStatusCommand(IntPtr myCameraRef, uint inCameraState, int inParam);

        #endregion

        #region EdsSetCapacity(inCameraRef, inCapacity)

        /// <summary>
        /// Sets the remaining HDD capacity on the host computer (excluding the portion
        /// from image transfer), as calculated by subtracting the portion from the
        /// previous time.
        /// Set a reset flag initially and designate the cluster length and number of
        /// free clusters.
        /// Some type 2 protocol standard cameras can display the number of shots left
        /// on the camera based on the available disk capacity of the host computer.
        /// For these cameras, after the storage destination is set to the computer,
        /// use this API to notify the camera of the available disk capacity
        /// of the host computer.
        /// </summary>
        /// <param name="inCameraRef">The reference of the camera which will receive the command.</param>
        /// <param name="inCapacity">The remaining capacity of a transmission place.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsSetCapacity(IntPtr myCameraRef, Capacity inCapacity);

        #endregion


        /*--------------------------------------------
          Volume operating functions
        ---------------------------------------------*/
        #region EdsGetVolumeInfo(inCameraRef, out outVolumeInfo)

        /// <summary>
        /// Gets volume information for a memory card in the camera.
        /// </summary>
        /// <param name="inCameraRef">The reference of the volume.</param>
        /// <param name="outVolumeInfo">information of  the volume.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsGetVolumeInfo(IntPtr myCameraRef, out VolumeInfo outVolumeInfo);

        #endregion

        #region EdsFormatVolume(inVolumeRef)

        /// <summary>
        /// Format volume.
        /// </summary>
        /// <param name="inVolumeRef">The reference of volume.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsFormatVolume(IntPtr inVolumeRef);

        #endregion


        /*--------------------------------------------
          Directory-item operating functions
        ---------------------------------------------*/
        #region EdsGetDirectoryItemInfo(inDirItemRef, out outDirItemInfo)

        /// <summary>
        /// Gets information about the directory or file objects
        /// on the memory card (volume) in a remote camera.
        /// </summary>
        /// <param name="inDirItemRef">The reference of the directory item.</param>
        /// <param name="outDirItemInfo">information of the directory item./param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsGetDirectoryItemInfo(IntPtr inDirItemRef, out DirectoryItemInfo outDirItemInfo);

        #endregion

        #region EdsDeleteDirectoryItem(inDirItemRef)

        /// <summary>
        /// Deletes a camera folder or file.
        /// If folders with subdirectories are designated, all files are deleted
        /// except protected files.
        /// EdsDirectoryItem objects deleted by means of this API are implicitly 
        /// released by the EDSDK. Thus, there is no need to release them 
        /// by means of EdsRelease.
        /// </summary>
        /// <param name="inDirItemRef">The reference of the directory item.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsDeleteDirectoryItem(IntPtr inDirItemRef);

        #endregion

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsDownload
        //
        //  Description:
        //       Downloads a file on a remote camera 
        //          (in the camera memory or on a memory card) to the host computer. 
        //      The downloaded file is sent directly to a file stream created in advance. 
        //      When dividing the file being retrieved, call this API repeatedly. 
        //      Also in this case, make the data block size a multiple of 512 (bytes), 
        //          excluding the final block.
        //
        //  Parameters:
        //       In:    inDirItemRef - The reference of the directory item.
        //              inReadSize   - 
        //
        //      Out:    outStream    - The reference of the stream.
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsDownload (IntPtr inDirItemRef, uint inReadSize, IntPtr outStream);

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsDownloadCancel
        //
        //  Description:
        //       Must be executed when downloading of a directory item is canceled. 
        //      Calling this API makes the camera cancel file transmission.
        //      It also releases resources. 
        //      This operation need not be executed when using EdsDownloadThumbnail. 
        //
        //  Parameters:
        //       In:    inDirItemRef - The reference of the directory item.
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsDownloadCancel (IntPtr inDirItemRef);

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsDownloadComplete
        //
        //  Description:
        //       Must be called when downloading of directory items is complete. 
        //          Executing this API makes the camera 
        //              recognize that file transmission is complete. 
        //          This operation need not be executed when using EdsDownloadThumbnail.
        //
        //  Parameters:
        //       In:    inDirItemRef - The reference of the directory item.
        //
        //      Out:    outStream    - None.
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsDownloadComplete (IntPtr inDirItemRef);

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsDownloadThumbnail
        //
        //  Description:
        //      Extracts and downloads thumbnail information from image files in a camera. 
        //      Thumbnail information in the camera's image files is downloaded 
        //          to the host computer. 
        //      Downloaded thumbnails are sent directly to a file stream created in advance.
        //
        //  Parameters:
        //       In:    inDirItemRef - The reference of the directory item.
        //
        //      Out:    outStream - The reference of the stream.
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsDownloadThumbnail(IntPtr inDirItemRef, IntPtr outStream);

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsGetAttribute
        //
        //  Description:
        //      Gets attributes of files on a camera.
        //  
        //  Parameters:
        //       In:    inDirItemRef - The reference of the directory item.
        //      Out:    outFileAttribute  - Indicates the file attributes. 
        //                  As for the file attributes, OR values of the value defined
        //                  by enum EdsFileAttributes can be retrieved. Thus, when 
        //                  determining the file attributes, you must check 
        //                  if an attribute flag is set for target attributes. 
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsGetAttribute(IntPtr inDirItemRef, out FileAttribute outFileAttribute);

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsSetAttribute
        //
        //  Description:
        //      Changes attributes of files on a camera.
        //  
        //  Parameters:
        //       In:    inDirItemRef - The reference of the directory item.
        //              inFileAttribute  - Indicates the file attributes. 
        //                      As for the file attributes, OR values of the value 
        //                      defined by enum EdsFileAttributes can be retrieved. 
        //      Out:    None
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsSetAttribute(IntPtr inDirItemRef, FileAttribute inFileAttribute);

        /*--------------------------------------------
          Stream operating functions
        ---------------------------------------------*/
        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsCreateFileStream
        //
        //  Description:
        //      Creates a new file on a host computer (or opens an existing file) 
        //          and creates a file stream for access to the file. 
        //      If a new file is designated before executing this API, 
        //          the file is actually created following the timing of writing 
        //          by means of EdsWrite or the like with respect to an open stream.
        //
        //  Parameters:
        //       In:    inFileName - Pointer to a null-terminated string that specifies
        //                           the file name.
        //              inCreateDisposition - Action to take on files that exist, 
        //                                and which action to take when files do not exist.  
        //              inDesiredAccess - Access to the stream (reading, writing, or both).
        //      Out:    outStream - The reference of the stream.
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/     
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsCreateFileStream( string inFileName, EdsFileCreateDisposition inCreateDisposition, Access inDesiredAccess, out IntPtr outStream);

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsCreateMemoryStream
        //
        //  Description:
        //      Creates a stream in the memory of a host computer. 
        //      In the case of writing in excess of the allocated buffer size, 
        //          the memory is automatically extended.
        //
        //  Parameters:
        //       In:    inBufferSize - The number of bytes of the memory to allocate.
        //      Out:    outStream - The reference of the stream.
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsCreateMemoryStream( uint inBufferSize, out IntPtr outStream);

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsCreateStreamEx
        //
        //  Description:
        //      An extended version of EdsCreateStreamFromFile. 
        //      Use this function when working with Unicode file names.
        //
        //  Parameters:
        //       In:    inFileName - Designate the file name. 
        //              inCreateDisposition - Action to take on files that exist, 
        //                                and which action to take when files do not exist.  
        //              inDesiredAccess - Access to the stream (reading, writing, or both).
        //
        //      Out:    outStream - The reference of the stream.
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsCreateStreamEx( 
           String                       inFileName,
           EdsFileCreateDisposition     inCreateDisposition,
           Access                       inDesiredAccess,
           out IntPtr                   outStream 
           );

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsCreateMemoryStreamFromPointer        
        //
        //  Description:
        //      Creates a stream from the memory buffer you prepare. 
        //      Unlike the buffer size of streams created by means of EdsCreateMemoryStream, 
        //      the buffer size you prepare for streams created this way does not expand.
        //
        //  Parameters:
        //       In:    inBufferSize - The number of bytes of the memory to allocate.
        //      Out:    outStream - The reference of the stream.
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsCreateMemoryStreamFromPointer(IntPtr inUserBuffer, uint inBufferSize, out IntPtr outStream);

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsGetPointer
        //
        //  Description:
        //      Gets the pointer to the start address of memory managed by the memory stream. 
        //      As the EDSDK automatically resizes the buffer, the memory stream provides 
        //          you with the same access methods as for the file stream. 
        //      If access is attempted that is excessive with regard to the buffer size
        //          for the stream, data before the required buffer size is allocated 
        //          is copied internally, and new writing occurs. 
        //      Thus, the buffer pointer might be switched on an unknown timing. 
        //      Caution in use is therefore advised. 
        //
        //  Parameters:
        //       In:    inStream - Designate the memory stream for the pointer to retrieve. 
        //      Out:    outPointer - If successful, returns the pointer to the buffer 
        //                  written in the memory stream.
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsGetPointer(IntPtr inStreamRef, out IntPtr outPointer);

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsRead
        //
        //  Description:
        //      Reads data the size of inReadSize into the outBuffer buffer, 
        //          starting at the current read or write position of the stream. 
        //      The size of data actually read can be designated in outReadSize.
        //
        //  Parameters:
        //       In:    inStreamRef - The reference of the stream or image.
        //              inReadSize -  The number of bytes to read.
        //      Out:    outBuffer - Pointer to the user-supplied buffer that is to receive
        //                          the data read from the stream. 
        //              outReadSize - The actually read number of bytes.
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsRead(IntPtr inStreamRef, uint inReadSize, IntPtr outBuffer, out uint outReadSize);

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsWrite
        //
        //  Description:
        //      Writes data of a designated buffer 
        //          to the current read or write position of the stream. 
        //
        //  Parameters:
        //       In:    inStreamRef  - The reference of the stream or image.
        //              inWriteSize - The number of bytes to write.
        //              inBuffer - A pointer to the user-supplied buffer that contains 
        //                         the data to be written to the stream.
        //      Out:    outWrittenSize - The actually written-in number of bytes.
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsWrite(IntPtr inStreamRef, uint inWriteSize, IntPtr inBuffer, out uint outWrittenSize);

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsSeek
        //
        //  Description:
        //      Moves the read or write position of the stream
                    (that is, the file position indicator).
        //
        //  Parameters:
        //       In:    inStreamRef  - The reference of the stream or image. 
        //              inSeekOffset - Number of bytes to move the pointer. 
        //              inSeekOrigin - Pointer movement mode. Must be one of the following 
        //                             values.
        //                  kEdsSeek_Cur     Move the stream pointer inSeekOffset bytes 
        //                                   from the current position in the stream. 
        //                  kEdsSeek_Begin   Move the stream pointer inSeekOffset bytes
        //                                   forward from the beginning of the stream. 
        //                  kEdsSeek_End     Move the stream pointer inSeekOffset bytes
        //                                   from the end of the stream. 
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsSeek(IntPtr inStreamRef, int inSeekOffset, SeekOrigin inSeekOrigin );

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsGetPosition
        //
        //  Description:
        //       Gets the current read or write position of the stream
        //          (that is, the file position indicator).
        //
        //  Parameters:
        //       In:    inStreamRef - The reference of the stream or image.
        //      Out:    outPosition - The current stream pointer.
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsGetPosition(IntPtr inStreamRef, out uint outPosition);

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsGetLength
        //
        //  Description:
        //      Gets the stream size.
        //
        //  Parameters:
        //       In:    inStreamRef - The reference of the stream or image.
        //      Out:    outLength - The length of the stream.
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsGetLength(IntPtr inStreamRef, out uint outLength );

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsCopyData
        //
        //  Description:
        //      Copies data from the copy source stream to the copy destination stream. 
        //      The read or write position of the data to copy is determined from 
        //          the current file read or write position of the respective stream. 
        //      After this API is executed, the read or write positions of the copy source 
        //          and copy destination streams are moved an amount corresponding to 
        //          inWriteSize in the positive direction. 
        //
        //  Parameters:
        //       In:    inStreamRef - The reference of the stream or image.
        //              inWriteSize - The number of bytes to copy.
        //      Out:    outStreamRef - The reference of the stream or image.
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsCopyData(IntPtr inStreamRef, uint inWriteSize, IntPtr outStreamRef);

        #region EdsSetProgressCallback(inRef, inProgressFunc, inProgressOption, myContext)

        /// <summary>
        /// Register a progress callback function.
        /// An event is received as notification of progress during processing that
        /// takes a relatively long time, such as downloading files from a remote camera. 
        /// If you register the callback function, the EDSDK calls the callback
        /// function during execution or on completion of the following APIs.
        /// This timing can be used in updating on-screen progress bars, for example.
        /// </summary>
        /// <param name="inRef">The reference of the stream or image.</param>
        /// <param name="inProgressFunc">Pointer to a progress callback function.</param>
        /// <param name="inProgressOption">The option about progress is specified. Must be one of the following values: kEdsProgressOption_Done -> When processing is completed,a callback function is called only at once. kEdsProgressOption_Periodically -> A callback function is performed periodically.</param>
        /// <param name="myContext">Application information, passed in the argument when the callback function is called. Any information required for your program may be added.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsSetProgressCallback(IntPtr inRef, EdsProgressCallback inProgressFunc, ProgressOption inProgressOption, IntPtr myContext);

        #endregion

        /*--------------------------------------------
          Image operating functions
        ---------------------------------------------*/ 
        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsCreateImageRef
        //
        //  Description:
        //      Creates an image object from an image file. 
        //      Without modification, stream objects cannot be worked with as images. 
        //      Thus, when extracting images from image files, 
        //          you must use this API to create image objects. 
        //      The image object created this way can be used to get image information 
        //          (such as the height and width, number of color components, and
        //           resolution), thumbnail image data, and the image data itself.
        //
        //  Parameters:
        //       In:    inStreamRef - The reference of the stream.
        //
        //       Out:    outImageRef - The reference of the image.
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsCreateImageRef(IntPtr inStreamRef,  out IntPtr outImageRef);

        /*-----------------------------------------------------------------------------
        //
        //  Function:   EdsGetImageInfo
        //
        //  Description:
        //      Gets image information from a designated image object. 
        //      Here, image information means the image width and height, 
        //          number of color components, resolution, and effective image area.
        //
        //  Parameters:
        //       In:    inStreamRef - Designate the object for which to get image information. 
        //              inImageSource - Of the various image data items in the image file,
        //                  designate the type of image data representing the 
        //                  information you want to get. Designate the image as
        //                  defined in Enum EdsImageSource. 
        //
        //                      kEdsImageSrc_FullView
        //                                  The image itself (a full-sized image) 
        //                      kEdsImageSrc_Thumbnail
        //                                  A thumbnail image 
        //                      kEdsImageSrc_Preview
        //                                  A preview image
        //                      kEdsImageSrc_RAWThumbnail
        //                                  A RAW thumbnail image 
        //                      kEdsImageSrc_RAWFullView
        //                                  A RAW full-sized image 
        //       Out:    outImageInfo - Stores the image data information designated 
        //                      in inImageSource. 
        //
        //  Returns:    Any of the sdk errors.
        -----------------------------------------------------------------------------*/
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static uint EdsGetImageInfo(IntPtr inImageRef, ImageSource inImageSource, out ImageInfo outImageInfo);

        #region EdsGetImage(myImageRef, myImageSource, myImageType, mySrcRect, myDstSize, myStreamRef)

        /// <summary>
        /// Gets designated image data from an image file, in the form of a designated rectangle.
        /// Returns uncompressed results for JPEGs and processed results in the designated pixel order (RGB, Top-down BGR, and so on) for RAW images.
        /// Additionally, by designating the input/output rectangle, it is possible to get reduced, enlarged, or partial images.
        /// However, because images corresponding to the designated output rectangle are always returned by the SDK, the SDK does not take the aspect ratio into account.
        /// To maintain the aspect ratio, you must keep the aspect ratio in mind when designating the rectangle.
        /// </summary>
        /// <param name="myImageRef">Designate the image object for which to get the image data.</param>
        /// <param name="myImageSource">Designate the type of image data to get from the image file (thumbnail, preview, and so on). Designate values as defined in Enum EdsImageSource.</param>
        /// <param name="myImageType">Designate the output image type. Because the output format of EdGetImage may only be RGB, only kEdsTargetImageType_RGB or kEdsTargetImageType_RGB16 can be designated. However, image types exceeding the resolution of inImageSource cannot be designated.</param>
        /// <param name="mySrcRect">Designate the coordinates and size of the rectangle to be retrieved (processed) from the source image.</param>
        /// <param name="myDstSize">Designate the rectangle size for output. </param>
        /// <param name="myStreamRef">Designate the memory or file stream for output of the image.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static UInt32 EdsGetImage(IntPtr myImageRef, ImageSource myImageSource, TargetImageType myImageType, Rectangle mySrcRect, Size myDstSize, IntPtr myStreamRef);

        #endregion

        #region EdsSaveImage(myImageRef, myImageType, mySaveSetting, myStreamRef)

        /// <summary>
        /// Saves as a designated image type after RAW processing.
        /// When saving with JPEG compression, the JPEG quality setting applies with respect to EdsOptionRef.
        /// </summary>
        /// <param name="myImageRef">Designate the image object for which to produce the file.</param>
        /// <param name="myImageType">Designate the image type to produce. Designate the following image types.</param>
        /// <param name="mySaveSetting">Designate saving options, such as JPEG image quality.</param>
        /// <param name="myStreamRef">Specifies the output file stream. The memory stream cannot be specified here.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static UInt32 EdsSaveImage(IntPtr myImageRef, TargetImageType myImageType, SaveImageSetting mySaveSetting, IntPtr myStreamRef);

        #endregion

        #region EdsCacheImage(myImageRef, myUseCache)

        /// <summary>
        /// Switches a setting on and off for creation of an image cache in the SDK 
        /// for a designated image object during extraction (processing) of the image data. 
        /// Creating the cache increases the processing speed, starting from the second time.
        /// </summary>
        /// <param name="myImageRef">The reference of the image.</param>
        /// <param name="myUseCache">If cache image data or not. If set to FALSE, the cached image data will released.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static UInt32 EdsCacheImage(IntPtr myImageRef, Boolean myUseCache);

        #endregion

        #region EdsReflectImageProperty(myImageRef)

        /// <summary>
        /// Incorporates image object property changes (effected by means of EdsSetPropertyData) in the stream. 
        /// </summary>
        /// <param name="myImageRef">The reference of the image.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static UInt32 EdsReflectImageProperty(IntPtr myImageRef);

        #endregion

        
        //----------------------------------------------
        //   Event handler registering functions
        //----------------------------------------------

        #region EdsSetCameraAddedHandler(myCameraAddedHandler, myContext);

        /// <summary>
        /// Registers a callback function for when a camera is detected.
        /// </summary>
        /// <param name="myCameraAddedHandler">Pointer to a callback function called when a camera is connected physically.</param>
        /// <param name="myContext">Specifies an application-defined value to be sent to the callback function pointed to by CallBack parameter.</param>
        /// <returns>Any of the sdk errors.</returns>
        [DllImport("DLLs\\EDSDK.dll")]
        public extern static UInt32 EdsSetCameraAddedHandler(EdsCameraAddedHandler myCameraAddedHandler, IntPtr myContext);

        #endregion

        #region EdsSetPropertyEventHandler(myCameraRef, myEvent, myPropertyEventHandler, myContext)

        [DllImport("DLLs\\EDSDK.dll")]
        private extern static UInt32 EdsSetPropertyEventHandler(IntPtr myCameraRef, UInt32 myEvent, EdsPropertyEventHandler myPropertyEventHandler, IntPtr myContext);

        /// <summary>
        /// Registers a callback function for receiving status change
        /// notification events for property states on a camera.
        /// </summary>
        /// <param name="myCameraRef">Designate the camera object. </param>
        /// <param name="myPropertyEvent">Designate one or all events to be supplemented.</param>
        /// <param name="myPropertyEventHandler">Designate the pointer to the callback function for receiving property-related camera events.</param>
        /// <param name="myContext">Designate application information to be passed by means of the callback function. Any data needed for your application can be passed. </param>
        /// <returns>Any of the sdk errors.</returns>
        public static UInt32 EdsSetPropertyEventHandler(IntPtr myCameraRef, PropertyEvent myPropertyEvent, EdsPropertyEventHandler myPropertyEventHandler, IntPtr myContext)
        {
            return EdsSetPropertyEventHandler(myCameraRef, (UInt32) myPropertyEvent, myPropertyEventHandler, myContext);
        }

        #endregion

        #region EdsSetObjectEventHandler(inCameraRef, myEvent, inObjectEventHandler, myContext)

        [DllImport("DLLs\\EDSDK.dll")]
        private extern static UInt32 EdsSetObjectEventHandler(IntPtr myCameraRef, UInt32 myEvent, EdsObjectEventHandler myObjectEventHandler, IntPtr myContext);

        /// <summary>
        /// Registers a callback function for receiving status change notification events for objects on a remote camera.
        /// Here, object means volumes representing memory cards, files and directories, and shot images stored in memory, in particular.
        /// </summary>
        /// <param name="myCameraRef">Designate the camera object./param>
        /// <param name="myEvent">Designate one or all events to be supplemented. To designate all events, use ObjectEvent.All.</param>
        /// <param name="myObjectEventHandler">Designate the pointer to the callback function for receiving object-related camera events.</param>
        /// <param name="myContext">Passes inContext without modification, as designated as an EdsSetObjectEventHandler argument.</param>
        /// <returns>Any of the sdk errors.</returns>
        public static UInt32 EdsSetObjectEventHandler(IntPtr myCameraRef, ObjectEvent myEvent, EdsObjectEventHandler myObjectEventHandler, IntPtr myContext)
        {
            return EdsSetObjectEventHandler(myCameraRef, (UInt32) myEvent, myObjectEventHandler, myContext);
        }

        #endregion

        #region EdsSetCameraStateEventHandler(myCameraRef, myEvent, myStateEventHandler, myContext)

        [DllImport("DLLs\\EDSDK.dll")]
        private extern static UInt32 EdsSetCameraStateEventHandler(IntPtr myCameraRef, UInt32 myEvent, EdsStateEventHandler myStateEventHandler, IntPtr myContext);

        /// <summary>
        /// Registers a callback function for receiving status change
        /// notification events for property states on a camera.
        /// </summary>
        /// <param name="myCameraRef">Designate the camera object. </param>
        /// <param name="myEvent">Designate one or all events to be supplemented. To designate all events, use StateEvent.All. </param>
        /// <param name="myStateEventHandler">Designate the pointer to the callback function for receiving events related to camera object states.</param>
        /// <param name="myContext">Designate application information to be passed by means of the callback function. Any data needed for your application can be passed.</param>
        /// <returns>Any of the sdk errors.</returns>
        public static UInt32 EdsSetCameraStateEventHandler(IntPtr myCameraRef, StateEvent myEvent, EdsStateEventHandler myStateEventHandler, IntPtr myContext)
        {
            return EdsSetCameraStateEventHandler(myCameraRef, (UInt32) myEvent, myStateEventHandler, myContext);
        }

        #endregion



        #region EdsCreateEvfImageRef(myStreamRef, out myImageRef)

        /// <summary>
        /// Creates an object used to get the live view image data set.
        /// </summary>
        /// <param name="myStreamRef">The stream reference which opened to get EVF JPEG image.</param>
        /// <param name="myImageRef">The EVFData reference.</param>
        /// <returns>Any of the sdk errors.</returns>
		[DllImport("DLLs\\EDSDK.dll")]
		public extern static UInt32 EdsCreateEvfImageRef(IntPtr myStreamRef, out IntPtr myImageRef);

        #endregion

        #region EdsDownloadEvfImage(myCameraRef, myImageRef)

        /// <summary>
        /// Downloads the live view image data set for a camera currently in live view mode.
        /// Live view can be started by using the property ID:kEdsPropertyID_Evf_OutputDevice and
        /// data:EdsOutputDevice_PC to call EdsSetPropertyData.
        /// In addition to image data, information such as zoom, focus position, and histogram data
        /// is included in the image data set. Image data is saved in a stream maintained by EdsEvfImageRef.
        /// EdsGetPropertyData can be used to get information such as the zoom, focus position, etc.
        /// Although the information of the zoom and focus position can be obtained from EdsEvfImageRef,
        /// settings are applied to EdsCameraRef.
        /// </summary>
        /// <param name="myCameraRef">The Camera reference.</param>
        /// <param name="myImageRef">The EVFData reference.</param>
        /// <returns>Any of the sdk errors.</returns>
		[DllImport("DLLs\\EDSDK.dll")]
		public extern static UInt32 EdsDownloadEvfImage(IntPtr myCameraRef, IntPtr myImageRef);

        #endregion

        #endregion

    }

}
