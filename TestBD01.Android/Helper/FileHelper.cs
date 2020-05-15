using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Essentials;

namespace TestBD01.Droid.Helper
{
    public class FileHelper
    {
        public static string ObtenerRutaLocal(string ElArchivo)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath= Path.Combine(ruta, ElArchivo);
            DBNotExists(ruta, ElArchivo);
            return dbPath;
        }
        
        private async static void DBNotExists(string dbPath, string ElArchivo)

        {
            if (!File.Exists(dbPath))
            {
                if (await PermissionUtils.GetPermission<Permissions.StorageWrite>())
                {
                    try
                    {
                        using (var br = new BinaryReader(Android.App.Application.Context.Assets.Open(ElArchivo)))
                        {
                            using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                            {
                                byte[] buffer = new byte[2048];
                                int length = 0;
                                while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    bw.Write(buffer, 0, length);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Generic error: " + ex.Message);
                    }
                } 
            }
         }
               
    }
}