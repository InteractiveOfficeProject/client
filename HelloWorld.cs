namespace InteractiveOfficeClient
{
    using Gtk;
    public class HelloWorld {
        static void Main() {
            Application.Init ();
            MessageDialog Hello = new MessageDialog (null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Hello world!");
            Hello.SecondaryText="This is an example dialog.";
            Hello.Run ();
        }
    }

}