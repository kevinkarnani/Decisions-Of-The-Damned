using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace TBD_TBG
{
    public class EnemyFileParser
    {
        public static Dictionary<string, Enemy> GlobalEnemies = new Dictionary<string, Enemy>(); //dictionary to hold Enemys based on their ID

        /*
         * This function will parse the CSV containing all the Enemys
         */
        public static void Parser()
        {
            string path = "CSV-Enemies.csv"; //store file path
            FileStream fileStream = new FileStream(path, FileMode.Open); //create File object
            using (StreamReader reader = new StreamReader(fileStream)) //read text
            using (CsvReader csv = new CsvReader(reader)) //parse text as a CSV
            {
                var records = csv.GetRecords<EnemyStats>(); //Get all records in the CSV as a Enumerable of ItemStats
                foreach (EnemyStats record in records)
                {
                    Enemy enemy = new Enemy(record.GetID(), record.GetName(), record.GetDescription(), record.GetDeathDescription()); //create Enemy object
                    enemy.SetAttackChance(record.GetChanceToLightAttack(), record.GetChanceToHeavyAttack(), record.GetChanceToDodge()); //set attributes of Enemy
                    enemy.SetEnemyStat(record.GetAgility(), record.GetAttack(), record.GetHP()); //set physical stats of Enemy
                    GlobalEnemies.Add(record.GetID(), enemy); //append Enemy to dictionary based on ID
                }
            }
        }
    }
}
