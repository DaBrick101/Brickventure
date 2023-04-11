using Brickventure_Library_0._1;
using System;
using System.Windows.Forms;

namespace Brickventure_WinFormsApp
{
    public class WriteMessageToGUI : IOutputMessageWriter
    {
        private readonly BrickventureForm _form;

        public WriteMessageToGUI(BrickventureForm form)
        {
            _form = form;
        }

        public void Write(string message)
        {

            _form.GetTextBox().Invoke(new MethodInvoker(delegate
            {
                _form.GetTextBox().Text = string.Format(message);
            }));
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public string GetMessage()
        {
            throw new NotImplementedException();
        }
    }
}
