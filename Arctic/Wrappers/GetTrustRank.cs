using UnityEngine;
using VRC.Core;
namespace Arctic.Wrappers
{
    class check_ranks
    {

        public static void gettrsutrank(APIUser player, ref string rank, ref Color color)
        {
            if (player != null)
            {
                //player.Fetch();
                var str = "";
                foreach (var tag in player.tags)
                {
                    str += tag;
                }
                //player.field_Private_APIUser_0.AddTag("A");
                rank = "Visitor";
                switch (true)
                {
                    case true when player.hasModerationPowers:
                        rank = "Moderator";
                        color = new Color(1, 0, 0);
                        break;
                    case true when player.hasSuperPowers:
                        rank = "Super powers";
                        color = new Color(0.6f, 0, 0);
                        break;
                    
                    /*
                    case true when str.Contains("system_legend"):
                        rank = "Legendary";
                        color = new Color(0, 0, 1f);
                        break;
                    case true when str.Contains("system_trust_legend"):
                        rank = "Veteran";
                        color = new Color(1, 0.5f, 0);
                        break;
                    */


                    case true when str.Contains("system_trust_veteran"):
                        rank = "Trusted";
                        color = Color.magenta;
                        break;
                    case true when str.Contains("system_trust_trusted"):
                        rank = "Known";
                        color = Color.yellow;
                        break;
                    case true when str.Contains("system_trust_known"):
                        rank = "User";
                        color = new Color(0, 1f, 0, 0.7f);
                        break;
                    case true when str.Contains("system_trust_basic"):
                        rank = "New User";
                        color = new Color(0, 0.7f, 1, 0.7f);
                        break;
                    case true when player.hasNegativeTrustLevel:
                        rank = "Visitor";
                        color = Color.white;
                        break;
                    case true when player.hasVeryNegativeTrustLevel:
                        rank = "Nuisance";
                        color = new Color(0.2f, 0, 0);
                        break;
                }
            }


        }


#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public static void convertotcolorank(ref string stringg, ref string? changestringcolor)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {
            switch (stringg)
            {
                case "Moderator":
                    stringg = "<color=#ff0000ff>Moderator</color>";
                    if (changestringcolor != null)
                        changestringcolor = $"<color=#ff0000ff>{changestringcolor}</color>";
                    break;
                case "Super powers":
                    stringg = "<color=#ffa500ff>Super powers</color>";
                    if (changestringcolor != null)
                        changestringcolor = $"<color=#ffa500ff>{changestringcolor}</color>";
                    break;
          /*      case "Legendary":
                    stringg = "<color=#00ffffff>Legendary</color>";
                    if (changestringcolor != null)
                        changestringcolor = $"<color=#00ffffff>{changestringcolor}</color>";
                    break;
                case "Veteran":
                    stringg = "<color=#808000ff>Veteran</color>";
                    if (changestringcolor != null)
                        changestringcolor = $"<color=#808000ff>{changestringcolor}</color>"; */

                    break;
                case "Trusted":
                    stringg = "<color=#800080ff>Trusted</color>";
                    if (changestringcolor != null)
                        changestringcolor = $"<color=#800080ff>{changestringcolor}</color>";
                    break;
                case "Known":
                    stringg = "<color=#ffa500ff>Known</color>";
                    if (changestringcolor != null)
                        changestringcolor = $"<color=#ffa500ff>{changestringcolor}</color>";
                    break;
                case "User":
                    stringg = "<color=#008000ff>User</color>";
                    if (changestringcolor != null)
                        changestringcolor = $"<color=#008000ff>{changestringcolor}</color>";
                    break;
                case "New User":
                    stringg = "<color=#00ffffff>New User</color>";
                    if (changestringcolor != null)
                        changestringcolor = $"<color=#00ffffff>{changestringcolor}</color>";
                    break;
                case "Visitor":
                    stringg = "Visitor";
                    if (changestringcolor != null)
                        changestringcolor = $"{changestringcolor}";
                    break;
                case "Nuisance":
                    stringg = "<color=#800000ff>Nuisance</color>";
                    if (changestringcolor != null)
                        changestringcolor = $"<color=#800000ff>{changestringcolor}</color>";
                    break;
            }

        }

    }
}
