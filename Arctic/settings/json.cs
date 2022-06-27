using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arctic.settings
{
    [Serializable]

    public class Users
    {
        public string User { get; set; }

        public string Joineddate { get; set; }

        public string Hwid { get; set; }

        public string Key { get; set; }
      
        public string code { get; set; }


    }

    public class Userinfo
    {
        public string UserName { get; set; }

        public string Id { get; set; }

        public int Trustrank { get; set; }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? CustomTag { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string code { get; set; }

    }

    public class WorldHistory
    {
        public string WorldName { get; set; }

        public string WorldId { get; set; }

    }

    public class Account
    {
        public string User { get; set; }
        public string Joineddate { get; set; }
        public string Hwid { get; set; }
        public string Key { get; set; }
        public string uid { get; set; }
        public string code { get; set; }

    }

    public class confirmauth
    {
        public string key { get; set; }

        public string Hwida { get; set; }
        public string code { get; set; }
    }

    public class avatarfav
    {
        public string AvatarName { get; set; }

        public string AvatarId { get; set; }

        public string ImageUrl { get; set; }

        public string Platform { get; set; }

    }

    public class sendsinglemsg
    {
        public string Custommsg { get; set; }

        public string code { get; set; }

    }

    public class sendclientmsg
    {
        public string clientKey { get; set; }

        public string clientpassword { get; set; }

        public string clientmessage { get; set; }

        public string code { get; set; }


    }

    public class ReciveRoles
    {

        public string userid { get; set; }

        public string permision { get; set; }

        public List<string> roleslist { get; set; }
        public string code { get; set; }


    }

    public class Recivemessage
    {
        public string clinetmessage { get; set; }

        public string user { get; set; }

        public string uid { get; set; }
        public string code { get; set; }

    }

    public class Setpassword
    {
        public string User { get; set; }
        public string Hwid { get; set; }
        public string Key { get; set; }
        public string Password { get; set; }
        public string code { get; set; }

    }

    public class sendtag
    {
        public string key { get; set; }
        public string password { get; set; }
        public string userid { get; set; }
        public string addnewtagtouser { get; set; }
        public string code { get; set; }

    }

    public class removealltags
    {
        public string abouttoremovealltagskey { get; set; }
        public string password { get; set; }
        public string code { get; set; }
    }

    public class movetagstotuser
    {
        public string tomovetagstouserkey { get; set; }
        public string password { get; set; }
        public string userid { get; set; }
        public string code { get; set; }

    }


    public class Logavi
    {
        public string AvatarName { get; set; }

        public string Author { get; set; }

        public string Authorid { get; set; }

        public string Avatarid { get; set; }   

        public string Description {get; set;}

        public string Asseturl { get; set; }

        public string Image { get; set; }

        public string Platform { get; set; }

        public string Status { get; set; }

        public string code { get; set; }

    }
}
