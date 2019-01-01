using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictute_Tool
{
    class UndoRedo
    {
        public Stack<Object> undo;
        public Stack<Object> redo;

        UndoRedo()
        {
            undo = new Stack<object>();
            redo = new Stack<object>();
        }

        public void Undo()
        {

        }
    }
}
