using System;

namespace PrototypePattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");

            sandwichMenu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly");

            Sandwich bltSandwich1 = sandwichMenu["BLT"].Clone() as Sandwich;

            Sandwich pbjSandwich1 = sandwichMenu["PB&J"].Clone() as Sandwich;

            Sandwich bltSandwich2 = sandwichMenu["BLT"].Clone() as Sandwich;
        }
    }
}
