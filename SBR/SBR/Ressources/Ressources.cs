using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SBR.Ressources
{
    public class Ressources
    {
        public static Stream GetSampleFromRessources(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            Stream retour = null;
            try
            {
                var test = assembly.GetManifestResourceNames();
                retour = assembly.GetManifestResourceStream("SBR.Ressources.Samples." + filename);
            }
            catch (Exception ex)
            {

            }
            return retour;
        }

        public static string GetJSONFromRessources(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            string retour = string.Empty;
            try
            {
                var stream = assembly.GetManifestResourceStream("SBR.Ressources." + filename);
                using (StreamReader sr = new StreamReader(stream))
                {
                    while (!sr.EndOfStream)
                    {
                        retour += sr.ReadLine();
                    }
                }
                stream.Close();
            }
            catch (Exception e)
            { }
            return retour;
        }
    }
}