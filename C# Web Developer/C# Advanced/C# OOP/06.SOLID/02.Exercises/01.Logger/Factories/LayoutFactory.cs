using System;
using _01.Logger.Models.Contracts;
using _01.Logger.Models.Layouts;

namespace _01.Logger.Factories
{
    public class LayoutFactory
    {
        public ILayout ProduceLayout(string type)
        {
            ILayout layout;

            if (type == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            else
            {
                throw new ArgumentException("Invalid layout type!");
            }

            return layout;
        }
    }
}