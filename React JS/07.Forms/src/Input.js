import React from "react";

const Input = ({id, error, label, value, onBlur, onChange}) => {
    const handleChange = (event) => {
        // console.log('value for validation', event.target.value);
        onChange(event.target.value);
    }
    return (
        <div>
            <label htmlFor={id}>
                {label}:
                <input value={value} id={id} onChange={handleChange} onBlur={onBlur}/>
                {error ? (<div>You have an error    </div>) : null}
            </label>
        </div>
    )
}

export default Input;