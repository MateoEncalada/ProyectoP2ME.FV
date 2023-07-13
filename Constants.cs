using SQLite;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoP2ME.FV
{
    public class Constants
    {
        private const string DBFileName = "SQLIte.db3";

        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;


        public static string DatabasePath//Propiedad publica para conocer la ruta de almacenamiento del archivo de bd
        {
            get 
            {
                return Path.Combine(FileSystem.AppDataDirectory, DBFileName);
            }
        }
    }
}
 
