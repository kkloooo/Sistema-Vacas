/*
 * Created by SharpDevelop.
 * User: Control
 * Date: 20/07/2013
 * Time: 15:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Drawing.Imaging;

namespace Vacas
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class frmAltaAnimal : Form
	{
		public frmAltaAnimal()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

            //pbImagen.Visible = false;
            dgvLista.Visible = false;
		}

        private BRL.Animales _rAnimales;
        public BRL.Animales rAnimal
        {
            get { if (_rAnimales == null) _rAnimales = new BRL.Animales(); return this._rAnimales; }
            set { this._rAnimales = value; }
        }

        public static Image ByteImagen(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            return Image.FromStream(ms);
        }

        public static byte[] ImagenByte(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            rAnimal.Nombre = txtNombre.Text;
            rAnimal.FechaNacimiento = DateTime.Parse(dtpFechaNacimiento.Text);
            rAnimal.FechaSalida = DateTime.Parse(dtpFechaSalida.Text);
            rAnimal.Observaciones = txtObservaciones.Text;
            rAnimal.Estado = chkEstado.Checked;
            try
            {
                rAnimal.Alta(rAnimal, rAnimal.lImagenes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Archivo JPG|*.jpg";

            if (file.ShowDialog() == DialogResult.OK)
            {
                EML.Imagenes img = new EML.Imagenes();
                img.Fecha = DateTime.Today;
                img.Imagen = ImagenByte(Image.FromFile(file.FileName));
                img.Observaciones = "Acavaunacajaviteh;";
                rAnimal.lImagenes.Add(img);
                pbImagen.Image = Image.FromFile(file.FileName); 
            }
            dgvImagenes.DataSource = rAnimal.lImagenes;
        }
	}   
}
