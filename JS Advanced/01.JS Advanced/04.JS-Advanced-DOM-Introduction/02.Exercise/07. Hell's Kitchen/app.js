function solve() {
    document.querySelector('#btnSend').addEventListener('click', onClick);

    let inputs = document.querySelector('#inputs textarea');
    let bestRestaurantP = document.querySelector('#bestRestaurant p');
    let workersP = document.querySelector('#workers p');

    function onClick() {
        let splittedInputs = JSON.parse(inputs.value);

        let restData = {};

        splittedInputs.forEach(line => {
            let splittedData = line.split(' - ');
            let restName = splittedData[0];
            let workers = splittedData[1].split(', ');
            let workersArr = [];

            for (let worker of workers) {
                let workersData = worker.split(' ');
                let salary = Number(workersData[1]);

                workersArr.push({
                    name: workersData[0],
                    salary
                })
            }

            if (restData[restName]) {
                workersArr = workersArr.concat(restData[restName].workersArr);
            }

            workersArr.sort((worker1, worker2) => worker2.salary - worker1.salary);
            let bestSalary = workersArr[0].salary;
            let averageSalary = workersArr.reduce((sum, worker) => sum + worker.salary, 0) / workersArr.length;

            restData[restName] = {
                workersArr,
                averageSalary,
                bestSalary
            }
        });

        let bestRestaurantSalary = 0;
        let best = undefined;

        for (let name in restData) {
            if (restData[name].averageSalary > bestRestaurantSalary) {
                best = {
                    name,
                    workersArr: restData[name].workersArr,
                    bestSalary: restData[name].bestSalary,
                    averageSalary: restData[name].averageSalary
                }

                bestRestaurantSalary = restData[name].averageSalary
            }
        }

        bestRestaurantP.textContent = `Name: ${best.name} Average Salary: ${best.averageSalary.toFixed(2)} Best Salary: ${best.bestSalary.toFixed(2)}`;

        let workersResult = [];

        best.workersArr.forEach(w => {
            workersResult.push(`Name: ${w.name} With Salary: ${w.salary}`
            )
        });

        workersP.textContent = workersResult.join(' ');
    }
}