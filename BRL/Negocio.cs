using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace BRL
{

	public class Animales : EML.Animal
	{

        private DAL.Acceso _Acceso;
        public DAL.Acceso oDAL
        {
            get { if (_Acceso == null) _Acceso = new DAL.Acceso(); return this._Acceso; }
            set { this._Acceso = value; }
        }

        private List<EML.Imagenes> _Imagenes;
        public List<EML.Imagenes> lImagenes
        {
            get { if (_Imagenes == null)_Imagenes = new List<EML.Imagenes>(); return this._Imagenes; }
            set { _Imagenes = value; }
        }

        public void Alta(EML.Animal oAnimal, List<EML.Imagenes> Imagenes)
        {
            try
            {
                using (SQLiteConnection oConn = oDAL.Conectar())
                {
                    using (SQLiteTransaction oTran = oDAL.Transaccion(oConn))
                    {
                        try
                        {
                            oAnimal.Codigo = oDAL.SiguienteAnimal(oConn, oTran);
                            oDAL.AltaAnimal(oConn, oTran, oAnimal);
                            if (Imagenes.Count > 0)
                            {
                                int siguiente = oDAL.SiguienteImagen(oConn, oTran, oAnimal.Codigo) - 1;
                                foreach (EML.Imagenes item in Imagenes)
                                {
                                    item.CodigoAnimal = oAnimal.Codigo;
                                    item.Codigo = siguiente++;
                                    oDAL.AltaImagen(oConn, oTran, item);
                                }
                            }
                            oTran.Commit();
                        }
                        catch (Exception ex)
                        {
                            oTran.Rollback();
                            throw ex; 
                        }
                    }
                    oConn.Close();
                }
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }
	}
}