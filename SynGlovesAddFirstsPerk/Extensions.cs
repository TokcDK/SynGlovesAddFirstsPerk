using Mutagen.Bethesda.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynGlovesAddFirstsPerk
{
    internal static class Extensions
    {
        internal static void TryAdd(this Dictionary<ModKey, Dictionary<string, List<MaterialFistsKeywordsData>>> list, MaterialFistsKeywordsData data)
        {
            var modData = list.ContainsKey(data.MaterialKeywordStringOptional.ModToSearchOptional) ? list[data.MaterialKeywordStringOptional.ModToSearchOptional] : new Dictionary<string, List<MaterialFistsKeywordsData>>();

            if (string.IsNullOrWhiteSpace(data.MaterialKeywordStringOptional.KeywordString)) return;

            if (modData.ContainsKey(data.MaterialKeywordStringOptional.KeywordString))
            {
                var dataList = modData[data.MaterialKeywordStringOptional.KeywordString];
                if (!dataList.Contains(data)) dataList.Add(data);
            }
            else modData.Add(data.MaterialKeywordStringOptional.KeywordString, new List<MaterialFistsKeywordsData>() { data });
        }
        internal static void TryAdd(this Dictionary<string, List<MaterialFistsKeywordsData>> list, MaterialFistsKeywordsData data)
        {
            if (string.IsNullOrWhiteSpace(data.MaterialKeywordStringOptional.KeywordString)) return;

            if (list.ContainsKey(data.MaterialKeywordStringOptional.KeywordString))
            {
                list[data.MaterialKeywordStringOptional.KeywordString].Add(data);
            }
            else list.Add(data.MaterialKeywordStringOptional.KeywordString, new List<MaterialFistsKeywordsData>() { data });
        }
        internal static void TryAddTo(this MaterialFistsKeywordsData data, Dictionary<string, List<MaterialFistsKeywordsData>> list, Dictionary<ModKey, Dictionary<string, List<MaterialFistsKeywordsData>>> modSpecificList, bool isMaterial)
        {
            if (isMaterial && data.MaterialKeyword == null) if (data.MaterialKeywordStringOptional.ModToSearchOptional != default) modSpecificList.TryAdd(data); else list.TryAdd(data);
            if (!isMaterial && data.FistsKeyword == null) if (data.MaterialKeywordStringOptional.ModToSearchOptional != default) modSpecificList.TryAdd(data); else list.TryAdd(data);
        }
    }
}
