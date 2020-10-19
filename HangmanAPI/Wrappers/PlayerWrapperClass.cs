namespace HangmanAPI.Wrappers
{
    public class PlayerWrapperClass
    {
        public PlayerWrapperClass(int pid, string pname, int win_amt)
        {
            this.pid = pid;
            this.pname = pname;
            this.win_amt = win_amt;
        }
        public int pid { get; }
        public string pname { get; }
        public int win_amt { get; }
    }
}
