var miModulo = (function () {
    var privada = 3;
    var metodoPrivado = function () {
        return 'Prueba metodo privado';
    };
    return {
        publica: 4,
        metodoPublico: function () {
            return ' Seguido por metodo publico ';
        },
        metodoPublico2: metodoPrivado,
        obtenerdata: function () {
            return metodoPrivado() + this.metodoPublico() + privada;
        }
    }
})();
console.log(miModulo.privada);//no es accesible UNDEFINED
//console.log(miModulo.metodoPrivado());//ERROR
console.log(miModulo.obtenerdata());
console.log(miModulo.metodoPublico2());
