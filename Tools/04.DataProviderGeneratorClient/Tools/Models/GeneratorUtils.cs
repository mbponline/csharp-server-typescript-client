using CodeGenerator.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tools.Models
{

    internal static class GeneratorUtils
    {
        public static void WriteRules(BlockWriter br, Property entityTypeProperty, Metadata metadata)
        {
            if (!entityTypeProperty.Nullable)
            {
                br.WriteLine("required: true,");
            }

            switch (metadata.Database.Dialect)
            {
                case "MSSQL":
                    switch (entityTypeProperty.Type)
                    {
                        case "int":
                        case "smallint":
                        case "real":
                            br.WriteLine("number: true,");
                            break;
                        case "nvarchar":
                        case "text":
                            br.WriteLine("maxLength: " + entityTypeProperty.MaxLength + ",");
                            break;
                        case "bit":
                            break;
                        case "datetime":
                            br.WriteLine("date: true,");
                            break;
                        default:
                            throw new ArgumentException("Unknown data type.");
                    }

                    break;
                case "MYSQL":
                    switch (entityTypeProperty.Type)
                    {
                        case "int":
                        case "smallint":
                        case "float":
                        case "decimal":
                        case "mediumint":
                        case "tinyint":
                        case "year":
                            br.WriteLine("number: true,");
                            break;
                        case "char":
                        case "varchar":
                        case "text":
                        case "longtext":
                        case "enum":
                        case "set":
                            br.WriteLine("maxLength: " + entityTypeProperty.MaxLength + ",");
                            break;
                        case "bit":
                            break;
                        case "datetime":
                        case "timestamp":
                            br.WriteLine("date: true,");
                            break;
                        case "geometry":
                        case "blob":
                            break;
                        default:
                            throw new ArgumentException("Unknown data type.");
                    }
                    break;
                default:
                    break;
            }
        }

        public static string GetFunctionParamList(Operation fc, Dictionary<string, string> opTypeConvert)
        {
            var result = fc.Parameters.Select((it) => string.Format("{0}: {1}", it.Name, opTypeConvert[it.Type])).ToList();
            if (fc.ReturnType.IsEntity && fc.ReturnType.IsCollection)
            {
                result.Add("queryObject: IQueryObject");
            }
            return string.Join(", ", result);
        }

        public static string GetActionParamList(Operation ac, Dictionary<string, string> opTypeConvert)
        {
            var result = ac.Parameters.Select((it) => string.Format("{0}: {1}", it.Name, opTypeConvert[it.Type]));
            return string.Join(", ", result);
        }

        public static string GetParamResult(ReturnType returnTypeParam, Dictionary<string, string> opTypeConvert)
        {
            if (returnTypeParam == null)
            {
                return "void";
            }
            else if (returnTypeParam.IsEntity && returnTypeParam.IsCollection)
            {
                return string.Format("IResult<{0}>", returnTypeParam.Type);
            }
            else if (returnTypeParam.IsEntity && !returnTypeParam.IsCollection)
            {
                return returnTypeParam.Type;
            }
            else if (!returnTypeParam.IsEntity && returnTypeParam.IsCollection)
            {
                return string.Format("{0}[]", opTypeConvert[returnTypeParam.Type]);
            }
            else
            {
                return opTypeConvert[returnTypeParam.Type];
            }
        }
    }
}