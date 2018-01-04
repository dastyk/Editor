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
using Editor.Properties;
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
            renderer = new Renderer(panel1);
            renderer.Init();
            if (Settings.Default.RenderWindowSize != null)
                this.Size = Settings.Default.RenderWindowSize;
        }

        bool rendering = false;
        public void ToggleRender()
        {
            if (rendering)
            {

                rendering = false;
                renderer.Pause();
              
            }
            else
            {
                rendering = true;

                renderer.UpdateSettings(panel1);
                renderer.Start();

            }

        }

        private void RenderWindow_SizeChanged(object sender, EventArgs e)
        {
            if (rendering)
            {

             
                renderer.Pause();
                renderer.UpdateSettings(panel1);
                renderer.Start();

            }
        }
    }
}
