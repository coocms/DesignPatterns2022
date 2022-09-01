using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsExec
{
    //设计模式之创建型模式
    public class BuildMode
    {
        //单例模式
        public void ShowSingleton()
        {
            var ins = SingletonPattern.GetInstance();
            Console.WriteLine(ins.GetHashCode());
            ins = SingletonPattern.GetInstance();
            Console.WriteLine(ins.GetHashCode());
        }

        //抽象工厂模式
        public void AbstructFactory()
        {
            //AbstructFactory factory = new BydFactory();
            AbstructFactory factory = new PorscheFactory();
            var car = factory.CreateCar();
            var suv = factory.CreateSuv();
        }
        //建造者模式
        public void ShowBuilderMode()
        {
            AbstractBuilder buickBuilder = new BuickBuilder();

            AbstractBuilder audiBuilder = new AoDiBuilder();
            Director director = new Director();

            var car1 = director.Construct(buickBuilder);

            var car2 = director.Construct(audiBuilder);


        }
    }
    #region 单例模式
    public class SingletonPattern
    {
        static SingletonPattern instance = new SingletonPattern();
        static object singletonLock = new object();
        public static SingletonPattern GetInstance()
        {
            return instance;
        }
    }
    #endregion

    #region 抽象工厂


    /// <summary>
    /// 抽象产品 Car
    /// </summary>
    public interface ICar
    {
        public string CarName { get; set; }
    }
    /// <summary>
    /// 抽象产品 SUV
    /// </summary>
    public interface ISuv
    {
        public string SuvName { get; set; }
    }


    /// <summary>
    /// 抽象工厂
    /// </summary>
    public abstract class AbstructFactory
    {
        public abstract ICar CreateCar();
        public abstract ISuv CreateSuv();
    }
    /// <summary>
    ///  具体工厂 BYD
    /// </summary>
    public class BydFactory : AbstructFactory
    {
        public override ICar CreateCar()
        {
            return new BydCar();
        }

        public override ISuv CreateSuv()
        {
            return new BydSuv();
        }
    }

    public class PorscheFactory : AbstructFactory
    {
        public override ICar CreateCar()
        {
            return new PorscheCar();
        }

        public override ISuv CreateSuv()
        {
            return new ProscheSuv();
        }
    }

    /// <summary>
    /// 具体产品
    /// </summary>
    public class BydCar : ICar
    {
        public string CarName { get; set; } = "BYD Car";
    }
    /// <summary>
    /// 具体产品
    /// </summary>
    public class BydSuv : ISuv
    {
        public string SuvName { get; set; } = "Byd Suv";
    }

    public class PorscheCar : ICar
    {
        public string CarName { get; set; } = "Prosche Car";
    }
    public class ProscheSuv : ISuv
    {
        public string SuvName { get; set; } = "Prosche Suv";
    }



    #endregion

    #region 建造者模式
    /// <summary>
    /// 汽车类
    /// </summary>
    public sealed class Car
    {
        // 汽车部件集合
        private IList<string> parts = new List<string>();

        // 把单个部件添加到汽车部件集合中
        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("汽车开始在组装.......");
            foreach (string part in parts)
            {
                Console.WriteLine("组件" + part + "已装好");
            }

            Console.WriteLine("汽车组装好了");
        }
    }
    /// <summary>
    /// 这个类型才是组装的，Construct方法里面的实现就是创建复杂对象固定算法的实现，该算法是固定的，或者说是相对稳定的
    /// 这个人当然就是老板了，也就是建造者模式中的指挥者
    /// </summary>


    public abstract class AbstractBuilder
    {
        // 创建车门
        public abstract void BuildCarDoor();
        // 创建车轮
        public abstract void BuildCarWheel();
        //创建车引擎
        public abstract void BuildCarEngine();
        // 当然还有部件，大灯、方向盘等，这里就省略了

        // 获得组装好的汽车
        public abstract Car GetCar();
    }
    public class Director
    {
        // 组装汽车
        public Car Construct(AbstractBuilder builder)
        {
            builder.BuildCarDoor();
            builder.BuildCarWheel();
            builder.BuildCarEngine();
            return builder.GetCar();
        }
    }
    /// <summary>
    /// 具体创建者，具体的车型的创建者，例如：奥迪
    /// </summary>
    public sealed class AoDiBuilder : AbstractBuilder
    {
        Car aoDiCar = new Car();
        public override void BuildCarDoor()
        {
            aoDiCar.Add("Aodi's Door");
        }

        public override void BuildCarWheel()
        {
            aoDiCar.Add("Aodi's Wheel");
        }

        public override void BuildCarEngine()
        {
            aoDiCar.Add("Aodi's Engine");
        }

        public override Car GetCar()
        {
            return aoDiCar;
        }
    }

    /// <summary>
    /// 具体创建者，具体的车型的创建者，例如：别克
    /// </summary>
    public sealed class BuickBuilder : AbstractBuilder
    {
        Car buickCar = new Car();
        public override void BuildCarDoor()
        {
            buickCar.Add("Buick's Door");
        }

        public override void BuildCarWheel()
        {
            buickCar.Add("Buick's Wheel");
        }

        public override void BuildCarEngine()
        {
            buickCar.Add("Buick's Engine");
        }

        public override Car GetCar()
        {
            return buickCar;
        }
    }
    #endregion
}
