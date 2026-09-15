(function () {
    var toggle = document.getElementById('navToggle');
    var sidebar = document.getElementById('sidebar');

    if (toggle && sidebar) {
        toggle.addEventListener('click', function () {
            var isOpen = sidebar.classList.toggle('open');
            toggle.setAttribute('aria-expanded', isOpen ? 'true' : 'false');
        });

        sidebar.querySelectorAll('.file-link').forEach(function (link) {
            link.addEventListener('click', function () {
                sidebar.classList.remove('open');
                toggle.setAttribute('aria-expanded', 'false');
            });
        });
    }

    var yearEl = document.getElementById('year');
    if (yearEl) {
        yearEl.textContent = new Date().getFullYear();
    }

    var links = document.querySelectorAll('.file-link');
    var sections = Array.from(links)
        .map(function (link) { return document.getElementById(link.dataset.target); })
        .filter(Boolean);

    if (sections.length && 'IntersectionObserver' in window) {
        var observer = new IntersectionObserver(function (entries) {
            entries.forEach(function (entry) {
                if (entry.isIntersecting) {
                    links.forEach(function (link) {
                        link.classList.toggle('active', link.dataset.target === entry.target.id);
                    });
                }
            });
        }, { rootMargin: '-40% 0px -55% 0px', threshold: 0 });

        sections.forEach(function (section) { observer.observe(section); });
    }
})();