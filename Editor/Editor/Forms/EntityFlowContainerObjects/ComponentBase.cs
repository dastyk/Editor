using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Forms.EntityFlowContainerObjects
{
    public delegate void DeleteEventHandler(object sender);
    public interface ComponentBase
    {
        ManagerBase GetManager();
        void Added();
        void ReadInfo();
        void RegisterDelete(DeleteEventHandler deleteEventHandler);

    }
}
