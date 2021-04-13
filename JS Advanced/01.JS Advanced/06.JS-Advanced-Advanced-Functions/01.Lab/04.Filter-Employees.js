function solve(inputData, criteria) {
    let data = JSON.parse(inputData);

    let criteriaType = criteria.split('-')[0];
    let criteriaValue = criteria.split('-')[1];
    let num = 0;
    if (criteria === 'all') {
        data.forEach(person => {
            console.log(num + '. ' + personToString.call(person));
            num++;
        });
    } else {
        data.forEach(person => {
            if (person[criteriaType] === criteriaValue) {
                console.log(num + '. ' + personToString.call(person));
                num++;
            }
        });
    }

    function personToString() {
        return `${this.first_name} ${this.last_name} - ${this.email}`;
    }
}

solve(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`,
    'gender-Female');

solve(`[{
    "id": "1",
    "first_name": "Kaylee",
    "last_name": "Johnson",
    "email": "k0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Johnson",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  }, {
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }, {
    "id": "4",
    "first_name": "Evanne",
    "last_name": "Johnson",
    "email": "ev2@hostgator.com",
    "gender": "Male"
  }]`,
    'last_name-Johnson');