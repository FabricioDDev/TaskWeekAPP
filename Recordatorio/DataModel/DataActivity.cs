using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using DomainModel;

namespace DataModel
{
    public class DataActivity
    {
        public DataActivity()
        {
            Data = new DataAccess();
        }
        private DataAccess Data;
        public List<Activity> Listing()
        {
            List<Activity> List = new List<Activity>();
            try
            {
                Data.Query("select A.Id as Id , A.Nombre as Nombre, A.Descripcion as Descripcion, A.Activo as Activo, E.Descripcion as DescripcionEstado, E.Id as Eid, F.Descripcion as DescripcionFrecuencia, F.Id as Fid from Actividad A, Estado E, Frecuencia F where E.Id = A.IdEstado and F.Id = A.IdFrecuencia and A.Activo = 1");
                Data.Read();
                while (Data.ReaderProp.Read())
                {
                    Activity Aux = new Activity();
                    Aux.Id = (int)Data.ReaderProp["Id"];
                    Aux.Name = (string)Data.ReaderProp["Nombre"];
                    Aux.Description = (string)Data.ReaderProp["Descripcion"];
                    Aux.Active = (int)Data.ReaderProp["Activo"];

                    Aux.StateType = new State();
                    Aux.StateType.Description = (string)Data.ReaderProp["DescripcionEstado"];
                    Aux.StateType.Id = (int)Data.ReaderProp["Eid"];

                    Aux.FrequencyType = new Frequency();
                    Aux.FrequencyType.Id = (int)Data.ReaderProp["Fid"];
                    Aux.FrequencyType.Description = (string)Data.ReaderProp["DescripcionFrecuencia"];

                    List.Add(Aux);
                }
                return List;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { Data.Close();}
        }
    
        public void Add(Activity New)
        {
            try
            {
                Data.Query("insert into Actividad (Nombre, Descripcion, IdEstado, IdFrecuencia, Activo) values ( @Name, @Description, @IdState, @IdFrequency, 1)");
                Data.Parameters("@Name", New.Name);
                Data.Parameters("@Description", New.Description);
                Data.Parameters("@IdState", New.StateType.Id);
                Data.Parameters("@IdFrequency", New.FrequencyType.Id);
                Data.Execute();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { Data.Close(); }
        }
        public void Modificate(Activity Mod)
        {
            try
            {
                Data.Query("update Actividad set Nombre = @Nombre, Descripcion = @Descripcion, IdEstado = @IdEstado, IdFrecuencia = @IdFrecuencia where Id = @Id");
                Data.Parameters("@Nombre", Mod.Name);
                Data.Parameters("@Descripcion", Mod.Description);
                Data.Parameters("@IdEstado", Mod.StateType.Id);
                Data.Parameters("@IdFrecuencia", Mod.FrequencyType.Id);
                Data.Parameters("@Id", Mod.Id);
                Data.Execute();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { }
        }
    
        public void LDelete(Activity Repose)
        {
            try
            {
                Data.Query("update Actividad set Activo = 0 where Id = @Id");
                Data.Parameters("@Id", Repose.Id);
                Data.Execute();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { Data.Close(); }
        }
        
    }
}
