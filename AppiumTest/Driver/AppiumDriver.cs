using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;

namespace AppiumTest
{
    public class AppiumDriverHelper
    {
        public AppiumDriverHelper()
        {
        }

        private static AppiumDriver Driver { get; set; }
        private static AppiumLocalService AppiumService { get; set; }
        private bool IsiOS;

        public static AppiumDriver GetDriver()
        {
            JsonDocument jsonDocument = JsonDocument.Parse(File.ReadAllText("/Users/nhict/Projects/AppiumTest/AppiumTest/config.json"));
            JsonElement rootElement = jsonDocument.RootElement;
            var isIOS = rootElement.GetProperty("isIOSDevice").GetBoolean();

            if (Driver == null)
            {
                AppiumService = InitAppiumServer();
                AppiumService.Start();
                if (isIOS)
                {
                    Driver = InitializeAppiumIos();
                }
                else
                {
                    InitAndroidEmulator();
                    Driver = InitializeAppium();
                }
            }

            return Driver;
        }

        public static AppiumLocalService InitAppiumServer()
        {
            Dictionary<String, String> environment = new Dictionary<String, String>();
            //KeyValuePair<string, string> myKeyValuePair = new KeyValuePair<string, string>("--simulator-name", "iPhone");
            environment.Add("CARTHAGE_PATH", "/opt/homebrew/bin");
            environment.Add("ANDROID_HOME", "/Users/nhict/Library/Android/sdk");
            environment.Add("ANDROID_SDK_ROOT", "/Users/nhict/Library/Android/sdk");
            var AppiumService = new AppiumServiceBuilder();
            AppiumService.WithAppiumJS(new FileInfo("/usr/local/lib/node_modules/appium/build/lib/main.js"))
                           .UsingDriverExecutable(new FileInfo("/usr/local/bin/node"))
                           .WithEnvironment(environment)
                           .WithIPAddress("127.0.0.1")
                           .UsingAnyFreePort();

            return AppiumService.Build();
        }
        public static void InitAndroidEmulator()
        {
            Process.Start("/Users/nhict/Library/Android/sdk/emulator/emulator", "-avd Pixel_2_API_30");
            Thread.Sleep(10000);
        }
        public static void CloseAppiumServer()
        {
            AppiumService.Dispose();
        }
        public static void CloseEmulator()
        {
            JsonDocument jsonDocument = JsonDocument.Parse(File.ReadAllText("/Users/nhict/Projects/AppiumTest/AppiumTest/config.json"));
            JsonElement rootElement = jsonDocument.RootElement;
            var isIOS = rootElement.GetProperty("isIOSDevice").GetBoolean();
            if (isIOS)
            {
                Process.Start("/usr/bin/xcrun", "simctl shutdown all");
            }
            else
            {
                Process.Start("/Users/nhict/Library/Android/sdk/platform-tools/adb", "-s emulator-5554 emu kill");
            }
        }

        private static AndroidDriver InitializeAppium()
        {
            var driverOptions = new AppiumOptions();
            driverOptions.DeviceName = "Pixel_2_API_30";
            driverOptions.PlatformName = "Android";
            driverOptions.PlatformVersion = "11";

            driverOptions.App = "/Users/nhict/Projects/AppiumTest/AppiumTest/Asset/VNW.apk";
            driverOptions.AutomationName = "UiAutomator2";
            driverOptions.AddAdditionalAppiumOption("autoDismissAlerts", "true");
            driverOptions.AddAdditionalAppiumOption("udid", "emulator-5554");
            driverOptions.AddAdditionalAppiumOption("autoGrantPermissions", "true");

            return new AndroidDriver(AppiumService, driverOptions);
        }

        private static IOSDriver InitializeAppiumIos()
        {
            AppiumOptions driverOptions = new AppiumOptions();
            driverOptions.DeviceName = "iPhone";
            driverOptions.PlatformName = "ios";
            driverOptions.PlatformVersion = "16.4";
            driverOptions.App = "/Users/nhict/Projects/AppiumTest/AppiumTest/Asset/VNW.app";
            driverOptions.AutomationName = "XCUITest";
            //driverOptions.AddAdditionalAppiumOption("resetOnSessionStartOnly", true);
            //driverOptions.AddAdditionalAppiumOption("enforceFreshSimulatorCreation", true);
            driverOptions.AddAdditionalAppiumOption("udid", "5EACA7E2-DD8D-404F-805C-70CFC843DC43");
            driverOptions.AddAdditionalAppiumOption(IOSMobileCapabilityType.AutoDismissAlerts, true);

            return new IOSDriver(AppiumService, driverOptions, TimeSpan.FromMinutes(2));
        }
    }
}
