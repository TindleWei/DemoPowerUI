//--------------------------------------
//               PowerUI
//
//        For documentation or 
//    if you have any issues, visit
//        powerUI.kulestar.com
//
//    Copyright � 2013 Kulestar Ltd
//          www.kulestar.com
//--------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using PowerUI;


namespace Dom{
	
	/// <summary>
	/// Represents a path to a file with a protocol.
	/// e.g. http://www.site.com/aFile.png
	/// The path may also be relative to some other path (aFile.png relative to http://www.site.com).
	/// </summary>
	
	public partial class Location{
		
		/// <summary>The protocol which will handle this URL.</summary>
		public FileProtocol Handler{
			get{
				return FileProtocols.Get(Protocol);
			}
		}
		
		/// <summary>The HTML document that this path belongs to, if any.</summary>
		public HtmlDocument htmlDocument{
			get{
				return document as HtmlDocument;
			}
		}
		
		/// <summary>Does this location have full access to the game? Depends on the protocol. E.g. http does not.</summary>
		public bool fullAccess{
			get{
				FileProtocol protocol=GetProtocol();
				
				if(protocol==null){
					return false;
				}
				
				return protocol.FullAccess(this);
			}
		}
		
		/// <summary>Gets the cookie jar for this path.</summary>
		public PowerUI.Http.CookieJar CookieJar{
			get{
				return PowerUI.Http.CookieJar.Get(host);
			}
		}
		
		/// <summary>Gets the file protocol for this location. Default is resources://.</summary>
		public FileProtocol GetProtocol(){
			return FileProtocols.Get(Protocol);
		}
		
	}
	
}