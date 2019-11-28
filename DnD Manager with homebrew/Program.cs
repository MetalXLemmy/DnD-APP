using DnD_Equip_screen;
using DnD_Manager.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD_Manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Setup the database
            DBConnector database = new DBConnector();
            database.SetupDB();

            GenerateTestData();

            // Set render options
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Run application
            Application.Run(new CharacterScreen());
        }

        static void GenerateTestData()
        {
            // Test Character Insert
            Models.Character character = new Models.Character
            {
                currentHealth = 10,
                maxHealth = 10,
                currentXP = 0,
                background = "A sad test character",
                gender = "Bytecode",
                name = "Tester"
            };
            int id = character.Insert();
            character.Load(id);
            Console.WriteLine(character.name);
        }
    }

}
