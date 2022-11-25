import React from "react";
import Counter from "./Counter";

const Counters = () => {
    const counters = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

    return counters.map((counter, index) => {
        return (
            <Counter key={{index}} counter = {counter} />
        )
    })
}

export default Counters;