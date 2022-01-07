using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarutoUpdater.Controllers
{
    internal class Files
    {
        private static int CountFiles = 0;
        private static readonly Random random = new();
        private static string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public static void RenameFile(string random, string file)
        {
            FileInfo OLDFILE = new(file);
            OLDFILE.Rename(random + ".g");

        }


        public static void Copy(string sourcePath, string targetPath)
        {

            int fileCount = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories).Length;
            //label3.Text = "[STATUS] Copiando arquivo " + CountFiles + " / " + fileCount;

            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                //MessageBox.Show(newPath.Replace(sourcePath, targetPath));
                CountFiles++;
                //File.Copy(newPath, targetPath);
                //foText.Text = "Copy file " + newPath.Replace(sourcePath, "");
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
                Lua.GenerateText(newPath.Replace(sourcePath, targetPath), newPath.Replace(sourcePath, ""), GenerateRandomString(30));
                //MessageBox.Show(newPath.Replace(sourcePath, "x"));
                if (CountFiles == fileCount)
                {
                   
                    //MessageBox.Show("Enr");
                    Lua.generate(targetPath);
                    //reneameAllFiles(newPath.Replace(sourcePath, ""), targetPath);
                }
            }

        }

        private static void filestoG(string OriginPath, string sDir)
        {

            //List<String> files = toLua(OriginPath, sDir);
            //foreach(string file in files)
            //{
            //    MessageBox.Show(file);
            //}
            //try
            //{
            //    //DirectoryInfo d = new DirectoryInfo(@"C:\DirectoryToAccess");
            //    //FileInfo[] infos = d.GetFiles();
            //    //foreach (FileInfo f in infos)
            //    //{
            //    //    File.Move(f.FullName, f.FullName.Replace("abc_", ""));
            //    //}

            //    foreach (string d in Directory.GetDirectories(sDir))
            //    {

            //        FileInfo[] infos = d.GetFiles();
            //        foreach (FileInfo f in infos)
            //        {
            //            File.Move(f.FullName, f.FullName.Replace("abc_", ""));
            //        }

            //        foreach (FileInfo[] f in Directory.GetFiles(d))
            //        {
            //            CountFilesTwo++;
            //            MessageBox.Show(f);
            //            File.Move(f, f.Replace("*", "TESTE"));
            //            if (CountFiles == CountFilesTwo)
            //            {
            //                MessageBox.Show("Renomenado");
            //                MessageBox.Show(Cmd.Main("cd /D " + sDir + " && for /r %x in (*.*) do ren \"%x\" *.g"));
            //            }
            //        }
            //        reneameAllFiles(d);
            //    }
            //}
            //catch (System.Exception excpt)
            //{
            //    Console.WriteLine(excpt.Message);
            //}

            // ALL TO .G


        }
    }
}
