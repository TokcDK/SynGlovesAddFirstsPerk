using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis.Settings;

namespace SynGlovesAddFirstsPerk
{
    public class KeywordSearchData
    {
        [SynthesisOrder]
        [SynthesisTooltip($"Keyword string to search")]
        public string? KeywordString;
        [SynthesisOrder]
        [SynthesisTooltip($"Mod where to search {nameof(KeywordString)}")]
        public ModKey ModToSearchOptional;
    }
    public class MaterialFistsKeywordsData
    {
        [SynthesisOrder]
        [SynthesisTooltip("Priority of the record. Records will be checked in order of priority from bigger to smaller.")]
        public int Priority = 0;
        [SynthesisOrder]
        [SynthesisTooltip("Type of armor where to search for keywords\nSometimes different armor types contains same maeterial keyword but fists keyword must be different")]
        public ArmorType? ArmorTypeToSetFor;
        [SynthesisOrder]
        [SynthesisTooltip("Material keyword")]
        public FormLink<IKeywordGetter>? MaterialKeyword;
        [SynthesisOrder]
        [SynthesisTooltip($"Material keyword string search by EDID\nUse only when {nameof(MaterialKeyword)} is not set")]
        public KeywordSearchData MaterialKeywordStringOptional = new();
        [SynthesisOrder]
        [SynthesisTooltip("Fists perk keyword")]
        public FormLink<IKeywordGetter>? FistsKeyword;
        [SynthesisOrder]
        [SynthesisTooltip($"Fists perk keyword string by EDID\nUse only when {nameof(FistsKeyword)} is not set")]
        public KeywordSearchData FistsKeywordStringOptional = new();
    }

    public class PatcherSettings
    {
        [SynthesisOrder]
        [SynthesisTooltip("Extra material/fists keywords list")]
        public HashSet<MaterialFistsKeywordsData> ModMaterialFists = new()
        {
#region heavy armor keywords
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDaedric.FormKey,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsDaedric.FormKey,
                 ArmorTypeToSetFor = ArmorType.HeavyArmor,
                 Priority = 100,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDragonplate.FormKey,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsDragonplate.FormKey,
                 ArmorTypeToSetFor = ArmorType.HeavyArmor,
                 Priority = 100,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialEbony.FormKey,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsEbony.FormKey,
                 ArmorTypeToSetFor = ArmorType.HeavyArmor,
                 Priority = 90,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialOrcish.FormKey,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsOrcish.FormKey,
                 ArmorTypeToSetFor = ArmorType.HeavyArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialImperialHeavy.FormKey,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsSteelPlate.FormKey,
                 ArmorTypeToSetFor = ArmorType.HeavyArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialBlades.FormKey,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsSteelPlate.FormKey,
                 ArmorTypeToSetFor = ArmorType.HeavyArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialSteelPlate.FormKey,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsSteelPlate.FormKey,
                 ArmorTypeToSetFor = ArmorType.HeavyArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDwarven.FormKey,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsDwarven.FormKey,
                 ArmorTypeToSetFor = ArmorType.HeavyArmor,
                 Priority = 60,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.WeapMaterialSilver.FormKey,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsSteel.FormKey,
                 ArmorTypeToSetFor = ArmorType.HeavyArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialSteel.FormKey,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsSteel.FormKey,
                 ArmorTypeToSetFor = ArmorType.HeavyArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialIron.FormKey,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsIron.FormKey,
                 ArmorTypeToSetFor = ArmorType.HeavyArmor,
                 Priority = 40,
            },
#endregion
#region light armor keywords
#region light armor keywords for heavy armors material keywords
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDaedric.FormKey,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists12" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 100,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDragonplate.FormKey,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists12" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 100,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialEbony.FormKey,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists11" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 90,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialOrcish.FormKey,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists10" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Dragonborn.Keyword.DLC2ArmorMaterialNordicHeavy.FormKey,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists10" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialImperialHeavy.FormKey,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists09" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialBlades.FormKey,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists09" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialSteelPlate.FormKey,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists09" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDwarven.FormKey,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists08" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 60,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.WeapMaterialSilver.FormKey,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists07" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialSteel.FormKey,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists07" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialIron.FormKey,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists06" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 40,
            },
#endregion
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDragonscale,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists12" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 100,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Dragonborn.Keyword.DLC2ArmorMaterialStalhrimLight,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists11" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 90,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialGlass,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists11" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 90,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialScaled,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists10" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorNightingale,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists10" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialThievesGuildLeader,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists10" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialElvenGilded,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists10" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialElven,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists09" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Dawnguard.Keyword.DLC1ArmorMaterialDawnguard,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists09" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Dragonborn.Keyword.DLC2ArmorMaterialChitinLight,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists09" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialThievesGuild,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists08" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 60,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialFalmer,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists08" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 60,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Dawnguard.Keyword.DLC1ArmorMaterialVampire,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists08" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 60,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialLeather,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists07" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialBearStormcloak,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists07" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialImperialLight,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists07" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialForsworn,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists06" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 40,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialForsworn,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists06" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 40,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialStormcloak,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists06" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 40,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialHide,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists05" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
                 Priority = 30,
            },
#endregion
        };
    }
}
