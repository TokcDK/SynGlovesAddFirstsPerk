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
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDragonscale,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists12" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Dragonborn.Keyword.DLC2ArmorMaterialStalhrimLight,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists11" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialGlass,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists11" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialScaled,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists10" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorNightingale,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists10" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialThievesGuildLeader,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists10" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialElvenGilded,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists10" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialElven,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists09" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Dawnguard.Keyword.DLC1ArmorMaterialDawnguard,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists09" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Dragonborn.Keyword.DLC2ArmorMaterialChitinLight,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists09" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialThievesGuild,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists08" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialFalmer,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists08" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Dawnguard.Keyword.DLC1ArmorMaterialVampire,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists08" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialLeather,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists07" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialImperialLight,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists07" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialForsworn,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists06" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialForsworn,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists06" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialStormcloak,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists06" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialHide,
                 FistsKeywordStringOptional = new KeywordSearchData(){ KeywordString = "WAF_PerkFists05" },
                 ArmorTypeToSetFor = ArmorType.LightArmor,
            },
        };
    }
}
