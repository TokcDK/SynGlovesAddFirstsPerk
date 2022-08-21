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
        [SynthesisTooltip("Type of armor where to search for keywords\n0=Light armor,1=Heavy armor,2=Clothing\nSometimes different armor types contains same material keyword but fists keyword must be different")]
        public int ArmorTypeToSetFor = -1;
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
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDaedric,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsDaedric,
                 ArmorTypeToSetFor = (int)ArmorType.HeavyArmor,
                 Priority = 100,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDragonplate,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsDragonplate,
                 ArmorTypeToSetFor = (int)ArmorType.HeavyArmor,
                 Priority = 100,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialEbony,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsEbony,
                 ArmorTypeToSetFor = (int)ArmorType.HeavyArmor,
                 Priority = 90,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialOrcish,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsOrcish,
                 ArmorTypeToSetFor = (int)ArmorType.HeavyArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialImperialHeavy,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsSteelPlate,
                 ArmorTypeToSetFor = (int)ArmorType.HeavyArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialBlades,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsSteelPlate,
                 ArmorTypeToSetFor = (int)ArmorType.HeavyArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialSteelPlate,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsSteelPlate,
                 ArmorTypeToSetFor = (int)ArmorType.HeavyArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDwarven,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsDwarven,
                 ArmorTypeToSetFor = (int)ArmorType.HeavyArmor,
                 Priority = 60,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.WeapMaterialSilver,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsSteel,
                 ArmorTypeToSetFor = (int)ArmorType.HeavyArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialSteel,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsSteel,
                 ArmorTypeToSetFor = (int)ArmorType.HeavyArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialIron,
                 FistsKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.PerkFistsIron,
                 ArmorTypeToSetFor = (int)ArmorType.HeavyArmor,
                 Priority = 40,
            },
#endregion
#region light armor keywords
#region light armor keywords for heavy armors material keywords
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDaedric,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists12" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 100,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDragonplate,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists12" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 100,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialEbony,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists11" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 90,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialOrcish,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists10" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Dragonborn.Keyword.DLC2ArmorMaterialNordicHeavy,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists10" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialImperialHeavy,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists09" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialBlades,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists09" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialSteelPlate,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists09" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDwarven,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists08" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 60,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.WeapMaterialSilver,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists07" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialSteel,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists07" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialIron,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists06" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 40,
            },
#endregion
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDragonscale,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists12" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 100,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Dragonborn.Keyword.DLC2ArmorMaterialStalhrimLight,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists11" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 90,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialGlass,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists11" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 90,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialScaled,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists10" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorNightingale,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists10" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialThievesGuildLeader,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists10" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialElvenGilded,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists10" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialElven,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists09" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Dawnguard.Keyword.DLC1ArmorMaterialDawnguard,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists09" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Dragonborn.Keyword.DLC2ArmorMaterialChitinLight,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists09" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialThievesGuild,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists08" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 60,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialFalmer,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists08" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 60,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Dawnguard.Keyword.DLC1ArmorMaterialVampire,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists08" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 60,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialLeather,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists07" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialBearStormcloak,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists07" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialImperialLight,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists07" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialForsworn,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists06" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 40,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialForsworn,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists06" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 40,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialStormcloak,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists06" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 40,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialHide,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists05" },
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 30,
            },
#endregion
        };
    }
}
