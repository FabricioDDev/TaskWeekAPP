using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DB;

namespace DataModel
{
    public class DataFrequency
    {
        public DataFrequency()
        {
            Data = new DataAccess();
        }
        private DataAccess Data;
        public List<Frequency> Listing()
        {
            List<Frequency> List = new List<Frequency>();
            try
            {
                Data.Query("select Id, Descripcion from Frecuencia");
                Data.Read();
                while (Data.ReaderProp.Read())
                {
                    Frequency aux = new Frequency();
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
