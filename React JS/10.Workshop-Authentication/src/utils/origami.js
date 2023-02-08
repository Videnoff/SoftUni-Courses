const getOrigami = async (length) => {

    const promise = await fetch(`http://localhost:9999/api/origami?length=${length}`, {
        headers: {
            'Access-Control-Allow-Origin': '*',
        }
    })
    const origamis = await promise.json()

    return origamis;
}

export default getOrigami;