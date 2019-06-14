(function (producto) {
    producto.success = successReload;
    producto.pages = 1;
    producto.rowSize = 25;

    init();

    return producto;

    function successReload(option) {
        //console.log('successreload');
        //alert(option);
        cibertec.closeModal(option);
    }

    function init() {
        $.get('producto/Count/' + producto.rowSize,
            function (data) {
                producto.pages = data;
                $('.pagination').bootpag({
                    total: producto.pages,
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
                    getproductos(num);
                });
                getproductos(1);
            });
    }

    function getproductos(num) {
        var url = '/producto/List/' + num + '/' + producto.rowSize;
        $.get(url, function (data) {
            $('.content').html(data);
        });
    }

})(window.producto = window.producto || {});    