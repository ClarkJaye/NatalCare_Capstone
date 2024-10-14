self.addEventListener('install', (event) => {
    event.waitUntil(
        caches.open('natalcare-app-cache').then((cache) => {
            return cache.addAll([
                '/',
                '/css/styles.css',
                '/js/site.js',
                '/img/icon.jpg',
                '/img/logo-icon.png'
            ]);
        })
    );
});

self.addEventListener('fetch', (event) => {
    event.respondWith(
        caches.match(event.request).then((response) => {
            return response || fetch(event.request);
        })
    );
});
