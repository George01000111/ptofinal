(function (cibertec) {
    cibertec.Index = {
        currentYear: function () {
            var hoy = new Date();
            return hoy.getFullYear();
        }
    };
    document.getElementById("date").innerHTML =
        cibertec.Index.currentYear();
})(window.cibertec = window.cibertec || {});