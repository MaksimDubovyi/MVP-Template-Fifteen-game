

namespace Пятнашки
{

    internal interface IModel
    {
        public int this[int index] { get; set; }
        public int Min { get; set; }
        public int Sec { get; set; }
        public void Load(int[] ar);
        public int[] Save();
        public int ProgressBarValue { get; set; }
    }
}
