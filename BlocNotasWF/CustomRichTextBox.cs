using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;

namespace BlocNotasWF
{
    public class CustomRichTextBox
    {
        private string archivoActual = "nuevoArchivo.txt";
        private FormConfiguracion configuracion = null;
        private string tituloVentana = "Bloc de notas: principal";
        int openFormCount = System.Windows.Forms.Application.OpenForms.Count;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cortarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pegarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fechaYHoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barraDeEstadoToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelWords;
        private System.Windows.Forms.ToolStripMenuItem aumentarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reducirToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelZoom;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolStripMenuItem restablecerZoomOriginalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionarTodoToolStripMenuItem;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.ToolStripMenuItem configurarPáginaToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCodification;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PictureBox pictureBoxConfig;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem deshacerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cortarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pegarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem seleccionarTodoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ortografiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OrtografiaActivarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deshacerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLineaCol;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSpacer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSpacer2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSpacer3;
        private System.Windows.Forms.ToolStripMenuItem nuevaPestañaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaVentanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem1;

        public CustomRichTextBox()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            //this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.configurarPáginaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deshacerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cortarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fechaYHoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.formatoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aumentarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reducirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restablecerZoomOriginalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barraDeEstadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            //this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deshacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cortarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarTodoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ortografiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrtografiaActivarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelLineaCol = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSpacer1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelWords = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSpacer2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelZoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSpacer3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCodification = new System.Windows.Forms.ToolStripStatusLabel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.pictureBoxConfig = new System.Windows.Forms.PictureBox();
            this.nuevaPestañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaVentanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();

            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.menuStrip1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.verToolStripMenuItem
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(544, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaPestañaToolStripMenuItem,
            this.nuevaVentanaToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.toolStripSeparator3,
            this.configurarPáginaToolStripMenuItem,
            this.imprimirToolStripMenuItem,
            this.toolStripSeparator4,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archivoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.archivoToolStripMenuItem.Text = "Achivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.abrirToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.AbrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.guardarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.GuardarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.guardarComoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar como...";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.GuardarComoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(233, 6);
            // 
            // configurarPáginaToolStripMenuItem
            // 
            this.configurarPáginaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.configurarPáginaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.configurarPáginaToolStripMenuItem.Name = "configurarPáginaToolStripMenuItem";
            this.configurarPáginaToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.configurarPáginaToolStripMenuItem.Text = "Configurar página";
            this.configurarPáginaToolStripMenuItem.Click += new System.EventHandler(this.ConfigurarPáginaToolStripMenuItem_Click);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.imprimirToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.ImprimirToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripSeparator4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(233, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.salirToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deshacerToolStripMenuItem1,
            this.toolStripSeparator,
            this.cortarToolStripMenuItem,
            this.copiarToolStripMenuItem,
            this.pegarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.toolStripSeparator1,
            this.buscarToolStripMenuItem,
            this.seleccionarTodoToolStripMenuItem,
            this.fechaYHoraToolStripMenuItem,
            this.toolStripSeparator2,
            this.formatoToolStripMenuItem1,
            this.colorToolStripMenuItem1});
            this.editarToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // deshacerToolStripMenuItem1
            // 
            this.deshacerToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.deshacerToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.deshacerToolStripMenuItem1.Name = "deshacerToolStripMenuItem1";
            this.deshacerToolStripMenuItem1.Size = new System.Drawing.Size(260, 22);
            this.deshacerToolStripMenuItem1.Text = "Deshacer";
            this.deshacerToolStripMenuItem1.Click += new System.EventHandler(this.deshacerToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(257, 6);
            // 
            // cortarToolStripMenuItem
            // 
            this.cortarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.cortarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.cortarToolStripMenuItem.Name = "cortarToolStripMenuItem";
            this.cortarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cortarToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.cortarToolStripMenuItem.Text = "Cortar";
            this.cortarToolStripMenuItem.Click += new System.EventHandler(this.CortarToolStripMenuItem_Click);
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.copiarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.copiarToolStripMenuItem.Text = "Copiar";
            this.copiarToolStripMenuItem.Click += new System.EventHandler(this.CopiarToolStripMenuItem_Click);
            // 
            // pegarToolStripMenuItem
            // 
            this.pegarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.pegarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.pegarToolStripMenuItem.Name = "pegarToolStripMenuItem";
            this.pegarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pegarToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.pegarToolStripMenuItem.Text = "Pegar";
            this.pegarToolStripMenuItem.Click += new System.EventHandler(this.PegarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.eliminarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(257, 6);
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.buscarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.buscarToolStripMenuItem.Text = "Buscar";
            this.buscarToolStripMenuItem.Click += new System.EventHandler(this.BuscarToolStripMenuItem_Click);
            // 
            // seleccionarTodoToolStripMenuItem
            // 
            this.seleccionarTodoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.seleccionarTodoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.seleccionarTodoToolStripMenuItem.Name = "seleccionarTodoToolStripMenuItem";
            this.seleccionarTodoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.seleccionarTodoToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.seleccionarTodoToolStripMenuItem.Text = "Seleccionar todo";
            this.seleccionarTodoToolStripMenuItem.Click += new System.EventHandler(this.SeleccionarTodoToolStripMenuItem_Click);
            // 
            // fechaYHoraToolStripMenuItem
            // 
            this.fechaYHoraToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.fechaYHoraToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.fechaYHoraToolStripMenuItem.Name = "fechaYHoraToolStripMenuItem";
            this.fechaYHoraToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.fechaYHoraToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.fechaYHoraToolStripMenuItem.Text = "Fecha y hora";
            this.fechaYHoraToolStripMenuItem.Click += new System.EventHandler(this.FechaYHoraToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(257, 6);
            // 
            // formatoToolStripMenuItem1
            // 
            this.formatoToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.formatoToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.formatoToolStripMenuItem1.Name = "formatoToolStripMenuItem1";
            this.formatoToolStripMenuItem1.Size = new System.Drawing.Size(260, 22);
            this.formatoToolStripMenuItem1.Text = "Fuente";
            this.formatoToolStripMenuItem1.Click += new System.EventHandler(this.FuenteToolStripMenuItem1_Click);
            // 
            // colorToolStripMenuItem1
            // 
            this.colorToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.colorToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.colorToolStripMenuItem1.Name = "colorToolStripMenuItem1";
            this.colorToolStripMenuItem1.Size = new System.Drawing.Size(260, 22);
            this.colorToolStripMenuItem1.Text = "Color";
            this.colorToolStripMenuItem1.Click += new System.EventHandler(this.ColorToolStripMenuItem1_Click);
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToolStripMenuItem,
            this.barraDeEstadoToolStripMenuItem});
            this.verToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verToolStripMenuItem.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aumentarToolStripMenuItem,
            this.reducirToolStripMenuItem,
            this.restablecerZoomOriginalToolStripMenuItem});
            this.zoomToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // aumentarToolStripMenuItem
            // 
            this.aumentarToolStripMenuItem.Name = "aumentarToolStripMenuItem";
            this.aumentarToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.aumentarToolStripMenuItem.Text = "Aumentar";
            this.aumentarToolStripMenuItem.Click += new System.EventHandler(this.AumentarToolStripMenuItem_Click);
            // 
            // reducirToolStripMenuItem
            // 
            this.reducirToolStripMenuItem.Name = "reducirToolStripMenuItem";
            this.reducirToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.reducirToolStripMenuItem.Text = "Reducir";
            this.reducirToolStripMenuItem.Click += new System.EventHandler(this.ReducirToolStripMenuItem_Click);
            // 
            // restablecerZoomOriginalToolStripMenuItem
            // 
            this.restablecerZoomOriginalToolStripMenuItem.Name = "restablecerZoomOriginalToolStripMenuItem";
            this.restablecerZoomOriginalToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.restablecerZoomOriginalToolStripMenuItem.Text = "Restablecer zoom original";
            this.restablecerZoomOriginalToolStripMenuItem.Click += new System.EventHandler(this.RestablecerZoomOriginalToolStripMenuItem_Click);
            // 
            // barraDeEstadoToolStripMenuItem
            // 
            this.barraDeEstadoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.barraDeEstadoToolStripMenuItem.Checked = true;
            this.barraDeEstadoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.barraDeEstadoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.barraDeEstadoToolStripMenuItem.Name = "barraDeEstadoToolStripMenuItem";
            this.barraDeEstadoToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.barraDeEstadoToolStripMenuItem.Text = "Barra de estado";
            this.barraDeEstadoToolStripMenuItem.Click += new System.EventHandler(this.BarraDeEstadoToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ContextMenuStrip = this.contextMenuStripMain;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Location = new System.Drawing.Point(0, 26);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(544, 285);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deshacerToolStripMenuItem,
            this.cortarToolStripMenuItem1,
            this.copiarToolStripMenuItem1,
            this.pegarToolStripMenuItem1,
            this.eliminarToolStripMenuItem1,
            this.seleccionarTodoToolStripMenuItem1,
            this.ortografiaToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(181, 180);
            // 
            // deshacerToolStripMenuItem
            // 
            this.deshacerToolStripMenuItem.Name = "deshacerToolStripMenuItem";
            this.deshacerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.deshacerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deshacerToolStripMenuItem.Text = "Deshacer";
            this.deshacerToolStripMenuItem.Click += new System.EventHandler(this.deshacerToolStripMenuItem_Click);
            // 
            // cortarToolStripMenuItem1
            // 
            this.cortarToolStripMenuItem1.Name = "cortarToolStripMenuItem1";
            this.cortarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cortarToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.cortarToolStripMenuItem1.Text = "Cortar";
            this.cortarToolStripMenuItem1.Click += new System.EventHandler(this.cortarToolStripMenuItem1_Click);
            // 
            // copiarToolStripMenuItem1
            // 
            this.copiarToolStripMenuItem1.Name = "copiarToolStripMenuItem1";
            this.copiarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copiarToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.copiarToolStripMenuItem1.Text = "Copiar";
            this.copiarToolStripMenuItem1.Click += new System.EventHandler(this.copiarToolStripMenuItem1_Click);
            // 
            // pegarToolStripMenuItem1
            // 
            this.pegarToolStripMenuItem1.Name = "pegarToolStripMenuItem1";
            this.pegarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pegarToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.pegarToolStripMenuItem1.Text = "Pegar";
            this.pegarToolStripMenuItem1.Click += new System.EventHandler(this.pegarToolStripMenuItem1_Click);
            // 
            // seleccionarTodoToolStripMenuItem1
            // 
            this.seleccionarTodoToolStripMenuItem1.Name = "seleccionarTodoToolStripMenuItem1";
            this.seleccionarTodoToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.seleccionarTodoToolStripMenuItem1.Text = "Seleccionar Todo";
            this.seleccionarTodoToolStripMenuItem1.Click += new System.EventHandler(this.seleccionarTodoToolStripMenuItem1_Click);
            // 
            // ortografiaToolStripMenuItem
            // 
            this.ortografiaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OrtografiaActivarToolStripMenuItem});
            this.ortografiaToolStripMenuItem.Name = "ortografiaToolStripMenuItem";
            this.ortografiaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ortografiaToolStripMenuItem.Text = "Corregir ortografía";
            // 
            // OrtografiaActivarToolStripMenuItem
            // 
            this.OrtografiaActivarToolStripMenuItem.Name = "OrtografiaActivarToolStripMenuItem";
            this.OrtografiaActivarToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.OrtografiaActivarToolStripMenuItem.Text = "Activar";
            this.OrtografiaActivarToolStripMenuItem.Click += new System.EventHandler(this.activarToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.statusStrip1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 80, 2);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLineaCol,
            this.toolStripStatusSpacer1,
            this.toolStripStatusLabelWords,
            this.toolStripStatusSpacer2,
            this.toolStripStatusLabelZoom,
            this.toolStripStatusSpacer3,
            this.toolStripStatusLabelCodification});
            this.statusStrip1.Location = new System.Drawing.Point(0, 289);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(544, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelLineaCol
            // 
            this.toolStripStatusLabelLineaCol.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripStatusLabelLineaCol.Name = "toolStripStatusLabelLineaCol";
            this.toolStripStatusLabelLineaCol.Size = new System.Drawing.Size(105, 17);
            this.toolStripStatusLabelLineaCol.Text = "Lin 1, Col 1  ";
            this.toolStripStatusLabelLineaCol.ToolTipText = "Línea , Columna";
            // 
            // toolStripStatusSpacer1
            // 
            this.toolStripStatusSpacer1.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusSpacer1.Name = "toolStripStatusSpacer1";
            this.toolStripStatusSpacer1.Size = new System.Drawing.Size(14, 17);
            this.toolStripStatusSpacer1.Text = "|";
            // 
            // toolStripStatusLabelWords
            // 
            this.toolStripStatusLabelWords.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelWords.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripStatusLabelWords.Margin = new System.Windows.Forms.Padding(0, 3, 20, 2);
            this.toolStripStatusLabelWords.Name = "toolStripStatusLabelWords";
            this.toolStripStatusLabelWords.Size = new System.Drawing.Size(98, 17);
            this.toolStripStatusLabelWords.Text = "Palabras: 0  ";
            // 
            // toolStripStatusSpacer2
            // 
            this.toolStripStatusSpacer2.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusSpacer2.Name = "toolStripStatusSpacer2";
            this.toolStripStatusSpacer2.Size = new System.Drawing.Size(14, 17);
            this.toolStripStatusSpacer2.Text = "|";
            // 
            // toolStripStatusLabelZoom
            // 
            this.toolStripStatusLabelZoom.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelZoom.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabelZoom.Margin = new System.Windows.Forms.Padding(0, 3, 20, 2);
            this.toolStripStatusLabelZoom.Name = "toolStripStatusLabelZoom";
            this.toolStripStatusLabelZoom.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabelZoom.Text = "100%";
            this.toolStripStatusLabelZoom.ToolTipText = "Zoom";
            // 
            // toolStripStatusSpacer3
            // 
            this.toolStripStatusSpacer3.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusSpacer3.Name = "toolStripStatusSpacer3";
            this.toolStripStatusSpacer3.Size = new System.Drawing.Size(14, 17);
            this.toolStripStatusSpacer3.Text = "|";
            // 
            // toolStripStatusLabelCodification
            // 
            this.toolStripStatusLabelCodification.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabelCodification.Name = "toolStripStatusLabelCodification";
            this.toolStripStatusLabelCodification.Size = new System.Drawing.Size(98, 17);
            this.toolStripStatusLabelCodification.Text = "Codificacion:";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // pictureBoxConfig
            // 
            this.pictureBoxConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.pictureBoxConfig.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxConfig.Image")));
            this.pictureBoxConfig.Location = new System.Drawing.Point(505, 0);
            this.pictureBoxConfig.Name = "pictureBoxConfig";
            this.pictureBoxConfig.Size = new System.Drawing.Size(27, 26);
            this.pictureBoxConfig.TabIndex = 3;
            this.pictureBoxConfig.TabStop = false;
            this.pictureBoxConfig.Click += new System.EventHandler(this.pictureBoxConfig_Click);
            // 
            // nuevaPestañaToolStripMenuItem
            // 
            this.nuevaPestañaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.nuevaPestañaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.nuevaPestañaToolStripMenuItem.Name = "nuevaPestañaToolStripMenuItem";
            this.nuevaPestañaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nuevaPestañaToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.nuevaPestañaToolStripMenuItem.Text = "Nueva pestaña";
            this.nuevaPestañaToolStripMenuItem.Click += new System.EventHandler(this.nuevaPestañaToolStripMenuItem_Click);
            // 
            // nuevaVentanaToolStripMenuItem
            // 
            this.nuevaVentanaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.nuevaVentanaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.nuevaVentanaToolStripMenuItem.Name = "nuevaVentanaToolStripMenuItem";
            this.nuevaVentanaToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.nuevaVentanaToolStripMenuItem.Text = "Nueva ventana";
            this.nuevaVentanaToolStripMenuItem.Click += new System.EventHandler(this.nuevaVentanaToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem1
            // 
            this.eliminarToolStripMenuItem1.Name = "eliminarToolStripMenuItem1";
            this.eliminarToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.eliminarToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.eliminarToolStripMenuItem1.Text = "Eliminar";
            this.eliminarToolStripMenuItem1.Click += new System.EventHandler(this.eliminarToolStripMenuItem1_Click);
        }
            public void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
            {
                string abrir;
                openFileDialog1.ShowDialog();

                try
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName);
                    if (openFileDialog1.FileName.Contains(".txt"))
                    {
                        abrir = file.ReadToEnd();
                        richTextBox1.Text = abrir;
                        archivoActual = openFileDialog1.FileName;
                    }
                    else
                    {
                        MessageBox.Show("El archivo elejido ha de ser un .txt");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al abrir archivo: " + ex.Message);
                }
            }

            #region metodos guardar y guardar como...
            public void GuardarToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (archivoActual == "nuevoArchivo.txt")
                {
                    GuardarComoToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    GuardarCambiosEnArchivo(archivoActual);
                }

            }

            public void GuardarCambiosEnArchivo(string nombreArchivo)
            {
                try
                {
                    using (StreamWriter savefile = new StreamWriter(nombreArchivo))
                    {
                        savefile.WriteLine(richTextBox1.Text);
                    }
                    Console.WriteLine("Cambios guardados correctamente en el archivo: " + nombreArchivo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al guardar los cambios: " + ex.Message);
                }
            }

            public void GuardarComoToolStripMenuItem_Click(object sender, EventArgs e)
            {
                saveFileDialog1.FileName = ".txt";
                var save = saveFileDialog1.ShowDialog();
                if (save == DialogResult.OK)
                {
                    using (var savefile = new System.IO.StreamWriter(saveFileDialog1.FileName))
                    {
                        GuardarComoCambiosEnArchivo(saveFileDialog1.FileName);
                        archivoActual = saveFileDialog1.FileName;
                        savefile.WriteLine(richTextBox1.Text);
                    }
                }
            }


            public void GuardarComoCambiosEnArchivo(string nombreArchivo = null)
            {
                string nombreArchivoGuardar = archivoActual;

                try
                {
                    using (StreamWriter savefile = new StreamWriter(nombreArchivoGuardar))
                    {
                        savefile.WriteLine(richTextBox1.Text);
                    }

                    Console.WriteLine("Cambios guardados correctamente en el archivo: " + nombreArchivoGuardar);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al guardar los cambios: " + ex.Message);
                }
            }
            #endregion

            public void ConfigurarPáginaToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
                {
                    //METODO A COMPLETAR AUN
                    /* Podremos modificar la orientación, el tamaño del papel y los márgenes con:
                     pageSetupDialog.Document.DefaultPageSettings.Landscape
                     pageSetupDialog.Document.DefaultPageSettings.PaperSize
                     pageSetupDialog.Document.DefaultPageSettings.Margins*/
                }
            }

            #region metodos imprimir
            public void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
            {
                DialogResult result = printDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    PrintDocument printDocument = new PrintDocument();
                    printDocument.PrintPage += new PrintPageEventHandler(PrintText);
                    printDocument.PrinterSettings = printDialog1.PrinterSettings;
                    printDocument.Print();
                }
            }

            public void PrintText(object sender, PrintPageEventArgs e)
            {
                string textToPrint = richTextBox1.Text;

                System.Drawing.Font font = richTextBox1.Font;
                Brush brush = new SolidBrush(richTextBox1.ForeColor);

                RectangleF bounds = e.MarginBounds;
                e.Graphics.DrawString(textToPrint, font, brush, bounds, StringFormat.GenericTypographic);
            }
            #endregion

            #region metodos seleccionar todo, cortar, copiar y pegar
            public void SeleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.SelectAll();
            }

            private void seleccionarTodoToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                richTextBox1.SelectAll();
            }

            public void CortarToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.Cut();
            }

            public void CopiarToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.Copy();
            }

            public void PegarToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (Clipboard.ContainsText())
                {
                    richTextBox1.Paste();
                }
            }


            private void cortarToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                if (richTextBox1.SelectedText.Length > 0)
                {
                    richTextBox1.Cut();
                }
            }

            private void copiarToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                if (richTextBox1.SelectedText.Length > 0)
                {
                    richTextBox1.Copy();
                }
            }

            private void pegarToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                if (Clipboard.ContainsText())
                {
                    richTextBox1.Paste();
                }
            }
            #endregion

            public void BuscarToolStripMenuItem_Click(object sender, EventArgs e)
            {
                FormBuscar form2 = new FormBuscar();

                form2.ShowDialog();

                string textoBuscado = form2.GetTextBoxData();

                if (!string.IsNullOrWhiteSpace(textoBuscado))
                {
                    int index = 0;
                    int lastIndex = richTextBox1.TextLength;

                    while (index < lastIndex)
                    {
                        index = richTextBox1.Find(textoBuscado, index, lastIndex, RichTextBoxFinds.None);
                        if (index == -1)
                            break;

                        richTextBox1.SelectionBackColor = Color.Yellow;
                        index += textoBuscado.Length;
                    }
                }
            }

            public void FechaYHoraToolStripMenuItem_Click(object sender, EventArgs e)
            {
                DateTime fechaHoraActual = DateTime.Now;
                string fechaHoraString = fechaHoraActual.ToString("yyyy-MM-dd HH:mm:ss");

                richTextBox1.Text = fechaHoraString + "\n" + richTextBox1.Text;
            }

            public void FuenteToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                var formato = fontDialog1.ShowDialog();
                if (formato == DialogResult.OK)
                {
                    richTextBox1.Font = fontDialog1.Font;
                }
            }

            public void ColorToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                var color = colorDialog1.ShowDialog();
                if (color == DialogResult.OK)
                {
                    richTextBox1.ForeColor = colorDialog1.Color;
                }
            }

            #region metodos de Zoom
            public void AumentarToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.ZoomFactor = richTextBox1.ZoomFactor + 0.2F;
                ZoomStatusLabel_Changed(sender, e);

            }

            public void ReducirToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.ZoomFactor = richTextBox1.ZoomFactor - 0.2F;
                ZoomStatusLabel_Changed(sender, e);
            }

            public void RestablecerZoomOriginalToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.ZoomFactor = 1;
                ZoomStatusLabel_Changed(sender, e);
            }

            public void ZoomStatusLabel_Changed(object sender, EventArgs e)
            {
                int valor = Convert.ToInt32(richTextBox1.ZoomFactor * 100);
                toolStripStatusLabelZoom.Text = $" {valor} %";
            }
            #endregion

            #region metodos barra de estado
            public void BarraDeEstadoToolStripMenuItem_Click(object sender, EventArgs e)
            {
                statusStrip1.Visible = !statusStrip1.Visible;
                barraDeEstadoToolStripMenuItem.Checked = !barraDeEstadoToolStripMenuItem.Checked;
            }

            public void RichTextBox1_TextChanged(object sender, EventArgs e)
            {
                int wordCount = richTextBox1.Text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
                toolStripStatusLabelWords.Text = "Palabras: " + wordCount;
                if (wordCount < 10)
                {
                    toolStripStatusLabelWords.Text = toolStripStatusLabelWords.Text + "  ";
                }
                else if (wordCount < 100)
                {
                    toolStripStatusLabelWords.Text = toolStripStatusLabelWords.Text + " ";
                }
            }

        #endregion

            #region metodos salir y cerrar
            public void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                Form closingForm = sender as Form;

                int openFormCount = System.Windows.Forms.Application.OpenForms.Count;

                if (openFormCount > 1)
                {
                    //if (closingForm.Text != tituloVentana)
                    //  e.Cancel = true;
                    //else    
                    //    MessageBox.Show("No se puede cerrar la ventana principal mientras tengas otras ventanas abiertas en la aplicación, actualmente tienes abiertas " + openFormCount + " ventanas.");
                }
                else
                {
                    if (e.CloseReason == CloseReason.UserClosing)
                    {
                        DialogResult result = MessageBox.Show("¿Quiere cerrar sin guardar?",
                                                              "Cerrar aplicación",
                                                              MessageBoxButtons.YesNoCancel,
                                                              MessageBoxIcon.Question);

                        if (result == DialogResult.No)
                        {
                            e.Cancel = true;
                            GuardarToolStripMenuItem_Click(sender, e);
                        }
                        else if (result == DialogResult.Yes)

                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }

            public void SalirToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Environment.Exit(0);
            }
            #endregion

            private void pictureBoxConfig_Click(object sender, EventArgs e)
            {
                if (configuracion == null || configuracion.IsDisposed)
                {
                    MainForm mainform = new MainForm();
                    configuracion = new FormConfiguracion(mainform);

                    configuracion.Show();
                }
                else
                {
                    configuracion.BringToFront();
                }

            }

            private void deshacerToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (richTextBox1.CanUndo)
                {
                    richTextBox1.Undo();
                }
            }
        #region métodosOrtografia

        public void activarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckSpelling(richTextBox1);
        }

        private void CheckSpelling(RichTextBox richTextBox)
        {
            // Crear una instancia de la aplicación de Word
            Word.Application wordApp = new Word.Application();
            wordApp.Visible = false; // Hacer que Word sea invisible

            // Crear un nuevo documento
            Word.Document document = wordApp.Documents.Add();

            // Poner el texto del RichTextBox en el documento
            document.Content.Text = richTextBox.Text;

            // Revisar la ortografía del documento
            document.CheckSpelling();

            // Obtener el texto corregido
            string correctedText = document.Content.Text;

            // Colocar el texto corregido de vuelta en el RichTextBox
            richTextBox.Text = correctedText;

            // Cerrar el documento sin guardar cambios
            document.Close(false);

            // Cerrar la aplicación de Word
            wordApp.Quit();

            // Liberar recursos
            System.Runtime.InteropServices.Marshal.ReleaseComObject(document);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);

            MessageBox.Show("Revisión ortográfica completa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region metodosEliminar
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eliminarTexto(sender, e);
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            eliminarTexto(sender, e);
        }

        public void eliminarTexto(object sender, EventArgs e)
        {
            // Eliminar el texto seleccionado en el RichTextBox
            if (!string.IsNullOrEmpty(this.richTextBox1.SelectedText))
            {
                this.richTextBox1.SelectedText = "";
            }
        }
        #endregion

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            // Obtener la posición actual del cursor
            int index = richTextBox1.SelectionStart;
            int line = richTextBox1.GetLineFromCharIndex(index);
            int firstCharIndex = richTextBox1.GetFirstCharIndexFromLine(line);
            int column = index - firstCharIndex;

            // Mostrar la información en una etiqueta
            toolStripStatusLabelLineaCol.Text = $"Ln {line + 1}, Col {column + 1}";
            if (line + 1 < 10)
            {
                toolStripStatusLabelLineaCol.Text = toolStripStatusLabelLineaCol.Text + "  ";
            }
            else if (line + 1 < 100)
            {
                toolStripStatusLabelLineaCol.Text = toolStripStatusLabelLineaCol.Text + " ";
            }
            if (column + 1 < 10)
            {
                toolStripStatusLabelLineaCol.Text = toolStripStatusLabelLineaCol.Text + "  ";
            }
            else if (column + 1 < 100)
            {
                toolStripStatusLabelLineaCol.Text = toolStripStatusLabelLineaCol.Text + " ";
            }
        }
        private void nuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevaVentanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm mainform2 = new MainForm();
            mainform2.Show();
        }
    }
}
