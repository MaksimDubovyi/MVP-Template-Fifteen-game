using System.Runtime.Serialization;
namespace Пятнашки
{
    [DataContract]
    internal class Model : IModel
    {
       
        [DataMember]
        int min = 0;
        [DataMember]
        int sec = 0;
        [DataMember]
        int[] arr = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
      
        public int this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }
        [DataMember]
        public int Min { get { return min; } set { min = value; } }
        [DataMember]
        public int Sec { get { return sec; } set { sec = value; } }
        [DataMember]
        public int ProgressBarValue { get; set; }
        public int[] Save()
        {
            return arr;
        }
        public void Load(int[] ar)
        {
            try
            {
                arr = ar;
            }
            catch (Exception ex) { }
        }
    }
}
   