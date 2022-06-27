using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arctic.settings.Anticrash
{
    internal class Anti
    {
        public static string shaderlistst = "";
        public static string whitelist = "";

        internal static void particlesp(VRCPlayer user, GameObject gameobj)
        {
            int particlescount = 0;
            var pcount = gameobj.GetComponentsInChildren<ParticleSystem>(true);


            for (int i = 0; i < pcount.Length; i++)
            {
                if (pcount[i].maxParticles > nconfig.maxparticles)
                {
                    pcount[i].maxParticles = 0;
                }
            }

            for (int i = 0; i < pcount.Length; i++)
            {
                if (pcount[i].emissionRate > 99)
                {
                    pcount[i].emissionRate = 0;
                }
            }



            if (pcount.Length > nconfig.particlesystem)
            {


                for (int i = 0; i < pcount.Length; i++)
                {
                    Component.DestroyImmediate(pcount[i]);
                }


            }
            else
            if (pcount.Length != 0)
            {
                for (int i = 0; i < pcount.Length; i++)
                {
                    particlescount += pcount[i].particleCount;
                }

                if (particlescount > 50000)
                {
                    for (int i = 0; i < pcount.Length; i++)
                    {
                        Component.DestroyImmediate(pcount[i]);
                    }
                }
            }
          
         }

        internal static bool verticies(VRCPlayer user, GameObject gameobj)
        {
            var Skindemeshrender = gameobj.GetComponentsInChildren<SkinnedMeshRenderer>(true);
            var meshrenders = gameobj.GetComponentsInChildren<MeshFilter>(true);
            int toinc = 0;

            try
            {
                for (int i = 0; i < Skindemeshrender.Length; i++)
                {
                    if (Skindemeshrender[i].sharedMesh.vertexCount > nconfig.maxverticies)
                        return false;
                }
            }
            catch { }

            try
            {
                for (int i = 0; i < meshrenders.Length; i++)
                {
                    toinc += meshrenders[i].sharedMesh.vertexCount;
                }
                if (toinc > nconfig.maxverticies)
                    return false;
            }
            catch { }
       
           

            return true;
        }

        internal static bool meshp(VRCPlayer user, GameObject gameobj)
        {
            var Skindemeshrender = gameobj.GetComponentsInChildren<SkinnedMeshRenderer>(true);
            var meshrenders = gameobj.GetComponentsInChildren<MeshRenderer>(true);


            int maxmaterials = 0;
            foreach (var psys in meshrenders)
            {
                maxmaterials += psys.materials.Length;
            }

            if (meshrenders.Length > nconfig.maxmeshes)
            {
                Style.textdebuger.OnscreenOnly($"AntiCrash H:[{user._player.field_Private_APIUser_0.displayName}]", $"User {user._player.field_Private_APIUser_0.displayName} hiddien by anticrash (Meshes) Meshrenders:[{meshrenders.Length}] ");
                return false;
            }
            if (maxmaterials > 800)
            {
                Style.textdebuger.OnscreenOnly($"AntiCrash H:[{user._player.field_Private_APIUser_0.displayName}]", $"User {user._player.field_Private_APIUser_0.displayName} hiddien by anticrash (Meshes) Giagantic number of materials:[{maxmaterials}] ");
                return false;

            }
            if (Skindemeshrender.Length > nconfig.maxmeshes /1.5f)
            {
                Style.textdebuger.OnscreenOnly($"AntiCrash H:[{user._player.field_Private_APIUser_0.displayName}]", $"User {user._player.field_Private_APIUser_0.displayName} hiddien by anticrash (Meshes) SkindeMeshRenders:[{Skindemeshrender.Length}] ");
                return false;
            }


            foreach (var psys in meshrenders)
                {
                    if (psys.materials.Count < nconfig.maxmaterials)
                    {
                        var a = new List<Material>();
                        a.Add(new Material(Shader.Find("Standard")));
                        psys.materials = a.ToArray();
                    }
                }
            
            
            for (int i = 0; i < Skindemeshrender.Length; i++)
            {
                if (i > 5)
                {
                   if (Skindemeshrender[i].materials.Length > nconfig.maxmaterials * 1.5f)
                    {

                        var a = new List<Material>();
                        a.Add(new Material(Shader.Find("Standard")));
                        Skindemeshrender[i].materials = a.ToArray();
                    }
                }
            }

            return true;
        }

        internal static void Shaderp(VRCPlayer user, GameObject gameobj)
        {

            var trails = gameobj.GetComponentsInChildren<UnityEngine.TrailRenderer>(true);

            if (trails.Length != 0)
            {
                for (int i2 = 0; i2 < trails.Length; i2++)
                {
                    for (int i = 0; i < trails[i2].materials.Length; i++)
                    {
                        bool isbadshader = false;

                        if (trails[i2].materials[i].shader.name.Contains("crash") || trails[i2].materials[i].shader.name.Contains("lag") || trails[i2].materials[i].shader.name.Contains("Crash") || trails[i2].materials[i].shader.name.Contains("Lag"))
                        {
                            Style.Consoles.consolelogger($"Shader Replaced:[{trails[i2].materials[i].shader.name}])");
                            trails[i2].materials[i].shader = Shader.Find("Standard");
                        }

                        var splited = shaderlistst.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);





                        foreach (var checkrole in splited)
                        {

                            var tobc = checkrole.Trim();
                            if (tobc.Length > 3)
                            {
                                if (trails[i2].materials[i].shader.name.Contains(tobc))
                                {
                                    isbadshader = true;
                                }
                            }

                        }


                        if (!isbadshader)
                        {
                            Style.Consoles.consolelogger($"Shader Replaced:[{trails[i2].materials[i].shader.name}])", nconfig.logshaderstoconsole);
                            trails[i2].materials[i].shader = Shader.Find("Standard");
                        }

                        if (trails[i2].materials[i].shader.passCount > 6)
                        {
                            Style.Consoles.consolelogger($"Shader Replaced:[{trails[i2].materials[i].shader.name}])", nconfig.logshaderstoconsole);
                            trails[i2].materials[i].shader = Shader.Find("Standard");

                        }


                    }
                }
            }





            var rendprt = gameobj.GetComponentsInChildren<ParticleSystemRenderer>(true);

            if (rendprt.Length != 0)
            {
                for (int i2 = 0; i2 < rendprt.Length; i2++)
                {
                    for (int i = 0; i < rendprt[i2].materials.Length; i++)
                    {
                        bool isbadshader = false;

                        if (rendprt[i2].materials[i].shader.name.Contains("crash") || rendprt[i2].materials[i].shader.name.Contains("lag") || rendprt[i2].materials[i].shader.name.Contains("Crash") || rendprt[i2].materials[i].shader.name.Contains("Lag"))
                        {
                            if (rendprt[i2].materials[i].shader.name != "Standard")
                            Style.Consoles.consolelogger($"Shader Replaced:[{rendprt[i2].materials[i].shader.name}]", nconfig.logshaderstoconsole);
                            rendprt[i2].materials[i].shader = Shader.Find("Standard");
                        }

                        var splited = shaderlistst.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);





                        foreach (var checkrole in splited)
                        {

                            var tobc = checkrole.Trim();
                            if (tobc.Length > 3)
                            {
                                if (rendprt[i2].materials[i].shader.name.Contains(tobc))
                                {
                                    isbadshader = true;
                                }
                            }

                        }


                        if (!isbadshader)
                        {
                            if (rendprt[i2].materials[i].shader.name != "Standard")
                                Style.Consoles.consolelogger($"Shader Replaced:[{rendprt[i2].materials[i].shader.name}]", nconfig.logshaderstoconsole);
                            rendprt[i2].materials[i].shader = Shader.Find("Standard");
                        }

                        if (rendprt[i2].materials[i].shader.passCount > 6)
                        {
                            if (rendprt[i2].materials[i].shader.name != "Standard")
                                Style.Consoles.consolelogger($"Shader Replaced:[{rendprt[i2].materials[i].shader.name}]", nconfig.logshaderstoconsole);
                            rendprt[i2].materials[i].shader = Shader.Find("Standard");

                        }


                    }
                }
            }

          



             var meshes = gameobj.GetComponentsInChildren<MeshRenderer>(true);

                    for (int i2 = 0; i2 < meshes.Length; i2++)
                    {
                        for (int i = 0; i < meshes[i2].materials.Length; i++)
                    {

                    bool isbadshader = false;

                        if (meshes[i2].materials[i].shader.name.Contains("crash") || meshes[i2].materials[i].shader.name.Contains("lag") || meshes[i2].materials[i].shader.name.Contains("Crash") || meshes[i2].materials[i].shader.name.Contains("Lag"))
                    {
                        if (meshes[i2].materials[i].shader.name != "Standard")
                            Style.Consoles.consolelogger($"Shader Replaced:[{meshes[i2].materials[i].shader.name}]", nconfig.logshaderstoconsole);
                        meshes[i2].materials[i].shader = Shader.Find("Standard");
                        }

                        var splited = shaderlistst.Split(new string[] {"\r", "\n"},StringSplitOptions.RemoveEmptyEntries);

                    



                    foreach (var checkrole in splited)
                        {

                            var tobc = checkrole.Trim();
                        if (tobc.Length > 3)
                        {
                            if (meshes[i2].materials[i].shader.name.Contains(tobc))
                            {
                                isbadshader = true;
                            }
                        }
 
                        }



                        if (!isbadshader)
                    {
                        if (meshes[i2].materials[i].shader.name != "Standard")
                            Style.Consoles.consolelogger($"Shader Replaced:[{meshes[i2].materials[i].shader.name}]", nconfig.logshaderstoconsole);
                        meshes[i2].materials[i].shader = Shader.Find("Standard");
                        }

                        if (meshes[i2].materials[i].shader.passCount > 6)
                    {
                        if (meshes[i2].materials[i].shader.name != "Standard")
                            Style.Consoles.consolelogger($"Shader Replaced:[{meshes[i2].materials[i].shader.name}]", nconfig.logshaderstoconsole);
                        meshes[i2].materials[i].shader = Shader.Find("Standard");

                        }


                    }
                }
            var skindemeshrender = gameobj.GetComponentsInChildren<SkinnedMeshRenderer>(true);

            
                for (int i2 = 0; i2 < skindemeshrender.Length; i2++)
                {
                for (int i = 0; i < skindemeshrender[i2].materials.Length; i++)
                {
                    bool isbadshader2 = false;

                    if (skindemeshrender[i2].materials[i].shader.name.Contains("crash") || skindemeshrender[i2].materials[i].shader.name.Contains("lag") || skindemeshrender[i2].materials[i].shader.name.Contains("Crash") || skindemeshrender[i2].materials[i].shader.name.Contains("Lag"))
                    {
                        if (skindemeshrender[i2].materials[i].shader.name != "Standard")
                            Style.Consoles.consolelogger($"Shader Replaced:[{skindemeshrender[i2].materials[i].shader.name}]", nconfig.logshaderstoconsole);
                        skindemeshrender[i2].materials[i].shader = Shader.Find("Standard");
                    }

                    var splited = shaderlistst.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var checkrole in splited)
                    {

                        var tobc = checkrole.Trim();
                        if (tobc.Length > 3)
                        {
                            if (skindemeshrender[i2].materials[i].shader.name.Contains(tobc))
                            {
                                isbadshader2 = true;
                            }
                        }

                    }


                    if (!isbadshader2)
                    {
                        if (skindemeshrender[i2].materials[i].shader.name != "Standard")
                            Style.Consoles.consolelogger($"Shader Replaced:[{skindemeshrender[i2].materials[i].shader.name}]", nconfig.logshaderstoconsole);
                        skindemeshrender[i2].materials[i].shader = Shader.Find("Standard");
                    }

                    if (skindemeshrender[i2].materials[i].shader.passCount > 6)
                    {
                        if (skindemeshrender[i2].materials[i].shader.name != "Standard")
                            Style.Consoles.consolelogger($"Shader Replaced:[{skindemeshrender[i2].materials[i].shader.name}]",nconfig.logshaderstoconsole);
                        skindemeshrender[i2].materials[i].shader = Shader.Find("Standard");
                    }


                }
            }
        }

        internal static void audiosourcep(VRCPlayer user, GameObject gameobj)
        {
            var audiosources = gameobj.GetComponentsInChildren<AudioSource>(true);
            var audiofiltre = gameobj.GetComponentsInChildren<AvatarAudioSourceFilter>(true);

            if (audiofiltre.Length > nconfig.maxaudiosources)
            {
                for (int i = 0; i < audiofiltre.Length; i++)
                {
                    Component.DestroyImmediate(audiofiltre[i]);
                }
            }



            if (audiosources.Length > nconfig.maxaudiosources)
            {
                for (int i = 0; i < audiosources.Length; i++)
                {
                        Component.DestroyImmediate(audiosources[i]);
                }
                return;
            }


                for (int i = 0; i < audiosources.Length; i++)
            {
                if (audiosources[i].clip == null)
                    Component.DestroyImmediate(audiosources[i]);
            }
            }



        internal static void linerender(VRCPlayer user, GameObject gameobj)
        {
            var linerenders = gameobj.GetComponentsInChildren<LineRenderer>(true);
            if (linerenders.Length > 49)
            {
                for (int i = 0; i < linerenders.Length; i++)
                {
                    Component.DestroyImmediate(linerenders[i]);
                }
                return;
            }

            for (int i = 0; i < linerenders.Length; i++)
            {
                if (linerenders[i].positionCount > 20)
                {
                    Component.DestroyImmediate(linerenders[i]);
                }
            }

        }


        internal static void lights(VRCPlayer user, GameObject gameobj)
        {
            var lights = gameobj.GetComponentsInChildren<Light>(true);
            if (lights.Length > 15)
            {
                for (int i = 0; i < lights.Length; i++)
                {
                    Component.DestroyImmediate(lights[i]);
                }

            }
        }
    }

}
