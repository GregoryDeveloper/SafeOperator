using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace SafeOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkCar>();
        }
    }

    [MemoryDiagnoser]
    public class BenchmarkCar
    {
        Car carNotNull = new Car
        {
            Brand = "Porsche",
            Model = "911 Carrera",
            Height = "150cm",
            Weight = "180kg",
            PlateNumber = "1-AAA-999"
        };

        Car carNull = null;

        string brand = "";
        string model = "";
        string height = "";
        string weight = "";
        string plateNumber = "";

        [Benchmark]
        public void TestWhenCarIsNotNullWithIf()
        {
            if (carNull != null)
            {
                brand = carNotNull.Brand;
                model = carNotNull.Model;
                height = carNotNull.Height;
                weight = carNotNull.Weight;
                plateNumber = carNotNull.PlateNumber;
            }
        }

        [Benchmark]
        public void TestWhenCarIsNotNullWithSafeOperator()
        {
            brand = carNotNull?.Brand;
            model = carNotNull?.Model;
            height = carNotNull?.Height;
            weight = carNotNull?.Weight;
            plateNumber = carNotNull?.PlateNumber;
        }

        [Benchmark]
        public void TestWhenCarIsNullWithIf()
        {
            if (carNull == null)
            {
                brand = null;
                model = null;
                height = null;
                weight = null;
                plateNumber = null;
            }
        }

        [Benchmark]
        public void TestWhenCarIsNullWithSafeOperator()
        {
            brand = carNull?.Brand;
            model = carNull?.Model;
            height = carNull?.Height;
            weight = carNull?.Weight;
            plateNumber = carNull?.PlateNumber;
        }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string PlateNumber { get; set; }
    }
}
