using System;
namespace Arctic.Wrappers
{
    class FetchByid
    {
        public static VRC.Core.APIUser fetchbyid(string id)
        {
            VRC.Core.APIUser usr = null;
            VRC.Core.APIUser.FetchUser(id, new Action<VRC.Core.APIUser>((a) => { usr = a; }), new Action<string>((a) => { Style.Consoles.consolelogger(a); }));
            return usr;
        }
    }
}
