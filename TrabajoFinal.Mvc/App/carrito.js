(function (carrito) {
    carrito.success = successReload;
    carrito.pages = 1;
    carrito.rowSize = 25;

    init();

    return carrito;

    function successReload(option) {
        //console.log('successreload');
        //alert(option);
        cibertec.closeModal(option);
    }

    function init() {
        $.get('carrito/Count/' + carrito.rowSize,
            function (data) {
                carrito.pages = data;
                $('.pagination').bootpag({
                    total: carrito.pages,
                    page: 1,
                    maxVisible: 5,
                    leaps: true,
                    firstLastUse: true,
                    first: '←',
                    last: '→',
                    wrapClass: 'pagination',
                    activeClass: 'active',
                    disabledClass: 'disabled',
                    nextClass: 'next',
                    prevClass: 'prev',
                    lastClass: 'last',
                    firstClass: 'first'
                }).on('page', function (event, num) {
                    getcarritos(num);
                });
                getcarritos(1);
            });
    }

    function getcarritos(num) {
        var url = '/carrito/List/' + num + '/' + carrito.rowSize;
        $.get(url, function (data) {
            $('.content').html(data);
        });
    }

})(window.carrito = window.carrito || {});    