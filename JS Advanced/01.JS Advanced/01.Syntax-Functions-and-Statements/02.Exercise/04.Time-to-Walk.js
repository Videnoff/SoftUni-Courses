function solve(...params) {
    let steps = params[0];
    let footprintLength = params[1];

    let speed = params[2] * 1000 / (60 * 60);
    let distance = steps * footprintLength;
    let breaks = Math.floor(distance / 500) * 60;
    let totalTime = distance / speed + breaks;

    let minutes = Math.floor(totalTime / 60).toFixed(0).padStart(2, '0');
    let hours = Math.floor(minutes / 60).toFixed(0).padStart(2, '0');
    let seconds = Number(totalTime % 60).toFixed(0).padStart(2, '0');

    return `${hours}:${minutes}:${seconds}`;
}

console.log(solve(4000, 0.60, 5));
console.log(solve(2564, 0.70, 5.5));