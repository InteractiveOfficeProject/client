namespace InteractiveOfficeClient
{
    public class FeatureToggles
    {
        /// <summary>
        /// Currently, we did not implement the "Take a break"-notification ("Take a break" - "Ok", "snooze"). This
        /// feature toggle adds the "Take a break"-title to the activity selection and with that fakes the
        /// break-notification. It can be removed after the actual notification was implemented.
        /// </summary>
        public static readonly bool FakeTakeBreakNotification = false;
        /// <summary>
        /// Currently, we do not have icons for the activities. The implemented buttons however can show an icons;
        /// When this feature toggle is enabled, the App shows "Missing image" for these icons. Otherwise, only text
        /// is loaded.
        /// </summary>
        public static readonly bool ShowMissingActivityIcons = false;
        /// <summary>
        /// Currently, we don't match people up. Therefore, this part of the application is not implemented. This
        /// feature toggle enables "Fake Matching", i.e. the authors will be shown as potential break partners.
        /// </summary>
        public static readonly bool ShowFakePeopleSelection = true;
        /// <summary>
        /// Enables the loading of user images. If disabled, only the user name is shown.
        /// </summary>
        public static readonly bool LoadUserIcons = true;
    }
}