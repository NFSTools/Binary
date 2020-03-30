namespace Binary.Endscript
{
    public class EndLine
    {
        public string Error { get; set; }
        public string Text { get; set; }
        public int Index { get; set; }
        public string Filename { get; set; }

        public override string ToString()
        {
            return $"{Index} | {Filename} | {Text}";
        }
    }
}