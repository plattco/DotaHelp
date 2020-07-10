using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;
using Xamarin.Essentials;
using System.Reflection;

namespace DotaHelp
{
    public class DB
    {
        private static string DBName = "log.db";
        public static SQLiteConnection conn;
        public static void OpenConnection()
        {
            string libFolder = FileSystem.AppDataDirectory;
            string fname = System.IO.Path.Combine(libFolder, DBName);
            conn = new SQLiteConnection(fname);
            conn.CreateTable<Matches>();
        }

        public static void DeleteTableContents(string tableName)
        {
            int v = conn.Execute("DELETE FROM " + tableName);
        }

        public static void RepopulateTables()
        {
            LoadMatches();
        }
        public static void LoadMatches()
        {
            try
            {
                DeleteTableContents("matches");
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("DotaHelp.log.txt");
                StreamReader input = new StreamReader(stream);
                while (!input.EndOfStream)
                {
                    string line = input.ReadLine();
                    Matches matches = Matches.ParseCSV(line);
                    conn.Insert(matches);
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
