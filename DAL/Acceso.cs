using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.Configuration;

namespace DAL
{
    public class Acceso
    {
        public SQLiteConnection Conectar()
        {
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString.ToString();
                SQLiteConnection oConn = new SQLiteConnection(conexion);
                oConn.Open();
                return oConn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SQLiteTransaction Transaccion(SQLiteConnection oConn)
        {
            try
            {
                SQLiteTransaction oTran = oConn.BeginTransaction();
                return oTran;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Animal

        public void AltaAnimal(SQLiteConnection oConn, SQLiteTransaction oTran, EML.Animal oAnimal)
        {
            string sentencia = "INSERT INTO Animal values(@id, @nombre, @fechaNacimiento, @fechaSalida, @observaciones, @estado)";
            try
            {
                using (SQLiteCommand oCmd = new SQLiteCommand(sentencia, oConn, oTran))
                {
                    //using System.Data; para el tipo Commandtype
                    oCmd.CommandType = CommandType.Text;
                    oCmd.Parameters.Add("@id", DbType.Int32).Value = oAnimal.Codigo;
                    oCmd.Parameters.Add("@nombre", DbType.String).Value = oAnimal.Nombre;
                    oCmd.Parameters.Add("@fechaNacimiento", DbType.DateTime).Value = oAnimal.FechaNacimiento;
                    oCmd.Parameters.Add("@fechaSalida", DbType.DateTime).Value = oAnimal.FechaSalida;
                    oCmd.Parameters.Add("@observaciones", DbType.String).Value = oAnimal.Observaciones;
                    oCmd.Parameters.Add("@estado", DbType.Boolean).Value = oAnimal.Estado;
                    oCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BajaAnimal(SQLiteConnection oConn, SQLiteTransaction oTran, EML.Animal oAnimal)
        {
            string sentencia = "DELETE FROM Animales WHERE id=@id";
            try
            {
                using (SQLiteCommand oCmd = new SQLiteCommand(sentencia, oConn, oTran))
                {
                    //using System.Data; para el tipo Commandtype
                    oCmd.CommandType = CommandType.Text;
                    oCmd.Parameters.Add("@id", DbType.Int32).Value = oAnimal.Codigo;
                    oCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarAnimal(SQLiteConnection oConn, SQLiteTransaction oTran, EML.Animal oAnimal)
        {
            string sentencia = "UPDATE Animal set nombre=@nombre, fechaNacimiento=@fechaNacimiento, fechaSalida@fechaSalida, observaciones=@observaciones, estado=@estado WHERE id=@id)";
            try
            {
                using (SQLiteCommand oCmd = new SQLiteCommand(sentencia, oConn, oTran))
                {
                    //using System.Data; para el tipo Commandtype
                    oCmd.CommandType = CommandType.Text;
                    oCmd.Parameters.Add("@id", DbType.Int32).Value = oAnimal.Codigo;
                    oCmd.Parameters.Add("@nombre", DbType.String).Value = oAnimal.Nombre;
                    oCmd.Parameters.Add("@fechaNacimiento", DbType.DateTime).Value = oAnimal.FechaNacimiento;
                    oCmd.Parameters.Add("@fechaSalida", DbType.DateTime).Value = oAnimal.FechaSalida;
                    oCmd.Parameters.Add("@observaciones", DbType.String).Value = oAnimal.Observaciones;
                    oCmd.Parameters.Add("@estado", DbType.Boolean).Value = oAnimal.Estado;
                    oCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SQLiteDataReader BuscarAnimal(SQLiteConnection oConn, SQLiteTransaction oTran, string filtro)
        {
            SQLiteDataReader dr = null;
            string sentencia = "SELECT * FROM animal " + filtro;
            try
            {
                using (SQLiteCommand oCmd = new SQLiteCommand(sentencia, oConn, oTran))
                {
                    oCmd.CommandType = CommandType.Text;
                    dr = oCmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dr;
        }

        public int SiguienteAnimal(SQLiteConnection oConn, SQLiteTransaction oTran)
        {
            int valor = 0;
            SQLiteDataReader dr = null;
            string sentencia = "SELECT (case when (max(id)) is null then 0 else (max(id)) end)+1 from animal";
            try
            {
                using (SQLiteCommand oCmd = new SQLiteCommand(sentencia, oConn, oTran))
                {
                    oCmd.CommandType = CommandType.Text;
                    dr = oCmd.ExecuteReader();
                }
                while (dr.Read()) valor = Convert.ToInt32(dr[0]);
                dr.Close();
                return valor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Imagenes

        public void AltaImagen(SQLiteConnection oConn, SQLiteTransaction oTran, EML.Imagenes oImagen)
        {
            string sentencia = "INSERT INTO Imagenes values(@id, @idAnimal, @imagen, @fecha, @observaciones)";
            try
            {
                using (SQLiteCommand oCmd = new SQLiteCommand(sentencia, oConn, oTran))
                {
                    //using System.Data; para el tipo Commandtype
                    oCmd.CommandType = CommandType.Text;
                    oCmd.Parameters.Add("@id", DbType.Int32).Value = oImagen.Codigo;
                    oCmd.Parameters.Add("@idAnimal", DbType.Int32).Value = oImagen.CodigoAnimal;
                    oCmd.Parameters.Add("@imagen", DbType.Binary).Value = oImagen.Imagen;
                    oCmd.Parameters.Add("@fecha", DbType.DateTime).Value = oImagen.Fecha;
                    oCmd.Parameters.Add("@observaciones", DbType.String).Value = oImagen.Observaciones;
                    oCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BajaImagen(SQLiteConnection oConn, SQLiteTransaction oTran, EML.Imagenes oImagen)
        {
            string sentencia = "DELETE FROM Imagenes WHERE id=@id";
            try
            {
                using (SQLiteCommand oCmd = new SQLiteCommand(sentencia, oConn, oTran))
                {
                    //using System.Data; para el tipo Commandtype
                    oCmd.CommandType = CommandType.Text;
                    oCmd.Parameters.Add("@id", DbType.Int32).Value = oImagen.Codigo;
                    oCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarImagen(SQLiteConnection oConn, SQLiteTransaction oTran, EML.Imagenes oImagen)
        {
            string sentencia = "Update Imagenes SET idAnimal=@idAnimal, imagen=@imagen, fecha=@fecha, observaciones=@observaciones WHERE id=@id";
            try
            {
                using (SQLiteCommand oCmd = new SQLiteCommand(sentencia, oConn, oTran))
                {
                    //using System.Data; para el tipo Commandtype
                    oCmd.CommandType = CommandType.Text;
                    oCmd.Parameters.Add("@id", DbType.Int32).Value = oImagen.Codigo;
                    oCmd.Parameters.Add("@idAnimal", DbType.Int32).Value = oImagen.CodigoAnimal;
                    oCmd.Parameters.Add("@imagen", DbType.Binary).Value = oImagen.Imagen;
                    oCmd.Parameters.Add("@fecha", DbType.DateTime).Value = oImagen.Fecha;
                    oCmd.Parameters.Add("@observaciones", DbType.String).Value = oImagen.Observaciones;
                    oCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SQLiteDataReader BuscarImagen(SQLiteConnection oConn, SQLiteTransaction oTran, EML.Imagenes oImagen, string filtro)
        {
            SQLiteDataReader dr = null;
            string sentencia = "SELECT * FROM Imagenes " + filtro; ;
            try
            {
                using (SQLiteCommand oCmd = new SQLiteCommand(sentencia, oConn, oTran))
                {
                    oCmd.CommandType = CommandType.Text;
                    dr = oCmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dr;
        }

        public int SiguienteImagen(SQLiteConnection oConn, SQLiteTransaction oTran, int CodAnimal)
        {
            int valor = 0;
            SQLiteDataReader dr = null;
            string sentencia = "SELECT (case when (max(id)) is null then 0 else (max(id)) end)+1 from Imagenes WHERE idAnimal=@idAnimal";
            try
            {
                using (SQLiteCommand oCmd = new SQLiteCommand(sentencia, oConn, oTran))
                {
                    oCmd.CommandType = CommandType.Text;
                    oCmd.Parameters.Add("@idAnimal", DbType.Int32).Value = CodAnimal;
                    dr = oCmd.ExecuteReader();
                }
                while (dr.Read()) valor = Convert.ToInt32(dr[0]);
                dr.Close();
                return valor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
