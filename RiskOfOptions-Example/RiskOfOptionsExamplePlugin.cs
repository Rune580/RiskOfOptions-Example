using BepInEx;
using BepInEx.Configuration;
using RiskOfOptions;
using RiskOfOptions.OptionConfigs;
using RiskOfOptions.Options;
using UnityEngine;

namespace RiskOfOptions_Example
{
    [BepInPlugin(Guid, ModName, Version)]
    public sealed class RiskOfOptionsExamplePlugin : BaseUnityPlugin
    {
        private const string
            ModName = "Risk Of Options Example",
            Author = "rune580",
            Guid = "com." + Author + "." + "riskofoptions-example",
            Version = "1.0.0";

        private ConfigEntry<bool> _disabled;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0051:Remove unused private members", Justification = "Awake is automatically called by Unity")]
        private void Awake()
        {
            GeneralShowcase();
            DisableShowcase();
        }

        private void GeneralShowcase()
        {
            ModSettingsManager.AddOption(new CheckBoxOption(Config.Bind("General",
                "CheckBox",
                false,
                "Normal CheckBox with default config")));
            
            ModSettingsManager.AddOption(new SliderOption(Config.Bind("General",
                "Slider",
                50f,
                "Normal Slider with default config")));
            
            ModSettingsManager.AddOption(new SliderOption(Config.Bind("General",
                    "Limited Slider",
                    75f,
                    "Slider with limited range 70 - 130"),
                new SliderConfig
                {
                    min = 70f,
                    max = 130f
                }));
            
            ModSettingsManager.AddOption(new StepSliderOption(Config.Bind("General",
                    "Stepped Slider",
                    2f,
                    "Slider with limited range 70 - 130"),
                new StepSliderConfig
                {
                    min = 1f,
                    max = 6f,
                    increment = 0.25f
                }));
            
            ModSettingsManager.AddOption(new IntSliderOption(Config.Bind("General",
                "Int Slider",
                3,
                "Slider limited to whole numbers with a range of 1 - 10"),
                new IntSliderConfig
                {
                    min = 1,
                    max = 10
                }));

            var key = Config.Bind("General",
                "KeyBind",
                new KeyboardShortcut(KeyCode.A),
                "KeyBind with a default keycode of `A`");

            ModSettingsManager.AddOption(new KeyBindOption(key));
            
            ModSettingsManager.AddOption(new StringInputFieldOption(Config.Bind("General",
                "InputField",
                "",
                "Input Field")));
            
            ModSettingsManager.AddOption(new GenericButtonOption("GenericButton",
                "General",
                "GenericButton that invokes the attached option",
                "Invokes Action",
                () => Debug.Log("Action invoked!")));

            ConfigEntry<MyEnum> testEnum = Config.Bind("General", "Choice", MyEnum.Two, "Choice Description");

            ModSettingsManager.AddOption(new ChoiceOption(testEnum));
            
            ModSettingsManager.AddOption(new ColorOption(Config.Bind("General",
                "Color Picker",
                Color.green,
                "A color option that opens a color picker to modify.")));
        }

        private void DisableShowcase()
        {
            _disabled = Config.Bind("Disable",
                "Toggle",
                false,
                "");
            
            ModSettingsManager.AddOption(new CheckBoxOption(_disabled));
            
            ModSettingsManager.AddOption(new CheckBoxOption(Config.Bind("Disable",
                "CheckBox",
                false,
                ""),
                new CheckBoxConfig { checkIfDisabled = Disabled }));
            
            ModSettingsManager.AddOption(new SliderOption(Config.Bind("Disable",
                "Slider",
                50f,
                ""),
                new SliderConfig { checkIfDisabled = Disabled }));
            
            ModSettingsManager.AddOption(new StepSliderOption(Config.Bind("Disable",
                    "Stepped Slider",
                    2f,
                    ""),
                new StepSliderConfig
                {
                    min = 1f,
                    max = 6f,
                    increment = 0.25f,
                    checkIfDisabled = Disabled
                }));
            
            ModSettingsManager.AddOption(new IntSliderOption(Config.Bind("Disable",
                    "Int Slider",
                    3,
                    ""),
                new IntSliderConfig
                {
                    min = 1,
                    max = 10,
                    checkIfDisabled = Disabled
                }));
            
            ModSettingsManager.AddOption(new KeyBindOption(Config.Bind("Disable",
                "KeyBind",
                new KeyboardShortcut(KeyCode.A),
                ""),
                new KeyBindConfig { checkIfDisabled = Disabled }));
            
            ModSettingsManager.AddOption(new StringInputFieldOption(Config.Bind("Disable",
                "InputField",
                "",
                ""),
                new InputFieldConfig { checkIfDisabled = Disabled }));
            
            ModSettingsManager.AddOption(new ChoiceOption(Config.Bind("Disable",
                "Choice",
                MyEnum.Two,
                ""),
                new ChoiceConfig { checkIfDisabled = Disabled }));
            
            ModSettingsManager.AddOption(new ColorOption(Config.Bind("Disable",
                "Color Picker",
                Color.green,
                "A color option that opens a color picker to modify."),
                new ColorOptionConfig { checkIfDisabled = Disabled }));
        }

        private bool Disabled()
        {
            return _disabled.Value;
        }
        
        public enum MyEnum
        {
            None,
            Two,
            Eight
        }
    }
}
