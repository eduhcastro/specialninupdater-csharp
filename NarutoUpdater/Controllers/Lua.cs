using System.Text;
using static NarutoUpdater.Controllers.Files;

namespace NarutoUpdater.Controllers
{
    internal class Lua
    {
        private static string Version = "1";
        private static string LuaText = "";
        private static Label? InfoText;
        public static void SetVersion(string version)
        {
           Version = version;
        }

        public static void GetLabel(Label label)
        {
            InfoText = label;
        }

    
        public static void GenerateText(string To, string Path, string Random)
        {

            FileInfo fi = new(To);
            if (fi.Exists)
            {
           //   InfoText.Text = "Lua Generate " + Random;
                RenameFile(Random, To);
                LuaText += "['" + Path[1..] + "']={file='" + Random + "',size=" + fi.Length + ",ver=" + Version + "},\n";
            }

        }

        private static string Concat()
        {
            return "return {\n" + LuaText + "\n}";
        }

        public static void generate(string path)
        {
            string fileName = path+ "/inc_ver.lua";
         // MessageBox.Show(fileName);
            FileInfo fi = new(fileName);

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (fi.Exists)
                {
                    fi.Delete();
                }

                // Create a new file     
                using (StreamWriter sw = fi.CreateText())
                {
                    string[] Explodido = LuaText.Split("},");
                    sw.WriteLine("return {");
                    foreach (string txt in Explodido)
                    {
                        if(txt.Length > 5)
                        {
                            sw.WriteLine(txt+"},");
                        }
                        else
                        {
                            MessageBox.Show("Done! <CastroMS#8830>", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Restart();
                        }
                       
                    }
                    sw.WriteLine("}");

                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}
