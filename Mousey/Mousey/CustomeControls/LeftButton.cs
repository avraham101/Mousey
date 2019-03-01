using Xamarin.Forms;

namespace Mousey
{
    public class LeftButton: Button 
    {
        private ConnectionHandler handler = null;
        public LeftButton() : base()
        {
            
        }

        public void SetHandler(ConnectionHandler handler)
        {
            this.handler = handler;
        }

        public void SendMessagge(bool up)
        {
            if (up)
                handler.sendMessage(Message.LeftClickUp);
            else
                handler.sendMessage(Message.LeftClickDown);
        }
    }
}
