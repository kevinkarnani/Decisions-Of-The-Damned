using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace TBD_TBG
{
    public class EnemyFileParser
    {
        public static Dictionary<string, Enemy> GlobalEnemies = new Dictionary<string, Enemy>();
        public static void Parser()
        {
            string path = "CSV-Enemies.csv";
            FileStream fileStream = new FileStream(path, FileMode.Open);
            using (var reader = new StreamReader(fileStream))
            using (var csv = new CsvReader(reader))
            {
                var records = csv.GetRecords<EnemyStats>();
                foreach (EnemyStats record in records)
                {
                    Enemy enemy = new Enemy(record.GetID(), record.GetName(), record.GetDescription());
                    GlobalEnemies.Add(record.GetID(), enemy);
                    GlobalEnemies[record.GetID()].SetAttackChance(record.GetChanceToLightAttack(), record.GetChanceToHeavyAttack(), record.GetChanceToDodge());
                    GlobalEnemies[record.GetID()].SetEnemyStat(record.GetAgility(), record.GetAttack(), record.GetHP());
                }
            }
        }
    }
}
