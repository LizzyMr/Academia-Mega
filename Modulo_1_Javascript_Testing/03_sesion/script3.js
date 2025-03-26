//Anotaciones de la sesión 3:

/*
//Funcion declarativa
function saludar(nombre){
    console.log(`Hola, ${nombre}`);
}
saludar("Lizeth");


//Funcion anonima
let saludar1 = function(nombre){
    console.log(`Hola, ${nombre}`);
}
saludar1("Lizeth");


let saludar2 = (nombre)=>console.log(`Hola, ${nombre}`)
saludar2("Lizeth")

//Sumar:
function sumar(a, b){
    return a + b;
}
console.log(sumar(5000, 453));

//Restar:
const restar = function(a, b){
    return a - b;
}
console.log(restar(10,4))

//Multiplicar:
const multiplicar = (a, b)=>a *b;
console.log(multiplicar(4, 2))

const sumar = (a, b)=>{
    let resultado = a + b;
    return resultado;
}
console.log(sumar(3,7))


let mensajeGlobal = "Hola desde fuera";

function ejemploScope(){
    let mensajeLocal = "Hola desde dentro";
    console.log(mensajeGlobal);
    console.log(mensajeLocal);
}

ejemploScope();
console.log(mensajeGlobal);
console.log(mensajeLocal);


// Closures

function contador(){
    let cuenta = 0;
    return function (){
        cuenta ++;
        return cuenta;
    };
}

const incrementar = contador();

console.log(incrementar());
console.log(incrementar());
console.log(incrementar());
console.log(incrementar());
console.log(incrementar());
console.log(incrementar());
*/

//Ejercicio 3: Crear una funcion que devuelva otra funcion que multiplica por un numero especifico
function multiplicador(factor){
    return function(numero){
        return numero * factor;
    }
}
const duplicar = multiplicador(2);
const triplicar = multiplicador(3);
const cuatriplicar = multiplicador(4);

console.log(duplicar(5));
console.log(triplicar(5));
console.log(cuatriplicar(5));
