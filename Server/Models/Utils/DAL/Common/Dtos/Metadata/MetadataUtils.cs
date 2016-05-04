using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

namespace Server.Models.Utils.DAL.Common
{
    public static class MetadataUtils
    {
        public static Metadata Deserialize(string metadataFileName)
        {
            Metadata metadata;

            var path = HostingEnvironment.MapPath(string.Format(@"~/App_Data/{0}.json", metadataFileName));

            // read json file
            using (StreamReader r = new StreamReader(path))
            {
                var jsonText = r.ReadToEnd();
                metadata = JsonConvert.DeserializeObject<Metadata>(jsonText);
            }
            metadata.Functions = OperationsDefinition.Functions;
            metadata.Actions = OperationsDefinition.Actions;

            return metadata;
        }

        public static Metadata ToMetadataClient(this Metadata metadata)
        {
            Dictionary<string, string> dbTypeConvert = null;

            switch (metadata.Dialect())
            {
                case Dialect.SQL2012:
                case Dialect.SQL2014:
                    dbTypeConvert = new Dictionary<string, string>()
                        {
                            { "int", "number" },
                            { "smallint", "number" },
                            { "real", "number" },
                            { "datetime", "Date" },
                            { "nvarchar", "string" },
                            { "text", "string" },
                            { "bit", "boolean" }
                        };
                    break;
                case Dialect.MYSQL:
                    dbTypeConvert = new Dictionary<string, string>()
                        {
                            { "int", "number" },
                            { "smallint", "number" },
                            { "float", "number" },
                            { "decimal", "number" },
                            { "mediumint", "number" },
                            { "tinyint", "number" },
                            { "datetime", "Date" },
                            { "timestamp", "Date" },
                            { "bit", "boolean" },
                            { "char", "string" },
                            { "varchar", "string" },
                            { "text", "string" },
                            { "longtext", "string" },
                            { "enum", "string" },
                            { "set", "string" },
                            { "geometry", "any" },
                            { "year", "number" },
                            { "blob", "any" },
                        };
                    break;
            }

            var opTypeConvert = new Dictionary<string, string>()
                        {
                            { "int", "number" },
                            { "DateTime", "Date" },
                            { "string", "string" },
                            { "bool", "boolean" }
                        };

            // clone metadata
            var metadataClient = JObject.FromObject(metadata).ToObject<Metadata>();

            //metadataClient.TinyintAsBoolean = tinyintAsBoolean;

            foreach (var entityTypeName in metadataClient.EntityTypes)
            {
                var properties = metadataClient.EntityTypes[entityTypeName.Key].Properties;
                foreach (var property in properties)
                {
                    property.Value.Type = dbTypeConvert[property.Value.Type];
                }
            }

            foreach (var function in metadataClient.Functions)
            {
                ConvertOperationType(function, opTypeConvert);
            }

            foreach (var action in metadataClient.Actions)
            {
                ConvertOperationType(action, opTypeConvert);
            }

            return metadataClient;
        }

        private static void ConvertOperationType(Operation operation, Dictionary<string, string> opTypeConvert)
        {
            foreach (var parameter in operation.Parameters)
            {
                parameter.Type = opTypeConvert[parameter.Type];
            }
            if (operation.ReturnType != null && !operation.ReturnType.IsEntity)
            {
                operation.ReturnType.Type = opTypeConvert[operation.ReturnType.Type];
            }
        }

    }
}