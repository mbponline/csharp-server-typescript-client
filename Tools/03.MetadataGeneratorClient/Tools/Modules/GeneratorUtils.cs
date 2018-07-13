using System;
using System.Collections.Generic;
using System.Linq;
using Tools.Modules.Common;

namespace Tools.Modules
{

    public static class GeneratorUtils
    {
        public static string Singularize(this string tableName)
        {
            if (tableName.Substring(tableName.Length - 1) == "s")
            {
                if (tableName.Substring(tableName.Length - 2) == "ss")
                {
                    return tableName;
                }

                return tableName.Remove(tableName.Length - 1);
            }

            return tableName;
        }

        public static string Pluralize(this string tableName)
        {
            var lastCharacter = tableName.Substring(tableName.Length - 1);
            if (lastCharacter == "y")
            {
                return tableName.Substring(0, tableName.Length - 1) + "ies";
            }
            else if (lastCharacter == "s")
            {
                if (tableName.Substring(tableName.Length - 2) == "ss")
                {
                    return tableName + "es";
                }
                return tableName;
            }
            else if (lastCharacter == "o")
            {
                return tableName + "es";
            }
            else
            {
                return tableName + "s";
            }
        }

        public static string GetNavigationPropertyName(this Dictionary<string, NavigationProperty> navigationProperties, string proposedName)
        {
            var result = proposedName;

            if (navigationProperties.ContainsKey(proposedName))
            {
                var last = proposedName.Substring(proposedName.Length - 1);
                int n;
                var isNumeric = int.TryParse(last, out n);
                if (isNumeric)
                {
                    result = proposedName.Substring(0, proposedName.Length - 1) + (n + 1).ToString();
                }
                else
                {
                    result = proposedName + "1";
                }
                result = navigationProperties.GetNavigationPropertyName(result);
            }

            return result;
        }

        public static void CreateRelation(this Dictionary<string, EntityType> entityTypes, string entityTypeNameLocal, string entityTypeNameRemote, List<string> keyRemote)
        {
            var entityTypeLocal = entityTypes[entityTypeNameLocal];
            var navigationPropertyLocal = new NavigationProperty()
            {
                EntityTypeName = entityTypeNameRemote,
                Multiplicity = "multi",
                KeyLocal = entityTypeLocal.Key,
                KeyRemote = keyRemote
            };
            var navigationPropertyNameLocal = entityTypeLocal.NavigationProperties.GetNavigationPropertyName(entityTypeNameRemote.Singularize().Pluralize());
            entityTypeLocal.NavigationProperties.Add(navigationPropertyNameLocal, navigationPropertyLocal);

            var entityTypeRemote = entityTypes[entityTypeNameRemote];
            foreach (var kr in keyRemote)
            {
                if (!entityTypeRemote.Properties.ContainsKey(kr))
                {
                    throw new ArgumentException("Could not find coresponding navigation property");
                }
            }
            var navigationPropertyRemote = new NavigationProperty()
            {
                EntityTypeName = entityTypeNameLocal,
                Multiplicity = "single",
                KeyLocal = keyRemote,
                KeyRemote = entityTypeLocal.Key
            };
            var navigationPropertyNameRemote = entityTypeRemote.NavigationProperties.GetNavigationPropertyName(entityTypeNameLocal.Singularize());
            entityTypeRemote.NavigationProperties.Add(navigationPropertyNameRemote, navigationPropertyRemote);

            AddAnnotation(entityTypeLocal, navigationPropertyNameLocal, entityTypeRemote, navigationPropertyNameRemote);
        }

