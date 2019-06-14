(function (usuario) {
    usuario.success = successReload;
    usuario.pages = 1;
    usuario.rowSize = 25;

    init();

    return usuario;

    function successReload(option) {
        //console.log('successreload');
        //alert(option);
        cibertec.closeModal(option);
    }

    function init() {
        $.get('usuario/Count/' + usuario.rowSize,
            function (data) {
                usuario.pages = data;
                $('.pagination').bootpag({
                    total: usuario.pages,
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
                    getusuarios(num);
                    });
                getusuarios(1);
            });
    }

    function getusuarios(num) {
        var url = '/usuario/List/' + num + '/' + usuario.rowSize;
        $.get(url, function (data) {
            $('.content').html(data);
        });
    }

})(window.usuario = window.usuario || {});    