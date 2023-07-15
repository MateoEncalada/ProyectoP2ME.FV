using ProyectoP2ME.FV.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoP2ME.FV
{
    public class InfoRepository
    {
        string _dbPath;
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;
        private async Task Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(_dbPath);

            await conn.CreateTableAsync<InformacionME_FV>();
        }
        public InfoRepository (string dbPath)
        { 
            _dbPath = dbPath; 
        }

        public async Task AddNewInfo(
            /*int NuevaInfoId,*/ string Semestre, string Materia, string NProfesor, string Calificacion, string Descripcion, string Cualidad, string Horario)
        {
            int result = 0;
            try
            {
                await Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(Semestre))
                    throw new Exception("Valid name required");
                

                result = await conn.InsertAsync(new InformacionME_FV { /*IdInfo = NuevaInfoId*/ Semestre=Semestre, Materia = Materia, NombreProfesor = NProfesor,
                Calificacion = Calificacion, Descripcion = Descripcion, Cualidad = Cualidad, Horario = Horario, });


                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, Semestre);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", Semestre, ex.Message);
            }

        }

        public async Task<List<InformacionME_FV>> GetAllPeople()
        {
            // TODO: Init then retrieve a list of Person objects from the database into a list
            try
            {
                await Init();
                return await conn.Table<InformacionME_FV>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<InformacionME_FV>();
        }

    }
}
