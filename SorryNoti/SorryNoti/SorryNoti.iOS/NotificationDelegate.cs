using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using UserNotifications;

namespace SorryNoti.iOS
{
    public class NotificationDelegate : UNUserNotificationCenterDelegate
    {
        public NotificationDelegate()
        {

        }
        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            // Tell system to display the notification anyway or use
            // `None` to say we have handled the display locally.
            completionHandler(UNNotificationPresentationOptions.Alert | UNNotificationPresentationOptions.Sound);
        }
        public override void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
        {
            // Take action based on Action ID
            switch (response.ActionIdentifier)
            {
                case "reply":
                    // Do something
                    break;
                default:
                    // Take action based on identifier
                    if (response.IsDefaultAction)
                    {
                        // Handle default action...
                    }
                    else if (response.IsDismissAction)
                    {
                        // Handle dismiss action
                    }
                    break;
            }

            // Inform caller it has been handled
            completionHandler();
        }
        public void RegisterNotification(string title, string body)
        {
            var noti = new UILocalNotification
            {
                FireDate = NSDate.FromTimeIntervalSinceNow(3),
                AlertTitle = title,
                AlertBody = body,
                ApplicationIconBadgeNumber = 1,
                SoundName = "police.wav"
            };
            UIApplication.SharedApplication.ScheduleLocalNotification(noti);
            //UNUserNotificationCenter center = UNUserNotificationCenter.Current;
            //UNUserNotificationCenter center = UNUserNotificationCenter.Current;
            ////creat a UNMutableNotificationContent which contains your notification content
            //UNMutableNotificationContent notificationContent = new UNMutableNotificationContent();
            //notificationContent.Title = title;
            //notificationContent.Body = body;
            //notificationContent.Sound = UNNotificationSound.GetSound("notification.aiff");
            //UNTimeIntervalNotificationTrigger trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(1, false);
            //UNNotificationRequest request = UNNotificationRequest.FromIdentifier("FiveSecond", notificationContent, trigger);
            //center.AddNotificationRequest(request, (NSError obj) =>
            //{

            //});
        }
    }
}