using System;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace CarSpending.Helpers
{
    public class Notification
    {
        public static void GetNotification(string notificationMessage)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode("CarSpending"));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode(notificationMessage));
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
