function attachEventsListeners() {
    document.getElementById("convert").addEventListener("click", convert);

    function convert() {
        const inputDistance = Number(document.getElementById("inputDistance").value);
        const distanceTypes = {
            mm: 1,
            cm: 10,
            m: 1000,
            km: 1000000,
            in: 25.4,
            ft: 304.8,
            yrd: 914.4,
            mi: 1609344
        };

        const inputType = document.getElementById("inputUnits").value;
        const outputType = document.getElementById("outputUnits").value;

        let result = (inputDistance * distanceTypes[inputType]) / distanceTypes[outputType];

        document.getElementById("outputDistance").value = result;
    }
}