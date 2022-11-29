const getGithubData = async () => {
    const githubDataPromise = await fetch('https://api.github.com/users/k1r1L');
    const data = await githubDataPromise.json();

    return data;
}

export default getGithubData;
