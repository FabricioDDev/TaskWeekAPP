using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DB;

namespace DataModel
{
    public class DataState
    {
        public DataState()
        {
            Data = new DataAccess();
        }
        private DataAccess Data;
        public List<State> Listing()
        {
            List<State> List = new List<State>();
            try
            {
                Data.Query("select Id, Descripcion from Estado");
                Data.Read();
                while (Data.ReaderProp.Read())
                {
                    State aux = new State();
                    aux.Id = (int)Data.ReaderProp["Id"];
                    aux.Description = (string)Data.ReaderProp["Descripcion"];
                    List.Add(aux);
                }
                return List;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Data.Close(); }
        }

    }
}
