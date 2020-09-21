
using System;
using System.Threading;
using System.Threading.Tasks;
using static SnowFlake.Snow;

namespace SnowFlake
{
    class Program
    {
        static void Main(string[] args)
        {
            // (new DateTime(2020, 2, 2).ToUniversalTime() - new DateTime(1970, 1, 1).TotalMilliseconds());
            // var Jan1st1970 = new DateTime(1970, 1, 1,0,0,0,DateTimeKind.Utc).ToUniversalTime();
            // var timestamp1 = (new DateTime(2020, 2, 2).ToUniversalTime() - Jan1st1970).TotalMilliseconds;
            // var ts= new DateTime(2020, 2, 2).ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            // string timestamp = Convert.ToInt64(ts.TotalMilliseconds).ToString();
            var dt1 = DateTime.Now;
            SnowFlakeId1 snow = new SnowFlakeId1(666);
            SnowFlakeId snowFlakeId = new SnowFlakeId(1, 20);
            for (int i = 1; i < 100_000; i++)
            {
              
                Task.Run(() => {

                   
                    var snowid = snow.NextId();
                   // Console.WriteLine("不带数据中心"+ snowid);
                    Console.WriteLine("不带数据中心解析" + snowid +"--"+ SnowFlakeId1.AnalyzeId(snowid));
                 
                    var snowid1 = snowFlakeId.NextId();
                   // Console.WriteLine("^^带数据中心"+ snowid1);
                    Console.WriteLine("^^带数据中心解析" + snowid1+"--"+ SnowFlakeId.AnalyzeId(snowid1));
                });
              
               
            }
          Task.Run(()=> {
                var dt2 = (DateTime.Now - dt1).TotalMilliseconds;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("生成20W个snowID用时：" + dt2.ToString());

            });
            
            Console.ReadLine();
        }
    }
}
