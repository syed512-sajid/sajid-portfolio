(function () {

    // =========================================================
    // PORTFOLIO LOADER — minimum display time + smooth fade-out
    // =========================================================
    var MIN_LOADER_MS = 3500;
    var MAX_LOADER_MS = 15000;
    var FADE_MS = 600;
    var BLAZOR_CHECK_INTERVAL = 50;
    var MAX_BLAZOR_CHECKS = 200;

    var startTime = Date.now();
    var hidden = false;

    function hideLoader(reason) {
        if (hidden) return;
        hidden = true;

        if (reason) {
            console.warn('[portfolio-loader] hidden via: ' + reason);
        }

        var loader = document.getElementById('portfolioLoader');
        if (!loader) return;

        loader.classList.add('fade-out');

        setTimeout(function () {
            loader.remove();
        }, FADE_MS);
    }

    setTimeout(function () {
        hideLoader('MAX_LOADER_MS timeout — Blazor never finished starting, check console/network tab');
    }, MAX_LOADER_MS);

    function startBlazorAndWait(checkCount) {
        checkCount = checkCount || 0;

        if (typeof Blazor === 'undefined') {
            if (checkCount >= MAX_BLAZOR_CHECKS) {
                console.error('[portfolio-loader] Blazor object never appeared. Check that _framework/blazor.webassembly.js is loading (Network tab).');
                hideLoader('blazor script never loaded');
                initSiteBehaviour();
                return;
            }
            setTimeout(function () { startBlazorAndWait(checkCount + 1); }, BLAZOR_CHECK_INTERVAL);
            return;
        }

        Blazor.start().then(function () {
            var elapsed = Date.now() - startTime;
            var remaining = Math.max(MIN_LOADER_MS - elapsed, 0);

            setTimeout(function () { hideLoader('blazor started normally'); }, remaining);

            initSiteBehaviour();
        }).catch(function (err) {
            console.error('Blazor failed to start:', err);
            hideLoader('blazor start() rejected');
            initSiteBehaviour();
        });
    }

    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', function () { startBlazorAndWait(0); });
    } else {
        startBlazorAndWait(0);
    }


    // =========================================================
    // EXISTING SITE BEHAVIOUR (sidebar nav, active-section highlight)
    // =========================================================
    var behaviourInitialised = false;

    function initSiteBehaviour() {
        if (behaviourInitialised) return;
        behaviourInitialised = true;

        document.addEventListener('click', function (e) {
            var toggle = document.getElementById('navToggle');
            var sidebar = document.getElementById('sidebar');
            if (!toggle || !sidebar) return;

            if (toggle.contains(e.target)) {
                var isOpen = sidebar.classList.toggle('open');
                toggle.setAttribute('aria-expanded', isOpen ? 'true' : 'false');
                return;
            }

            if (sidebar.contains(e.target) && e.target.closest('.file-link')) {
                sidebar.classList.remove('open');
                toggle.setAttribute('aria-expanded', 'false');
            }
        });

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
    }

})();


// =========================================================
// --new: JS LIGHTBOX — sirf project DETAIL page ke eye button
// se use hota hai. Bari image + /- zoom controls ke sath.
// window level pe define hai isliye Blazor render se pehle/baad
// dono halaat mein available rehta hai.
// =========================================================

