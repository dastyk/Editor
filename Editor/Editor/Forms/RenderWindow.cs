using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Importer;
namespace Editor.Forms
{
    public partial class RenderWindow : Form
    {
        Utilities.EditorWrapper wrapper;
        public Renderer renderer;
        public RenderWindow(Utilities.EditorWrapper wrapper)
        {
            InitializeComponent();
            this.wrapper = wrapper;
            renderer = new Renderer(this);


        }

        private void RenderWindow_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                renderer.Start();
            else
               renderer.Pause();
        }
    }
}
