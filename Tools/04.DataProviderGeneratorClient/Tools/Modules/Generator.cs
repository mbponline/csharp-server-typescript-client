using System.Linq;
using Tools.Modules.Common;
using MetadataCli = Tools.Modules.Common.MetadataCli;

namespace Tools.Modules
{
    internal static class Generator
    {
        public static string Generate(MetadataCli.Metadata metadataCli)
        {
            var entityTypes = metadataCli.EntityTypes.ToList();

            var function = metadataCli.Functions != null ? metadataCli.Functions : Enumerable.Empty<MetadataCli.Operation>();
            var action = metadataCli.Actions != null ? metadataCli.Actions : Enumerable.Empty<MetadataCli.Operation>();

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
                br.WriteLine(fc.Name + "?: (" + GeneratorUtils.GetFunctionParamList(fc) + ")" + " => JQueryDeferred<" + GeneratorUtils.GetParamResult(fc.ReturnType) + ">;");
            }
            br.EndBlock();

            // IServiceActions
            br.BeginBlock("export interface IServiceActions {");
            foreach (var ac in action)
            {
                br.WriteLine(ac.Name + "?: (" + GeneratorUtils.GetActionParamList(ac) + ")" + " => JQueryDeferred<" + GeneratorUtils.GetParamResult(ac.ReturnType) + ">;");
            }
            br.EndBlock();

            // ILocalViews
            br.BeginBlock("export interface ILocalViews {");
            foreach (var entityType in entityTypes)
            {
                br.WriteLine(string.Format("{0}?: IDataViewLocal<{1}>;", entityType.Value.EntitySetName, entityType.Key));
            }
            br.WriteLine("[propName: string]: any;");
            br.EndBlock();

            // IRemoteViews
            br.BeginBlock("export interface IRemoteViews {");
            foreach (var entityType in entityTypes)
            {
                br.WriteLine(string.Format("{0}?: IDataViewRemote<{1}>;", entityType.Value.EntitySetName, entityType.Key));
            }
            br.WriteLine("[propName: string]: any;");
            br.EndBlock();

            // entityTypes
            br.BeginBlock("export var entityTypes = {");
            foreach (var entityType in entityTypes)
            {
                br.WriteLine(string.Format("{0}: \"{0}\",", entityType.Key));
            }
            br.EndBlock();

            //// entitySets
            //br.BeginBlock("export var entitySets = {");
            //foreach (var entityType in entityTypes)
            //{
            //    br.WriteLine(string.Format("{0}: \"{1}\",", entityType.Key, entityType.Value.EntitySetName));
            //}
            //br.EndBlock();

            // rules
            br.BeginBlock("export var rules = {");
            foreach (var entityType in entityTypes)
            {
                var properties = entityType.Value.Properties;
                br.BeginBlock(entityType.Key + ": {");
                foreach (var property in properties)
                {
                    br.BeginBlock(property.Key + ": {");
                    GeneratorUtils.WriteRules(br, property.Value, metadataCli);
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
                    br.WriteLine(property.Key + ": " + property.Value.Type + ";");
                }
                br.WriteLine();

                // navigation properties for intellisense
                MetadataCli.NavigationProperty anp;
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
