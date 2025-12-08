// Toggle sidebar on mobile
document.querySelector('.admin-menu-toggle')?.addEventListener('click', () => {
    document.querySelector('.admin-sidebar').classList.toggle('active');
});

// Close sidebar when clicking outside on mobile
document.addEventListener('click', (e) => {
    const sidebar = document.querySelector('.admin-sidebar');
    const toggle = document.querySelector('.admin-menu-toggle');
    if (window.innerWidth <= 992 && !sidebar.contains(e.target) && !toggle.contains(e.target)) {
        sidebar.classList.remove('active');
    }
});