var igv = 18;
var igv2 = "18";

console.log(igv);
console.log(igv2);
console.log(igv == igv2);
console.log(igv === igv2);

var dias = ["Lunes", "Martes", "Miercoles", "Jueves", "Viernes"];
console.log(dias[1]);//martes
console.log(dias[5]);//error

var verdad = true;
console.log(verdad);

var fecha = new Date();
var fecha2 = new Date('8/29/2019');
console.log(fecha);
console.log(fecha2);

//! = negacion
var visible = true;
var cantidad = 0;//false
var cantidad2 = 3;//>0 true
var mensaje = "";//false
var mensaje2 = "ejemplo";//true
console.log(!visible);
console.log(!cantidad);
console.log(!cantidad2);
console.log(!mensaje);
console.log(!mensaje2);


//if
var edad = 10;
if (edad < 12) {
    console.log("eres pequeño");
} else if (edad < 19) {
    console.log("eres adolescente");
} else if (edad < 35) {
    console.log("aun eres joven");
} else {
    console.log("a cuidarse");
}
//switch
var diaDeSemana = 3;
switch (diaDeSemana) {
    case 1:
        console.log("Lunes");
        break;
    default:
        console.log("NO ES Lunes");
}
//for
for (var i = 0; i < 5; i++) {
    console.log(i);
}
//while
var count = 0;
while (count < 5) {
    console.log(count);
    count++;// count = count +1;
}
//do while
count = 0;
do {
    console.log(count);
    count++;// count = count +1;
} while (count < 5);
//for each for in
for (i in dias) {
    console.log(dias[i]);
}

//Objetos
var miAuto = new Object();
miAuto.marca = "Toyota";
miAuto.modelo = "Yaris";
miAuto["fabricacion"] = 2011;

console.log(miAuto.marca);
console.log(miAuto["modelo"]);
console.log(miAuto.fabricacion);

var miHonda = { color: "rojo", ruedas: 4, motor: { cilindros: 4, tamanio: 2 } };

var miObjeto = new Object();
miObjeto.miMetodo = function () {
    console.log("Hola miMetodo");
};
miObjeto.miMetodo();

var miObjeto2 = {
    miMetodo2: function (parametro) {
        console.log("Hola miMetodo2: " + parametro);
    }
};
miObjeto2.miMetodo2("miparam");
//eliminar propiedad de miAuto
delete miAuto.marca;
console.log(miAuto.marca);//undefined
console.log("marca" in miAuto);//false