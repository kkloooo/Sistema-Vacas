/*
 * Created by SharpDevelop.
 * User: Control
 * Date: 20/07/2013
 * Time: 14:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace EML
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class Animal
	{
		private int id;
        public int Codigo
        {
            get { return id; }
            set { id = value; }
        }
		
		private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
		
		private DateTime fechaNacimiento;
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
		
		private DateTime fechaSalida;
        public DateTime FechaSalida
        {
            get { return fechaSalida; }
            set { fechaSalida = value; }
        }
		
		private string observaciones;
        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }
		
		private bool estado;
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
	}
	
	public class Imagenes
	{
		private int id;
        public int Codigo
        {
            get { return id; }
            set { id = value; }
        }
		
		private int idAnimal;
        public int CodigoAnimal
        {
            get { return idAnimal; }
            set { idAnimal = value; }
        }
		
		private byte[] imagen;
        public byte[] Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
		
		private DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
		
		private string observaciones;
        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }
	}
	
	public class Novedades
	{
		private int id;
        public int Codigo
        {
            get { return id; }
            set { id = value; }
        }
		
		private int idAnimal;
        public int CodigoAnimal
        {
            get { return idAnimal; }
            set { idAnimal = value; }
        }
		
		private string novedad;
        public string Novedad
        {
            get { return novedad; }
            set { novedad = value; }
        }
		
		private DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
	}
}