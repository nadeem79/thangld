﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace beans {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class reports {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal reports() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("beans.reports", typeof(reports).Assembly);
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
        ///   Looks up a localized string similar to &lt;h3&gt;
        ///    $winning$ thắng trận&lt;/h3&gt;
        ///May mắn (phía tấn công): $luck$
        ///&lt;br /&gt;
        ///&lt;br /&gt;
        ///&lt;table style=&quot;border: 1px solid rgb(222, 211, 185);&quot; width=&quot;100%&quot;&gt;
        ///    &lt;tbody&gt;
        ///        &lt;tr&gt;
        ///            &lt;th width=&quot;100&quot;&gt;
        ///                Tấn công:
        ///            &lt;/th&gt;
        ///            &lt;th&gt;
        ///                &lt;a href=&apos;user_info.aspx?player=$attacker_id$&apos;&gt;$attacker_name$&lt;/a&gt;
        ///            &lt;/th&gt;
        ///        &lt;/tr&gt;
        ///        &lt;tr&gt;
        ///            &lt;td&gt;
        ///                Thành phố:
        ///            &lt;/td&gt;
        ///            &lt;td&gt;
        ///                &lt;a href [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Attack {
            get {
                return ResourceManager.GetString("Attack", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;a href=&apos;user_info.aspx?player=$inviter_id$&apos;&gt;$inviter_name$&lt;/a&gt; mời bạn gia nhập bang hội &lt;a href=&apos;group_info.aspx?group=$tribe_id$&apos;&gt;$group_name$&lt;/a&gt;
        ///&lt;br /&gt;&lt;br /&gt;
        ///&lt;a href=&apos;untribe.aspx&apos;&gt;Xem thư mời&lt;/a&gt;.
        /// </summary>
        internal static string Invite {
            get {
                return ResourceManager.GetString("Invite", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;table width=&quot;100%&quot;&gt;
        ///    &lt;tbody&gt;
        ///        &lt;tr&gt;
        ///            &lt;th width=&quot;60&quot;&gt;
        ///                from:
        ///            &lt;/th&gt;
        ///            &lt;th&gt;
        ///                &lt;a href=&quot;user_info.aspx?player=$from_id$&quot;&gt;$from_name$&lt;/a&gt;
        ///            &lt;/th&gt;
        ///        &lt;/tr&gt;
        ///        &lt;tr&gt;
        ///            &lt;td&gt;
        ///                Village:
        ///            &lt;/td&gt;
        ///            &lt;td&gt;
        ///                &lt;a href=&apos;village_info.aspx?village=$from_village_id$&apos;&gt;$from_village_name$ ($from_village_x$|$from_village_y$)&lt;/a&gt;
        ///            &lt;/td&gt;
        ///        &lt;/tr&gt;
        ///      [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ResourceReceive {
            get {
                return ResourceManager.GetString("ResourceReceive", resourceCulture);
            }
        }
    }
}