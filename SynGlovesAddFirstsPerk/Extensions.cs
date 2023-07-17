using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;

namespace SynGlovesAddFirstsPerk
{
    internal static class Extensions
    {
        internal static void TryAdd(this Dictionary<string, List<MaterialFistsKeywordsData>> list, MaterialFistsKeywordsData data, string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return;

            key = key.ToLower();

            if (list.ContainsKey(key))
            {
                list[key].Add(data);
            }
            else list.Add(key, new List<MaterialFistsKeywordsData>() { data });
        }
        internal static void TryAddTo(this MaterialFistsKeywordsData data, Dictionary<string, List<MaterialFistsKeywordsData>> list, bool isMaterial)
        {
            if (isMaterial && (data.MaterialKeyword == default || data.MaterialKeyword.IsNull))
            {
                list.TryAdd(data, data.MaterialKeywordEdidOptional!);
            }                
            else if (!isMaterial && (data.FistsKeyword == default || data.FistsKeyword.IsNull))
            {
                list.TryAdd(data, data.FistsKeywordEdidOptional!);
            }
        }

        internal static void TryAddKeyWord(this Dictionary<string, List<MaterialFistsKeywordsData>> listToSearch, IKeywordGetter itemGetter, string keyWordEdid)
        {
            var list = listToSearch[keyWordEdid];
            for (int i = 0; i < list.Count; i++)
            {
                var d = list[i];
                if (d.FistsKeyword != null && !d.FistsKeyword.IsNull) continue;

                // set value and remove reference from search list
                d.FistsKeyword = itemGetter.FormKey;
                list.Remove(d);
            }

            // remove empty list reference
            if (list.Count == 0) listToSearch.Remove(keyWordEdid);
        }
    }
}
