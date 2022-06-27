using Arctic.Apis.Desktopui;
namespace Arctic.Main
{
    class desktopui
    {
        public static void setupui()
        {
            if (!settings.nconfig.DESKTOPUI) return;
            var mainmenu = Main_page.gamemenu();
            SubPage.Createsubmenu("Main Page", true, mainmenu);
        }
    }
}
