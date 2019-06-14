(function (iniciarsesion) {
    iniciarsesion.success = successReload;
    iniciarsesion.pages = 1;
    iniciarsesion.rowSize = 25;

    init();

    return iniciarsesion;

    function successReload(option) {
        //console.log('successreload');
        //alert(option);
        cibertec.closeModal(option);
    }

    function init() {
        $.get('iniciarsesion/Count/' + iniciarsesion.rowSize,
            function (data) {
                iniciarsesion.pages = data;
                $('.pagination').bootpag({
                    total: iniciarsesion.pages,
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
                    getiniciarsesions(num);
                });
                getiniciarsesions(1);
            });
    }

    function getiniciarsesions(num) {
        var url = '/iniciarsesion/List/' + num + '/' + iniciarsesion.rowSize;
        $.get(url, function (data) {
            $('.content').html(data);
        });
    }

})(window.iniciarsesion = window.iniciarsesion || {});    