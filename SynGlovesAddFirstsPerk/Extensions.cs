using Mutagen.Bethesda.Plugins;

namespace SynGlovesAddFirstsPerk
{
    internal static class Extensions
    {
        internal static void TryAdd(this Dictionary<string, List<MaterialFistsKeywordsData>> list, MaterialFistsKeywordsData data, string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return;

            if (list.ContainsKey(key))
            {
                list[key].Add(data);
            }
            else list.Add(key, new List<MaterialFistsKeywordsData>() { data });
        }
        internal static void TryAddTo(this MaterialFistsKeywordsData data, Dictionary<string, List<MaterialFistsKeywordsData>> list, bool isMaterial)
        {
            if (isMaterial && data.MaterialKeyword == null) list.TryAdd(data, data.MaterialKeywordEdidOptional!);
            if (!isMaterial && data.FistsKeyword == null) list.TryAdd(data, data.FistsKeywordEdidOptional!);
        }
    }
}
