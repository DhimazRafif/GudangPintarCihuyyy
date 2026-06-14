namespace GudangPintarGui.ControllerGui
{
    public class CommandInvoker
    {
        public bool Execute(ICommand command, out string message)
        {
            // Validasi input command (Fail-Fast Principle)
            return command.Execute(out message);
        }
    }
}