﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleQuizCreator.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class EnumResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal EnumResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SimpleQuizCreator.Resources.EnumResources", typeof(EnumResources).Assembly);
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
        ///   Looks up a localized string similar to Multi answer - hard.
        /// </summary>
        internal static string AllGoodWithMinus {
            get {
                return ResourceManager.GetString("AllGoodWithMinus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Multi answer - simple.
        /// </summary>
        internal static string AllGoodWithoutMinus {
            get {
                return ResourceManager.GetString("AllGoodWithoutMinus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Single answer - medium.
        /// </summary>
        internal static string OneGoodOneBad {
            get {
                return ResourceManager.GetString("OneGoodOneBad", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Single answer - hard.
        /// </summary>
        internal static string OneGoodOneBadOneNo {
            get {
                return ResourceManager.GetString("OneGoodOneBadOneNo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Single answer - simple.
        /// </summary>
        internal static string OneGoodZeroBad {
            get {
                return ResourceManager.GetString("OneGoodZeroBad", resourceCulture);
            }
        }
    }
}
