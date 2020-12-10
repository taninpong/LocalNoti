using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using UserNotifications;

namespace SorryNoti.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                UNUserNotificationCenter.Current.RequestAuthorization(
                    UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound,
                    (approved, error) => { });
                UNUserNotificationCenter.Current.Delegate = new UserNotwwificationCenterDelegate();
            }
            else if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                // Ask the user for permission to get notifications on iOS 8.0+
                var settings = UIUserNotificationSettings.GetSettingsForTypes(
                    UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                    new NSSet());

                UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            }
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public override void OnResignActivation(UIApplication application)
        {
            var blurEffect = UIBlurEffect.FromStyle(UIBlurEffectStyle.ExtraDark);
            var blurEffectView = new UIVisualEffectView(blurEffect)
            {
                Frame = application.KeyWindow.Subviews.First().Bounds,
                AutoresizingMask = UIViewAutoresizing.FlexibleDimensions,
                Tag = 12
            };
            application.KeyWindow.Subviews.Last().AddSubview(blurEffectView);
            base.OnResignActivation(application);
        }

        public override void OnActivated(UIApplication uiApplication)
        {
            var sub = uiApplication.KeyWindow?.Subviews.Last();
            if (sub == null)
                return;
            foreach (var vv in sub.Subviews)
            {
                if (vv.Tag == 12)
                    vv.RemoveFromSuperview();
            }
            base.OnActivated(uiApplication);
        }
    }
}
