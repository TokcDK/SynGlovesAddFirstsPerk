using Mutagen.Bethesda.Plugins;

namespace SynGlovesAddFirstsPerk
{
    internal static class Extensions
    {
        internal static void TryAdd(this Dictionary<ModKey, Dictionary<string, List<MaterialFistsKeywordsData>>> list, MaterialFistsKeywordsData data, string key)
        {
            var modData = list.ContainsKey(key) ? list[key] : new Dictionary<string, List<MaterialFistsKeywordsData>>();

            if (string.IsNullOrWhiteSpace(key)) return;

            if (modData.ContainsKey(key))
            {
                var dataList = modData[key];
                if (!dataList.Contains(data)) dataList.Add(data);
            }
            else modData.Add(key, new List<MaterialFistsKeywordsData>() { data });
        }
        internal static void TryAdd(this Dictionary<string, List<MaterialFistsKeywordsData>> list, MaterialFistsKeywordsData data, string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return;

            if (list.ContainsKey(key))
            {
                list[key].Add(data);
            }
            else list.Add(key, new List<MaterialFistsKeywordsData>() { data });
        }
        internal static void TryAddTo(this MaterialFistsKeywordsData data, Dictionary<string, List<MaterialFistsKeywordsData>> list, Dictionary<ModKey, Dictionary<string, List<MaterialFistsKeywordsData>>> modSpecificList, bool isMaterial)
        {
            if (isMaterial && data.MaterialKeyword == null) if (data.MaterialKeywordStringOptional.ModToSearchOptional != default) modSpecificList.TryAdd(data, data.MaterialKeywordStringOptional.KeywordString!); else list.TryAdd(data, data.MaterialKeywordStringOptional.KeywordString!);
            //Console.WriteLine($"data.FistsKeyword={data.FistsKeyword}");
            if (!isMaterial && data.FistsKeyword == null)
            {
                //Console.WriteLine($"1");
                //Console.WriteLine($"data.MaterialKeywordStringOptional.ModToSearchOptional={data.MaterialKeywordStringOptional.ModToSearchOptional}");
                if (data.MaterialKeywordStringOptional.ModToSearchOptional != ModKey.Null)
                {
                    //Console.WriteLine($"---");
                    modSpecificList.TryAdd(data, data.FistsKeywordStringOptional.KeywordString!);
                }
                else
                {
                    //Console.WriteLine($"2");
                    list.TryAdd(data, data.FistsKeywordStringOptional.KeywordString!);
                }
            }
        }
    }
}
