namespace InteractiveOfficeClient
{
    /// <summary>
    /// This class collects all feature toggles to enable and disable function as necessary. For more information on
    /// this pattern see https://martinfowler.com/articles/feature-toggles.html
    ///
    /// Toggles should only introduced for new and experimental features. If a toggle is stable, you can set it to its
    /// final state and replace <code>static readonly</code> with <code>const</code>; your IDE will most likely give you
    /// a warning about "unreachable branches" - these can be removed as they are not used anymore.
    /// </summary>
    public class FeatureToggles
    {
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