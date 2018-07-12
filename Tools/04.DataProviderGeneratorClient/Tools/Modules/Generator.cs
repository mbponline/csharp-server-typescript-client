using CodeGenerator.Modules.Common;
using System.Collections.Generic;
using System.Linq;

namespace Tools.Modules
{
    internal static class Generator
    {
        public static string Generate(Metadata metadata, OperationsDefinition operationsDefinition)
        {
            metadata.Functions = operationsDefinition.Functions;
            metadata.Actions = operationsDefinition.Actions;

            var entityTypes = metadata.EntityTypes.ToList();

            var function = metadata.Functions != null ? metadata.Functions : Enumerable.Empty<Operation>();
            var action = metadata.Actions != null ? metadata.Actions : Enumerable.Empty<Operation>();

            Dictionary<string, string> dbTypeConvert = null;

            switch (metadata.Database.Dialect)
            {
                case "MSSQL":
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
                case "MYSQL":
                    dbTypeConvert = new Dictionary<string, string>()
                        {
                            { "int", "number" },
                            { "smallint", "number" },
                            { "float", "number" },
                            { "decimal", "number" },
                            { "mediumint", "number" },
                            { "tinyint",  "number" },
                            { "datetime", "Date" },
                            { "timestamp", "Date" },
                            { "bit",  "boolean" },
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
                default:
                    break;
            }

            var opTypeConvert = new Dictionary<string, string>()
                        {
                            { "int", "number" },
                            { "DateTime", "Date" },
                            { "string", "string" },
                            { "bool", "boolean" }
                        };

            var br = new BlockWriter();

            br.WriteLine()
                .WriteLine("//------------------------------------------------------------------------------")
                .WriteLine("//    This code was auto-generated.")
                .WriteLine("//")
                .WriteLine("//    Manual changes to this file may cause unexpected behavior in your application.")
                .WriteLine("//    Manual changes to this file will be overwritten if the code is regenerated.")
                .WriteLine("//------------------------------------------------------------------------------")
                .WriteLine();

            br.BeginBlock("module dataProvider {")
                .WriteLine();

            // IServiceFunctions
            br.BeginBlock("export interface IServiceFunctions {");
            foreach (var fc in function)
            {
                br.WriteLine(fc.Name + "?: (" + GeneratorUtils.GetFunctionParamList(fc, opTypeConvert) + ")" + " => JQueryDeferred<" + GeneratorUtils.GetParamResult(fc.ReturnType, opTypeConvert) + ">;");
            }
            br.EndBlock();

            // IServiceActions
            br.BeginBlock("export interface IServiceActions {");
            foreach (var ac in action)
            {
                br.WriteLine(ac.Name + "?: (" + GeneratorUtils.GetActionParamList(ac, opTypeConvert) + ")" + " => JQueryDeferred<" + GeneratorUtils.GetParamResult(ac.ReturnType, opTypeConvert) + ">;");
            }
            br.EndBlock();

            // ILocalViews
            br.BeginBlock("export interface ILocalViews {");
            foreach (var entityType in entityTypes)
            {
                br.WriteLine(string.Format("{0}?: IDataViewLocal<{1}>;", entityType.Value.EntitySetName, entityType.Key));
            }
            br.EndBlock();

            // IRemoteViews
            br.BeginBlock("export interface IRemoteViews {");
            foreach (var entityType in entityTypes)
            {
                br.WriteLine(string.Format("{0}?: IDataViewRemote<{1}>;", entityType.Value.EntitySetName, entityType.Key));
            }
            br.EndBlock();

            // entityTypes
            br.BeginBlock("export var entityTypes = {");
            foreach (var entityType in entityTypes)
            {
                br.WriteLine(string.Format("{0}: \"{0}\",", entityType.Key));
            }
            br.EndBlock();

            // rules
            br.BeginBlock("export var rules = {");
            foreach (var entityType in entityTypes)
            {
                var properties = entityType.Value.Properties;
                br.BeginBlock(entityType.Key + ": {");
                foreach (var property in properties)
                {
                    br.BeginBlock(property.Key + ": {");
                    GeneratorUtils.WriteRules(br, property.Value, metadata);
                    br.EndBlock("},", false);
                }
                br.EndBlock("},", false);
            }
            br.EndBlock();

            // Entities
            foreach (var entityType in entityTypes)
            {
                // with constructor generator
                br.BeginBlock("export interface " + entityType.Key + " {");

                var etp = entityType.Value.Properties;
                foreach (var property in etp)
                {
                    br.WriteLine(property.Key + ": " + dbTypeConvert[property.Value.Type] + ";");
                }
                br.WriteLine();

                // navigation properties for intellisense
                NavigationProperty anp;
                var navigationProperties = entityType.Value.NavigationProperties;
                foreach (var navigationProperty in navigationProperties)
                {
                    anp = navigationProperty.Value;
                    br.WriteLine(navigationProperty.Key + ": " + anp.EntityTypeName + (anp.Multiplicity == "multi" ? "[]" : "") + ";");
                }

                br.EndBlock();
            }
            br.EndBlock();

            br.WriteLine("export = dataProvider;");

            return br.ToString();
        }
    }

}
