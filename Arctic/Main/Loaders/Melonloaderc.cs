using MelonLoader;

namespace Arctic.Main
{
    public class Melonloaderc : MelonMod
    {

        public override void OnApplicationStart() => load.Start();

        public override void OnUpdate() => load.lateupdate();

        public override void OnGUI() => load.ongui();

       
    }
 }




