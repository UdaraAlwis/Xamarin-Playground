using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFForcefulKeyboardDismiss
{
    /// <summary>
    /// Forcefully push down the keyboard (dismissal)
    /// </summary>
    public interface IForceKeyboardDismissalService
    {
        void DismissKeyboard();
    }
}
