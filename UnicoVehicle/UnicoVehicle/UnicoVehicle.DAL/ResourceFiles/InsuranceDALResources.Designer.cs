﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnicoVehicle.DAL.ResourceFiles {
    using System;
    using System.Reflection;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class InsuranceDALResources {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal InsuranceDALResources() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("UnicoVehicle.DAL.ResourceFiles.InsuranceDALResources", typeof(InsuranceDALResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string GetInsuranceCompany {
            get {
                return ResourceManager.GetString("GetInsuranceCompany", resourceCulture);
            }
        }
        
        internal static string GetInsuranceCompanybyId {
            get {
                return ResourceManager.GetString("GetInsuranceCompanybyId", resourceCulture);
            }
        }
        
        internal static string InsertInsuranceCompany {
            get {
                return ResourceManager.GetString("InsertInsuranceCompany", resourceCulture);
            }
        }
        
        internal static string DeleteInsuranceCompany {
            get {
                return ResourceManager.GetString("DeleteInsuranceCompany", resourceCulture);
            }
        }
        
        internal static string UpdateInsuranceCompany {
            get {
                return ResourceManager.GetString("UpdateInsuranceCompany", resourceCulture);
            }
        }
        
        internal static string GetInsuranceType {
            get {
                return ResourceManager.GetString("GetInsuranceType", resourceCulture);
            }
        }
        
        internal static string GetInsuranceTypebyId {
            get {
                return ResourceManager.GetString("GetInsuranceTypebyId", resourceCulture);
            }
        }
        
        internal static string InsertInsuranceType {
            get {
                return ResourceManager.GetString("InsertInsuranceType", resourceCulture);
            }
        }
        
        internal static string DeleteInsuranceType {
            get {
                return ResourceManager.GetString("DeleteInsuranceType", resourceCulture);
            }
        }
        
        internal static string UpdateInsuranceType {
            get {
                return ResourceManager.GetString("UpdateInsuranceType", resourceCulture);
            }
        }
        
        internal static string GetInsuranceTypebyCompany {
            get {
                return ResourceManager.GetString("GetInsuranceTypebyCompany", resourceCulture);
            }
        }
    }
}
