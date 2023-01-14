import React, {useEffect, useState} from "react";

const useCounter = (initialValue) => {
    const [counter, setCounter] = useState(0);

    useEffect(() => {
        document.title = `Counter is ${counter}`
    }, [counter]);

    const handleClick = () => {
        setCounter(counter + 1);
    }

    return {
        counter,
        handleClick
    };
}

export default useCounter;
