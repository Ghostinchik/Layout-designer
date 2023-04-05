using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Компонувальник
{
    internal class LayoutDesigner
    {
        public interface IBicycleComponent
        {
            string GetName();
            double GetPrice();
        }

        // Простий компонент велосипеду
        public class BicycleComponent : IBicycleComponent
        {
            private string name;
            private double price;

            public BicycleComponent(string name, double price)
            {
                this.name = name;
                this.price = price;
            }

            public string GetName()
            {
                name = " Велосипед ";
                return this.name;
            }

            public double GetPrice()
            {
                return this.price;
            }
        }

        // Композитний компонент велосипеду
        public class Composite : IBicycleComponent
        {
            private List<IBicycleComponent> components;

            public Composite()
            {
                components = new List<IBicycleComponent>();
            }

            public void AddComponent(IBicycleComponent component)
            {
                components.Add(component);
            }

            public void RemoveComponent(IBicycleComponent component)
            {
                components.Remove(component);
            }

            public IBicycleComponent FindComponent(string name)
            {
                foreach (IBicycleComponent component in components)
                {
                    if (component.GetName() == name)
                    {
                        return component;
                    }
                }

                return null;
            }

            public string GetName()
            {
                return "Composite";
            }

            public double GetPrice()
            {
                double price = 0;

                foreach (IBicycleComponent component in components)
                {
                    price += component.GetPrice();
                }

                return price;
            }
        }

        // Декоратор компонентів велосипеду
        public abstract class BicycleDecorator : IBicycleComponent
        {
            private IBicycleComponent component;

            public BicycleDecorator(IBicycleComponent component)
            {
                this.component = component;
            }

            public virtual string GetName()
            {
                return component.GetName();
            }

            public virtual double GetPrice()
            {
                return component.GetPrice();
            }
        }

        // Декоратор колес велосипеду
        public class WheelDecorator : BicycleDecorator
        {
            private string name;
            private double price;

            public WheelDecorator(IBicycleComponent component, string name, double price) : base(component)
            {
                this.name = name;
                this.price = price;
            }

            public override string GetName()
            {
                return base.GetName() + " with " + name + " wheels";
            }

            public override double GetPrice()
            {
                return base.GetPrice() + price;
            }
        }

        // Декоратор сидіння велосипеду
        public class SeatDecorator : BicycleDecorator
        {
            private string name;
            private double price;

            public SeatDecorator(IBicycleComponent component, string name, double price) : base(component)
            {
                this.name = name;
                this.price = price;
            }

            public override string GetName()
            {
                return base.GetName() + " with " + name + " seat";
            }

            public override double GetPrice()
            {
                return base.GetPrice() + price;
            }
        }

        //Декоратор керма велосипеда
        public class HandlebarDecorator : BicycleDecorator
        {
            private string name;
            private double price;
            public HandlebarDecorator(IBicycleComponent component, string name, double price) : base(component)
            {
                this.name = name;
                this.price = price;
            }

            public override string GetName()
            {
                return base.GetName() + " with " + name + " handlebars";
            }

            public override double GetPrice()
            {
                return base.GetPrice() + price;
            }
        }
        // Формування складових велосипеду
        public class BicycleBuilder
        {
            private Composite bicycle;
            public BicycleBuilder()
            {
                bicycle = new Composite();
            }

            public void BuildFrame(string frameName, double framePrice)
            {
                BicycleComponent frame = new BicycleComponent(frameName, framePrice);
                bicycle.AddComponent(frame);
            }

            public void BuildWheel(string wheelName, double wheelPrice)
            {
                BicycleComponent wheel = new BicycleComponent(wheelName, wheelPrice);
                bicycle.AddComponent(wheel);
            }

            public void BuildSeat(string seatName, double seatPrice)
            {
                BicycleComponent seat = new BicycleComponent(seatName, seatPrice);
                bicycle.AddComponent(seat);
            }

            public void BuildHandlebar(string handlebarName, double handlebarPrice)
            {
                BicycleComponent handlebar = new BicycleComponent(handlebarName, handlebarPrice);
                bicycle.AddComponent(handlebar);
            }

            public void AddWheelDecorator(string name, double price)
            {
                IBicycleComponent component = bicycle.FindComponent("Wheel");

                if (component != null)
                {
                    WheelDecorator wheelDecorator = new WheelDecorator(component, name, price);
                    bicycle.RemoveComponent(component);
                    bicycle.AddComponent(wheelDecorator);
                }
            }

            public void AddSeatDecorator(string name, double price)
            {
                IBicycleComponent component = bicycle.FindComponent("Seat");

                if (component != null)
                {
                    SeatDecorator seatDecorator = new SeatDecorator(component, name, price);
                    bicycle.RemoveComponent(component);
                    bicycle.AddComponent(seatDecorator);
                }
            }

            public void AddHandlebarDecorator(string name, double price)
            {
                IBicycleComponent component = bicycle.FindComponent("Handlebar");

                if (component != null)
                {
                    HandlebarDecorator handlebarDecorator = new HandlebarDecorator(component, name, price);
                    bicycle.RemoveComponent(component);
                    bicycle.AddComponent(handlebarDecorator);
                }
            }
            public Composite GetBicycle()
            {
                return bicycle;
            }
        }
    }
}
