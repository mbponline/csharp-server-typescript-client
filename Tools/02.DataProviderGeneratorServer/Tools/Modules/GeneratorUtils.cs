using System.Collections.Generic;
using System.Linq;
using Tools.Modules.Common;
using MetadataSrv = Tools.Modules.Common.MetadataSrv;

namespace Tools.Modules
{

    internal static class GeneratorUtils
    {

        public static void WriteProperties(BlockWriter br, Dictionary<string, MetadataSrv.Property> properties, Dictionary<string, string> dbTypeConvert)
        {
            foreach (var property in properties)
            {
                var nullable = property.Value.Nullable ? "?" : string.Empty;
                var type = dbTypeConvert[property.Value.Type];
                nullable = (new string[] { "string", "object", "byte[]" }).Contains(type) ? string.Empty : nullable;
                br.WriteLine(string.Format("public {0}{1} {2} {{ get {{ return ({0}{1})this.entity.dto[\"{2}\"]; }} set {{ this.entity.dto[\"{2}\"] = value; }} }}", type, nullable, property.Key));
            }
            br.WriteLine();
        }

        public static void WriteNavigationProperties(BlockWriter br, string entityTypeName, Dictionary<string, MetadataSrv.NavigationProperty> navigationProperties)
        {
            foreach (var navigationProperty in navigationProperties)
            {
                var anp = navigationProperty.Value;
                var multi = anp.Multiplicity == "multi";
                var returnType = multi ? string.Format("IEnumerable<{0}>", anp.EntityTypeName) : anp.EntityTypeName;
                var navigationType = multi ? "Multi" : "Single";

                br.WriteLine("[JsonIgnore]");
                if (multi)
                {
                    br.WriteLine(string.Format("public {0} {1} {{ get {{ return this.entity.Navigate{2}<{3}>(\"{4}\", \"{1}\"); }} }}", returnType, navigationProperty.Key, navigationType, anp.EntityTypeName, entityTypeName));
                }
                else
                {
                    br.WriteLine(string.Format("public {0} {1} {{ get {{ return this.entity.Navigate{2}<{0}>(\"{4}\", \"{1}\"); }} }}", returnType, navigationProperty.Key, navigationType, anp.EntityTypeName, entityTypeName));
                }
            }
            br.WriteLine();
        }
    }

}