        public static void AddAnnotation(EntityType entityTypeLocal, string navigationPropertyNameLocal, EntityType entityTypeRemote, string navigationPropertyNameRemote)
        {
            var navigationPropertyLocal = entityTypeLocal.NavigationProperties[navigationPropertyNameLocal];
            var navigationPropertyRemote = entityTypeRemote.NavigationProperties[navigationPropertyNameRemote];

            if (!(navigationPropertyLocal.KeyLocal.SequenceEqual(navigationPropertyRemote.KeyRemote) && navigationPropertyLocal.KeyRemote.SequenceEqual(navigationPropertyRemote.KeyLocal)))
            {
                throw new ArgumentException("The two navigation properties are not pairs");
            }

            var idGroupLocal = (entityTypeLocal.Annotations != null && entityTypeLocal.Annotations.ContainsKey("IdGroup")) ? (int)entityTypeLocal.Annotations["IdGroup"] : default(int?);
            var idGroupRemote = (entityTypeRemote.Annotations != null && entityTypeRemote.Annotations.ContainsKey("IdGroup")) ? (int)entityTypeRemote.Annotations["IdGroup"] : default(int?);

            if (idGroupLocal != null || idGroupRemote != null)
            {
                if (idGroupLocal != idGroupRemote)
                {
                    if (idGroupLocal != null)
                    {
                        if (navigationPropertyRemote.Annotations == null)
                        {
                            navigationPropertyRemote.Annotations = new Dictionary<string, object>();
                        }
                        if (entityTypeLocal.Annotations.ContainsKey("IsVirtual"))
                        {
                            navigationPropertyRemote.Annotations.Add("IsVirtual", entityTypeLocal.Annotations["IsVirtual"]);
                        }
                        navigationPropertyRemote.Annotations.Add("IdGroup", idGroupLocal);
                    }

                    if (idGroupRemote != null)
                    {
                        if (navigationPropertyLocal.Annotations == null)
                        {
                            navigationPropertyLocal.Annotations = new Dictionary<string, object>();
                        }
                        if (entityTypeRemote.Annotations.ContainsKey("IsVirtual"))
                        {
                            navigationPropertyLocal.Annotations.Add("IsVirtual", entityTypeRemote.Annotations["IsVirtual"]);
                        }
                        navigationPropertyLocal.Annotations.Add("IdGroup", idGroupRemote);
                    }
                }
            }
        }

        public static void RemoveEntityType(this Dictionary<string, EntityType> entityTypes, string entityTypeName)
        {
            var entityType = entityTypes[entityTypeName];

            foreach (var np in entityType.NavigationProperties)
            {
                var navigationPropertyName = np.Key;
                var navigationProperty = np.Value;

                var otherEntityType = entityTypes[navigationProperty.EntityTypeName];
                var otherNavigationPropertyName = (from t in otherEntityType.NavigationProperties
                                                   where t.Value.EntityTypeName == entityTypeName && t.Value.KeyLocal.SequenceEqual(navigationProperty.KeyRemote) && t.Value.KeyRemote.SequenceEqual(navigationProperty.KeyLocal)
                                                   select t.Key).FirstOrDefault();

                if (!string.IsNullOrEmpty(otherNavigationPropertyName))
                {
                    otherEntityType.NavigationProperties.Remove(otherNavigationPropertyName);
                }
                else
                {
                    throw new Exception("Could not find coresponding navigation property");
                }
            }

            entityTypes.Remove(entityTypeName);
        }

        public static void ConvertPropertyTypes(this Dictionary<string, EntityType> entityTypes, Dictionary<string, string> typeConvert)
        {
            foreach (var item in entityTypes)
            {
                var entityTypeName = item.Key;
                var entityType = item.Value;
                foreach (var prop in entityType.Properties)
                {
                    prop.Value.Type = typeConvert[prop.Value.Type];
                }
            }
        }

        public static void ConvertOperationType(this Operation[] operations, Dictionary<string, string> typeConvert)
        {
            foreach (var operation in operations)
            {
                foreach (var parameter in operation.Parameters)
                {
                    parameter.Type = typeConvert[parameter.Type];
                }
                if (operation.ReturnType != null && !operation.ReturnType.IsEntity)
                {
                    operation.ReturnType.Type = typeConvert[operation.ReturnType.Type];
                }
            }
        }

        public static void AddAnnotation(this EntityType entityType, string key, object value)
        {
            if (entityType.Annotations == null)
            {
                entityType.Annotations = new Dictionary<string, object>();
            }
            entityType.Annotations.Add(key, value);
        }

    }

}
