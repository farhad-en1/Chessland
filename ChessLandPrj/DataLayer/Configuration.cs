/*

using System.Data.Entity.Migrations;
namespace ChessLandPrj.DataLayer
{
    public class Configuration : DbMigrationsConfiguration<ChLanContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(ChLanContext context)
        {
            base.Seed(context);
        }

    }
}
     public class SimpleDbMigrations
        {
            public static void UpdateDatabaseSchema<T>(string SQLScriptPath = "script.sql") where T : ChLanContext
            {
                var configuration = new Configuration<T>();
                var dbMigrator = new DbMigrator(configuration);
                saveToFile(SQLScriptPath, dbMigrator);
                dbMigrator.Update();
            }

            private static void saveToFile(string SQLScriptPath, DbMigrator dbMigrator)
            {
                if (string.IsNullOrWhiteSpace(SQLScriptPath)) return;

                var scriptor = new MigratorScriptingDecorator(dbMigrator);
                var script = scriptor.ScriptUpdate(sourceMigration: null, targetMigration: null);
                File.WriteAllText(SQLScriptPath, script);
                Console.WriteLine(script);
            }


        }

    */


