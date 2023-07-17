using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis;

namespace SynGlovesAddFirstsPerk
{
    public class Program
    {
        static Lazy<PatcherSettings> Settings = null!;

        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetAutogeneratedSettings("PatcherSettings", "settings.json", out Settings)
                .SetTypicalOpen(GameRelease.SkyrimLE, "SynGlovesAddFirstsPerk.esp")
                .Run(args);
        }

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            // fill data for keywords search
            var materialKeywordsSearch = new Dictionary<string, List<MaterialFistsKeywordsData>>();
            var fistsKeywordsSearch = new Dictionary<string, List<MaterialFistsKeywordsData>>();
            HashSet<MaterialFistsKeywordsData>? modMaterialFistsList = new(Settings.Value.ModMaterialFists);
            foreach (var data in modMaterialFistsList)
            {
                data.TryAddTo(materialKeywordsSearch, true);
                data.TryAddTo(fistsKeywordsSearch, false);
            }

            // search in settings keywords
            foreach (var data in modMaterialFistsList)
            {
                SearchKeyWordsInSettings(state.LinkCache, materialKeywordsSearch, data.MaterialKeyword);

                SearchKeyWordsInSettings(state.LinkCache, fistsKeywordsSearch, data.FistsKeyword);
            }

            // search for mod specific
            //foreach (var modGetter in state.LoadOrder)
            //{
            //    if (modGetter.Value == null) continue;
            //    if (modGetter.Value.Mod == null) continue;

            //    bool isSearchMaterial = ModSpecificMaterialKeywordsSearch.ContainsKey(modGetter.Value.ModKey);
            //    bool isSearchFists = ModSpecificFistsKeywordsSearch.ContainsKey(modGetter.Value.ModKey);
            //    if (isSearchMaterial || isSearchFists)
            //    {
            //        Dictionary<string, List<MaterialFistsKeywordsData>>? matList = isSearchMaterial ? ModSpecificMaterialKeywordsSearch[modGetter.Value.ModKey] : null;
            //        Dictionary<string, List<MaterialFistsKeywordsData>>? fList = isSearchFists ? ModSpecificFistsKeywordsSearch[modGetter.Value.ModKey] : null;
            //        foreach (var keyWordGetter in modGetter.Value.Mod.Keywords)
            //        {
            //            if (string.IsNullOrWhiteSpace(keyWordGetter.EditorID)) continue;

            //            if (isSearchMaterial && matList!.ContainsKey(keyWordGetter.EditorID))
            //            {
            //                var list = matList[keyWordGetter.EditorID];
            //                for (int i = 0; i < list.Count; i++)
            //                {
            //                    var d = list[i];
            //                    if (d.MaterialKeyword != null) continue;

            //                    // set value and remove reference from search list
            //                    d.MaterialKeyword = keyWordGetter.FormKey;
            //                    list.Remove(d);
            //                }

            //                // remove empty list reference
            //                if (list.Count == 0) matList.Remove(keyWordGetter.EditorID);
            //            }
            //            if (isSearchFists && fList!.ContainsKey(keyWordGetter.EditorID))
            //            {
            //                var list = fList[keyWordGetter.EditorID];
            //                for (int i = 0; i < list.Count; i++)
            //                {
            //                    var d = list[i];
            //                    if (d.MaterialKeyword != null) continue;

            //                    // set value and remove reference from search list
            //                    d.MaterialKeyword = keyWordGetter.FormKey;
            //                    list.Remove(d);
            //                }

            //                // remove empty list reference
            //                if (list.Count == 0) fList.Remove(keyWordGetter.EditorID);
            //            }
            //        }
            //    }
            //}

            // search keywords in all
            bool isMatSearch = materialKeywordsSearch.Any(d => d.Value.Any(v => (v.MaterialKeyword == default || v.MaterialKeyword.IsNull)));
            bool isFSearch = fistsKeywordsSearch.Any(d => d.Value.Any(v => (v.FistsKeyword == null || v.FistsKeyword.IsNull)));

            if (isMatSearch || isFSearch)
            {
                SearchKeywordsByEdId(state.LoadOrder.PriorityOrder
                    , isMatSearch, materialKeywordsSearch
                    , isFSearch, fistsKeywordsSearch);
            }

            // get valid list
            var modMaterialFistsListResult = GetValidList(modMaterialFistsList);

            HashSet<FormLink<IKeywordGetter>> fistsKeywords = new();
            foreach (var d in modMaterialFistsListResult!) foreach (var v in d.Value) if (!fistsKeywords.Contains(v.FistsKeyword!)) fistsKeywords.Add(v.FistsKeyword!);

