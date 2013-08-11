/*
 * Created by SharpDevelop.
 * User: Control
 * Date: 20/07/2013
 * Time: 14:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Vacas
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class Principal : Form
	{
		public Principal()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

        void AltaToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAltaAnimal"] == null)     //Si no esta abierta la ventana, abro la ventana
            {
                frmAltaAnimal frmAnimal = new frmAltaAnimal();
                frmAnimal.MdiParent = this;
                frmAnimal.Show();
            }
            else Application.OpenForms["frmAltaAnimal"].Activate();
        }
	}
}
