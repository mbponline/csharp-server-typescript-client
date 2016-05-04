using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Models.Utils.DAL.Common
{

    internal static class DataViewLocalDtoUtils
    {
        public static void FillResultSingleRelatedItems(string entityTypeName, ResultSingleSerialData destination, string[] expand, Metadata metadata)
        {
            if (destination.Item != null)
            {
                var result = new ResultSerialData()
                {
                    Items = new List<object>() { destination.Item },
                    EntityTypeName = entityTypeName,
                    TotalCount = 0,
                    RelatedItems = { }
                };
                FillResultRelatedItems(entityTypeName, result, expand, metadata);
                destination.RelatedItems = result.RelatedItems;
            }
        }

        public static void FillResultRelatedItems(string entityTypeName, ResultSerialData destination, string[] expand, Metadata metadata)
        {
            if (expand != null && expand.Length > 0 && destination.Items != null && destination.Items.Count() > 0)
            {
                var splitExpand = DataUtils.SplitExpand(expand, (el) => el);
                DataUtils.ForEachNavigation(splitExpand, (branch) =>
                {
                    var navs = DataUtils.BranchToNavigation(entityTypeName, branch, metadata);
                    var lastNav = navs[navs.Count - 1];
                    IEnumerable<object> rootItems;
                    if (branch.Count == 1)
                    {
                        rootItems = destination.Items;
                    }
                    else
                    {
                        var rootEntityName = navs[navs.Count - 2].EntityTypeName;
                        rootItems = destination.RelatedItems[rootEntityName];
                    }
                    var navProp = branch[branch.Count - 1];
                    var relatedEntityTypeName = lastNav.EntityTypeName;
                    var relatedEntityItems = new List<object>();
                    if (lastNav.Multiplicity == "multi")
                    {
                        foreach (var it in rootItems)
                        {
                            var value = (IEnumerable<object>)it.GetType().GetProperty(navProp).GetValue(it, null);
                            PushMultiIfNotThere(value, relatedEntityItems);
                        }
                    }
                    else
                    {
                        foreach (var it in rootItems)
                        {
                            var value = it.GetType().GetProperty(navProp).GetValue(it, null);
                            PushSingleIfNotThere(value, relatedEntityItems);
                        }
                    }
                    destination.AddRelatedItems(relatedEntityTypeName, relatedEntityItems);
                });
            }
        }

        public static void AddRelatedItems(this ResultSerialData resultSerial, string entityTypeName, IEnumerable<object> items)
        {
            if (resultSerial.RelatedItems == null)
            {
                resultSerial.RelatedItems = new Dictionary<string, IEnumerable<object>>();
            }
            if (!resultSerial.RelatedItems.ContainsKey(entityTypeName))
            {
                resultSerial.RelatedItems[entityTypeName] = items;
            }
            else
            {
                throw new ArgumentException(string.Format("RelatedItems have already been populated for {0}", entityTypeName));
                //var existingItems = resultSerial.RelatedItems[entityTypeName].ToList();
                //existingItems.AddRange(items);
                //resultSerial.RelatedItems[entityTypeName] = existingItems;
            }
        }

        public static void PushSingleIfNotThere(object item, List<object> destination)
        {
            if (!destination.Contains(item))
            {
                destination.Add(item);
            }
        }

        public static void PushMultiIfNotThere(IEnumerable<object> items, List<object> destination)
        {
            foreach (var item in items)
            {
                if (!destination.Contains(item))
                {
                    destination.Add(item);
                }
            }
        }
    }

}