namespace PrintColorScheme
{
    using System.Reflection;
    using HarmonyLib;
    using IPA;
    using IPALogger = IPA.Logging.Logger;

    [Plugin(RuntimeOptions.DynamicInit)]
    internal class Plugin
    {
        internal static IPALogger Logger { get; private set; }

        private const string HARMONYID = "com.noodle.BeatSaber.PrintColorScheme";

        private static readonly Harmony _harmonyInstance = new Harmony(HARMONYID);

        [Init]
        public void Init(IPALogger logger)
        {
            Logger = logger;
        }

        [OnEnable]
        public void OnEnable()
        {
            _harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnDisable]
        public void OnDisable()
        {
            _harmonyInstance.UnpatchAll(HARMONYID);
        }
    }
}
