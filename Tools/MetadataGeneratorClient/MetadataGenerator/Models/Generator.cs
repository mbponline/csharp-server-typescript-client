using CodeGenerator.Models.Common;
using System.Collections.Generic;
using System.Linq;

namespace MetadataGenerator.Models
{
    internal static class Generator
    {
        public static string GenerateModel(Metadata metadata, OperationsDefinition operationsDefinition)
        {
            metadata.Functions = operationsDefinition.Functions;
            metadata.Actions = operationsDefinition.Actions;

            var entityTypes = metadata.EntityTypes.ToList();

            var function = metadata.Functions != null ? metadata.Functions : Enumerable.Empty<Operation>();
            var action = metadata.Actions != null ? metadata.Actions : Enumerable.Empty<Operation>();

            Dictionary<string, string> dbType = null;

            switch (metadata.Database.Dialect)
            {
                case "MSSQL":
                    dbType = new Dictionary<string, string>()
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
                    dbType = new Dictionary<string, string>()
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

            var opType = new Dictionary<string, string>()
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

            br.WriteLine("import DataAdapter = require(\"./Common/Dtos/DataAdapter\");")
                .WriteLine("import DataViewRemote = require(\"./Common/Entities/DataViews/DataViewRemote\");")
                .WriteLine("import RemoteViewsBase = require(\"./Common/Entities/DataViews/RemoteViewsBase\");")
                .WriteLine("import DataViewLocal = require(\"./Common/Entities/DataViews/DataViewLocal\");")
                .WriteLine("import LocalViewsBase = require(\"./Common/Entities/DataViews/LocalViewsBase\");")
                .WriteLine("import DataContext = require(\"./Common/Entities/DataContext\");")
                .WriteLine("import DataServiceBase = require(\"./Common/Entities/DataServiceBase\");")
                .WriteLine();

            br.BeginBlock("module dataProvider {")
                .WriteLine();

            br.BeginBlock("export interface IServiceFunctions {");
            foreach (var fc in function)
            {
                br.WriteLine(fc.Name + "?: (" + GeneratorUtils.GetFunctionParamList(fc, opType) + ")" + " => JQueryDeferred<" + GeneratorUtils.GetParamResult(fc.ReturnType, opType) + ">;");
            }
            br.EndBlock();

            br.BeginBlock("export interface IServiceActions {");
            foreach (var ac in action)
            {
                br.WriteLine(ac.Name + "?: (" + GeneratorUtils.GetActionParamList(ac, opType) + ")" + " => JQueryDeferred<" + GeneratorUtils.GetParamResult(ac.ReturnType, opType) + ">;");
            }
            br.EndBlock();

            br.BeginBlock("export class LocalViews extends LocalViewsBase {")
                .WriteLine("constructor(dataContext: DataContext) { super(dataContext); }")
                .WriteLine();
            foreach (var entityType in entityTypes)
            {
                br.WriteLine(string.Format("get {0}() {{ return this.getPropertyValue<{1}>(\"{1}\"); }}", entityType.Value.EntitySetName, entityType.Key));
            }
            br.EndBlock();

            br.BeginBlock("export class RemoteViews extends RemoteViewsBase {")
                .WriteLine("constructor(dataAdapter: DataAdapter, dataContext: DataContext) { super(dataAdapter, dataContext); }")
                .WriteLine();
            foreach (var entityType in entityTypes)
            {
                br.WriteLine(string.Format("get {0}() {{ return this.getPropertyValue<{1}>(\"{1}\"); }}", entityType.Value.EntitySetName, entityType.Key));
            }
            br.EndBlock();

            br.BeginBlock("export class DataService extends DataServiceBase<LocalViews, RemoteViews, IServiceFunctions, IServiceActions> {");
            br.BeginBlock("constructor(metadata: metadataTypes.Metadata, baseUrl: string) {")
                .WriteLine("super(metadata, baseUrl);");
            br.BeginBlock("this.from = {")
                .WriteLine("local: new LocalViews(this.dataContext),")
                .WriteLine("remote: new RemoteViews(this.dataAdapter, this.dataContext),");
            br.EndBlock("};", false);
            br.EndBlock("}", false);
            br.EndBlock("}");

            br.BeginBlock("export var entityTypes = {");
            foreach (var entityType in entityTypes)
            {
                br.WriteLine(string.Format("{0}: '{0}',", entityType.Key));
            }
            br.EndBlock();

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

            foreach (var entityType in entityTypes)
            {
                // with constructor generator
                br.BeginBlock("export interface " + entityType.Key + " {");

                var etp = entityType.Value.Properties;
                foreach (var property in etp)
                {
                    br.WriteLine(property.Key + ": " + dbType[property.Value.Type] + ";");
                }
                br.WriteLine();

                // navigation properties for intellisense
                NavigationProperty anp;
                var etnp = entityType.Value.NavigationProperties;
                foreach (var navigationProperty in etnp)
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
