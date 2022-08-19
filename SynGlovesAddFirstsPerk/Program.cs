using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis;

namespace SynGlovesAddFirstsPerk
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetTypicalOpen(GameRelease.SkyrimSE, "YourPatcher.esp")
                .Run(args);
        }

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            // material keyword and fists keyword for in in order from stronger to weaker because can be two material keywords and need to get stronger
            Dictionary<FormLink<IKeywordGetter>, FormLink<IKeywordGetter>> materialFirstKeyword = new()
            {
                { Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDaedric.FormKey, Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsDaedric.FormKey },
                { Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDragonplate.FormKey, Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsDragonplate.FormKey },
                { Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialEbony.FormKey, Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsEbony.FormKey },
                { Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialImperialHeavy.FormKey, Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsSteelPlate.FormKey },
                { Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialBlades.FormKey, Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsSteelPlate.FormKey },
                { Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialSteelPlate.FormKey, Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsSteelPlate.FormKey },
                { Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialOrcish.FormKey, Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsOrcish.FormKey },
                { Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDwarven.FormKey, Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsDwarven.FormKey },
                { Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.WeapMaterialSilver.FormKey, Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsSteel.FormKey },
                { Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialSteel.FormKey, Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsSteel.FormKey },
                { Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialIron.FormKey, Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsIron.FormKey },
            };

            int patchedCount = 0;
            foreach (var itemGetter in state.LoadOrder.PriorityOrder.Armor().WinningOverrides())
            {
                //if (itemGetter.EditorID != "ArmorDragonplateGauntlets") continue;// test skip

                // skip inavalid
                if (itemGetter.IsDeleted) continue;
                if (itemGetter.MajorFlags.HasFlag(Armor.MajorFlag.NonPlayable)) continue;
                if (itemGetter.MajorFlags.HasFlag(Armor.MajorFlag.Shield)) continue;
                if (itemGetter.BodyTemplate == null) continue;
                if (itemGetter.BodyTemplate.Flags.HasFlag(BodyTemplate.Flag.NonPlayable)) continue;
                if (itemGetter.BodyTemplate.ArmorType == ArmorType.Clothing) continue; // maybe try to parse this variant later?
                if (!itemGetter.BodyTemplate.FirstPersonFlags.HasFlag(BipedObjectFlag.Hands)) continue; // maybe try to parse this variant later?
                if (itemGetter.Keywords == null || itemGetter.Keywords.Count == 0) continue;

                // find material keyword
                //Console.WriteLine($"Find material keyword for {itemGetter.EditorID}");
                FormLink<IKeywordGetter>? foundFormKey = null;
                bool found = false;
                bool alreadyHaveOneOfFistsKeyword = false;
                foreach (var formKey in materialFirstKeyword) // iterati in order from stronger to weaker
                {
                    if (itemGetter.Keywords.Contains(formKey.Value.FormKey))
                    {
                        alreadyHaveOneOfFistsKeyword = true;
                        break;
                    }
                    if (!found && itemGetter.Keywords.Contains(formKey.Key.FormKey))
                    {
                        found = true;
                        foundFormKey = formKey.Key;
                    }
                }

                // skip if not found or fists keyword already exists
                if (alreadyHaveOneOfFistsKeyword || foundFormKey == null || foundFormKey.FormKey == default) continue;

                // add missing fists keyword
                patchedCount++;
                var itemToPatch = state.PatchMod.Armors.GetOrAddAsOverride(itemGetter);
                itemToPatch.Keywords!.Add(materialFirstKeyword[foundFormKey!]); // add fists keyword for the materia
            }

            Console.WriteLine($"Patched {patchedCount} records");
        }
    }
}
