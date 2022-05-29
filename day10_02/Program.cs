using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//추가해야하는 부분
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//구조체, 클래스 단위로 읽고 쓰기 BinaryFormatter와 [Serializable]
namespace day10_02
{
    [Serializable]
    struct DATA
    {
        public int var01;
        public float var02;
        public string var03;
        public void setdata(int var01, float var02, string var03)
        {
            this.var01 = var01;
            this.var02 = var02;
            this.var03 = var03;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DATA[] Data = new DATA[2];
            Data[0].setdata(1, 0.5f, "test1");
            Data[1].setdata(2, 0.8f, "test2");

            using (FileStream fs1 = new FileStream("test.dat", FileMode.Create))    //쓰기 작업
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs1, Data);
            }

            DATA[] ResultData;

            using(FileStream fs2 = new FileStream("test.dat", FileMode.Open))
            {
                BinaryFormatter bf2 = new BinaryFormatter();
                ResultData = (DATA[])bf2.Deserialize(fs2);
            }

            for(int i = 0; i < ResultData.Length; i++)
            {
                Console.WriteLine("{0} {1} {2}", ResultData[i].var01, ResultData[i].var02, ResultData[i].var03);
            }
        }
    }
}
