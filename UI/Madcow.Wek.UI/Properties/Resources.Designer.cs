﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Madcow.Wek.UI.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Madcow.Wek.UI.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The host configuration failed to save..
        /// </summary>
        internal static string Error_FailedToSaveWekHosts {
            get {
                return ResourceManager.GetString("Error_FailedToSaveWekHosts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do nothing.
        /// </summary>
        internal static string HostDoubleClickAction_DoNothing {
            get {
                return ResourceManager.GetString("HostDoubleClickAction_DoNothing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Show the machine properties.
        /// </summary>
        internal static string HostDoubleClickAction_ShowHostProperties {
            get {
                return ResourceManager.GetString("HostDoubleClickAction_ShowHostProperties", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wake the machine.
        /// </summary>
        internal static string HostDoubleClickAction_WakeTheHost {
            get {
                return ResourceManager.GetString("HostDoubleClickAction_WakeTheHost", resourceCulture);
            }
        }
        
        internal static System.Drawing.Bitmap machine2 {
            get {
                object obj = ResourceManager.GetObject("machine2", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Auto detect.
        /// </summary>
        internal static string NetworkLocality_AutoDetect {
            get {
                return ResourceManager.GetString("NetworkLocality_AutoDetect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Local subnet.
        /// </summary>
        internal static string NetworkLocality_LocalSubnet {
            get {
                return ResourceManager.GetString("NetworkLocality_LocalSubnet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Remote network.
        /// </summary>
        internal static string NetworkLocality_Remote {
            get {
                return ResourceManager.GetString("NetworkLocality_Remote", resourceCulture);
            }
        }
        
        internal static System.Drawing.Icon wek {
            get {
                object obj = ResourceManager.GetObject("wek", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
    }
}
