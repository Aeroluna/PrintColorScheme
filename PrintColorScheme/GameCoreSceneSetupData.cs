namespace PrintColorScheme
{
    using HarmonyLib;
    using UnityEngine;
    using IPALogger = IPA.Logging.Logger;

    [HarmonyPatch(typeof(StandardLevelScenesTransitionSetupDataSO))]
    [HarmonyPatch("Init")]
    internal static class GameCoreSceneSetupDataCtor
    {
        private static void Postfix(IDifficultyBeatmap difficultyBeatmap, ColorScheme overrideColorScheme, OverrideEnvironmentSettings overrideEnvironmentSettings)
        {
            IPALogger logger = Plugin.Logger;
            EnvironmentInfoSO environmentInfoSO = difficultyBeatmap.GetEnvironmentInfo();
            if (overrideEnvironmentSettings != null)
            {
                environmentInfoSO = overrideEnvironmentSettings.GetOverrideEnvironmentInfoForType(environmentInfoSO.environmentType);
            }

            ColorScheme colorScheme = overrideColorScheme ?? new ColorScheme(environmentInfoSO.colorScheme);
            logger.Info("===================");
            logger.Info("ACTIVE COLOR SCHEME:");
            logger.Info($"colorSchemeId: {colorScheme.colorSchemeId}");
            logger.Info($"nonLocalizedName: {colorScheme.nonLocalizedName}");
            logger.Info($"colorSchemeNameLocalizationKey: {colorScheme.colorSchemeNameLocalizationKey}");
            logger.Info($"supportsEnvironmentColorBoost: {colorScheme.supportsEnvironmentColorBoost}");
            logger.Info($"saberAColor: {PrintFullColor(colorScheme.saberAColor)}");
            logger.Info($"saberBColor: {PrintFullColor(colorScheme.saberBColor)}");
            logger.Info($"environmentColor0: {PrintFullColor(colorScheme.environmentColor0)}");
            logger.Info($"environmentColor1: {PrintFullColor(colorScheme.environmentColor1)}");
            logger.Info($"environmentColorW: {PrintFullColor(colorScheme.environmentColorW)}");
            logger.Info($"environmentColor0Boost: {PrintFullColor(colorScheme.environmentColor0Boost)}");
            logger.Info($"environmentColor1Boost: {PrintFullColor(colorScheme.environmentColor1Boost)}");
            logger.Info($"environmentColorWBoost: {PrintFullColor(colorScheme.environmentColorWBoost)}");
            logger.Info($"obstaclesColor: {PrintFullColor(colorScheme.obstaclesColor)}");
            logger.Info("===================");
        }
        private static string PrintFullColor(Color color)
        {
            return $"{{ {color.r}, {color.g}, {color.b} }}";
        }
    }
}
