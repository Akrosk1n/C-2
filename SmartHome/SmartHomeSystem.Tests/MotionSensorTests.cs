using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.Tests
{
    public class MotionSensorTests
    {
        private TextWriter _originalOut;

        [SetUp]
        public void SetUp()
        {
            _originalOut = Console.Out;
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetOut(_originalOut);
        }

        [Test]
        public void MotionSensor_InheritsDeviceButNotIEnergyConsumer()
        {
            var type = typeof(MotionSensor);
            Assert.IsTrue(typeof(Device).IsAssignableFrom(type), "MotionSensor має наслідувати Device");
            Assert.IsFalse(typeof(IEnergyConsumer).IsAssignableFrom(type),
                "MotionSensor НЕ має реалізувати IEnergyConsumer");
        }

        [Test]
        public void MotionSensor_TurnOn_PrintsCorrectMessage()
        {
            var sensor = new MotionSensor("Тестовий датчик");

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                sensor.TurnOn();

                Assert.IsTrue(sensor.IsOn);
                Assert.That(sw.ToString(), Does.Contain("Тестовий датчик активовано."));
            }
        }

        [Test]
        public void MotionSensor_TurnOff_PrintsCorrectMessage()
        {
            var sensor = new MotionSensor("Тестовий датчик");
            sensor.TurnOn();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                sensor.TurnOff();

                Assert.IsFalse(sensor.IsOn);
                Assert.That(sw.ToString(), Does.Contain("Тестовий датчик деактивовано."));
            }
        }
    }

}