            int patchedCount = 0;
            foreach (var itemGetter in state.LoadOrder.PriorityOrder.Armor().WinningOverrides())
            {
                // skip invalid
                if (itemGetter.IsDeleted) continue;
                if (itemGetter.MajorFlags.HasFlag(Armor.MajorFlag.NonPlayable)) continue;
                if (itemGetter.MajorFlags.HasFlag(Armor.MajorFlag.Shield)) continue;
                if (itemGetter.BodyTemplate == null) continue;
                if (itemGetter.BodyTemplate.Flags.HasFlag(BodyTemplate.Flag.NonPlayable)) continue;
                if (itemGetter.BodyTemplate.ArmorType == ArmorType.Clothing) continue; // maybe try to parse this variant later?
                if (!itemGetter.BodyTemplate.FirstPersonFlags.HasFlag(BipedObjectFlag.Hands)) continue; // maybe try to parse this variant later?
                if (itemGetter.Keywords == null || itemGetter.Keywords.Count == 0) continue;

                // find material keyword
                FormLink<IKeywordGetter>? foundFormLink = null;
                bool found = false;
                bool alreadyHaveOneOfFistsKeyword = false;
                foreach (var keyword in itemGetter.Keywords) // iterati in order from stronger to weaker
                {
                    if (fistsKeywords.Contains(keyword))
                    {
                        alreadyHaveOneOfFistsKeyword = true;
                        break;
                    }
                    if (!found && modMaterialFistsListResult.ContainsKey(keyword.FormKey))
                    {
                        found = true;
                        var l = modMaterialFistsListResult[keyword.FormKey];
                        foreach (var d in l)
                        {
                            if (d.ArmorTypeToSetFor == -1 || (int)itemGetter.BodyTemplate.ArmorType != d.ArmorTypeToSetFor) continue;

                            foundFormLink = d.FistsKeyword;
                            break;
                        }
                    }
                }

                // skip if not found or fists keyword already exists
                if (alreadyHaveOneOfFistsKeyword || foundFormLink == null || foundFormLink.IsNull || foundFormLink.FormKey == default) continue;

                // add missing fists keyword
                patchedCount++;
                var itemToPatch = state.PatchMod.Armors.GetOrAddAsOverride(itemGetter);
                itemToPatch.Keywords!.Add(foundFormLink); // add fists keyword for the materia
            }

            Console.WriteLine($"Patched {patchedCount} records");
        }

        private static Dictionary<FormLink<IKeywordGetter>, List<MaterialFistsKeywordsData>>? GetValidList(HashSet<MaterialFistsKeywordsData> modMaterialFistsList)
        {
            Dictionary<FormLink<IKeywordGetter>, List<MaterialFistsKeywordsData>>? modMaterialFistsListResult = new();
            foreach (var data in modMaterialFistsList)
            {
                if (data.MaterialKeyword == null || data.MaterialKeyword.IsNull || data.FistsKeyword == null || data.FistsKeyword.IsNull) continue;

                if (modMaterialFistsListResult.ContainsKey(data.MaterialKeyword))
                    modMaterialFistsListResult[data.MaterialKeyword].Add(data);
                else
                    modMaterialFistsListResult.Add(data.MaterialKeyword, new List<MaterialFistsKeywordsData>() { data });
            }
            // order by priority
            List<FormLink<IKeywordGetter>> keys = new(modMaterialFistsListResult.Keys);
            foreach (var key in keys)
            {
                var list = modMaterialFistsListResult[key];
                list = list.OrderByDescending(d => d.Priority).ToList();
            }
            return modMaterialFistsListResult.OrderByDescending(d => d.Value[0].Priority).ToDictionary(k => k.Key, v => v.Value);
        }

        private static void SearchKeyWordsInSettings(Mutagen.Bethesda.Plugins.Cache.ILinkCache<ISkyrimMod, ISkyrimModGetter> linkCache, Dictionary<string, List<MaterialFistsKeywordsData>> keywordsToSearch, FormLink<IKeywordGetter>? keywordFormLink)
        {
            if (keywordFormLink != null && keywordFormLink.TryResolve(linkCache, out var mKeywordGetter) && !string.IsNullOrWhiteSpace(mKeywordGetter.EditorID))
            {
                string keyWordEdId = mKeywordGetter.EditorID.ToLowerInvariant();

                if (keywordsToSearch.ContainsKey(keyWordEdId))
                {
                    var list = keywordsToSearch[keyWordEdId];
                    foreach (var d in list)
                    {
                        if (d.MaterialKeyword != null) continue;

                        // set value and remove reference from search list
                        d.MaterialKeyword = keywordFormLink;
                        list.Remove(d);
                    }

                    // remove empty list reference
                    if (list.Count == 0) keywordsToSearch.Remove(keyWordEdId);
                }
            }
        }

        private static void SearchKeywordsByEdId(IEnumerable<Mutagen.Bethesda.Plugins.Order.IModListing<ISkyrimModGetter>> priorityOrder, bool isMatSearch, Dictionary<string, List<MaterialFistsKeywordsData>> materialKeywordsSearch, bool isFSearch, Dictionary<string, List<MaterialFistsKeywordsData>> fistsKeywordsSearch)
        {
            foreach (var itemGetter in priorityOrder.Keyword().WinningOverrides())
            {
                if (string.IsNullOrWhiteSpace(itemGetter.EditorID)) continue;

                string keyWordEdid = itemGetter.EditorID.ToLower();

                if (isMatSearch && materialKeywordsSearch.ContainsKey(keyWordEdid))
                {
                    materialKeywordsSearch.TryAddKeyWord(itemGetter, keyWordEdid);
                }
                if (isFSearch && fistsKeywordsSearch.ContainsKey(keyWordEdid))
                {
                    fistsKeywordsSearch.TryAddKeyWord(itemGetter, keyWordEdid);
                }
            }
        }
    }
}