window.Lightbox = (function () {
    var overlay, imgEl, counterEl, prevBtn, nextBtn, zoomLevelEl;
    var images = [];
    var activeIndex = 0;
    var zoom = 1;
    var MIN_ZOOM = 1;
    var MAX_ZOOM = 3;
    var ZOOM_STEP = 0.5;

    function build() {
        if (overlay) return;

        overlay = document.createElement('div');
        overlay.className = 'lightbox-overlay';
        overlay.style.display = 'none';

        overlay.innerHTML =
            '<button class="lightbox-close" aria-label="Close">✕</button>' +
            '<button class="lightbox-nav lightbox-prev" aria-label="Previous image">‹</button>' +
            '<img class="lightbox-img" alt="" />' +
            '<button class="lightbox-nav lightbox-next" aria-label="Next image">›</button>' +
            '<span class="gallery-counter lightbox-counter"></span>' +
            '<div class="lightbox-zoom-controls">' +
            '<button class="lightbox-zoom-btn" data-action="out" aria-label="Zoom out">−</button>' +
            '<span class="lightbox-zoom-level">100%</span>' +
            '<button class="lightbox-zoom-btn" data-action="in" aria-label="Zoom in">+</button>' +
            '</div>' +
            '<span class="lightbox-hint">Use +/- to zoom, or click image</span>';

        document.body.appendChild(overlay);

        imgEl = overlay.querySelector('.lightbox-img');
        counterEl = overlay.querySelector('.lightbox-counter');
        prevBtn = overlay.querySelector('.lightbox-prev');
        nextBtn = overlay.querySelector('.lightbox-next');
        zoomLevelEl = overlay.querySelector('.lightbox-zoom-level');

        overlay.querySelector('.lightbox-close').addEventListener('click', close);
        prevBtn.addEventListener('click', function (e) { e.stopPropagation(); prev(); });
        nextBtn.addEventListener('click', function (e) { e.stopPropagation(); next(); });
        overlay.querySelector('[data-action="in"]').addEventListener('click', function (e) { e.stopPropagation(); zoomIn(); });
        overlay.querySelector('[data-action="out"]').addEventListener('click', function (e) { e.stopPropagation(); zoomOut(); });

        overlay.addEventListener('click', function (e) {
            if (e.target === overlay) close();
        });
        imgEl.addEventListener('click', function () {
            zoom = zoom > MIN_ZOOM ? MIN_ZOOM : 2;
            applyZoom();
        });

        document.addEventListener('keydown', function (e) {
            if (!overlay || overlay.style.display === 'none') return;
            if (e.key === 'Escape') close();
            if (e.key === 'ArrowLeft') prev();
            if (e.key === 'ArrowRight') next();
            if (e.key === '+') zoomIn();
            if (e.key === '-') zoomOut();
        });
    }

    function render() {
        imgEl.onerror = function () {
            imgEl.onerror = null;
            imgEl.src = 'images/projects/placeholder.png';
        };
        imgEl.src = images[activeIndex];

        var multi = images.length > 1;
        prevBtn.style.display = multi ? 'flex' : 'none';
        nextBtn.style.display = multi ? 'flex' : 'none';
        counterEl.style.display = multi ? 'block' : 'none';
        counterEl.textContent = (activeIndex + 1) + ' / ' + images.length;

        zoom = 1;
        applyZoom();
    }

    function applyZoom() {
        imgEl.classList.toggle('zoomed', zoom > 1);
        imgEl.style.transform = 'scale(' + zoom + ')';
        imgEl.style.cursor = zoom > MIN_ZOOM ? 'zoom-out' : 'zoom-in';
        zoomLevelEl.textContent = Math.round(zoom * 100) + '%';
    }

    function open(list, startIndex) {
        build();
        images = Array.isArray(list) ? list : [list];
        activeIndex = startIndex || 0;
        overlay.style.display = 'flex';
        document.body.style.overflow = 'hidden';
        render();
    }

    function close() {
        if (!overlay) return;
        overlay.style.display = 'none';
        document.body.style.overflow = '';
    }

    function next() {
        if (images.length) {
            activeIndex = (activeIndex + 1) % images.length;
            render();
        }
    }

    function prev() {
        if (images.length) {
            activeIndex =
                (activeIndex - 1 + images.length) % images.length;
            render();
        }
    }

    function zoomIn() {
        zoom = Math.min(MAX_ZOOM, zoom + ZOOM_STEP);
        applyZoom();
    }

    function zoomOut() {
        zoom = Math.max(MIN_ZOOM, zoom - ZOOM_STEP);
        applyZoom();
    }

    return {
        open: open,
        close: close
    };
})();
