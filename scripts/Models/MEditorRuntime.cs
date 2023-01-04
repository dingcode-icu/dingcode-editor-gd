namespace Model
{
    public class MEditorRuntime
    {
        private static MEditorRuntime _inc;
        public static MEditorRuntime Instance => _inc ?? (_inc = new MEditorRuntime());

        // public void
    }
}