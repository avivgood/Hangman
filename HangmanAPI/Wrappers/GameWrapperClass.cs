namespace HangmanAPI.Wrappers
{
    public class GameWrapperClass
    {
        public GameWrapperClass(int gid, string word, int maxTries)
        {
            this.gid = gid;
            this.word = word;
            this.MaxTries = MaxTries;
        }
        public int gid { get; }
        public int MaxTries { get; }

        public string word { get; }
        public bool HasStarted { get; }
        public bool HasEnded { get; }
    }
}
