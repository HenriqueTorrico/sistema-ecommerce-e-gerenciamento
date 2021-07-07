const $menu = document.querySelector('.menu')
const $btnMenuOpen = document.querySelector('.btnMenu_open')
const $btnMenuClose = document.querySelector('.btnMenu_close')

$btnMenuOpen.addEventListener('click', function () {
    $menu.classList.add('menu_open');
})

$btnMenuClose.addEventListener('click', function () {
    $menu.classList.remove('menu_open');
})

window.addEventListener("scroll", function () {
    var header1 = document.querySelector(".header-1");
    header1.classList.toggle("sticky", window.scrollY > 300);
    var menuDesktop = document.querySelector(".menu-desktop");
    menuDesktop.classList.toggle("teste", window.scrollY > 300);
})

window.addEventListener("scroll", function () {
    var header1 = document.querySelector(".menu-mobile .header");
    header1.classList.toggle("sticky", window.scrollY > 60);
})