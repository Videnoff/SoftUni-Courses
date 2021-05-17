function solve() {
    const TASKS = {
        JUNIOR: [' is working on a simple task.'],
        SENIOR: [' is working on a complicated task.',
            ' is taking time off work.',
            ' is supervising junior workers.'
        ],
        MANAGER: [' scheduled a meeting.',
            ' is preparing a quarterly report.',
        ]
    };

    class Employee {
        constructor(name, age, tasks) {
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = tasks;
            this._index = 0;
        }

        work() {
            if (this._index === this.tasks.length) {
                this._index = 0;
            }

            console.log(this.name + this.tasks[this._index]);
            this._index++;
        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary} this month.`);
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age, TASKS.JUNIOR);
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age, TASKS.SENIOR);
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age, TASKS.MANAGER);
            this.divident = 0;
        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary + this.divident} this month.`);
        }
    }

    return {
        Employee,
        Junior,
        Senior,
        Manager
    }
}

const company = solve();
const junior = new company.Junior('Ivan',25);

junior.work();
junior.work();

junior.salary = 5811;
junior.collectSalary();

const senior = new company.Senior('Alex', 31);

senior.work();
senior.work();
senior.work();
senior.work();

senior.salary = 12050;
senior.collectSalary();

const manager = new company.Manager('Tom', 55);

manager.salary = 15000;
manager.collectSalary();
manager.dividend = 2500;
manager.collectSalary();

