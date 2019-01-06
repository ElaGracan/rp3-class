using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace Pictute_Tool
{
    class UndoRedo
    {
        public Stack<string> undo;
        public Stack<string> redo;

        public UndoRedo()
        {
            undo = new Stack<string>();
            redo = new Stack<string>();
        }

        public PictureBox Undo()
        {
           PictureBox pb = new PictureBox();
           if(undo.Count > 1)
            {
                redo.Push(undo.Pop());
                
                pb = Program.Deserialize(undo.Peek());
            }
            return pb;
        }

        public PictureBox Redo()
        {
            PictureBox pb = new PictureBox();
            if (redo.Count > 1)
            {
                

                pb = Program.Deserialize(redo.Peek());

                undo.Push(redo.Pop());
            }
            return pb;
        }

        public void MakeSnapshot(PictureBox pb)
        {
            undo.Push(Program.Serialize(pb));

        }

        
    }
}
