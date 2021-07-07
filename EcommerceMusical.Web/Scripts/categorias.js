const $menuFiltrar = document.querySelector('.filtros-mobile')
const $btnFiltroOpen = document.querySelector('.btn-filtrar-mobile-open')
const $btnFiltroClose = document.querySelector('.btn-filtrar-mobile-close')

$btnFiltroOpen.addEventListener('click', function () {
    $menuFiltrar.classList.add('filtrar_open');
    $btnFiltroOpen.classList.add('btn-display-none');
});

$btnFiltroClose.addEventListener('click', function () {
    $menuFiltrar.classList.remove('filtrar_open');
    $btnFiltroOpen.classList.remove('btn-display-none');
});