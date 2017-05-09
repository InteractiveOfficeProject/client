namespace InteractiveOfficeClient
{
    public class FeatureToggles
    {
        /// <summary>
        ///
        /// </summary>
        public static readonly bool FakeTakeBreakNotification = true;
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
        ///
        /// </summary>
        public static readonly bool LoadUserIcons = true;
    }
}