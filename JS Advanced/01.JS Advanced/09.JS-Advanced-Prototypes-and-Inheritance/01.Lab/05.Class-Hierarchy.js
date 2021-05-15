function solve() {

    class Figure {
        constructor(unit = 'cm') {
            this.unit = unit;
        }
        changeUnits(newUnit) {
            this.unit = newUnit;
        }

        calcUnit(num) {
            let units = {
                m: 0.01,
                cm: 1,
                mm: 10,
            }
            return num * units[this.unit];
        }
    }

    class Circle extends Figure {
        constructor(radius, unit) {
            super(unit);
            this.radius = radius;
        }
        get area() {
            return (Math.PI * this.calcUnit(this.radius) ** 2);
        }
        toString() {
            return `Figures units: ${this.unit} Area: ${this.area} - radius: ${this.calcUnit(this.radius)}`
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, unit) {
            super(unit);
            this.width = width;
            this.height = height;
        }
        get area() {
            return (this.calcUnit(this.height) * this.calcUnit(this.width));
        }
        toString() {
            return `Figures units: ${this.unit} Area: ${this.area} - width: ${this.calcUnit(this.width)}, height: ${this.calcUnit(this.height)}`
        }
    }

    return {
        Figure,
        Circle,
        Rectangle
    }

}


let classes = solve();
let Figure = classes.Figure;
let Rectangle = classes.Rectangle;
let Circle = classes.Circle;

let c = new Circle(5);
console.log(c.area); // 78.53981633974483
console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

let r = new Rectangle(3, 4, 'mm');
console.log(r.area); // 1200
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50