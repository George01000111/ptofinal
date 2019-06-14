(function (productospedidos) {
    productospedidos.success = successReload;
    productospedidos.pages = 1;
    productospedidos.rowSize = 25;

    init();

    return productospedidos;

    function successReload(option) {
        //console.log('successreload');
        //alert(option);
        cibertec.closeModal(option);
    }

    function init() {
        $.get('productospedidos/Count/' + productospedidos.rowSize,
            function (data) {
                productospedidos.pages = data;
                $('.pagination').bootpag({
                    total: productospedidos.pages,
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
                    getproductospedidoss(num);
                });
                getproductospedidoss(1);
            });
    }

    function getproductospedidoss(num) {
        var url = '/productospedidos/Orden/' + num + '/' + productospedidos.rowSize;
        $.get(url, function (data) {
            $('.content').html(data);
        });
    }

})(window.productospedidos = window.productospedidos || {});    