using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace TBD_TBG.Combat_system
{
    public class EnemyFileParser
    {
        public static void Parser()
        {
            string path = "CSV-Enemies.csv";
            FileStream fileStream = new FileStream(path, FileMode.Open);
            using (var reader = new StreamReader(fileStream))
            using (var csv = new CsvReader(reader))
            {
                var records = csv.GetRecords<EnemyStats>();
                List<EnemyStats> Enemies = new List<EnemyStats>();
                foreach (EnemyStats record in records)
                {
                    Enemies.Add(record);
                }
            }
        }
    }
}
