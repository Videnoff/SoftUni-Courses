export function createNavigation(main, nav) {
    const views = {};
    const links = {};

    setupNavigation();

    const navigation = {
        setUserNav,
        registerView,
        goTo,
    };

    return navigation;

    async function goTo(name, ...params) {
        const linkId = Object.entries(links).find(([k, v]) => v == name) || [];
        setActiveNav(linkId[0]);
        
        main.innerHTML = '';
        const section = await views[name](...params);
        main.appendChild(section);
    }

    function registerView(name, section, setup, navId) {
        const view = setup(section, navigation);

        views[name] = view;
        if (navId) {
            links[navId] = name;
        }
    }

    function setupNavigation() {
        setUserNav();
        
        nav.addEventListener('click', (ev) => {
            if (ev.target.tagName == 'A') {
                const viewName = links[ev.target.id];
                if (viewName) {
                    const view = views[viewName];
                    ev.preventDefault();
                    view();
                }
            }
        });
    }

    function setActiveNav(targetId) {
        [...nav.querySelectorAll('a')].forEach(a => (targetId && a.id == targetId) ? a.classList.add('active') : a.classList.remove('active'));
    }


    function setUserNav() {
        if (sessionStorage.getItem('authToken') != null) {
            document.getElementById('user').style.display = 'inline-block';
            document.getElementById('guest').style.display = 'none';
        } else {
            document.getElementById('user').style.display = 'none';
            document.getElementById('guest').style.display = 'inline-block';
        }
    }
}