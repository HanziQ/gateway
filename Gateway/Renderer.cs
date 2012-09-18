
namespace Gateway
{
    public class Renderer
    {
        #region ASCII

        public static char S_TOPLEFT = (char)218;

        #endregion

        private string _title = "";
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                Render();
            }
        }

        private string _body = "";
        public string Body
        {
            get
            {
                return _body;
            }
            set
            {
                _body = value;
                Render();
            }
        }

        private string _prompt = "";
        public string Prompt
        {
            get
            {
                return _prompt;
            }
            set
            {
                _prompt = value;
                Render();
            }
        }

        public void Render()
        {

        }
    }
}
