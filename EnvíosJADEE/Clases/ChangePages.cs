using System.Windows.Forms;
namespace EnvíosJADEE.Clases
{
    public class ChangePages
    {
        public static void ChangeWindow(Form formToOpen, Form formToClose)
        {
            formToOpen.Show();
            formToClose.Close();
        }
    }
}
