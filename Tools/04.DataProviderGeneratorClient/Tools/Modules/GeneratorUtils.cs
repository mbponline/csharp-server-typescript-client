using System;
using System.Linq;
using Tools.Modules.Common;

namespace Tools.Modules
{

    internal static class GeneratorUtils
    {
        public static void WriteRules(BlockWriter br, Property entityTypeProperty, Metadata metadata)
        {
            if (!entityTypeProperty.Nullable)
            {
                br.WriteLine("required: true,");
            }

            switch (entityTypeProperty.Type)
            {
                case "number":
                    br.WriteLine("number: true,");
                    break;
                case "string":
                    br.WriteLine("maxLength: " + entityTypeProperty.MaxLength + ",");
                    break;
                case "boolean":
                    break;
                case "Date":
                    br.WriteLine("date: true,");
                    break;
                case "any":
                case "any[]":
                    break;
                default:
                    throw new ArgumentException("Unknown data type.");
            }
        }

        public static string GetFunctionParamList(Operation fc)
        {
            var result = fc.Parameters.Select((it) => string.Format("{0}: {1}", it.Name, it.Type)).ToList();
            if (fc.ReturnType.IsEntity && fc.ReturnType.IsCollection)
            {
                result.Add("queryObject: IQueryObject");
            }
            return string.Join(", ", result);
        }

        public static string GetActionParamList(Operation ac)
        {
            var result = ac.Parameters.Select((it) => string.Format("{0}: {1}", it.Name, it.Type));
            return string.Join(", ", result);
        }

        public static string GetParamResult(ReturnType returnTypeParam)
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
                return string.Format("{0}[]", returnTypeParam.Type);
            }
            else
            {
                return returnTypeParam.Type;
            }
        }
    }
}