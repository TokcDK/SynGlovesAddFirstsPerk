using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis.Settings;

namespace SynGlovesAddFirstsPerk
{
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
        public string? MaterialKeywordEdidOptional;
        [SynthesisOrder]
        [SynthesisTooltip("Fists perk keyword")]
        public FormLink<IKeywordGetter>? FistsKeyword;
        [SynthesisOrder]
        [SynthesisTooltip($"Fists perk keyword string by EDID\nUse only when {nameof(FistsKeyword)} is not set")]
        public string? FistsKeywordEdidOptional;
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
                 FistsKeywordEdidOptional = "WAF_PerkFists12",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 100,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDragonplate,
                 FistsKeywordEdidOptional = "WAF_PerkFists12",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 100,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialEbony,
                 FistsKeywordEdidOptional = "WAF_PerkFists11",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 90,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialOrcish,
                 FistsKeywordEdidOptional = "WAF_PerkFists10",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Dragonborn.Keyword.DLC2ArmorMaterialNordicHeavy,
                 FistsKeywordEdidOptional = "WAF_PerkFists10",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialImperialHeavy,
                 FistsKeywordEdidOptional = "WAF_PerkFists09",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialBlades,
                 FistsKeywordEdidOptional = "WAF_PerkFists09",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialSteelPlate,
                 FistsKeywordEdidOptional = "WAF_PerkFists09",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDwarven,
                 FistsKeywordEdidOptional = "WAF_PerkFists08",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 60,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.WeapMaterialSilver,
                 FistsKeywordEdidOptional = "WAF_PerkFists07",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialSteel,
                 FistsKeywordEdidOptional = "WAF_PerkFists07",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword = Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialIron,
                 FistsKeywordEdidOptional = "WAF_PerkFists06",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 40,
            },
#endregion
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialDragonscale,
                 FistsKeywordEdidOptional = "WAF_PerkFists12",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 100,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Dragonborn.Keyword.DLC2ArmorMaterialStalhrimLight,
                 FistsKeywordEdidOptional = "WAF_PerkFists11",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 90,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialGlass,
                 FistsKeywordEdidOptional = "WAF_PerkFists11",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 90,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialScaled,
                 FistsKeywordEdidOptional = "WAF_PerkFists10",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorNightingale,
                 FistsKeywordEdidOptional = "WAF_PerkFists10",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialThievesGuildLeader,
                 FistsKeywordEdidOptional = "WAF_PerkFists10",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialElvenGilded,
                 FistsKeywordEdidOptional = "WAF_PerkFists10",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 80,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialElven,
                 FistsKeywordEdidOptional = "WAF_PerkFists09",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Dawnguard.Keyword.DLC1ArmorMaterialDawnguard,
                 FistsKeywordEdidOptional = "WAF_PerkFists09",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Dragonborn.Keyword.DLC2ArmorMaterialChitinLight,
                 FistsKeywordEdidOptional = "WAF_PerkFists09",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 70,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialThievesGuild,
                 FistsKeywordEdidOptional = "WAF_PerkFists08",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 60,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialFalmer,
                 FistsKeywordEdidOptional = "WAF_PerkFists08",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 60,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Dawnguard.Keyword.DLC1ArmorMaterialVampire,
                 FistsKeywordEdidOptional = "WAF_PerkFists08",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 60,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialLeather,
                 FistsKeywordEdidOptional = "WAF_PerkFists07",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialBearStormcloak,
                 FistsKeywordEdidOptional = "WAF_PerkFists07",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialImperialLight,
                 FistsKeywordEdidOptional = "WAF_PerkFists07",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 50,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialForsworn,
                 FistsKeywordEdidOptional = "WAF_PerkFists06",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 40,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Update.Keyword.ArmorMaterialForsworn,
                 FistsKeywordEdidOptional = "WAF_PerkFists06",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 40,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialStormcloak,
                 FistsKeywordEdidOptional = "WAF_PerkFists06",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 40,
            },
            new MaterialFistsKeywordsData()
            {
                 MaterialKeyword=Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.Keyword.ArmorMaterialHide,
                 FistsKeywordEdidOptional = "WAF_PerkFists05",
                 ArmorTypeToSetFor = (int)ArmorType.LightArmor,
                 Priority = 30,
            },
#endregion
        };
    }
}
