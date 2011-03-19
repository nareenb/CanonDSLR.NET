﻿/*
 * Copyright (c) 2011, Aperis GmbH <agplsources@aperis.com>
 * Autor: Achim 'ahzf' Friedland <code@ahzf.de>
 * This file is part of CanonDSLRServer
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
using System.IO;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using de.ahzf.Hermod;
using de.ahzf.Hermod.HTTP;
using de.ahzf.Hermod.HTTP.Common;
using com.aperis.CanonDSLR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#endregion

namespace com.aperis.CanonDSLRServer
{

    /// <summary>
    /// The CanonDSLR service implementation.
    /// </summary>
    public class CanonDSLRService : ICanonDSLRService
    {

        
        #region Data

        #endregion

        #region Properties

        #region IHTTPConnection

        public IHTTPConnection IHTTPConnection { get; private set; }

        #endregion

        #region CanonDSLRWrapper

        public CanonDSLRWrapper CanonDSLRWrapper { get; set; }

        #endregion

        #endregion

        #region Constructor(s)

        #region CanonDSLRService()

        /// <summary>
        /// Creates a new CanonDSLRService.
        /// </summary>
        public CanonDSLRService()
        { }

        #endregion

        #region CanonDSLRService(myIHTTPConnection)

        /// <summary>
        /// Creates a new CanonDSLRService.
        /// </summary>
        /// <param name="myIHTTPConnection">The http connection for this request.</param>
        public CanonDSLRService(IHTTPConnection myIHTTPConnection)
        {
            IHTTPConnection = myIHTTPConnection;
        }

        #endregion

        #endregion



        #region (private) HTMLBuilder(myHeadline, myFunc)

        /// <summary>
        /// A little HTML genereator...
        /// </summary>
        /// <param name="myHeadline"></param>
        /// <param name="myFunc"></param>
        /// <returns></returns>
        private String HTMLBuilder(String myHeadline, Action<StringBuilder> myFunc)
        {

            var _StringBuilder = new StringBuilder();

            _StringBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            _StringBuilder.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\">");
            _StringBuilder.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            _StringBuilder.AppendLine("<head>");
            _StringBuilder.AppendLine("<title>Rexster</title>");
            _StringBuilder.AppendLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"/resources/style.css\" />");
            _StringBuilder.AppendLine("</head>");
            _StringBuilder.AppendLine("<body>");
            _StringBuilder.Append("<h1>").Append(myHeadline).AppendLine("</h1>");
            _StringBuilder.AppendLine("<table>");
            _StringBuilder.AppendLine("<tr>");
            _StringBuilder.AppendLine("<td style=\"width: 100px\">&nbsp;</td>");
            _StringBuilder.AppendLine("<td>");

            myFunc(_StringBuilder);

            _StringBuilder.AppendLine("</td>");
            _StringBuilder.AppendLine("</tr>");
            _StringBuilder.AppendLine("</table>");
            _StringBuilder.AppendLine("</body>");
            _StringBuilder.AppendLine("</html>").AppendLine();

            return _StringBuilder.ToString();

        }

        #endregion


        #region (private) GetStartOffset()

        private UInt32 GetStartOffset()
        {

            String _StringValue = null;

            if (IHTTPConnection.RequestHeader.QueryString != null)
                if (IHTTPConnection.RequestHeader.QueryString.TryGetValue("OFFSET" + "." + "START", out _StringValue))
                {

                    UInt32 _Value;

                    if (UInt32.TryParse(_StringValue, out _Value))
                        return _Value;

                }

            return 0;

        }

        #endregion

        #region (private) GetEndOffset()

        private UInt32 GetEndOffset()
        {

            String _StringValue = null;

            if (IHTTPConnection.RequestHeader.QueryString != null)
                if (IHTTPConnection.RequestHeader.QueryString.TryGetValue("OFFSET" + "." + "END", out _StringValue))
                {

                    UInt32 _Value;

                    if (UInt32.TryParse(_StringValue, out _Value))
                        return _Value;

                }

            return 0;

        }

        #endregion


        #region HasShowTypes()

        /// <summary>
        /// Determines if the data types should be shown in the results.
        /// Checks the request for the show_types parameter which must be set
        /// to a boolean value. Types are not shown by default or if the value
        /// cannot be parsed from the request.
        /// </summary>
        /// <returns>true if show_types is set to "true" and false otherwise.</returns>
        private Boolean HasShowTypes()
        {

            Boolean showTypes = false;

            //JSONObject rexster = this.getRexsterRequest();

            //if (rexster != null) {
            //    if (rexster.has(Tokens.SHOW_TYPES)) {
            //        showTypes = rexster.optBoolean(Tokens.SHOW_TYPES, false);
            //    }
            //}

            return showTypes;

        }

        #endregion

        #region GetReturnKeys()

        private List<String> GetReturnKeys()
        {
            
            //JSONObject rexster = this.getRexsterRequest();
            
            //if (rexster != null) {

            //    //return (List<String>) rexster.opt(Tokens.RETURN_KEYS);
            //    JSONArray arr = rexster.optJSONArray(Tokens.RETURN_KEYS);
            //    List<String> keys = new ArrayList<String>();

            //    if (arr != null)
            //    {
            //        for (int ix = 0; ix < arr.length(); ix++)
            //        {
            //            keys.add(arr.optString(ix));
            //        }
            //    }

            //    else
            //        keys = null;

            //    return keys;
            
            //}
            
            //else
                return new List<String>();

        }

        #endregion



        #region GetLandingpage

        #region GetLandingpage()

        /// <summary>
        /// Get the landing page.
        /// </summary>
        /// <returns>The landing page.</returns>
        public HTTPResponse GetLandingpage()
        {
            return GetResources("mainpage.html");
        }

        #endregion

        #endregion

        #region Camera Properties

        #region (private) GetPropertyMap(myCamera, myPropertyFunc)

        private HTTPResponse GetPropertyMap(String myCamera, Func<Camera, IEnumerable<KeyValuePair<String, String>>> myPropertyFunc)
        {

            UInt32 _CameraId;
            if (UInt32.TryParse(myCamera, out _CameraId))
            {

                var _CanonDSLRWrapper = CanonDSLRWrapper.Instance;
                var _Camera           = _CanonDSLRWrapper.GetCamera(_CameraId);
                //var _JSONAvMap        = JsonConvert.SerializeObject(_Camera.AvMap, Formatting.Indented);

                //var _JSON = _Camera.AvMap.Aggregate(new JObject(), (J, v) => J.Add(v.Key, v.Value));

                var _JSON = new JObject();
                foreach (var _item in myPropertyFunc(_Camera))
                    _JSON.Add(new JProperty(_item.Key, _item.Value));

                #region HTTPResponse

                var _ContentType = HTTPContentType.JSON_UTF8;

                return new HTTPResponse(

                    new HTTPResponseHeader()
                    {
                        HttpStatusCode = HTTPStatusCode.OK,
                        CacheControl   = "no-cache",
                        ContentType    = _ContentType
                    },

                    UTF8Encoding.UTF8.GetBytes(_JSON.ToString())

                );
            }

            else
            {

                return new HTTPResponse(

                    new HTTPResponseHeader()
                    {
                        HttpStatusCode = HTTPStatusCode.NotFound,
                        CacheControl   = "no-cache",
                        ContentType    = HTTPContentType.HTML_UTF8
                    },

                    UTF8Encoding.UTF8.GetBytes("Camera '" + myCamera + "' not found!")

                );
            } 

            #endregion

        }

        #endregion

        #region GetTvMap(myCamera)

        public HTTPResponse GetTvMap(String myCamera)
        {
            return GetPropertyMap(myCamera, _Camera => _Camera.TvMap);
        }

        #endregion

        #region GetAvMap(myCamera)

        public HTTPResponse GetAvMap(String myCamera)
        {
            return GetPropertyMap(myCamera, _Camera => _Camera.AvMap);
        }

        #endregion

        #region GetISOMap(myCamera)

        public HTTPResponse GetISOMap(String myCamera)
        {
            return GetPropertyMap(myCamera, _Camera => _Camera.ISOMap);
        }

        #endregion

        #endregion

        #region Camera Actions

        #region TakePicture(myCamera)

        /// <summary>
        /// Take a picture.
        /// </summary>
        /// <param name="myCamera">The identification of the camera.</param>
        /// <returns>A picture.</returns>
        public HTTPResponse TakePicture(String myCamera)
        {

            #region HTTPResponse

            //ToDo: Implement real content negotiation!
            var _ContentType = HTTPContentType.HTML_UTF8;

            return new HTTPResponse(

                new HTTPResponseHeader()
                {
                    HttpStatusCode = HTTPStatusCode.OK,
                    CacheControl   = "no-cache",
                    ContentType    = _ContentType
                },

                UTF8Encoding.UTF8.GetBytes("No picture taken!")

            );

            #endregion

        }

        #endregion

        #endregion



        #region GetResources(myResource)

        /// <summary>
        /// Returns internal resources embedded within the assembly.
        /// </summary>
        /// <param name="myResource">The path and name of the resource.</param>
        public HTTPResponse GetResources(String myResource)
        {

            #region Data

            var _PackageName  = "CanonDSLRServer";
            var _Assembly     = Assembly.GetExecutingAssembly();
            var _AllResources = _Assembly.GetManifestResourceNames();

            myResource = myResource.Replace('/', '.');

            #endregion

            #region Return internal assembly resources...

            if (_AllResources.Contains(_PackageName + ".resources." + myResource))
            {

                var _ResourceContent = _Assembly.GetManifestResourceStream(_PackageName + ".resources." + myResource);

                HTTPContentType _ResponseContentType = null;

                // Get the apropriate content type based on the suffix of the requested resource
                switch (myResource.Remove(0, myResource.LastIndexOf(".") + 1))
                {
                    case "htm":  _ResponseContentType = HTTPContentType.XHTML_UTF8;      break;
                    case "html": _ResponseContentType = HTTPContentType.XHTML_UTF8;      break;
                    case "css":  _ResponseContentType = HTTPContentType.CSS_UTF8;        break;
                    case "gif":  _ResponseContentType = HTTPContentType.GIF;             break;
                    case "ico":  _ResponseContentType = HTTPContentType.ICO;             break;
                    case "swf":  _ResponseContentType = HTTPContentType.SWF;             break;
                    case "js":   _ResponseContentType = HTTPContentType.JAVASCRIPT_UTF8; break;
                    default:     _ResponseContentType = HTTPContentType.OCTETSTREAM;     break;
                }

                return new HTTPResponse(

                    new HTTPResponseHeader()
                        {
                            HttpStatusCode = HTTPStatusCode.OK,
                            ContentType    = _ResponseContentType,
                            ContentLength  = (UInt64) _ResourceContent.Length,
                            CacheControl   = "no-cache",
                            Connection     = "close",
                        },

                    _ResourceContent

                );

            }

            #endregion

            #region ...or send an (custom) error 404!

            else
            {
                
                Stream _ResourceContent = null;

                if (_AllResources.Contains(_PackageName + ".resources.errorpages.Error404.html"))
                    _ResourceContent = _Assembly.GetManifestResourceStream(_PackageName + ".resources.errorpages.Error404.html");
                else
                    _ResourceContent = new MemoryStream(UTF8Encoding.UTF8.GetBytes("Error 404 - File not found!"));

                return new HTTPResponse(

                    new HTTPResponseHeader()
                        {
                            HttpStatusCode = HTTPStatusCode.NotFound,
                            ContentType    = HTTPContentType.XHTML_UTF8,
                            ContentLength  = (UInt64) _ResourceContent.Length,
                            CacheControl   = "no-cache",
                            Connection     = "close",
                        },

                    _ResourceContent

                );

            }

            #endregion

        }

        #endregion

        #region GetResources_JQuery(myResource)

        public HTTPResponse GetResources_JQuery(String myResource)
        {
            return GetResources("jquery/" + myResource);
        }

        #endregion

        #region GenerateWADL()

        /// <summary>
        /// Generate the WADL description of this service.
        /// </summary>
        public HTTPResponse GenerateWADL()
        {
            throw new NotImplementedException("Sorry, WADL generation is out of order!");
        }

        #endregion

        #region GetFavicon()

        /// <summary>
        /// Returns the favicon.ico.
        /// </summary>
        public HTTPResponse GetFavicon()
        {
            return GetResources("favicon.ico");
        }

        #endregion

        #region GetError(myHTTPStatusCode)

        /// <summary>
        /// Get a http error for debugging purposes.
        /// An additional error reason may be given via the
        /// QueryString (e.g. "/error/204&reason=unknown")
        /// </summary>
        /// <param name="myHTTPStatusCode">The http status code.</param>
        public HTTPResponse GetError(String myHTTPStatusCode)
        {

            IHTTPConnection.ResponseHeader.HttpStatusCode = HTTPStatusCode.ParseString(myHTTPStatusCode);

            if (IHTTPConnection.RequestHeader.QueryString.ContainsKey("reason"))
                IHTTPConnection.ErrorReason = IHTTPConnection.RequestHeader.QueryString["reason"];

            return new HTTPResponse(

                new HTTPResponseHeader()
                {
                    HttpStatusCode = IHTTPConnection.ResponseHeader.HttpStatusCode,
                    Connection     = "close"
                }

            );

        }

        #endregion

        
    }

}

