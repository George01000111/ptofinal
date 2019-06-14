var miModulo = {
    miPropiedad: "valor0",
    miConfiguracion: {
        usaEspanol: true,
        usaMascara:false
    },
    miMetodo1: function () {
        console.log("miMetodo1");
    },
    miMetodo2: function () {
        console.log("La mascara esta " + (this.miConfiguracion.usaMascara) ? 'habilitada' : 'deshabilitada');
    },
    miMetodo3: function (configuracion) {
        if (typeof configuracion == 'object') {
            this.miConfiguracion = configuracion;
            console.log(this.miConfiguracion.usaEspanol);
        }
    }
};

console.log(miModulo.miPropiedad);
miModulo.miMetodo1();