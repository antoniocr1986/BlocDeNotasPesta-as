using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlocNotasWF
{
    public partial class Pestañas : Form
    {
        public Pestañas()
        {
            InitializeComponent();
        }

        private void nuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crearPestañaConCierre();
        }

        private void crearPestañaConCierre()
        {
            // Crear una nueva pestaña
            TabPage newTabPage = new TabPage("Nueva Pestaña");

            VentanaCompleta pestañaNueva = new VentanaCompleta { Dock = DockStyle.Fill };

            // Crear una instancia del RichTextBox personalizado
            /*CustomRichTextBox customRichTextBox = new CustomRichTextBox
            {
                Dock = DockStyle.Fill // Hacer que el RichTextBox llene la pestaña
            };*/

            // Crear un botón de cierre
            Button closeButton = new Button
            {
                Text = "X",
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                ForeColor = Color.Red,
                FlatStyle = FlatStyle.Flat
            };

            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (s, e) =>
            {
                // Confirmar el cierre
                DialogResult result = MessageBox.Show("¿Estás seguro de que quieres cerrar esta pestaña?",
                                                      "Cerrar pestaña",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    tabControl1.TabPages.Remove(newTabPage);
                }
            };

            // Agregar el botón al encabezado de la pestaña (tab header)
           //newTabPage.Controls.Add(customRichTextBox);
            newTabPage.Controls.Add(closeButton);

            // Posicionar el botón en la esquina superior derecha de la pestaña
            closeButton.Location = new Point(newTabPage.Width - closeButton.Width - 5, 5);

            // Agregar la pestaña al TabControl
            tabControl1.TabPages.Add(newTabPage);
        }
    }
}
