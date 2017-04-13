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

## Next Steps

 * Add "minimize to tray" to keep the app running when window is closed. Useful links: 
   * http://www.mono-project.com/docs/gui/gtksharp/widgets/notification-icon/
 * Add "start on boot"
   * No research done yet
 * Add the simplified tracking work-flow: ["start working"] -(30min)-> ["start break"] -(10min)-> ["start working"] ... 
   * Most minimal application
 * Then extend according to https://drive.google.com/drive/folders/0B6Tl_UdBt6QYWUtTSExzQ2toOHc ?
  * 
