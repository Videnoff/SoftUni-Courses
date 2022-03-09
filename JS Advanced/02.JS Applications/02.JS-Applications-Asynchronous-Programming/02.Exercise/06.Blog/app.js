let viewBtn = document.getElementById('btnViewPost');

function attachEvents() {
    document.getElementById('btnLoadPosts').addEventListener('click', getPosts);
    viewBtn.addEventListener('click', displayPost);
    viewBtn.disabled = true;
}

attachEvents();

async function getPosts() {
    let url = 'http://localhost:3030/jsonstore/blog/posts';
    let response = await fetch(url);
    let data = await response.json();

    let select = document.getElementById('posts');
    select.innerHTML = '';

    Object.values(data).map(createOption).forEach(o => select.appendChild(o));

    viewBtn.disabled = false;
}

function createOption(post) {
    let result = document.createElement('option');
    result.textContent = post.title;
    result.value = post.id;

    return result;
}

function displayPost() {
    // find selected option
    const postId = document.getElementById('posts').value;
    getCommentsByPostId(postId);
}

async function getCommentsByPostId(postId) {
    let commentsUl = document.getElementById('post-comments');
    commentsUl.innerHTML = '';

    let postUrl = 'http://localhost:3030/jsonstore/blog/posts' + postId;

    let commentsUrl = 'http://localhost:3030/jsonstore/blog/comments';

    const [postResponse, commentsResponse] = await Promise.all([
        fetch(postUrl),
        fetch(commentsUrl)
    ]);

    let postData = await postResponse.json();

    document.getElementById('post-title').textContent = postData.title;
    document.getElementById('post-body').textContent = postData.body;

    let commentsData = await commentsResponse.json();

    let comments = Object.values(commentsData).filter(c => c.postId == postId);

    comments.map(createComment).forEach(c => commentsUl.appendChild(c));
}

function createComment(comment) {
    let result = document.createElement('li');
    result.textContent = comment.text;
    result.id = comment.id;
    return result;
}