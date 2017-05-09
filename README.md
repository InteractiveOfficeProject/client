# client
Desktop-Client for our DIS project


## Setup

Install [gtksharp](http://www.mono-project.com/docs/gui/gtksharp/).

On manjaro/arch this is contained in the package `gtk-sharp-3`. For 
MacOs and Windows, see http://www.mono-project.com/download/

## Resources

Add them to the project, place them in the Resources folder, and set them to
"Embedded Resource". E.g. you can load image resources via
`.LoadFromResource("InteractiveOfficeClient.Resources.$fileName")`

## Releases

 * I did not find out where the version for the assembly is set. Therefore just update the things below ;)
 * Update the `CHANGELOG.md` with the new version and your changes
   * We are still in beta, so we will have versions like 0.XX.YY
 * Create a new annotated tag and add your changes in the annotation (`git tag -a v${VersionCode}`, e.g. `git tag -a v0.0.1`)
   * To see an example you can use `git tag -v v0.0.1`
 * On Linux you can use `build-release.sh` to create a distributable from the source
 * Push the created tag via `git push --tags` and upload the file `bin/Release/InteractiveOfficeClient.exe` to the newly created Github Release

## Running

 * Download one of the releases as 7z and unpack it
 * Run it: `mono InteractiveOfficeClient.exe` on Linux, double-click on the `InteractiveOfficeClient.exe` in Windows
   * Untested on Windows/Mac
 * You must have GTK installed (untested/unknown)

## Server API

The Server API is documented at http://pivanics.users.cs.helsinki.fi/interactive-office-api-documentation

## Next Steps

 * [x] Add "minimize to tray" to keep the app running when window is closed. Useful links:
   * http://www.mono-project.com/docs/gui/gtksharp/widgets/notification-icon/
 * [x] Add the simplified tracking work-flow: ["start working"] -(30min)-> ["start break"] -(5min)-> ["start working"] ...
   * Most minimal application
   * App gets invisible on starting something, visible when it's done
 * [ ] Add "start on boot"
   * No research done yet
 * [ ] Then extend according to https://drive.google.com/drive/folders/0B6Tl_UdBt6QYWUtTSExzQ2toOHc ?
  * Notifications: libnotify
 * [X] Adapt release script to bundle build with dlls in zip
 * [x] Add Google Form link
 * [ ] Cross-Platform Build
  * http://stackoverflow.com/questions/3429451/is-developing-in-mono-cross-platform
  * https://stephenhaunts.com/2014/04/28/cross-platform-development-with-mono/
  * http://www.c-sharpcorner.com/UploadFile/84c85b/building-cross-platform-net-app-using-mono/
  * monodevelop contains an example GTK# application
  * [ ] Add sound for notification
 * [ ] Heuristic Evaluation of Application
 * [ ] Re-Design UI to look nice
 * [ ] Add notification to foreground. Currently they're not necessarily 
       in foreground
 * [ ] Demo-Variant for Demo Day
 * [ ] Rewrite in Java?
